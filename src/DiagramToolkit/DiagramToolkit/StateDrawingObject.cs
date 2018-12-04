using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DiagramToolkit.States;

namespace DiagramToolkit
{
    public abstract class StateDrawingObject : DrawingObject
    {
        public DrawingState State
        {
            get
            {
                return this.state;
            }
        }

        private DrawingState state;

        public StateDrawingObject()
        {
            this.ChangeState(PreviewState.GetInstance()); //default initial state
        }

        public abstract void RenderOnStaticView();
        public abstract void RenderOnEditingView();
        public abstract void RenderOnPreview();

        public void ChangeState(DrawingState state)
        {
            this.state = state;
        }

        public override void Draw()
        {
            this.state.Draw(this);
        }

        public void Select()
        {
            Debug.WriteLine("Object id=" + ID.ToString() + " is selected.");
            this.state.Select(this);
        }

        public void Deselect()
        {
            Debug.WriteLine("Object id=" + ID.ToString() + " is deselected.");
            this.state.Deselect(this);
        }
    }
}
