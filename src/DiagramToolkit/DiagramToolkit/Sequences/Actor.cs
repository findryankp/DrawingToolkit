﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DiagramToolkit.Shapes
{
    public class Actor : DrawingObject
    {
        private const double EPSILON = 3.0;

        public Point Startpoint { get; set; }
        public Point Endpoint { get; set; }

        private Pen pen;

        public Actor()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
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

        public override void RenderOnStaticView()
        {
            pen.Color = Color.Black;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;

            if (GetGraphics() != null)
            {
                GetGraphics().SmoothingMode = SmoothingMode.AntiAlias;
                //GetGraphics().DrawLine(pen, this.Startpoint, this.Endpoint);
                DrawText();
                drawSecondLine();
                drawLifeLine();
            }
        }

        public override void RenderOnEditingView()
        {
            pen.Color = Color.Blue;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;

            if (GetGraphics() != null)
            {
                GetGraphics().SmoothingMode = SmoothingMode.AntiAlias;
                //GetGraphics().DrawLine(pen, this.Startpoint, this.Endpoint);
                DrawText();
                drawSecondLine();
                drawLifeLine();
            }
        }

        public override void RenderOnPreview()
        {
            pen.Color = Color.Red;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;

            if (GetGraphics() != null)
            {
                GetGraphics().SmoothingMode = SmoothingMode.AntiAlias;
                //GetGraphics().DrawLine(pen, this.Startpoint, this.Endpoint);
                DrawText();
                drawSecondLine();
                drawLifeLine();
            }
        }

        public override bool Intersect(int xTest, int yTest)
        {
            x1 = Startpoint.X;
            y1 = Startpoint.Y;
            x2 = Endpoint.X;
            y2 = Endpoint.Y;

            if ((xTest >= (x1-10) && xTest <= (x1+10)) && (yTest >= y1 && yTest <= (y2 +10)))
            {
                Debug.WriteLine("Object " + ID + " is selected.");
                return true;
            }
            return false;
        }

        public double GetSlope()
        {
            double m = (double)(Endpoint.Y - Startpoint.Y) / (double)(Endpoint.X - Startpoint.X);
            return m;
        }

        public override void Translate(MouseEventArgs e, int xAmount, int yAmount)
        {
            this.Startpoint = new Point(this.Startpoint.X + xAmount, this.Startpoint.Y + yAmount);
            this.Endpoint = new Point(this.Endpoint.X + xAmount, this.Endpoint.Y + yAmount);
        }

        public int x1;
        public int y1;
        public int x2;
        public int y2;

        public void drawSecondLine()
        {
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
        }

        public void drawLifeLine()
        {
            pen.Color = Color.Black;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;

            x1 = Startpoint.X;
            y1 = Startpoint.Y;
            x2 = Endpoint.X;
            y2 = Endpoint.Y;

            Point sTest = new Point(x1, y2 + 27);
            Point eTest = new Point(x1, 500);
            GetGraphics().DrawLine(pen, sTest, eTest);
        }

        private SizeF textSize;
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

            string text = "Actor";
            textSize = GetGraphics().MeasureString(text, font);

            float pos1 = Startpoint.X-(textSize.Width / 2);
            float pos2 = Endpoint.Y + 10;
            PointF aaa = new PointF(pos1, pos2);

            GetGraphics().DrawString(text, font, brush, aaa);
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
            throw new NotImplementedException();
        }
    }
}