using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DiagramToolkit.Shapes;

namespace DiagramToolkit.Shapes
{
    class Connector : DrawingObject, IObserver
    {
        private const double EPSILON = 3.0;
        public Point startPoint;
        public Point finishPoint;
        private Pen pen;

        public DrawingObject objectSource;
        public DrawingObject objectDestination;

        public Connector(DrawingObject objectSource, DrawingObject objectDestination)
        {
            this.pen = new Pen(Color.Black);
            this.objectSource = objectSource;
            this.objectDestination = objectDestination;
            Update();
        }

        public override Point GetCenterPoint()
        {
            throw new NotImplementedException();
        }

        public override void RenderOnEditingView()
        {
            pen.Color = Color.Blue;
            pen.DashStyle = DashStyle.Solid;
            this.Graphics.DrawLine(pen, this.startPoint, this.finishPoint);
        }

        public override void RenderOnPreview()
        {
            pen.Color = Color.Blue;
            pen.DashStyle = DashStyle.DashDotDot;
            this.Graphics.DrawLine(pen, this.startPoint, this.finishPoint);
        }

        public override void RenderOnStaticView()
        {
            pen.Color = Color.Black;
            pen.DashStyle = DashStyle.Solid;
            this.Graphics.DrawLine(pen, this.startPoint, this.finishPoint);
        }

        public override void Translate(MouseEventArgs e, int xAmount, int yAmount)
        {
            Point point = e.Location;
            this.startPoint = new Point(this.startPoint.X + xAmount, this.startPoint.Y + yAmount);
            this.finishPoint = new Point(this.finishPoint.X + xAmount, this.finishPoint.Y + yAmount);
        }

        public override bool Intersect(int xTest, int yTest)
        {
            double a = (double)(finishPoint.Y - startPoint.Y) / (double)(finishPoint.X - startPoint.X);
            double b = finishPoint.Y - a * finishPoint.X;
            double c = a * xTest + b;

            if (Math.Abs(yTest - c) < EPSILON)
            {
                return true;
            }
            return false;
        }

        public void Update()
        {
            this.startPoint = objectSource.GetCenterPoint();
            this.finishPoint = objectDestination.GetCenterPoint();
        }
    }
}
