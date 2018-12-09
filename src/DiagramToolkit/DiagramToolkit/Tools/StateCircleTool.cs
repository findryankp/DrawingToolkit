using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiagramToolkit.Shapes;
using System.Diagnostics;

namespace DiagramToolkit.Tools
{
    public class StateCircleTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private CircleState varCircleState;

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

        public StateCircleTool()
        {
            this.Name = "State Circle Tool";
            this.ToolTipText = "State Circle Tool";
            this.Image = IconSet.circled;
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
                this.varCircleState = new CircleState(e.X, e.Y);
                canvas.AddDrawingObject(this.varCircleState);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int width = e.X - this.varCircleState.cirX;
                int height = e.Y - this.varCircleState.cirY;

                if (width > 0 && height > 0)
                {
                    this.varCircleState.cirWidth = width;
                    this.varCircleState.cirHeight = height;
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                varCircleState.Select();
                //canvas.AddDrawingObject(this.varCircleState);
            }
        }
    }
}
