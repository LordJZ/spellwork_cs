using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace SpellWork
{
    public static class ProcInfo
    {
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
                familyTree.Nodes.Add(node);
            }

            foreach (var elem in spells)
            {
                var spell = elem.Spell.Value;
                bool IsSkill = elem.SkillId != 0;
                string name = IsSkill
                ? String.Format("+({0}) {1} ({2}) (Sk{3}) ({4})", spell.ID, spell.SpellName, spell.Rank, elem.SkillId, spell.School)
                : String.Format("-({0}) {1} ({2}) ({3})", spell.ID, spell.SpellName, spell.Rank, spell.School);

                int i = 0;
                foreach (TreeNode node in familyTree.Nodes)
                {
                    uint mask_1 = 0, mask_2 = 0, mask_3 = 0;

                    if (i < 32)
                        mask_1 = 1U << i;
                    else if (i < 64)
                        mask_2 = 1U << (i - 32);
                    else
                        mask_3 = 1U << (i - 64);

                    if ((spell.SpellFamilyFlags1 & mask_1) != 0 ||
                        (spell.SpellFamilyFlags2 & mask_1) != 0 ||
                        (spell.SpellFamilyFlags3 & mask_3) != 0)
                    {
                        TreeNode child = new TreeNode();
                        child = node.Nodes.Add(name);
                        child.Name = spell.ID.ToString();
                        child.ForeColor = IsSkill ? Color.Blue : Color.Red;
                    }
                    i++;
                }
            }
        }

        public static void SetProcData()
        {
        }
    }
}
