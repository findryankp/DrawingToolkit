using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DiagramToolkit
{
    class DrawingGroup : DrawingObject
    {
        private List<DrawingObject> drawingGroups = new List<DrawingObject>();

        public void AddComposite(DrawingObject drawingObject)
        {
            this.drawingGroups.Add(drawingObject);
        }

        public void RemoveComposite(DrawingObject drawingObject)
        {
            this.drawingGroups.Remove(drawingObject);
        }

        public override void ChangeState(DrawingState state)
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                drawingObject.ChangeState(state);
            }
            this.state = state;
        }

        public override void RenderOnEditingView()
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                drawingObject.RenderOnEditingView();
            }
        }

        public override void RenderOnPreview()
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                drawingObject.RenderOnPreview();
            }
        }

        public override void RenderOnStaticView()
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                drawingObject.RenderOnStaticView();
            }
        }

        public override Point GetCenterPoint()
        {
            throw new NotImplementedException();
        }

        public override bool Intersect(int xTest, int yTest)
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                if (drawingObject.Intersect(xTest, yTest))
                {
                    return true;
                }
            }
            return false;
        }

        public override void Translate(MouseEventArgs e, int xAmount, int yAmount)
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                drawingObject.Translate(e, xAmount,yAmount);
            }
        }

        public override void Select()
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                drawingObject.Select();
            }
        }

        public override void Deselect()
        {
            foreach (DrawingObject drawingObject in drawingGroups)
            {
                drawingObject.Deselect();
            }
        }

        public override void Draw()
        {

        }

        public override string GetText()
        {
            throw new NotImplementedException();
        }

        public override void SetText(string s)
        {
            throw new NotImplementedException();
        }

        public override bool Add(DrawingObject obj)
        {
            throw new NotImplementedException();
        }

        public override bool Remove(DrawingObject obj)
        {
            throw new NotImplementedException();
        }

        public override void Rezise(MouseEventArgs e, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
