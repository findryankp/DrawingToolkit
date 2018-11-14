using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit.Commands
{
    public class WhiteCanvasBgCommand : ICommand
    {
        private ICanvas canvas;

        public WhiteCanvasBgCommand(ICanvas canvas)
        {
            this.canvas = canvas;
        }

        public void Execute()
        {
            Debug.WriteLine("Change background color to white");
            this.canvas.SetBackgroundColor(Color.White);
            this.canvas.Repaint();
        }
    }
}
