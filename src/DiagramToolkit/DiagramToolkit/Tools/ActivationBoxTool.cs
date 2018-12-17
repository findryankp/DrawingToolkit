using DiagramToolkit.Shapes;
using System;
using System.Windows.Forms;
using DiagramToolkit.Sequences;

namespace DiagramToolkit.Tools
{
    public class ActivationBoxTool : ToolStripButton, ITool
    {
        private ActivationBox activationBox;
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

        public ActivationBoxTool()
        {
            this.Name = "ActivationBox tool";
            this.ToolTipText = "ActivationBox tool";
            this.Image = IconSet.activation_box;
            this.CheckOnClick = true;
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                activationBox = new ActivationBox();
                activationBox.Value = "Text";
                activationBox.X = e.X;
                activationBox.Y = e.Y;

                DrawingObject obj = canvas.SelectObjectAt(e.X, e.Y);

                if (obj == null)
                {
                    canvas.AddDrawingObject(activationBox);
                }
                else
                {
                    bool allowed = obj.Add(activationBox);

                    if (!allowed)
                    {
                        canvas.AddDrawingObject(activationBox);
                    }
                }
            }
        }
        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.activationBox != null)
                {
                    int width = e.X - this.activationBox.X;
                    int height = e.Y - this.activationBox.Y;

                    if (width > 0 && height > 0)
                    {
                        this.activationBox.Width = width;
                        this.activationBox.Height = height;
                    }
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {

        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {

        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {

        }

        public void ToolHotKeysDown(object sender, Keys e)
        {

        }
    }
}
