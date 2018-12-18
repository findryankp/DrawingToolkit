using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DiagramToolkit.Shapes
{
    public class StateLine : DrawingObject
    {
        private const double EPSILON = 3.0;

        public Point Startpoint { get; set; }
        public Point Endpoint { get; set; }

        private Pen pen;

        public StateLine()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
        }

        public StateLine(Point startpoint) :
            this()
        {
            this.Startpoint = startpoint;
        }

        public StateLine(Point startpoint, Point endpoint) :
            this(startpoint)
        {
            this.Endpoint = endpoint;
        }

        public override void RenderOnStaticView()
        {
            pen.Color = Color.Black;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;

            if (GetGraphics() != null)
            {
                GetGraphics().SmoothingMode = SmoothingMode.AntiAlias;
                GetGraphics().DrawLine(pen, this.Startpoint, this.Endpoint);
            }
        }

        public override void RenderOnEditingView()
        {
            pen.Color = Color.Blue;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;

            if (GetGraphics() != null)
            {
                GetGraphics().SmoothingMode = SmoothingMode.AntiAlias;
                GetGraphics().DrawLine(pen, this.Startpoint, this.Endpoint);
            }
        }

        public override void RenderOnPreview()
        {
            pen.Color = Color.Red;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;

            if (GetGraphics() != null)
            {
                GetGraphics().SmoothingMode = SmoothingMode.AntiAlias;
                GetGraphics().DrawLine(pen, this.Startpoint, this.Endpoint);
            }
        }

        public override bool Intersect(int xTest, int yTest)
        {
            double m = GetSlope();
            double b = Endpoint.Y - m * Endpoint.X;
            double y_point = m * xTest + b;

            if (Math.Abs(yTest - y_point) < EPSILON)
            {
                Debug.WriteLine("Object " + ID + " is selected.");
                return true;
            }
            return false;
        }

        public double GetSlope()
        {
            double m = (double)(Endpoint.Y - Startpoint.Y) / (double)(Endpoint.X - Startpoint.X);
            return m;
        }

        public override void Translate(MouseEventArgs e, int xAmount, int yAmount)
        {
            Point point = e.Location;
            this.Startpoint = new Point(this.Startpoint.X + xAmount, this.Startpoint.Y + yAmount);
            this.Endpoint = new Point(this.Endpoint.X + xAmount, this.Endpoint.Y + yAmount);
        }

        public override bool Add(DrawingObject obj)
        {
            throw new NotImplementedException();
        }

        public override bool Remove(DrawingObject obj)
        {
            throw new NotImplementedException();
        }

        public override string GetText()
        {
            throw new NotImplementedException();
        }

        public override void SetText(string s)
        {
            throw new NotImplementedException();
        }

        public override Point GetCenterPoint()
        {
            Point point = new Point();
            point.X = (Startpoint.X + Endpoint.X) / 2;
            point.Y = (Startpoint.Y + Endpoint.Y) / 2;
            return point;
        }

        public override void Rezise(MouseEventArgs e, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
