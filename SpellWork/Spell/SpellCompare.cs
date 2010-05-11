using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpellWork
{
    class SpellCompare
    {
        public static void Compare(RichTextBox rtb1, RichTextBox rtb2, SpellEntry spell1, SpellEntry spell2)
        {
            new SpellInfo(rtb1, spell1);
            new SpellInfo(rtb2, spell2);
        }
    }
}
