using System.Windows.Forms;

namespace SpellWork
{
    public static class TreeViewExtensions
    {
        public static uint[] GetMask(this TreeView tv)
        {
            uint[] val = new uint[3];
            foreach (TreeNode node in tv.Nodes)
            {
                if (node.Checked)
                {
                    if(node.Index < 32)
                        val[0] += 1U << node.Index;
                    else if(node.Index < 64)
                        val[1] += 1U << (node.Index - 32);
                    else
                        val[2] += 1U << (node.Index - 64);
                }
            }
            return val;
        }

        public static void SetMask(this TreeView tv, uint[] mask)
        {
            ProcInfo.Update = false;
            
            for (int i = 0; i < tv.Nodes.Count; ++i)
            {
                if (i < 32)
                    tv.Nodes[i].Checked = ((mask[0] / (1 << i)) % 2) != 0;
                else if (i < 64)
                    tv.Nodes[i].Checked = ((mask[1] / (1 << (i - 32))) % 2) != 0;
                else
                    tv.Nodes[i].Checked = ((mask[2] / (1 << (i - 64))) % 2) != 0;
            }

            ProcInfo.Update = true;
        }
    }
}
