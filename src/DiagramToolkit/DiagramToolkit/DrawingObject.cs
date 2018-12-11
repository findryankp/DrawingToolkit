using DiagramToolkit.States;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DiagramToolkit
{
    public abstract class DrawingObject : IObservable
    {
        public Guid ID { get; set; }
        public Graphics Graphics { get; set; }

        List<IObserver> observers = new List<IObserver>();

        public DrawingState State
        {
            get
            {
                return this.state;
            }
        }

        protected DrawingState state;

        public DrawingObject()
        {
            ID = Guid.NewGuid();
            this.ChangeState(PreviewState.GetInstance()); //default initial state
        }

        public abstract bool Intersect(int xTest, int yTest);
        public abstract void Translate(MouseEventArgs e, int xAmount, int yAmount);

        public abstract void RenderOnPreview();
        public abstract void RenderOnEditingView();
        public abstract void RenderOnStaticView();

        public virtual void ChangeState(DrawingState state)
        {
            this.state = state;
        }

        public virtual void Draw()
        {
            this.state.Draw(this);
            Notify();
        }

        public virtual void Select()
        {
            Debug.WriteLine("Object id=" + ID.ToString() + " is selected.");
            this.state.Select(this);
        }

        public virtual void Deselect()
        {
            Debug.WriteLine("Object id=" + ID.ToString() + " is deselected.");
            this.state.Deselect(this);
        }

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (IObserver observer in observers)
            {
                observer.Update();
            }
        }

        public abstract Point GetCenterPoint();

    }
}
