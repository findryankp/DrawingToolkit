using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DiagramToolkit.Sequences
{
    public class MessageToSelf : DrawingObject
    {
        private const double EPSILON = 3.0;

        public Point Startpoint { get; set; }
        public Point Endpoint { get; set; }

        private Pen pen;

        public MessageToSelf()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
        }

        public MessageToSelf(Point startpoint) :
            this()
        {
            this.Startpoint = startpoint;
        }

        public MessageToSelf(Point startpoint, Point endpoint) :
            this(startpoint)
        {
            this.Endpoint = endpoint;
        }

        public override void RenderOnStaticView()
        {
            pen.Color = Color.Black;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;

            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
            }
            drawFirstLine();
            drawSecondLine();
            drawthirdLine();
            arrow1();
            arrow2();
        }

        public override void RenderOnEditingView()
        {
            pen.Color = Color.Blue;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;

            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
            }
            drawFirstLine();
            drawSecondLine();
            drawthirdLine();
            arrow1();
            arrow2();
        }

        public override void RenderOnPreview()
        {
            pen.Color = Color.Red;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;

            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
            }
            drawFirstLine();
            drawSecondLine();
            drawthirdLine();
            arrow1();
            arrow2();
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

        public override void Translate(int x, int y, int xAmount, int yAmount)
        {
            this.Startpoint = new Point(this.Startpoint.X + xAmount, this.Startpoint.Y + yAmount);
            this.Endpoint = new Point(this.Endpoint.X + xAmount, this.Endpoint.Y + yAmount);
        }

        public int x1;
        public int y1;
        public int x2;
        public int y2;

        public void drawFirstLine()
        {
            pen.Color = Color.Red;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;
            x1 = Startpoint.X;
            y1 = Startpoint.Y;
            x2 = Endpoint.X;
            y2 = Endpoint.Y;
            Point sTest = new Point(x1, y1);
            Point eTest = new Point(x2, y1);
            this.Graphics.DrawLine(pen, sTest, eTest);
        }

        public void drawSecondLine()
        {
            pen.Color = Color.Red;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;
            x1 = Startpoint.X;
            y1 = Startpoint.Y;
            x2 = Endpoint.X;
            y2 = Endpoint.Y;
            Point sTest = new Point(x2, y1);
            Point eTest = new Point(x2, y2);
            this.Graphics.DrawLine(pen, sTest, eTest);
        }

        public void drawthirdLine()
        {
            pen.Color = Color.Red;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;
            x1 = Startpoint.X;
            y1 = Startpoint.Y;
            x2 = Endpoint.X;
            y2 = Endpoint.Y;
            Point sTest = new Point(x2, y2);
            Point eTest = new Point(x1, y2);
            this.Graphics.DrawLine(pen, sTest, eTest);
        }

        public void arrow1()
        {
            pen.Color = Color.Red;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;
            x1 = Startpoint.X;
            y1 = Startpoint.Y;
            x2 = Endpoint.X;
            y2 = Endpoint.Y;
            Point sTest = new Point(x1, y2);
            Point eTest = new Point(x1 + 10, y2 - 10);
            this.Graphics.DrawLine(pen, sTest, eTest);
        }

        public void arrow2()
        {
            pen.Color = Color.Red;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;
            x1 = Startpoint.X;
            y1 = Startpoint.Y;
            x2 = Endpoint.X;
            y2 = Endpoint.Y;
            Point sTest = new Point(x1, y2);
            Point eTest = new Point(x1 + 10, y2 + 10);
            this.Graphics.DrawLine(pen, sTest, eTest);
        }

    }
}
