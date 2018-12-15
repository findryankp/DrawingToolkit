using DiagramToolkit.Shapes;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

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
                Point eTest = new Point(Endpoint.X, Startpoint.Y);
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.Startpoint, eTest);
                drawSecondLine();
                arrow();
                getTextPosition();
            }
        }

        public override void RenderOnEditingView()
        {
            pen.Color = Color.Blue;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;

            if (this.Graphics != null)
            {
                Point eTest = new Point(Endpoint.X, Startpoint.Y);
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.Startpoint, eTest);
                drawSecondLine();
                arrow();
                getTextPosition();
            }
        }

        public override void RenderOnPreview()
        {
            pen.Color = Color.Red;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;

            if (this.Graphics != null)
            {
                Point eTest = new Point(Endpoint.X, Startpoint.Y);
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.Startpoint, eTest);
                drawSecondLine();
                arrow();
                getTextPosition();
            }
        }

        public override bool Intersect(int xTest, int yTest)
        {
            if ((xTest >= Startpoint.X && xTest <= (Endpoint.X)) && (yTest >= Startpoint.Y && yTest <= (Endpoint.Y)))
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
            Point sTest = new Point(x2, y1);
            Point eTest = new Point(x2, y2);
            this.Graphics.DrawLine(pen, sTest, eTest);

            sTest = new Point(x2, y2);
            eTest = new Point(x1, y2);
            this.Graphics.DrawLine(pen, sTest, eTest);
        }

        public void arrow()
        {
            x1 = Startpoint.X;
            y1 = Startpoint.Y;
            x2 = Endpoint.X;
            y2 = Endpoint.Y;
            Point sTest = new Point(x1, y2);
            Point eTest = new Point(x1 + 10, y2 - 10);
            this.Graphics.DrawLine(pen, sTest, eTest);

            eTest = new Point(x1 + 10, y2 + 10);
            this.Graphics.DrawLine(pen, sTest, eTest);
        }

        public static float xText;
        public static float yText;

        public void getTextPosition()
        {
            xText = Endpoint.X;
            yText = ((Startpoint.Y- Endpoint.Y)*2 / 4)+ Endpoint.Y;
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
            throw new NotImplementedException();
        }
    }
}
