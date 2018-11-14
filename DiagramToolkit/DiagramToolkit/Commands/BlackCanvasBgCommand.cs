using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit.Commands
{
    public class BlackCanvasBgCommand : ICommand
    {
        private ICanvas canvas;

        public BlackCanvasBgCommand(ICanvas canvas)
        {
            this.canvas = canvas;
        }

        public void Execute()
        {
            Debug.WriteLine("Change background color to black");
            this.canvas.SetBackgroundColor(Color.Black);
            this.canvas.Repaint();
        }
    }
}
