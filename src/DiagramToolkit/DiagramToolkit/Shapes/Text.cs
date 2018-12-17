using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System;
using System.Drawing.Drawing2D;

namespace DiagramToolkit.Shapes
{
    public class Text : DrawingObject
    {
        public string text;
        public string Value { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        private Brush brush;
        private Font font;
        private SizeF textSize;

        public static float Textlenght;

        private const double EPSILON = 3.0;
        private Pen pen;

        public Text()
        {
            this.text = "Edit";
            this.brush = new SolidBrush(Color.Black);

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
            if ((xTest >= X && xTest <= X + textSize.Width) && (yTest >= Y && yTest <= Y + textSize.Height))
            {
                Debug.WriteLine("Object " + ID + " is selected.");
                return true;
            }
            return false;
        }

        public override void RenderOnEditingView()
        {
            GetGraphics().DrawString(this.text, font, brush, new PointF(X, Y));
            textSize = GetGraphics().MeasureString(this.text, font);
            Textlenght = textSize.Width;
        }

        public override void RenderOnPreview()
        {
            GetGraphics().DrawString(this.text, font, brush, new PointF(X, Y));
            textSize = GetGraphics().MeasureString(this.text, font);
            Textlenght = textSize.Width;
        }

        public override void RenderOnStaticView()
        {
            GetGraphics().DrawString(this.text, font, brush, new PointF(X, Y));
            textSize = GetGraphics().MeasureString(this.text, font);
            Textlenght = textSize.Width;
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
    }
}
