using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace SpellWork
{
    public class ProcInfo
    {
        public static SpellEntry SpellProc { get; set; }
        public static bool Update = true;

        public ProcInfo(TreeView familyTree, SpellFamilyNames spellfamily)
        {
            familyTree.Nodes.Clear();

            var spells = from Spell in DBC.Spell
                         where Spell.Value.SpellFamilyName == (uint)spellfamily
                         join sk in DBC.SkillLineAbility on Spell.Key equals sk.Value.SpellId into temp1
                         from Skill in temp1.DefaultIfEmpty()
                         join skl in DBC.SkillLine on Skill.Value.SkillId equals skl.Key into temp2
                         from SkillLine in temp2.DefaultIfEmpty()
                         select new
                         {
                             Spell,
                             Skill.Value.SkillId,
                             SkillLine.Value
                         };

            for (int i = 0; i < 96; i++)
            {
                uint[] mask = new uint[3];

                if (i < 32)
                    mask[0] = 1U << i;
                else if (i < 64)
                    mask[1] = 1U << (i - 32);
                else
                    mask[2] = 1U << (i - 64);

                TreeNode node   = new TreeNode();
                node.Text       = String.Format("0x{0:X8} {1:X8} {2:X8}", mask[2], mask[1], mask[0]);
                node.ImageKey   = "family.ico";
                familyTree.Nodes.Add(node);
            }

            foreach (var elem in spells)
            {
                SpellEntry spell = elem.Spell.Value;
                bool IsSkill     = elem.SkillId != 0;
                string name      = IsSkill
                ? String.Format("{0} - {1} (Skill {2}) ({3})", spell.ID, spell.SpellNameRank, elem.SkillId, spell.School.ToString().NormaliseString("MASK_"))
                : String.Format("{0} - {1} ({2})", spell.ID, spell.SpellNameRank, spell.School.ToString().NormaliseString("MASK_"));

                string toolTip = IsSkill
                ? String.Format("Spell Name: {0}\r\nDescription: {1}\r\nToolTip: {2}\r\nSkill Name: {3}\r\nDescription: {4}",
                                spell.SpellNameRank, spell.Description, spell.ToolTip, elem.Value.Name, elem.Value.Description)
                : String.Format("Spell Name: {0}\r\nDescription: {1}\r\nToolTip: {2}", spell.SpellNameRank, spell.Description, spell.ToolTip);

                foreach (TreeNode node in familyTree.Nodes)
                {
                    uint[] mask = new uint[3];

                    if (node.Index < 32)
                        mask[0] = 1U << node.Index;
                    else if (node.Index < 64)
                        mask[1] = 1U << (node.Index - 32);
                    else
                        mask[2] = 1U << (node.Index - 64);

                    if ((spell.SpellFamilyFlags.Contain(mask)))
                    {
                        TreeNode child  = new TreeNode();
                        child           = node.Nodes.Add(name);
                        child.Name      = spell.ID.ToString();
                        child.ImageKey  = IsSkill ? "plus.ico" : "munus.ico";
                        child.ForeColor = IsSkill ? Color.Blue : Color.Red;
                        child.ToolTipText = toolTip;
                    }
                }
            }
        }
    }
}
