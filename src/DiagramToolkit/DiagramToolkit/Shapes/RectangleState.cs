using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DiagramToolkit.Shapes
{
    public class RectangleState : DrawingObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private Pen pen;
        private List<DrawingObject> drawingObjects;

        public RectangleState()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
            drawingObjects = new List<DrawingObject>();
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
            this.pen.Color = Color.Red;
            this.pen.DashStyle = DashStyle.DashDot;
            GetGraphics().DrawRectangle(this.pen, X, Y, Width, Height);

            foreach (DrawingObject obj in drawingObjects)
            {
                obj.SetGraphics(GetGraphics());
                obj.RenderOnPreview();
            }
        }

        public override void RenderOnEditingView()
        {
            this.pen.Color = Color.Blue;
            this.pen.DashStyle = DashStyle.Solid;
            GetGraphics().DrawRectangle(this.pen, X, Y, Width, Height);

            foreach (DrawingObject obj in drawingObjects)
            {
                obj.SetGraphics(GetGraphics());
                obj.RenderOnEditingView();
            }
        }

        public override void RenderOnStaticView()
        {
            this.pen.Color = Color.Black;
            this.pen.DashStyle = DashStyle.Solid;
            GetGraphics().DrawRectangle(this.pen, X, Y, Width, Height);

            foreach (DrawingObject obj in drawingObjects)
            {
                obj.SetGraphics(GetGraphics());
                obj.RenderOnStaticView();
            }
        }

        public override void Rezise(MouseEventArgs e, int xa, int ya)
        {
            Point point = e.Location;
            Width = (e.X - X) * 2 / 2;
            Height = (e.Y - Y) * 2 / 2;
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
            foreach (DrawingObject obj in drawingObjects)
            {
                obj.Translate(e, xAmount, yAmount);
            }
        }

        public override bool Add(DrawingObject obj)
        {
            drawingObjects.Add(obj);

            return true;
        }

        public override bool Remove(DrawingObject obj)
        {
            drawingObjects.Remove(obj);

            return true;
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
