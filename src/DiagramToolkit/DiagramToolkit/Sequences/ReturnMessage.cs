using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System;
using System.Drawing.Drawing2D;

namespace DiagramToolkit.Sequences
{
    public class ReturnMessage : DrawingObject
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

        public ReturnMessage()
        {
            this.text = "Return Message";

            FontFamily fontFamily = new FontFamily("Arial");
            font = new Font(
               fontFamily,
               16,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
        }

        public ReturnMessage(Point startpoint) :
            this()
        {
            this.Startpoint = startpoint;
        }

        public ReturnMessage(Point startpoint, Point endpoint) :
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

        private const double EPSILON = 3.0;
        public override bool Intersect(int xTest, int yTest)
        {
            double m = GetSlope();
            double b = Startpoint.Y - m * Startpoint.X;
            double y_point = m * xTest + b;

            if (Math.Abs(yTest - y_point) < EPSILON)
            {
                Debug.WriteLine("Object " + ID + " is selected.");
                return true;
            }
            return false;
        }

        public double GetSlope()
        {
            double m = (double)(Startpoint.Y - Endpoint.Y) / (double)(Startpoint.X - Endpoint.X);
            return m;
        }

        public float pos1;
        public float pos2;

        public override void RenderOnEditingView()
        {
            this.pen = new Pen(Color.Blue);
            this.brush = new SolidBrush(Color.Blue);
            float pos1 = Startpoint.X + ((Endpoint.X-Startpoint.X)*2/4) - (textSize.Width/2);
            float pos2 = Startpoint.Y - 20;
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
            float pos1 = Startpoint.X + ((Endpoint.X - Startpoint.X) * 2 / 4) - (textSize.Width / 2);
            float pos2 = Startpoint.Y - 20;
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
            float pos1 = Startpoint.X + ((Endpoint.X - Startpoint.X) * 2 / 4) - (textSize.Width / 2);
            float pos2 = Startpoint.Y - 20;
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
            pen.DashStyle = DashStyle.Dash;

            x1 = Startpoint.X;
            y1 = Startpoint.Y;
            x2 = Endpoint.X;
            y2 = Endpoint.Y;

            Point sTest = new Point(x1, y1);
            Point eTest = new Point(x2, y1);
            GetGraphics().DrawLine(pen, sTest, eTest);

            //arrow
            pen.DashStyle = DashStyle.Solid;
            sTest = new Point(x2, y1);
            eTest = new Point(x2 + 10, y1 - 10);
            GetGraphics().DrawLine(pen, sTest, eTest);

            eTest = new Point(x2 + 10, y1 + 10);
            GetGraphics().DrawLine(pen, sTest, eTest);
        }

        public override void Rezise(MouseEventArgs e, int x, int y)
        {
            Point point = e.Location;
            Endpoint = e.Location;
        }
    }
}
