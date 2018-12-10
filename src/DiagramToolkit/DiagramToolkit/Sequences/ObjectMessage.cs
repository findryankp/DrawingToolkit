using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DiagramToolkit.Sequences
{
    public class ObjectMessage : DrawingObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private Pen pen;

        private SizeF textSize;

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
                drawArrow();
                DrawText();
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
                drawArrow();
                DrawText();
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
                drawArrow();
                DrawText();
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

        public void drawBox()
        {
            xTest = Width + X;
            this.Graphics.DrawRectangle(pen, xTest, Y, 10, 30);
        }

        public int x1;
        public int y1;
        public int x2;
        public int y2;

        public void drawArrow()
        {
            x1 = X + Width;
            y1 = Y;
            Point sTest = new Point(x1, y1);
            Point eTest = new Point(x1 - 10, y1 - 10);
            this.Graphics.DrawLine(pen, sTest, eTest);

            eTest = new Point(x1 - 10, y1 + 10);
            this.Graphics.DrawLine(pen, sTest, eTest); 
        }

        private Brush brush;
        private Font font;

        public void DrawText()
        {
            this.brush = new SolidBrush(Color.Black);

            FontFamily fontFamily = new FontFamily("Arial");
            font = new Font(
               fontFamily,
               12,
               FontStyle.Regular,
               GraphicsUnit.Pixel);

            string text = "Value";
            textSize = this.Graphics.MeasureString(text, font);

            float pos1 = ((Width - textSize.Width) / 2) + X;
            float pos2 = Y - 20;
            PointF aaa = new PointF(pos1, pos2);

            this.Graphics.DrawString(text, font, brush, aaa);
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