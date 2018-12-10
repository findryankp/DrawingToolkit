using System.Drawing;
using System.Diagnostics;

namespace DiagramToolkit.Shapes
{
    public class Text : DrawingObject
    {
        public string Value { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        private Brush brush;
        private Font font;
        private SizeF textSize;

        public Text()
        {
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
            this.Graphics.DrawString(Value, font, brush, new PointF(X, Y));
            textSize = this.Graphics.MeasureString(Value, font);

        }

        public override void RenderOnPreview()
        {
            this.Graphics.DrawString(Value, font, brush, new PointF(X, Y));
            textSize = this.Graphics.MeasureString(Value, font);
        }

        public override void RenderOnStaticView()
        {
            this.Graphics.DrawString(Value, font, brush, new PointF(X, Y));
            textSize = this.Graphics.MeasureString(Value, font);
        }

        public override void Translate(int x, int y, int xAmount, int yAmount)
        {
            X += xAmount;
            Y += yAmount;
        }
    }
}
