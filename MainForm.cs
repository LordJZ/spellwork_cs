using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SpellWork
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();

            listview_SearchResults.ClearItems();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string spellNameOrId = tb_SpellName.Text;

            if (spellNameOrId == "")
                return;

            listview_SearchResults.ClearItems();

            spellNameOrId = spellNameOrId.ToLower();

            uint parsedId = 0;
            try
            {
                parsedId = UInt32.Parse(spellNameOrId);

                if (parsedId > 0)
                {
                    SpellEntry spell = DBC.Spell.LookupEntry<SpellEntry>(parsedId);
                    if (spell.Id == parsedId)
                        listview_SearchResults.AddSpellItem(spell);
                }
                return;
            }
            catch(Exception)
            {
            }

            var query = from entry in DBC.Spell
                        where entry.Value.getName().ToLower() == spellNameOrId
                        select entry.Value;

            /*Dictionary<uint, SpellEntry>.KeyCollection keys = DBC.Spell.Keys;
            uint added = 0;
            for (int i = 0; i < keys.Count; ++i)
            {
                if (added >= 500)
                    break;

                uint spellId = keys.ElementAt<uint>(i);

                SpellEntry spell = DBC.Spell.LookupEntry<SpellEntry>(spellId);

                if(spell.getName().ToLower() == spellNameOrId)
                {
                    listview_SearchResults.AddSpellItem(spell);
                    ++added;
                }
            }*/
            uint added = 0;
            foreach(var spell in query)
            {
                if (added >= 500)
                    break;

                listview_SearchResults.AddSpellItem(spell);
                ++added;
            }
        }
    }
}
