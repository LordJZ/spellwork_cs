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
        /// Search terms
        /// </summary>
        string[] words = new[] { "=====" };// todo: more wodrs

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

            string[] strsl = rtb1.Text.Split('\n');
            string[] strsr = rtb2.Text.Split('\n');
            
            int pos = 0;
            foreach (string str in strsl)
            {
                pos += str.Length + 1;
                rtb1.Select(pos - str.Length - 1, pos - 1);

                if (rtb2.Find(str, RichTextBoxFinds.WholeWord) != -1)
                {
                    if (str.ContainsText(words))
                    {
                        rtb1.SelectionBackColor = rtb1.BackColor;
                    }
                    else
                    {
                        rtb1.SelectionBackColor = Color.Cyan;
                    }
                }
                else
                {
                    rtb1.SelectionBackColor = Color.Salmon;
                }
            }

            pos = 0;
            foreach (string str in strsr)
            {
                pos += str.Length + 1;
                rtb2.Select(pos - str.Length - 1, pos - 1);

                if (rtb1.Find(str, RichTextBoxFinds.WholeWord) != -1)
                {
                    if (str.ContainsText(words))
                    {
                        rtb2.SelectionBackColor = rtb2.BackColor;
                    }
                    else
                    {
                        rtb2.SelectionBackColor = Color.Cyan;
                    }
                }
                else
                {
                    rtb2.SelectionBackColor = Color.Salmon;
                }
            }
        }
    }
}
