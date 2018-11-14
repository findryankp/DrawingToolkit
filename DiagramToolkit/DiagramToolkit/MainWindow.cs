using DiagramToolkit.Commands;
using DiagramToolkit.MenuItems;
using DiagramToolkit.ToolbarItems;
using DiagramToolkit.Tools;
using System.Diagnostics;
using System.Windows.Forms;

namespace DiagramToolkit
{
    public partial class MainWindow : Form
    {
        private IToolbox toolbox;
        private ICanvas canvas;
        private IToolbar toolbar;
        private IMenubar menubar;

        public MainWindow()
        {
            InitializeComponent();
            InitUI();
        }

        private void InitUI()
        {
            Debug.WriteLine("Initializing UI objects.");

            #region Canvas

            Debug.WriteLine("Loading canvas...");
            this.canvas = new DefaultCanvas();
            this.toolStripContainer1.ContentPanel.Controls.Add((Control)this.canvas);

            #endregion

            #region Commands

            BlackCanvasBgCommand blackCanvasBgCmd = new BlackCanvasBgCommand(this.canvas);
            WhiteCanvasBgCommand whiteCanvasBgCmd = new WhiteCanvasBgCommand(this.canvas);

            #endregion

            #region Menubar

            Debug.WriteLine("Loading menubar...");
            this.menubar = new DefaultMenubar();
            this.Controls.Add((Control)this.menubar);

            DefaultMenuItem fileMenuItem = new DefaultMenuItem("File");
            this.menubar.AddMenuItem(fileMenuItem);

            DefaultMenuItem newMenuItem = new DefaultMenuItem("New");
            fileMenuItem.AddMenuItem(newMenuItem);
            fileMenuItem.AddSeparator();
            DefaultMenuItem exitMenuItem = new DefaultMenuItem("Exit");
            fileMenuItem.AddMenuItem(exitMenuItem);

            DefaultMenuItem editMenuItem = new DefaultMenuItem("Edit");
            this.menubar.AddMenuItem(editMenuItem);

            DefaultMenuItem undoMenuItem = new DefaultMenuItem("Undo");
            editMenuItem.AddMenuItem(undoMenuItem);
            DefaultMenuItem redoMenuItem = new DefaultMenuItem("Redo");
            editMenuItem.AddMenuItem(redoMenuItem);

            DefaultMenuItem viewMenuItem = new DefaultMenuItem("View");
            this.menubar.AddMenuItem(viewMenuItem);

            DefaultMenuItem helpMenuItem = new DefaultMenuItem("Help");
            this.menubar.AddMenuItem(helpMenuItem);

            DefaultMenuItem aboutMenuItem = new DefaultMenuItem("About");
            helpMenuItem.AddMenuItem(aboutMenuItem);

            #endregion

            #region Toolbox

            // Initializing toolbox
            Debug.WriteLine("Loading toolbox...");
            this.toolbox = new DefaultToolbox();
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add((Control)this.toolbox);

            #endregion

            #region Tools

            // Initializing tools
            Debug.WriteLine("Loading tools...");
            this.toolbox.AddTool(new SelectionTool());
            this.toolbox.AddSeparator();
            this.toolbox.AddTool(new LineTool());
            this.toolbox.AddTool(new RectangleTool());
            this.toolbox.AddSeparator();
            this.toolbox.AddTool(new CircleTool());
            this.toolbox.ToolSelected += Toolbox_ToolSelected;

            #endregion

            #region Toolbar

            // Initializing toolbar
            Debug.WriteLine("Loading toolbar...");
            this.toolbar = new DefaultToolbar();
            this.toolStripContainer1.TopToolStripPanel.Controls.Add((Control)this.toolbar);

            ExampleToolbarItem toolItem1 = new ExampleToolbarItem();
            toolItem1.SetCommand(whiteCanvasBgCmd);
            ExampleToolbarItem toolItem2 = new ExampleToolbarItem();
            toolItem2.SetCommand(blackCanvasBgCmd);

            this.toolbar.AddToolbarItem(toolItem1);
            this.toolbar.AddSeparator();
            this.toolbar.AddToolbarItem(toolItem2);

            #endregion

        }

        private void Toolbox_ToolSelected(ITool tool)
        {
            if (this.canvas != null)
            {
                Debug.WriteLine("Tool " + tool.Name + " is selected");
                this.canvas.SetActiveTool(tool);
                tool.TargetCanvas = this.canvas;
            }
        }
    }
}
