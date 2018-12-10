using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DiagramToolkit.Shapes
{
    public class Actor : DrawingObject
    {
        private const double EPSILON = 3.0;

        public Point Startpoint { get; set; }
        public Point Endpoint { get; set; }

        private Pen pen;

        public Actor()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
        }

        public Actor(Point startpoint) :
            this()
        {
            this.Startpoint = startpoint;
        }

        public Actor(Point startpoint, Point endpoint) :
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
                //this.Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
                drawSecondLine();
                drawLifeLine();
            }
        }

        public override void RenderOnEditingView()
        {
            pen.Color = Color.Blue;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;

            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                //this.Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
                drawSecondLine();
                drawLifeLine();
            }
        }

        public override void RenderOnPreview()
        {
            pen.Color = Color.Red;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;

            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                //this.Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
                drawSecondLine();
                drawLifeLine();
            }
        }

        public override bool Intersect(int xTest, int yTest)
        {
            x1 = Startpoint.X;
            y1 = Startpoint.Y;
            x2 = Endpoint.X;
            y2 = Endpoint.Y;

            if ((xTest >= (x1-10) && xTest <= (x1+10)) && (yTest >= y1 && yTest <= (y2 +10)))
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

        public void drawSecondLine()
        {
            x1 = Startpoint.X;
            y1 = Startpoint.Y;
            x2 = Endpoint.X;
            y2 = Endpoint.Y;

            //garis pusat
            Point sTest = new Point(x1, y1);
            Point eTest = new Point(x1, y2);
            this.Graphics.DrawLine(pen, sTest, eTest);

            //kaki kiri
            sTest = new Point(x1, y2);
            eTest = new Point(x1 - 10, y2 + 10);
            this.Graphics.DrawLine(pen, sTest, eTest);

            //kaki kanan
            sTest = new Point(x1, y2);
            eTest = new Point(x1 + 10, y2 + 10);
            this.Graphics.DrawLine(pen, sTest, eTest);

            //tangan kiri
            sTest = new Point(x1, y1);
            eTest = new Point(x1 - 10, y1);
            this.Graphics.DrawLine(pen, sTest, eTest);

            //tangan kanan
            sTest = new Point(x1, y1);
            eTest = new Point(x1 + 10, y1);
            this.Graphics.DrawLine(pen, sTest, eTest);

            //leher
            sTest = new Point(x1, y1);
            eTest = new Point(x1, y1 - 5);
            this.Graphics.DrawLine(pen, sTest, eTest);

            //kepala
            this.Graphics.DrawEllipse(pen, x1 - 10, y1 - 25, 20, 20);
        }

        public void drawLifeLine()
        {
            pen.Color = Color.Black;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;

            x1 = Startpoint.X;
            y1 = Startpoint.Y;
            x2 = Endpoint.X;
            y2 = Endpoint.Y;

            Point sTest = new Point(x1, y2 + 10);
            Point eTest = new Point(x1, 500);
            this.Graphics.DrawLine(pen, sTest, eTest);
        }

        public override bool Add(DrawingObject obj)
        {
            throw new NotImplementedException();
        }

        public override bool Remove(DrawingObject obj)
        {
            throw new NotImplementedException();
        }
    }
}