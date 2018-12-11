using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiagramToolkit.Shapes;

namespace DiagramToolkit.Tools
{
    public class SelectionTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private DrawingObject selectedObject;
        private int xInitial;
        private int yInitial;
        private Text text;

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
            throw new NotImplementedException();
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            this.xInitial = e.X;
            this.yInitial = e.Y;

            if (e.Button == MouseButtons.Left && canvas != null)
            {
                canvas.DeselectAllObjects();
                selectedObject = canvas.SelectObjectAt(e.X, e.Y);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && canvas != null)
            {
                if (selectedObject != null)
                {
                    int xAmount = e.X - xInitial;
                    int yAmount = e.Y - yInitial;
                    xInitial = e.X;
                    yInitial = e.Y;

                    selectedObject.Translate(e.X, e.Y, xAmount, yAmount);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private string passingText;
        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("selection tool double click");

            text = new Text();
            text.X = e.X;
            text.Y = e.Y;

            //DrawingObject obj = canvas.SelectObjectAt(e.X, e.Y);
            DrawingObject obj = canvas.GetObjectAt(e.X, e.Y);

            if (obj == null)
            {
                //canvas.AddDrawingObject(text);
            }
            else
            {
                passingText = obj.GetText();
                using (Form1 form2 = new Form1(passingText, obj, canvas))
                {
                    if (form2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        form2.ShowDialog();
                    }
                }
                bool allowed = obj.Add(text);

                if (!allowed)
                {
                    //canvas.AddDrawingObject(text);
                }
            }
        }
    }
}
