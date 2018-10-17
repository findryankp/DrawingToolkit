using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingToolkit.Interfaces
{
    public interface ICanvas
    {
        void SetActiveTool(ITool tool); //memanggil interface tool untuk mengambil mouse
        void Repaint();
        void SetBackgroundColor(Color color);
        void AddDrawingObject(DrawingObject drawingObject); //membuat gambarnya
    }
}
