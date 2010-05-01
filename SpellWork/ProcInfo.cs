using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace SpellWork
{
    public static class ProcInfo
    {
        public static SpellEntry SpellProc { get; set; }

        public static void BuildFamilyTree(TreeView familyTree, SpellFamilyNames spellfamily)
        {
            familyTree.Nodes.Clear();

            var spells = from Spell in DBC.Spell
                         where Spell.Value.SpellFamilyName == (uint)spellfamily
                         join sk in DBC.SkillLineAbility on Spell.Key equals sk.Value.SpellId into temp
                         from Skill in temp.DefaultIfEmpty()
                         select new
                         {
                             Spell,
                             Skill.Value.SkillId
                         };

            for (int i = 0; i < 96; i++)
            {
                uint mask_0 = 0, mask_1 = 0, mask_2 = 0;

                if (i < 32)
                    mask_0 = 1U << i;
                else if (i < 64)
                    mask_1 = 1U << (i - 32);
                else
                    mask_2 = 1U << (i - 64);

                TreeNode node = new TreeNode();
                node.Text = String.Format("0x{0:X8} {1:X8} {2:X8}", mask_2, mask_1, mask_0);
                node.ImageKey = "family.ico";
                familyTree.Nodes.Add(node);
            }

            foreach (var elem in spells)
            {
                var spell = elem.Spell.Value;
                bool IsSkill = elem.SkillId != 0;
                string name = IsSkill
                ? String.Format("+{0} - {1} (Skill {2}) ({3})", spell.ID, spell.SpellNameRank, elem.SkillId, spell.School.ToString().NormaliseString("MASK_"))
                : String.Format("-{0} - {1} ({2})", spell.ID, spell.SpellNameRank, spell.School.ToString().NormaliseString("MASK_"));

                foreach (TreeNode node in familyTree.Nodes)
                {
                    uint mask_0 = 0, mask_1 = 0, mask_2 = 0;

                    if (node.Index < 32)
                        mask_0 = 1U << node.Index;
                    else if (node.Index < 64)
                        mask_1 = 1U << (node.Index - 32);
                    else
                        mask_2 = 1U << (node.Index - 64);

                    if ((spell.SpellFamilyFlags1 & mask_0) != 0 ||
                        (spell.SpellFamilyFlags2 & mask_1) != 0 ||
                        (spell.SpellFamilyFlags3 & mask_2) != 0)
                    {
                        TreeNode child = new TreeNode();
                        child = node.Nodes.Add(name);
                        child.Name = spell.ID.ToString();
                        child.ImageKey = IsSkill ? "plus.ico" : "munus.ico";
                        child.ForeColor = IsSkill ? Color.Blue : Color.Red;
                    }
                }
            }
        }

        public static void SetProcData()
        {
        }
    }
}
