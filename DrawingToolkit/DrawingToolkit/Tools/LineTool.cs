﻿using System.Windows.Forms;
using DrawingToolkit.Shape;
using DrawingToolkit.Interfaces;
using DrawingToolkit.Tools;

namespace DrawingToolkit.Tools
{
    public class LineTool : ToolStripButton, ITool
    {
        private ICanvas drawingCanvas;
        private Line line;

        public Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public ICanvas TargetCanvas
        {
            get
            {
                return this.drawingCanvas;
            }

            set
            {
                this.drawingCanvas = value;
            }

        }

        public LineTool()
        {
            this.Name = "Line Tool";
            this.ToolTipText = "Line Tool";
            this.Image = IconSet.line;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            line = new Line(new System.Drawing.Point(e.X, e.Y));
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
        
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            line.finishPoint = new System.Drawing.Point(e.X, e.Y);
            drawingCanvas.AddDrawingObject(line);
        }
    }
}