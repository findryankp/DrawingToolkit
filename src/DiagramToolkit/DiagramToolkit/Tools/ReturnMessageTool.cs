using DiagramToolkit.Shapes;
using DiagramToolkit.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiagramToolkit.Sequences;

namespace DiagramToolkit.Tools
{
    public class ReturnMessageTool : ToolStripButton, ITool
    {
        private ICanvas varCanvas;
        private ReturnMessage returnMessage;
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

        public ReturnMessageTool()
        {
            this.Name = "Return Message tool";
            this.ToolTipText = "Return Message tool";
            this.Image = IconSet.line_dot;
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
                returnMessage = new ReturnMessage(new System.Drawing.Point(e.X, e.Y));
                returnMessage.Endpoint = new System.Drawing.Point(e.X, e.Y);
                varCanvas.AddDrawingObject(returnMessage);                
            }
        }

        public void drawText()
        {

        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.returnMessage != null)
                {
                    returnMessage.Endpoint = new System.Drawing.Point(e.X, e.Y);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.returnMessage != null)
                {
                    returnMessage.Endpoint = new System.Drawing.Point(e.X, e.Y);
                    returnMessage.Select();
                }
            }
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
