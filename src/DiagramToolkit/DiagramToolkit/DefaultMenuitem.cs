using System.Windows.Forms;

namespace DiagramToolkit
{
    class DefaultMenuitem : ToolStripMenuItem, IMenuItem
    {
        public DefaultMenuitem()
        {
            this.Name = "exampleToolStripMenuItem";
            this.Size = new System.Drawing.Size(37, 20);
        }

        public DefaultMenuitem(string text) : base()
        {
            this.Text = text;
        }

        public void AddMenuItem(IMenuItem menuItem)
        {
            this.DropDownItems.Add((ToolStripMenuItem)menuItem);
        }
    }
}
