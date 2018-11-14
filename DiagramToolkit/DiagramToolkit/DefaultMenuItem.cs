using System;
using System.Windows.Forms;

namespace DiagramToolkit.MenuItems
{
    public class DefaultMenuItem : ToolStripMenuItem, IMenuItem
    {
        private ICommand command;

        public DefaultMenuItem()
        {
            this.Name = "exampleToolStripMenuItem";
            this.Size = new System.Drawing.Size(37, 20);

            this.Click += DefaultMenuItem_Click;
        }

        private void DefaultMenuItem_Click(object sender, EventArgs e)
        {
            if (command != null)
            {
                this.command.Execute();
            }
        }

        public DefaultMenuItem(string text) : this()
        {
            this.Text = text;
        }

        public void AddMenuItem(IMenuItem menuItem)
        {
            this.DropDownItems.Add((ToolStripMenuItem)menuItem);
        }

        public void AddSeparator()
        {
            this.DropDownItems.Add(new ToolStripSeparator());
        }

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }
    }
}
