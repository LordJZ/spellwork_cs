using System.Windows.Forms;
using System.Drawing;

namespace SpellWork
{
    /// <summary>
    /// Compares two spells
    /// </summary>
    class SpellCompare
    {
        /// <summary>
        /// Compares two spells
        /// </summary>
        /// <param name="rtb1">RichTextBox 1 in left</param>
        /// <param name="rtb2">RichTextBox 2 in right</param>
        /// <param name="spell1">Compare Spell 1</param>
        /// <param name="spell2">Compare Spell 2</param>
        public SpellCompare(RichTextBox rtb1, RichTextBox rtb2, SpellEntry spell1, SpellEntry spell2)
        {
            new SpellInfo(rtb1, spell1);
            new SpellInfo(rtb2, spell2);

            if (rtb1.Text == rtb2.Text)
            {
                MessageBox.Show(string.Format("Spells {0} and {1} - identical!", spell1.ID, spell2.ID), 
                    "Spell Compare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // left textbox
                string[] strsl = rtb1.Text.Split('\n');
                int posl = 0;
                float clp1 = 0.0f;
                float clp2 = 0.0f;

                foreach (string str in strsl)
                {
                    int index = rtb2.Find(str);

                    posl += str.Length + 1;
                    rtb1.Select(posl - str.Length - 1, posl - 1);
                    if (index != -1)
                    { 
                        clp1++;
                        rtb1.SelectionBackColor = Color.Cyan;
                    }
                    else
                    { 
                        clp2++;
                        rtb1.SelectionBackColor = Color.Salmon;
                    }
                }

                // right textbox
                string[] strsr = rtb2.Text.Split('\n');
                int posr = 0;
                float crp1 = 0.0f;
                float crp2 = 0.0f;

                foreach (string str in strsr)
                {
                    int index = rtb1.Find(str);

                    posr += str.Length + 1;
                    rtb2.Select(posr - str.Length - 1, posr - 1);
                    if (index != -1)
                    { 
                        crp1++;
                        rtb2.SelectionBackColor = Color.Cyan;
                    }
                    else
                    { 
                        crp2++;
                        rtb2.SelectionBackColor = Color.Salmon;
                    }
                }

                //rtb1.SelectionBackColor = rtb2.SelectionBackColor = rtb1.ForeColor;

                //rtb1.SetStyle(FontStyle.Bold, Color.Red);
                //rtb1.AppendFormatLine("\tSpell compare in {0:F2}%", (clp2 / clp1) * 100);

                //rtb2.SetStyle(FontStyle.Bold, Color.Red);
                //rtb2.AppendFormatLine("\tSpell compare in {0:F2}%", (crp2 / crp1) * 100);
            }
        }
    }
}
