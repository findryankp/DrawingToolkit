using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System;
using System.Drawing.Drawing2D;

namespace DiagramToolkit.Sequences
{
    public class Actor : DrawingObject
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

        public Actor()
        {
            this.text = "Edit";

            FontFamily fontFamily = new FontFamily("Arial");
            font = new Font(
               fontFamily,
               16,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
        }

        public Actor(Point startpoint) :
            this()
        {
            this.Startpoint = startpoint;
        }

        public Actor(Point startpoint, Point endpoint) :
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
            if ((xTest >= (Startpoint.X - 10) && xTest <= (Startpoint.X + 10)) 
                && (yTest >= Startpoint.Y - 5 && yTest <= (Endpoint.Y + 10)))
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
            this.brush = new SolidBrush(Color.Blue);
            this.pen = new Pen(Color.Blue);
            float pos1 = Startpoint.X - (textSize.Width / 2);
            float pos2 = Endpoint.Y + 10;
            PointF aaa = new PointF(pos1, pos2);
            GetGraphics().DrawString(this.text, font, brush, aaa);

            textSize = GetGraphics().MeasureString(this.text, font);
            Textlenght = textSize.Width;
            DrawActor();
        }

        public override void RenderOnPreview()
        {
            this.brush = new SolidBrush(Color.Red);
            this.pen = new Pen(Color.Red);
            float pos1 = Startpoint.X - (textSize.Width / 2);
            float pos2 = Endpoint.Y + 10;
            PointF aaa = new PointF(pos1, pos2);
            GetGraphics().DrawString(this.text, font, brush, aaa);

            textSize = GetGraphics().MeasureString(this.text, font);
            Textlenght = textSize.Width;
            DrawActor();
        }

        public override void RenderOnStaticView()
        {
            this.brush = new SolidBrush(Color.Black);
            this.pen = new Pen(Color.Black);
            float pos1 = Startpoint.X - (textSize.Width / 2);
            float pos2 = Endpoint.Y + 10;
            PointF aaa = new PointF(pos1, pos2);
            GetGraphics().DrawString(this.text, font, brush, aaa);

            textSize = GetGraphics().MeasureString(this.text, font);
            Textlenght = textSize.Width;
            DrawActor();
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

        public void DrawActor()
        {
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;

            x1 = Startpoint.X;
            y1 = Startpoint.Y;
            x2 = Endpoint.X;
            y2 = Endpoint.Y;

            //garis pusat
            Point sTest = new Point(x1, y1);
            Point eTest = new Point(x1, y2);
            GetGraphics().DrawLine(pen, sTest, eTest);

            //kaki kiri
            sTest = new Point(x1, y2);
            eTest = new Point(x1 - 10, y2 + 10);
            GetGraphics().DrawLine(pen, sTest, eTest);

            //kaki kanan
            sTest = new Point(x1, y2);
            eTest = new Point(x1 + 10, y2 + 10);
            GetGraphics().DrawLine(pen, sTest, eTest);

            //tangan kiri
            sTest = new Point(x1, y1);
            eTest = new Point(x1 - 10, y1);
            GetGraphics().DrawLine(pen, sTest, eTest);

            //tangan kanan
            sTest = new Point(x1, y1);
            eTest = new Point(x1 + 10, y1);
            GetGraphics().DrawLine(pen, sTest, eTest);

            //leher
            sTest = new Point(x1, y1);
            eTest = new Point(x1, y1 - 5);
            GetGraphics().DrawLine(pen, sTest, eTest);

            //kepala
            GetGraphics().DrawEllipse(pen, x1 - 10, y1 - 25, 20, 20);

            //lifeline
            pen.DashStyle = DashStyle.Dash;
            sTest = new Point(x1, y2 + 27);
            eTest = new Point(x1, 500);
            GetGraphics().DrawLine(pen, sTest, eTest);
        }
    }
}
