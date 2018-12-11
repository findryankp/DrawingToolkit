using DiagramToolkit.Shapes;
using System;
using System.Windows.Forms;

namespace DiagramToolkit.Tools
{
    public class TextTool : ToolStripButton, ITool
    {
        private Text text;
        private ICanvas canvas;

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

        private string passingText;

        public TextTool()
        {
            this.Name = "Text tool";
            this.ToolTipText = "Text tool";
            this.Image = IconSet.font;
            this.CheckOnClick = true;
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right && canvas != null)
            {
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
            if (e.Button == MouseButtons.Left)
            {
                text = new Text();
                text.Value = "Text";
                text.X = e.X;
                text.Y = e.Y;

                DrawingObject obj = canvas.SelectObjectAt(e.X, e.Y);
                //DrawingObject obj = canvas.GetObjectAt(e.X, e.Y);

                if (obj == null)
                {
                    canvas.AddDrawingObject(text);
                }
                else
                {
                    bool allowed = obj.Add(text);

                    if (!allowed)
                    {
                        canvas.AddDrawingObject(text);
                    }
                }
            }
        }
        public void ToolMouseMove(object sender, MouseEventArgs e)
        {

        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {

        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {

        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {

        }

        public void ToolHotKeysDown(object sender, Keys e)
        {

        }
    }
}
