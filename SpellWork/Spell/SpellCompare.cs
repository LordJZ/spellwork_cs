using System.Windows.Forms;
using System.Drawing;

namespace SpellWork
{
    /// <summary>
    /// Compares two spells, highlighted similarities and razbezhnosti
    /// </summary>
    class SpellCompare
    {
        /// <summary>
        /// Compares two spells, highlighted similarities and razbezhnosti
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

                foreach (string str in strsl)
                {
                    int index = rtb2.Find(str);

                    posl += str.Length + 1;
                    rtb1.Select(posl - str.Length - 1, posl - 1);

                    rtb1.SelectionBackColor = index != -1 ? Color.Cyan : Color.Salmon;
                }
                // right textbox
                string[] strsr = rtb2.Text.Split('\n');
                int posr = 0;

                foreach (string str in strsr)
                {
                    int index = rtb1.Find(str);

                    posr += str.Length + 1;
                    rtb2.Select(posr - str.Length - 1, posr - 1);

                    rtb2.SelectionBackColor = index != -1 ? Color.Cyan : Color.Salmon;
                }
            }
        }
    }
}
