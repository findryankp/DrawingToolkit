using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagramToolkit
{
    public class DefaultToolbar : ToolStrip, IToolbar
    {
        public DefaultToolbar()
        {
            Init();
        }

        private void Init()
        {
            this.Dock = DockStyle.Top;
        }

        public void AddToolbarItem(IToolbarItem item)
        {
            this.Items.Add((ToolStripItem)item);
        }

        public void AddSeparator()
        {
            this.Items.Add(new ToolStripSeparator());
        }
    }
}
