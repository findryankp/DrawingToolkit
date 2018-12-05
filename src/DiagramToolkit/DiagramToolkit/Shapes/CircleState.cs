using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DiagramToolkit.Shapes
{
    //copy semua sama
    //masukan fungsi draw di circle pada oneditingview
    public class CircleState : DrawingObject
    {
        public int cirX { get; set; }
        public int cirY { get; set; }
        public int cirWidth { get; set; }
        public int cirHeight { get; set; }

        private Pen pen;

        public CircleState()
        {
            this.pen = new Pen(Color.Black);
        }

        public CircleState(int initX, int initY) : this()
        {
            this.cirX = initX;
            this.cirY = initY;
        }

        public CircleState(int initX, int initY, int initWidth, int initHeight) : this(initX, initY)
        {
            this.cirWidth = initWidth;
            this.cirHeight = initHeight;
        }

        public override void RenderOnStaticView()
        {
            this.pen = new Pen(Color.Red);
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawEllipse(pen, cirX, cirY, cirWidth, cirHeight);
            }
        }

        public override void RenderOnEditingView()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawEllipse(pen, cirX, cirY, cirWidth, cirHeight);
            }
        }

        public override void RenderOnPreview()
        {
            RenderOnStaticView();
        }

        public override bool Intersect(int xTest, int yTest)
        {
            throw new NotImplementedException();
        }
    }
}
