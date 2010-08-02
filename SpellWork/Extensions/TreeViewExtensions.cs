using System.Windows.Forms;

namespace SpellWork
{
    public static class TreeViewExtensions
    {
        /// <summary>
        /// Returns the value of the collection of selected items
        /// </summary>
        /// <param name="tv"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Check items of the collection...
        /// </summary>
        /// <param name="tv"></param>
        /// <param name="mask"></param>
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

        /// <summary>
        /// Check items of the collection...
        /// </summary>
        /// <param name="tv"></param>
        /// <param name="mask"></param>
        public static void SetMask(this TreeView tv, uint[,] mask)
        {
            ProcInfo.Update = false;

            for (int i = 0; i < tv.Nodes.Count; ++i)
            {
                if (i < 32)
                    tv.Nodes[i].Checked = ((mask[0, 0] / (1 << i)) % 2) != 0;
                else if (i < 64)
                    tv.Nodes[i].Checked = ((mask[0, 1] / (1 << (i - 32))) % 2) != 0;
                else
                    tv.Nodes[i].Checked = ((mask[0, 2] / (1 << (i - 64))) % 2) != 0;
            }

            ProcInfo.Update = true;
        }
    }
}
