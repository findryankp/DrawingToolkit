using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DiagramToolkit.Shapes
{
    public class ObjectMessage : DrawingObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private Pen pen;

        public int xTest;
        public int yTest;
        public int wTest;
        public int hTest;

        public ObjectMessage()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
        }

        public ObjectMessage(int x, int y) : this()
        {
            this.X = x;
            this.Y = y;
        }

        public ObjectMessage(int x, int y, int width, int height) : this(x, y)
        {
            this.Width = width;
            this.Height = height;
        }

        public override void RenderOnPreview()
        {
            this.pen = new Pen(Color.Red);
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawRectangle(pen, X, Y, Width, 1);
                drawBox();
            }
        }

        public override void RenderOnEditingView()
        {
            this.pen = new Pen(Color.Blue);
            pen.Width = 1.5f;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawRectangle(pen, X, Y, Width, 1);
                drawBox();
            }
        }

        public override void RenderOnStaticView()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawRectangle(pen, X, Y, Width, 1);
                drawBox();
            }
        }

        public override bool Intersect(int xTest, int yTest)
        {
            if ((xTest >= X && xTest <= X + Width) && (yTest >= Y && yTest <= Y + Height))
            {
                Debug.WriteLine("Object " + ID + " is selected.");
                return true;
            }
            return false;
        }

        public override void Translate(int x, int y, int xAmount, int yAmount)
        {
            this.X += xAmount;
            this.Y += yAmount;
        }

        public Point Startpoint;
        public Point Endpoint;

        public void drawBox()
        {
            this.pen = new Pen(Color.Red);
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;
            xTest = Width + X;
            this.Graphics.DrawRectangle(pen, xTest, Y, 10, 30);
        }
    }
}