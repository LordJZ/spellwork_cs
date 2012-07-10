using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpellWork
{
    public class ProcInfo
    {
        public static SpellEntry SpellProc { get; set; }
        public static bool Update = true;

        public ProcInfo(TreeView familyTree, SpellFamilyNames spellfamily)
        {
            familyTree.Nodes.Clear();

            var spells = from Spell in DBC.Spell.Records
                         where Spell.SpellFamilyName == (uint)spellfamily
                         join sk in DBC.SkillLineAbility.Records on Spell.ID equals sk.SpellId into temp1
                         from Skill in temp1.DefaultIfEmpty()
                         join skl in DBC.SkillLine.Records on Skill.SkillId equals skl.ID into temp2
                         from SkillLine in temp2.DefaultIfEmpty()
                         select new
                         {
                             Spell,
                             Skill.SkillId,
                             SkillLine
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
                SpellEntry spell = elem.Spell;
                bool IsSkill     = elem.SkillId != 0;

                StringBuilder name    = new StringBuilder();
                StringBuilder toolTip = new StringBuilder();

                name.AppendFormat("{0} - {1} ", spell.ID, spell.SpellNameRank);
                
                toolTip.AppendFormatLine("Spell Name: {0}",  spell.SpellNameRank);
                toolTip.AppendFormatLine("Description: {0}", spell.Description);
                toolTip.AppendFormatLine("ToolTip: {0}",     spell.ToolTip);

                if (IsSkill)
                {
                    name.AppendFormat("(Skill: ({0}) {1}) ", elem.SkillId, elem.SkillLine.Name);

                    toolTip.AppendLine();
                    toolTip.AppendFormatLine("Skill Name: {0}", elem.SkillLine.Name);
                    toolTip.AppendFormatLine("Description: {0}", elem.SkillLine.Description);
                }

                name.AppendFormat("({0})", spell.School.ToString().NormaliseString("MASK_"));
                
                foreach (TreeNode node in familyTree.Nodes)
                {
                    uint[] mask = new uint[3];

                    if (node.Index < 32)
                        mask[0] = 1U << node.Index;
                    else if (node.Index < 64)
                        mask[1] = 1U << (node.Index - 32);
                    else
                        mask[2] = 1U << (node.Index - 64);

                    if ((spell.SpellFamilyFlags.ContainsElement(mask)))
                    {
                        TreeNode child  = new TreeNode();
                        child           = node.Nodes.Add(name.ToString());
                        child.Name      = spell.ID.ToString();
                        child.ImageKey  = IsSkill ? "plus.ico" : "munus.ico";
                        child.ForeColor = IsSkill ? Color.Blue : Color.Red;
                        child.ToolTipText = toolTip.ToString();
                    }
                }
            }
        }
    }
}
