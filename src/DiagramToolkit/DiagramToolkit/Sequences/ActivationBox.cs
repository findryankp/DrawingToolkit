using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DiagramToolkit.Sequences
{
    public class ActivationBox : DrawingObject
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

        public ActivationBox()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
        }

        public ActivationBox(int x, int y) : this()
        {
            this.X = x;
            this.Y = y;
        }

        public ActivationBox(int x, int y, int width, int height) : this(x, y)
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
                this.Graphics.DrawRectangle(pen, X, Y, Width, Height);
                drawLine();
            }
        }

        public override void RenderOnEditingView()
        {
            this.pen = new Pen(Color.Blue);
            pen.Width = 1.5f;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawRectangle(pen, X, Y, Width, Height);
                drawLine();
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
                this.Graphics.DrawRectangle(pen, X, Y, Width, Height);
                drawLine();
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

        public override void Translate(MouseEventArgs e, int xAmount, int yAmount)
        {
            this.X += xAmount;
            this.Y += yAmount;
        }

        public Point Startpoint;
        public Point Endpoint;

        public void drawLine()
        {
            this.pen = new Pen(Color.Red);
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;
            xTest = (Width / 2) + X;
            yTest = Height + Y;
            hTest = Width + Width;
            this.Graphics.DrawRectangle(pen, xTest, yTest, 1, hTest);
        }

        public override Point GetCenterPoint()
        {
            throw new NotImplementedException();
        }
    }
}
