using DiagramToolkit.Shapes;
using DiagramToolkit.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagramToolkit.Tools
{
    public class StateLineTool : ToolStripButton, ITool
    {
        private ICanvas varCanvas;
        private StateLine varStateLine;

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

        public StateLineTool()
        {
            this.Name = "Stateful Line tool";
            this.ToolTipText = "Stateful Line tool";
            this.Image = IconSet.diagonal_line;
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
                varStateLine = new StateLine(new System.Drawing.Point(e.X, e.Y));
                varStateLine.Endpoint = new System.Drawing.Point(e.X, e.Y);
                varCanvas.AddDrawingObject(varStateLine);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.varStateLine != null)
                {
                    varStateLine.Endpoint = new System.Drawing.Point(e.X, e.Y);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.varStateLine != null)
                {
                    varStateLine.Endpoint = new System.Drawing.Point(e.X, e.Y);
                    varStateLine.Select();
                }
            }
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
