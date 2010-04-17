using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SpellWork
{
    static class DBCReader
    {
        public static void Run()
        {
            // First we load DBC files
            string path = @"./dbc/";

            Dictionary<uint, string> nullStringDict = null;

            DBC.Spell            = DBCReader.ReadDBC<SpellEntry>(path + "Spell.dbc", ref DBC._SpellStrings);
            DBC.SpellRadius      = DBCReader.ReadDBC<SpellRadiusEntry>(path + "SpellRadius.dbc", ref nullStringDict);
            DBC.SpellRange       = DBCReader.ReadDBC<SpellRangeEntry>(path + "SpellRange.dbc", ref DBC._SpellRangeStrings);
            DBC.SpellDuration    = DBCReader.ReadDBC<SpellDurationEntry>(path + "SpellDuration.dbc", ref nullStringDict);
            DBC.SkillLineAbility = DBCReader.ReadDBC<SkillLineAbilityEntry>(path + "SkillLineAbility.dbc", ref nullStringDict);
            DBC.SkillLine        = DBCReader.ReadDBC<SkillLineEntry>(path + "SkillLine.dbc", ref DBC._SkillLineStrings);
            DBC.SpellCastTimes   = DBCReader.ReadDBC<SpellCastTimesEntry>(path + "SpellCastTimes.dbc", ref nullStringDict);

            // Currently we use entry 1 from Spell.dbc to detect DBC locale
            byte DetectedLocale = 0;
            while (DBC.Spell.LookupEntry<SpellEntry>(1).GetName(DetectedLocale) == null)
                ++DetectedLocale;
            if (DetectedLocale > 16)
                throw new Exception("Detected uncnown locale index " + DetectedLocale);
        }

        public static unsafe Dictionary<uint,T> ReadDBC<T>(string fileName, ref Dictionary<uint, string> strDict) where T : struct
        {

            Dictionary<uint, T> dict = new Dictionary<uint, T>();

            if (!File.Exists(fileName))
                throw new Exception("File " + fileName + " not found");

            BinaryReader reader = new BinaryReader(new FileStream(fileName, FileMode.Open, FileAccess.Read), Encoding.UTF8);

            // Sanity check
            if (reader.BaseStream.Length < 20 || reader.ReadUInt32() != 0x43424457)
                throw new Exception(String.Format("Bad DBC file {0}", fileName));

            int recordsCount    = reader.ReadInt32();
            int fieldsCount     = reader.ReadInt32();
            int recordSize      = reader.ReadInt32();
            int stringTableSize = reader.ReadInt32();

            int size = Marshal.SizeOf(typeof(T));

            if (recordSize != size)
                throw new Exception(String.Format("\n\nSize of row in DBC file ({0}) != size of DBC struct ({1})\nDBC: {2}\n\n", recordSize, size, fileName));

            BinaryReader dataReader    = new BinaryReader(new MemoryStream(reader.ReadBytes(recordsCount * recordSize)), Encoding.UTF8);
            BinaryReader stringsReader = new BinaryReader(new MemoryStream(reader.ReadBytes(stringTableSize)), Encoding.UTF8);

            reader.Close();

            for (int r = 0; r < recordsCount; ++r)
            {
                uint key = dataReader.ReadUInt32();
                dataReader.BaseStream.Position -= 4;

                byte[] rawData = dataReader.ReadBytes(size);

                GCHandle handle = GCHandle.Alloc(rawData, GCHandleType.Pinned);
                T T_entry = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
                handle.Free();

                dict.Add(key, T_entry);
            }

            dataReader.Close();

            // Now we read strings
            if (strDict != null)
            {
                byte[] data = stringsReader.ReadBytes((int)stringsReader.BaseStream.Length);
                List<byte> str = new List<byte>();
                for (uint i = 1; i < data.Length; i++)
                {
                    if (data[i] == char.MinValue && i > 0)
                    {
                        strDict.Add(i-(uint)str.Count, Encoding.UTF8.GetString(str.ToArray()));
                        str.Clear();
                    }
                    else
                    {
                        str.Add(data[i]);
                    }
                }
            }

            stringsReader.Close();

            return dict;
        }
    }
}
