using DiagramToolkit.Shapes;
using System;
using System.Windows.Forms;
using DiagramToolkit.Sequences;

namespace DiagramToolkit.Tools
{
    class ActivationBoxTool : ToolStripButton, ITool
    {
        private ICanvas varCanvas;
        private ActivationBox activationBox;

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

        public ActivationBoxTool()
        {
            this.Name = "Activation Box tool";
            this.ToolTipText = "Activation Box tool";
            this.Image = IconSet.activation_box;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                activationBox = new ActivationBox(e.X, e.Y);
                this.varCanvas.AddDrawingObject(this.activationBox);
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (activationBox != null)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        this.activationBox.Select();
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        varCanvas.RemoveDrawingObject(this.activationBox);
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
    }
}
