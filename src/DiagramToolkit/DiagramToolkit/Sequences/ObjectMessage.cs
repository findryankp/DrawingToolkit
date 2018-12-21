using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System;
using System.Drawing.Drawing2D;

namespace DiagramToolkit.Sequences
{
    public class ObjectMessage : DrawingObject
    {
        public string text;
        public string Value { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private Brush brush;
        private Font font;
        private SizeF textSize;

        public static float Textlenght;

        public ObjectMessage()
        {
            this.text = "ObjectMessage";

            FontFamily fontFamily = new FontFamily("Arial");
            font = new Font(
               fontFamily,
               16,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
        }

        public override bool Add(DrawingObject obj)
        {
            return false;
        }

        public override bool Remove(DrawingObject obj)
        {
            return false;
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

        public float pos1;
        public float pos2;

        public override void RenderOnEditingView()
        {
            this.pen = new Pen(Color.Blue);
            this.brush = new SolidBrush(Color.Blue);
            pos1 = ((Width - textSize.Width) / 2) + this.X;
            pos2 = Y - 20;
            PointF aaa = new PointF(pos1, pos2);
            GetGraphics().DrawString(this.text, font, brush, aaa);

            textSize = GetGraphics().MeasureString(this.text, font);
            Textlenght = textSize.Width;
            drawRectangle();
        }

        public override void RenderOnPreview()
        {
            this.pen = new Pen(Color.Red);
            this.brush = new SolidBrush(Color.Red);
            pos1 = ((Width - textSize.Width) / 2) + this.X;
            pos2 = Y - 20;
            PointF aaa = new PointF(pos1, pos2);
            GetGraphics().DrawString(this.text, font, brush, aaa);

            textSize = GetGraphics().MeasureString(this.text, font);
            Textlenght = textSize.Width;
            drawRectangle();
        }

        public override void RenderOnStaticView()
        {
            this.pen = new Pen(Color.Black);
            this.brush = new SolidBrush(Color.Black);
            pos1 = ((Width - textSize.Width) / 2) + this.X;
            pos2 = Y - 20;
            PointF aaa = new PointF(pos1, pos2);
            GetGraphics().DrawString(this.text, font, brush, aaa);

            textSize = GetGraphics().MeasureString(this.text, font);
            Textlenght = textSize.Width;
            drawRectangle();
        }

        public override string GetText()
        {
            return this.text;
        }

        public override void SetText(string s)
        {
            this.text = s;
        }

        public override void Translate(MouseEventArgs e, int xAmount, int yAmount)
        {
            this.X += xAmount;
            this.Y += yAmount;
        }

        public override Point GetCenterPoint()
        {
            throw new System.NotImplementedException();
        }

        private Pen pen;
        public int x1;
        public int y1;
        public int x2;
        public int y2;

        public void drawRectangle()
        {
            pen.Width = 1.0f;
            this.pen.DashStyle = DashStyle.Solid;
            GetGraphics().DrawRectangle(this.pen, X, Y, Width, 1);

            x1 = Width + X;

            if (Height <= 30)
            {
                Height = 30;
            }
            GetGraphics().FillRectangle(this.brush, x1, Y, 10, Height);

            x1 = X + Width;
            y1 = Y;
            Point sTest = new Point(x1, y1);
            Point eTest = new Point(x1 - 10, y1 - 10);
            GetGraphics().DrawLine(pen, sTest, eTest);

            eTest = new Point(x1 - 10, y1 + 10);
            GetGraphics().DrawLine(pen, sTest, eTest);
        }

        public override void Rezise(MouseEventArgs e, int x, int y)
        {
            Point point = e.Location;
            Width = (e.X - X) * 2 / 2;
            Height = (e.Y - Y) * 2 / 2;
        }
    }
}
