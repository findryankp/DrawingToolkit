using System.Collections.Generic;
using System.Windows.Forms;
using DrawingToolkit.Interfaces;
using DrawingToolkit.Tools;
using DrawingToolkit.Shape;

namespace DrawingToolkit.Tools
{
    public class SelectTool : ToolStripButton, ITool
    {
        private ICanvas drawingCanvas;
        private Selected shape;

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

        public SelectTool()
        {
            this.Name = "Select Tool";
            this.ToolTipText = "Select Tool";
            this.Image = IconSet.cursor;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            List<DrawingObject> temp = this.drawingCanvas.GetObject();
            foreach (DrawingObject dobject in temp)
            {

                if (dobject.Selected(e.Location))
                {

                    this.drawingCanvas.Repaint();
                }
                else
                {
                    dobject.Idle();
                    this.drawingCanvas.Repaint();
                }

            }
            //shape = new Selected();
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {

        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}