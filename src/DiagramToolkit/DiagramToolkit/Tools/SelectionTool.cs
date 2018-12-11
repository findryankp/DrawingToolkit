using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Linq;
using DiagramToolkit.States;

namespace DiagramToolkit.Tools
{
    public class SelectionTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private DrawingObject selectedObject;

        Point point;
        private Boolean multiSelect = false;

        private List<DrawingObject> tempGroup = new List<DrawingObject>();

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
                return this.canvas;
            }

            set
            {
                this.canvas = value;
            }
        }

        public SelectionTool()
        {
            this.Name = "Selection tool";
            this.ToolTipText = "Selection tool";
            this.Image = IconSet.cursor;
            this.CheckOnClick = true;
        }

        public void ToolHotKeysDown(object sender, Keys e)
        {
            throw new NotImplementedException();
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                multiSelect = true;
            }
            else if (e.KeyCode == Keys.G)
            {
                if (tempGroup.Count() > 1)
                {
                    DrawingGroup drawingGroup = new DrawingGroup();
                    foreach (DrawingObject drawingObject in tempGroup)
                    {
                        drawingGroup.AddComposite(drawingObject);
                    }
                    drawingGroup.ChangeState(StaticState.GetInstance());
                    this.canvas.AddDrawingObject(drawingGroup);
                    tempGroup.Clear();
                }
            }
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                multiSelect = false;
            }
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            point = e.Location;

            if (e.Button == MouseButtons.Left && canvas != null)
            {
                if (selectedObject == null)
                {
                    canvas.DeselectAllObjects();
                    tempGroup.Clear();
                }
                else if (!multiSelect)
                {
                    selectedObject.ChangeState(StaticState.GetInstance());
                }
                selectedObject = canvas.SelectObjectAt(e.X, e.Y);
                if (selectedObject != null)
                {
                    selectedObject.ChangeState(EditState.GetInstance());
                    if (multiSelect)
                    {
                        tempGroup.Add(selectedObject);
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                canvas.RemoveDrawingObject(this.selectedObject);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && canvas != null)
            {
                if (selectedObject != null)
                {
                    int xAmount = e.X - point.X;
                    int yAmount = e.Y - point.Y;
                    point = e.Location;
                    selectedObject.Translate(e, xAmount, yAmount);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            
        }
    }
}
