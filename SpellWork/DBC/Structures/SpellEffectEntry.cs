using System;
using System.Linq;
using DBFilesClient.NET;

namespace SpellWork.DBC.Structures
{
    public sealed class SpellEffectEntry
    {
        public uint Id;
        public uint Type;
        public float ValueMultiplier;
        public uint ApplyAuraName;
        public uint Amplitude;
        public int BasePoints;
        public float BonusMultiplier;
        public float DamageMultiplier;
        public uint ChainTarget;
        public int DieSides;
        public uint ItemType;
        public uint Mechanic;
        public int MiscValue;
        public int MiscValueB;
        public float PointsPerComboPoint;
        public uint RadiusIndex;
        public uint RadiusMaxIndex;
        public float RealPointsPerLevel;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 3)]
        public uint[] SpellClassMask;
        public uint TriggerSpell;
        public uint ImplicitTargetA;
        public uint ImplicitTargetB;
        public uint SpellId;
        public uint Index;
        public uint Unk0;

        public string MaxRadius
        {
            get
            {
                if (RadiusMaxIndex == 0 || !DBC.SpellRadius.ContainsKey(RadiusMaxIndex))
                    return String.Empty;

                return String.Format("Max Radius (Id {0}) {1:F}", RadiusMaxIndex, DBC.SpellRadius[RadiusMaxIndex].Radius);
            }
        }

        public string Radius
        {
            get
            {
                if (RadiusIndex == 0 || !DBC.SpellRadius.ContainsKey(RadiusIndex))
                    return String.Empty;

                return String.Format("Radius (Id {0}) {1:F}", RadiusIndex, DBC.SpellRadius[RadiusIndex].Radius);
            }
        }
    }
}
