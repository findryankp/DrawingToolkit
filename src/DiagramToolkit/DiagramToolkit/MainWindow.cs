using DiagramToolkit.Tools;
using System.Diagnostics;
using System.Windows.Forms;

namespace DiagramToolkit
{
    #region langkah
    //1. buatlah Icanvas -> untuk menampung gambar
    //2. buatlah Itool -> toolnya nanti bisa apa saja
    //3. buat IToolbox -> untuk menampung atau sebagai tempat tool-toolnya
    //4. buat default toolbox -> implementasi fungsi2 yang sudah dibuat di IToolbox
    //5. Buat Toolbar -> menampung menu2 yang berada diatas
    //6. buat Itoolbar -> Toolbarnya nanti biasa ngapain aja
    //7. membuat menubar -> berisi file, edit, dan lain2
    //8. Buat IMenubar
    //9. buat IMenuItem
    //10. buat default menu bar
    //11. Membuat background color pada ICanvas
    //12. buat default canvasnya

    //---Lanjutan--//
    //1. Buat drawign object nya untuk menampung hasil gambarnya
    //2. Buat segment bentukknya (pada shape->Line)
    //3. tambahkan list object pada default canvas dan isi2nya
    //4. tambahkan inisialisasi pada mainwindow

    ////---Lanjutan--////
    //1. buat rectanglenya.cs (di shape->rectangle) bagaimana kotak bisa terbentuk
    //2. buat rectangle toolnya -> untuk menampung hal-hal yang dilakukan oleh mouse saat tool rectangle dipilih
    //3. tambahkan toolnya di main window
    #endregion

    #region State
    //--Line State--//
    //1. buat statedrawing objectnya
    //2. buat kelas drawing statenya
    //3. buat folder State
    //4. buat preview state
    //5. buat file pada folder shapesnya stateLine
    //6. ubah canvasnya tambahin repaint pada setiap gerakan mousenya
    #endregion

    #region selection
     //1. buat selection tool
     //2. tambahkan select deselect pada defaultcanvas
     //3. tambahkan pada drawing object
    #endregion

    public partial class MainWindow : Form
    {
        private IToolbox toolbox;
        private ICanvas canvas;
        private IToolbar toolbar;
        private IMenubar menubar;

        public MainWindow()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            Debug.WriteLine("Initializing UI objects.");

            #region Toolbox

           //tempat2 nya tool
            //Initialize toolbox
            Debug.WriteLine("Loading toolbox...");

            //inisialisasi toolbox
            this.toolbox = new DefaultToolbox();
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add((Control)this.toolbox);

            #endregion

            #region Tools
            //tool tool yang di keluarkan
            ////Initialize tools
            Debug.WriteLine("Loading tools...");

            this.toolbox.AddTool(new SelectionTool());
            //state
            this.toolbox.AddTool(new StateLineTool());
            this.toolbox.AddTool(new StateRectangleTool());
            this.toolbox.AddTool(new StateCircleTool());
            this.toolbox.AddTool(new TextTool());
            //sequence
            this.toolbox.AddSeparator();
            this.toolbox.AddTool(new ActorTool());
            this.toolbox.AddTool(new ActivationBoxTool());
            this.toolbox.AddTool(new ObjectMessageTool());
            this.toolbox.AddTool(new MessageToSelfTool());
            this.toolbox.AddTool(new ReturnMessageTool());
            this.toolbox.ToolSelected += Toolbox_ToolSelected;
            #endregion


            #region Toolbar
            // Initializing toolbar
            //Debug.WriteLine("Loading toolbar...");
            //this.toolbar = new DefaultToolbar();
            //this.toolStripContainer1.TopToolStripPanel.Controls.Add((Control)this.toolbar);

            //this.toolbar.AddToolbarItem(new ExampleToolbarItem());
            //this.toolbar.AddSeparator();
            //this.toolbar.AddToolbarItem(new ExampleToolbarItem());
            #endregion

            #region Menubar
            Debug.WriteLine("Loading menubar...");
            this.menubar = new DefaultMenubar();
            this.Controls.Add((Control)this.menubar);

            DefaultMenuitem exampleMenuItem1 = new DefaultMenuitem("File");
            this.menubar.AddMenuItem(exampleMenuItem1);
                DefaultMenuitem exampleMenuItem11 = new DefaultMenuitem("New");
                exampleMenuItem1.AddMenuItem(exampleMenuItem11);

            DefaultMenuitem exampleMenuItem2 = new DefaultMenuitem("Edit");
            this.menubar.AddMenuItem(exampleMenuItem2);
                DefaultMenuitem exampleMenuItem21 = new DefaultMenuitem("Cut");
                exampleMenuItem2.AddMenuItem(exampleMenuItem21);
                DefaultMenuitem exampleMenuItem22 = new DefaultMenuitem("Copy");
                exampleMenuItem2.AddMenuItem(exampleMenuItem22);

            #endregion

            #region Canvas
            Debug.WriteLine("Loading canvas...");
            this.canvas = new DefaultCanvas();
            this.toolStripContainer1.ContentPanel.Controls.Add((Control)this.canvas);
            #endregion
        }

        private void Toolbox_ToolSelected(ITool tool)
        {
            if (this.canvas != null)
            {
                this.canvas.SetActiveTool(tool);
                tool.TargetCanvas = this.canvas;
            }
        }
    }
}
