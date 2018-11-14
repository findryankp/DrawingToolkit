using System;
using System.Drawing;

namespace DiagramToolkit
{
    public abstract class DrawingObject
    {
        public Guid ID { get; set; }
        public Graphics Graphics { get; set; }

        public DrawingObject()
        {
            ID = Guid.NewGuid();
        }

        public abstract void Draw();

    }
}
