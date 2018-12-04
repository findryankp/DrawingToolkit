using System.Windows.Forms;
using DiagramToolkit;
using DiagramToolkit.Shapes;

namespace DiagramToolkit.Tools
{
    public class CircleTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Circle circle;

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

        public CircleTool()
        {
            this.Name = "Circle Tool";
            this.ToolTipText = "Circle Tool";
            this.Image = IconSet.diagonal_line;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.circle = new Circle(e.X, e.Y);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int width = e.X - this.circle.cirX;
                int height = e.Y - this.circle.cirY;

                if (width > 0 && height > 0)
                {
                    this.circle.cirWidth = width;
                    this.circle.cirHeight = height;
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                canvas.AddDrawingObject(this.circle);
            }
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        public void ToolHotKeysDown(object sender, Keys e)
        {
            throw new System.NotImplementedException();
        }
    }
}
