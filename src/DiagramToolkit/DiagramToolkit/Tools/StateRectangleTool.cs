using DiagramToolkit.Shapes;
using System;
using System.Windows.Forms;

namespace DiagramToolkit.Tools
{
    class StateRectangleTool : ToolStripButton, ITool
    {
        private ICanvas varCanvas;
        private RectangleState varStateRectangle;

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
                return this.varCanvas;
            }

            set
            {
                this.varCanvas = value;
            }
        }

        public StateRectangleTool()
        {
            this.Name = "State Rectangle tool";
            this.ToolTipText = "State Rectangle tool";
            this.Image = IconSet.bounding_box;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                varStateRectangle = new RectangleState(e.X, e.Y);
                this.varCanvas.AddDrawingObject(this.varStateRectangle);
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (varStateRectangle != null)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        this.varStateRectangle.Select();
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        varCanvas.RemoveDrawingObject(this.varStateRectangle);
                    }
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.varStateRectangle != null)
                {
                    int width = e.X - this.varStateRectangle.X;
                    int height = e.Y - this.varStateRectangle.Y;

                    if (width > 0 && height > 0)
                    {
                        this.varStateRectangle.Width = width;
                        this.varStateRectangle.Height = height;
                    }
                }
            }
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolHotKeysDown(object sender, Keys e)
        {
            throw new NotImplementedException();
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
