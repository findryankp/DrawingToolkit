using System.Drawing;

namespace DiagramToolkit.Shapes
{
    public class LineSegment : DrawingObject
    {
        public Point Startpoint { get; set; }
        public Point Endpoint { get; set; }

        private Pen pen;

        public LineSegment()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
        }

        public LineSegment(Point startpoint) :
            this()
        {
            this.Startpoint = startpoint;
        }

        public LineSegment(Point startpoint, Point endpoint) :
            this(startpoint)
        {
            this.Endpoint = endpoint;
        }

        public override void Draw()
        {
            this.Graphics.DrawLine(this.pen, Startpoint, Endpoint);
        }
    }
}
