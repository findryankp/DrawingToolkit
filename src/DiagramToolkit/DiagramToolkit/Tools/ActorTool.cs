using DiagramToolkit.Shapes;
using System;
using System.Windows.Forms;
using DiagramToolkit.Sequences;

namespace DiagramToolkit.Tools
{
    public class ActorTool : ToolStripButton, ITool
    {
        private Actor actor;
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

        public ActorTool()
        {
            this.Name = "Actor tool";
            this.ToolTipText = "Actor tool";
            this.Image = IconSet.aktor;
            this.CheckOnClick = true;
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                actor = new Actor();
                actor.Value = "Text";
                actor.X = e.X;
                actor.Y = e.Y;

                DrawingObject obj = canvas.SelectObjectAt(e.X, e.Y);

                actor = new Actor(new System.Drawing.Point(e.X, e.Y));
                actor.Endpoint = new System.Drawing.Point(e.X, e.Y);

                if (obj == null)
                {
                    canvas.AddDrawingObject(actor);
                }
                else
                {
                    bool allowed = obj.Add(actor);

                    if (!allowed)
                    {
                        canvas.AddDrawingObject(actor);
                    }
                }
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
