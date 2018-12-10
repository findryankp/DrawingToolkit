﻿using DiagramToolkit.Shapes;
using DiagramToolkit.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiagramToolkit.Sequences;

namespace DiagramToolkit.Tools
{
    public class ReturnMessageTool : ToolStripButton, ITool
    {
        private ICanvas varCanvas;
        private ReturnMessage returnMessage;

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
                return this.varCanvas;
            }

            set
            {
                this.varCanvas = value;
            }
        }

        public ReturnMessageTool()
        {
            this.Name = "Stateful Line tool";
            this.ToolTipText = "Stateful Line tool";
            this.Image = IconSet.diagonal_line;
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
            if (e.Button == MouseButtons.Left)
            {
                returnMessage = new ReturnMessage(new System.Drawing.Point(e.X, e.Y));
                returnMessage.Endpoint = new System.Drawing.Point(e.X, e.Y);
                varCanvas.AddDrawingObject(returnMessage);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.returnMessage != null)
                {
                    returnMessage.Endpoint = new System.Drawing.Point(e.X, e.Y);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.returnMessage != null)
                {
                    returnMessage.Endpoint = new System.Drawing.Point(e.X, e.Y);
                    returnMessage.Select();
                }
            }
        }
    }
}