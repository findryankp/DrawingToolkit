using System.Windows.Forms;
using System.Drawing;
using DiagramToolkit.Shapes;
using DiagramToolkit.States;
using System.Linq;

namespace DiagramToolkit.Tools
{
    class ConnectorTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private CircleState varCircleState;

        Point point;

        public DrawingObject objectSource;
        public DrawingObject objectDestination;

        public Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public ICanvas TargetCanvas
        {
            get
            {
                return this.canvas;
            }

            set
            {
                this.canvas = value;
            }

        }
        public ConnectorTool()
        {
            this.Name = "Connector Tool";
            this.ToolTipText = "Connector Tool";
            this.Image = IconSet.circle_icon;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            point = e.Location;

            if (e.Button == MouseButtons.Left && canvas != null)
            {
                canvas.DeselectAllObjects();
                objectSource = canvas.SelectObjectAt(e.X, e.Y);

            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && canvas != null)
            {

                canvas.DeselectAllObjects();

                if (objectSource != null)
                {
                    objectDestination = canvas.SelectObjectAt(e.X, e.Y);

                    Connector connector = new Connector(objectSource, objectDestination);
                    objectSource.Attach(connector);
                    objectDestination.Attach(connector);

                    canvas.AddDrawingObjectToFront(connector);
                    connector.ChangeState(StaticState.GetInstance());

                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {

        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {

        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {

        }

        public void ToolHotKeysDown(object sender, Keys e)
        {

        }
    }
}
