using System;
using System.Windows.Forms;
using DiagramToolkit.Sequences;

namespace DiagramToolkit.Tools
{
    class ObjectMessageTool : ToolStripButton, ITool
    {
        private ICanvas varCanvas;
        private ObjectMessage objectMessage;

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

        public ObjectMessageTool()
        {
            this.Name = "Object Message tool";
            this.ToolTipText = "Object Message tool";
            this.Image = IconSet.objectbox_;
            this.CheckOnClick = true;
        }

        public void ToolHotKeysDown(object sender, Keys e)
        {
            throw new NotImplementedException();
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                objectMessage = new ObjectMessage(e.X, e.Y);
                this.varCanvas.AddDrawingObject(this.objectMessage);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.objectMessage != null)
                {
                    int width = e.X - this.objectMessage.X;
                    int height = e.Y - this.objectMessage.Y;

                    if (width > 0 && height > 0)
                    {
                        this.objectMessage.Width = width;
                        this.objectMessage.Height = height;
                    }
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (objectMessage != null)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        this.objectMessage.Select();
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        varCanvas.RemoveDrawingObject(this.objectMessage);
                    }
                }
            }
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
