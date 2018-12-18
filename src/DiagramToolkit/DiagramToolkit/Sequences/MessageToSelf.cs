using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System;
using System.Drawing.Drawing2D;

namespace DiagramToolkit.Sequences
{
    public class MessageToSelf : DrawingObject
    {
        public string text;
        public string Value { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Point Startpoint { get; set; }
        public Point Endpoint { get; set; }

        private Brush brush;
        private Font font;
        private SizeF textSize;

        public static float Textlenght;

        public MessageToSelf()
        {
            this.text = "MessageToSelf";

            FontFamily fontFamily = new FontFamily("Arial");
            font = new Font(
               fontFamily,
               16,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
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
            if ((xTest >= Startpoint.X && xTest <= (Endpoint.X)) && (yTest >= Startpoint.Y && yTest <= (Endpoint.Y)))
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
            float pos1 = Endpoint.X + 2;
            float pos2 = Startpoint.Y + ((Endpoint.Y - Startpoint.Y) * 2 / 4)
                - (textSize.Height / 2);
            PointF aaa = new PointF(pos1, pos2);
            GetGraphics().DrawString(this.text, font, brush, aaa);

            textSize = GetGraphics().MeasureString(this.text, font);
            Textlenght = textSize.Width;
            DrawLine();
        }

        public override void RenderOnPreview()
        {
            this.pen = new Pen(Color.Red);
            this.brush = new SolidBrush(Color.Red);
            float pos1 = Endpoint.X + 2;
            float pos2 = Startpoint.Y + ((Endpoint.Y - Startpoint.Y) * 2 / 4)
                - (textSize.Height / 2);
            PointF aaa = new PointF(pos1, pos2);
            GetGraphics().DrawString(this.text, font, brush, aaa);

            textSize = GetGraphics().MeasureString(this.text, font);
            Textlenght = textSize.Width;
            DrawLine();
        }

        public override void RenderOnStaticView()
        {
            this.pen = new Pen(Color.Black);
            this.brush = new SolidBrush(Color.Black);
            float pos1 = Endpoint.X + 2;
            float pos2 = Startpoint.Y + ((Endpoint.Y - Startpoint.Y) * 2 / 4)
                - (textSize.Height / 2);
            PointF aaa = new PointF(pos1, pos2);
            GetGraphics().DrawString(this.text, font, brush, aaa);

            textSize = GetGraphics().MeasureString(this.text, font);
            Textlenght = textSize.Width;
            DrawLine();
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
            this.Startpoint = new Point(this.Startpoint.X + xAmount, this.Startpoint.Y + yAmount);
            this.Endpoint = new Point(this.Endpoint.X + xAmount, this.Endpoint.Y + yAmount);
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

        public void DrawLine()
        {
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;

            x1 = Startpoint.X;
            y1 = Startpoint.Y;
            x2 = Endpoint.X;
            y2 = Endpoint.Y;

            Point sTest = new Point(x1, y1);
            Point eTest = new Point(x2, y1);
            GetGraphics().DrawLine(pen, sTest, eTest);

            sTest = new Point(x2, y1);
            eTest = new Point(x2, y2);
            GetGraphics().DrawLine(pen, sTest, eTest);

            sTest = new Point(x2, y2);
            eTest = new Point(x1, y2);
            GetGraphics().DrawLine(pen, sTest, eTest);

            //arrow
            sTest = new Point(x1, y2);
            eTest = new Point(x1 + 10, y2 - 10);
            GetGraphics().DrawLine(pen, sTest, eTest);

            eTest = new Point(x1 + 10, y2 + 10);
            GetGraphics().DrawLine(pen, sTest, eTest);
        }

        public override void Rezise(MouseEventArgs e, int x, int y)
        {
            Point point = e.Location;
            Endpoint= e.Location;
        }
    }
}
