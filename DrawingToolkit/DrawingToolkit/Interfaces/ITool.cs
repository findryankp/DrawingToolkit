using System;
using System.Windows.Forms;
using DrawingToolkit.Interfaces;

namespace DrawingToolkit.Interfaces
{
    public interface ITool
    {
        String Name { get; set; }
        Cursor Cursor { get; }
        ICanvas TargetCanvas { get; set; } //arah ke nomer 4 

        void ToolMouseDown(object sender, MouseEventArgs e);
        void ToolMouseUp(object sender, MouseEventArgs e);
        void ToolMouseMove(object sender, MouseEventArgs e);
    }
}
