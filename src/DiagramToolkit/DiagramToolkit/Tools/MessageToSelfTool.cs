using DiagramToolkit.Shapes;
using DiagramToolkit.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiagramToolkit.Sequences;
using System.Windows.Forms;

namespace DiagramToolkit.Tools
{
    public class MessageToSelfTool : ToolStripButton, ITool
    {
        private ICanvas varCanvas;
        private MessageToSelf messageToSelf;
        private Text text;

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

        public MessageToSelfTool()
        {
            this.Name = "Message To Self tool";
            this.ToolTipText = "Message To Self tool";
            this.Image = IconSet.messageTo_self;
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
                messageToSelf = new MessageToSelf(new System.Drawing.Point(e.X, e.Y));
                messageToSelf.Endpoint = new System.Drawing.Point(e.X, e.Y);
                varCanvas.AddDrawingObject(messageToSelf);
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

                    text = new Text();
                    text.Value = "TextAAAAAAAAAAAAA";
                    int newX = (int)MessageToSelf.xText;
                    int newY = (int)MessageToSelf.yText;
                    text.X = newX;
                    text.Y = newY;
                    varCanvas.AddDrawingObject(text);
                }
            }
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}

