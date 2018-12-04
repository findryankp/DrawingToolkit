using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiagramToolkit.Shapes;

namespace DiagramToolkit.Tools
{
    public class LineTool : ToolStripButton, ITool
    {
        private ICanvas varCanvas;
        private Line varLine;

        public Cursor Cursor
        {
            get
            {
                return Cursors.Cross;
            }
        }

        public ICanvas TargetCanvas
        {
            get
            {
                return this.varCanvas;
            }

            set
            {
                this.varCanvas = value;
            }
        }

        public LineTool()
        {
            this.Name = "Line tool";
            this.ToolTipText = "Line tool";
            Debug.WriteLine(this.Name + " is initialized.");
            Init();
        }

        private void Init()
        {
            this.Image = IconSet.pixel;
            this.CheckOnClick = true;
        }

        public void ToolHotKeysDown(object sender, Keys e)
        {

        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {

        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {

        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            varLine = new Line(new System.Drawing.Point(e.X, e.Y));
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {

        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            varLine.Endpoint = new System.Drawing.Point(e.X, e.Y);
            varCanvas.AddDrawingObject(varLine);
        }
    }
}
