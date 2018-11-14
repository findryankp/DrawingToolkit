using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagramToolkit.Tools
{
    public class SelectionTool : ToolStripButton, ITool
    {
        private ICanvas canvas;

        public Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public ICanvas TargetCanvas
        {
            get
            {
                return this.canvas;
            }

            set
            {
                this.canvas = value;
            }
        }

        public SelectionTool()
        {
            this.Name = "Selection tool";
            this.ToolTipText = "Selection tool";
            this.Image = IconSet.cursor;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
