using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit
{
    public abstract class DrawingState
    {
        public DrawingState State
        {
            get
            {
                return this.state;
            }
        }

        private DrawingState state;

        public abstract void Draw(DrawingObject obj);

        public virtual void Deselect(DrawingObject obj)
        {
            //default implementation, no state transition
        }

        public virtual void Select(DrawingObject obj)
        {
            //default implementation, no state transition
        }
    }
}
