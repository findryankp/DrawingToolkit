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
    public class ActorTool : ToolStripButton, ITool
    {
        private ICanvas varCanvas;
        private Actor actor;

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

        public ActorTool()
        {
            this.Name = "Actor tool";
            this.ToolTipText = "Actor tool";
            this.Image = IconSet.aktor;
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
                actor = new Actor(new System.Drawing.Point(e.X, e.Y));
                actor.Endpoint = new System.Drawing.Point(e.X, e.Y);
                varCanvas.AddDrawingObject(actor);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.actor != null)
                {
                    actor.Endpoint = new System.Drawing.Point(e.X, e.Y);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.actor != null)
                {
                    actor.Endpoint = new System.Drawing.Point(e.X, e.Y);
                    actor.Select();
                }
            }
        }
    }
}
