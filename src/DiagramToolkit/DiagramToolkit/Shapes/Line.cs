using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace DiagramToolkit.Shapes
{
    public class Line : DrawingObject
    {
        public Point Startpoint { get; set; }
        public Point Endpoint { get; set; }

        private Pen pen;

        public Line()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
        }

        public Line(Point startpoint) :
            this()
        {
            this.Startpoint = startpoint;
        }

        public Line(Point startpoint, Point endpoint) :
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
