using System.Drawing;
using System.Drawing.Drawing2D;

namespace DiagramToolkit.States
{
    public class StateLineSegment : StateDrawingObject
    {
        public Point Startpoint { get; set; }
        public Point Endpoint { get; set; }

        private Pen pen;

        public StateLineSegment()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
        }

        public StateLineSegment(Point startpoint) :
            this()
        {
            this.Startpoint = startpoint;
        }

        public StateLineSegment(Point startpoint, Point endpoint) :
            this(startpoint)
        {
            this.Endpoint = endpoint;
        }

        public override void RenderOnEditingView()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;

            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
            }
        }

        public override void RenderOnPreview()
        {
            RenderOnStaticView();
        }

        public override void RenderOnStaticView()
        {
            this.pen = new Pen(Color.Red);
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;

            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
            }
        }
    }
}
