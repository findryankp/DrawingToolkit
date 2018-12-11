using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagramToolkit
{
    public interface ITool
    {
        String Name { get; set; } //mereturn nama tool nya
        Cursor Cursor { get; } //cursor disana bisa ngapain aja
        ICanvas TargetCanvas { get; set; } // melakukan aksi di canvasnya


        //hal-hal yang dilakukan oleh Tool
        void ToolMouseDown(object sender, MouseEventArgs e);
        void ToolMouseUp(object sender, MouseEventArgs e);
        void ToolMouseMove(object sender, MouseEventArgs e);
        void ToolMouseDoubleClick(object sender, MouseEventArgs e);

        void ToolKeyUp(object sender, KeyEventArgs e);
        void ToolKeyDown(object sender, KeyEventArgs e);
        void ToolHotKeysDown(object sender, Keys e);
    }
}
