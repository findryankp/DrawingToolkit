using System.Windows.Forms;

namespace DiagramToolkit
{
    public class ExampleToolbarItem : ToolStripButton, IToolbarItem
    {
        public ExampleToolbarItem()
        {
            this.Name = "Example";
            this.ToolTipText = "Example toolbaritem";
            this.Image = IconSet.folder;
            this.DisplayStyle = ToolStripItemDisplayStyle.Image;
        }
    }
}
