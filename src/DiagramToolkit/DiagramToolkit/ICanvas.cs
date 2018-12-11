using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DiagramToolkit.Shapes;

namespace DiagramToolkit
{
    public interface ICanvas
    {
        String Name { get; set; }
        ITool GetActiveTool();
        void SetActiveTool(ITool tool); // untuk mengaktifkan tool yang dipilih
        void Repaint(); //fungsi untuk menggambar pada canvas
        void SetBackgroundColor(Color color);

        void AddDrawingObject(DrawingObject drawingObject);
        void RemoveDrawingObject(DrawingObject drawingObject);

        DrawingObject GetObjectAt(int x, int y);
        DrawingObject SelectObjectAt(int x, int y);
        void DeselectAllObjects();

        List<DrawingObject> GetAllObject();
    }
}
