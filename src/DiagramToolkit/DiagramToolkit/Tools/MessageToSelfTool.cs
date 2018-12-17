using DiagramToolkit.Shapes;
using System;
using System.Windows.Forms;
using DiagramToolkit.Sequences;

namespace DiagramToolkit.Tools
{
    public class MessageToSelfTool : ToolStripButton, ITool
    {
        private MessageToSelf messageToSelf;
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

        public MessageToSelfTool()
        {
            this.Name = "MessageToSelf tool";
            this.ToolTipText = "MessageToSelf tool";
            this.Image = IconSet.messageTo_self;
            this.CheckOnClick = true;
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                messageToSelf = new MessageToSelf();
                messageToSelf.Value = "Text";
                messageToSelf.X = e.X;
                messageToSelf.Y = e.Y;

                DrawingObject obj = canvas.SelectObjectAt(e.X, e.Y);

                messageToSelf = new MessageToSelf(new System.Drawing.Point(e.X, e.Y));
                messageToSelf.Endpoint = new System.Drawing.Point(e.X, e.Y);

                if (obj == null)
                {
                    canvas.AddDrawingObject(messageToSelf);
                }
                else
                {
                    bool allowed = obj.Add(messageToSelf);

                    if (!allowed)
                    {
                        canvas.AddDrawingObject(messageToSelf);
                    }
                }
            }
        }
        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.messageToSelf != null)
                {
                    messageToSelf.Endpoint = new System.Drawing.Point(e.X, e.Y);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.messageToSelf != null)
                {
                    messageToSelf.Endpoint = new System.Drawing.Point(e.X, e.Y);
                    messageToSelf.Select();
                }
            }
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
