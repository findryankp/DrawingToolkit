using DiagramToolkit.Shapes;
using System;
using System.Windows.Forms;
using DiagramToolkit.Sequences;

namespace DiagramToolkit.Tools
{
    public class ObjectMessageTool : ToolStripButton, ITool
    {
        private ObjectMessage objectMessage;
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

        public ObjectMessageTool()
        {
            this.Name = "Object Message tool";
            this.ToolTipText = "Object Message tool";
            this.Image = IconSet.objectbox_;
            this.CheckOnClick = true;
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                objectMessage = new ObjectMessage();
                objectMessage.Value = "Text";
                objectMessage.X = e.X;
                objectMessage.Y = e.Y;

                DrawingObject obj = canvas.SelectObjectAt(e.X, e.Y);

                if (obj == null)
                {
                    canvas.AddDrawingObject(objectMessage);
                }
                else
                {
                    bool allowed = obj.Add(objectMessage);

                    if (!allowed)
                    {
                        canvas.AddDrawingObject(objectMessage);
                    }
                }
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
