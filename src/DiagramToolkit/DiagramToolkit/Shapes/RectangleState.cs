using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DiagramToolkit.Shapes
{
    public class RectangleState : DrawingObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private Pen pen;

        public RectangleState()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
        }

        public RectangleState(int x, int y) : this()
        {
            this.X = x;
            this.Y = y;
        }

        public RectangleState(int x, int y, int width, int height) : this(x, y)
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
                this.Graphics.DrawRectangle(pen, X, Y, Width, Height);
            }
        }

        public override void RenderOnEditingView()
        {
            this.pen = new Pen(Color.Blue);
            pen.Width = 1.5f;
            if (this.Graphics != null)
            {
                this.Graphics.DrawRectangle(pen, X, Y, Width, Height);
            }
        }

        public override void RenderOnStaticView()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;
            if (this.Graphics != null)
            {
                this.Graphics.DrawRectangle(pen, X, Y, Width, Height);
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
            Point point = e.Location;
            this.X += xAmount;
            this.Y += yAmount;
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
            point.X = X + (Width / 2);
            point.Y = Y + (Height / 2);
            return point;
        }
    }
}
