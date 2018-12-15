using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DiagramToolkit.Shapes;
using System.Linq;

namespace DiagramToolkit
{
    public class DefaultCanvas : Control, ICanvas
    {
        private ITool activeTool;
        private List<DrawingObject> drawingObjects; //menampung jumlah object yang digambar

        public DefaultCanvas()
        {
            Init();
        }

        private void Init()
        {
            this.drawingObjects = new List<DrawingObject>();
            this.DoubleBuffered = true;
            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            this.Paint += DefaultCanvas_Paint;
            this.MouseDown += DefaultCanvas_MouseDown;
            this.MouseUp += DefaultCanvas_MouseUp;
            this.MouseMove += DefaultCanvas_MouseMove;
            this.MouseDoubleClick += DefaultCanvas_MouseDoubleClick;

            this.KeyDown += DefaultCanvas_KeyDown;
            this.KeyUp += DefaultCanvas_KeyUp;
            this.PreviewKeyDown += DefaultCanvas_PreviewKeyDown;
        }

        private void DefaultCanvas_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                    e.IsInputKey = true;
                    break;
                case Keys.Up:
                    e.IsInputKey = true;
                    break;
                case Keys.Down:
                    e.IsInputKey = true;
                    break;
                case Keys.Left:
                    e.IsInputKey = true;
                    break;
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void DefaultCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseMove(sender, e);
                this.Repaint();
            }
        }

        private void DefaultCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseUp(sender, e);
                this.Repaint();
            }
        }

        private void DefaultCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseDown(sender, e);
                this.Repaint();
            }
        }

        private void DefaultCanvas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseDoubleClick(sender, e);
                this.Repaint();
            }
        }

        private void DefaultCanvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (DrawingObject obj in drawingObjects.Reverse<DrawingObject>())
            {
                obj.Graphics = e.Graphics;
                obj.Draw();
            }
        }

        private void DefaultCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolKeyDown(sender, e);
            }
        }
        private void DefaultCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolKeyUp(sender, e);
            }
        }

        public void Repaint()
        {
            this.Invalidate();
            this.Update();
        }

        public void SetActiveTool(ITool tool)
        {
            this.activeTool = tool;
        }

        public ITool GetActiveTool()
        {
            return this.activeTool;
        }

        public void SetBackgroundColor(Color color)
        {
            this.BackColor = color;
        }

        public void AddDrawingObject(DrawingObject drawingObject)
        {
            this.drawingObjects.Add(drawingObject);
        }

        public void AddDrawingObjectToFront(DrawingObject drawingObject)
        {
            this.drawingObjects.Insert(0, drawingObject);
            System.Console.WriteLine(this.drawingObjects[0]);
        }

        public void RemoveDrawingObject(DrawingObject drawingObject)
        {
            this.drawingObjects.Remove(drawingObject);
        }

        public DrawingObject GetObjectAt(int x, int y)
        {
            foreach (DrawingObject obj in drawingObjects.Reverse<DrawingObject>())
            {
                if (obj.Intersect(x, y))
                {
                    return obj;
                }
            }
            return null;
        }

        public DrawingObject SelectObjectAt(int x, int y)
        {
            DrawingObject obj = GetObjectAt(x, y);
            if (obj != null)
            {
                obj.Select();
            }

            return obj;
        }

        public void DeselectAllObjects()
        {
            foreach (DrawingObject drawObj in drawingObjects.Reverse<DrawingObject>())
            {
                drawObj.Deselect();
            }
        }

        public List<DrawingObject> GetAllObject()
        {
            return drawingObjects;
        }
    }
}
