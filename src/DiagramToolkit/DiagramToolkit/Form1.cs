using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagramToolkit
{
    public partial class Form1 : Form
    {
        private DrawingObject obj;
        private ICanvas canvas;
        public Form1(string text, DrawingObject obj, ICanvas canvas)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.textBox1.Text = text;
            this.obj = obj;
            this.canvas = canvas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<DrawingObject> drawingObjects = canvas.GetAllObject();
            foreach(DrawingObject object1 in drawingObjects)
            {
                if (this.obj == object1)
                {
                    obj.SetText(this.textBox1.Text);
                }
            }
            this.Close();
        }
    }
}
