using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WinBud¿et_3
{
	/// <summary>
	/// Summary description for MainWindow.
	/// </summary>
	public class MainWindow : System.Windows.Forms.Form
	{
    private Tulkit tulkit;
    private DataModule budzet;
    private Analizator analizator;
    private VerticalBox verticalBox1;
    private VerticalBox verticalBox2;
    
    /// <summary>
    /// Heniek
    /// </summary>
    public Tulkit Tulkit
    {
      get { return this.tulkit; }
    }
    
    private System.Windows.Forms.MenuItem menuItem6;
    private System.Windows.Forms.MenuItem menuItemNew;
    private System.Windows.Forms.MenuItem menuItemFile;
    private System.Windows.Forms.MenuItem menuItemLoad;
    private System.Windows.Forms.MenuItem menuItemSave;
    private System.Windows.Forms.MenuItem menuItemSaveAs;
    private System.Windows.Forms.MenuItem menuItemExit;
    private System.Windows.Forms.MenuItem menuItemHelp;
    private System.Windows.Forms.MenuItem menuItemAbout;
    private System.Windows.Forms.MainMenu mainMenu;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.SaveFileDialog saveFileDialog;
    private System.Windows.Forms.RichTextBox debugPanel;
    private System.Windows.Forms.TabControl tabControlGlowny;
    private System.Windows.Forms.TabControl tabControlWprowadzanieDanych;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.TabPage tabPage4;
    private System.Windows.Forms.TabPage tabPage5;
    private System.Windows.Forms.TabPage tabPage6;
    private System.Windows.Forms.TabPage tabPage7;
    private System.Windows.Forms.Button button1;
    private WinBud¿et_3.GridPlanow gridPlanyWplywow;
    private WinBud¿et_3.GridPlanow gridPlanyWydatkow;
    private WinBud¿et_3.GridChrono gridChronWydatki;
    private WinBud¿et_3.GridChrono gridChronoWplywy;
    private WinBud¿et_3.GridOperacjiMieszkowych gridOperacjiMieszkowych;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage8;
    private WinBud¿et_3.PanelMieszkiBilans panelMieszkiBilans1;
    private System.Windows.Forms.TabPage tabPage9;
    private WinBud¿et_3.PanelRealizacjaPlanow panelRealizacjaPlanow1;
    private System.Windows.Forms.TabControl tabControlAnalizyDanych;
    private WinBud¿et_3.PanelChronologii panelChronologii1;
    private System.Windows.Forms.TabPage tabPageChronologii;
    private System.Windows.Forms.TabPage tabPageKategorie;
    private WinBud¿et_3.PanelKategorii panelKategorii1;


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Konstruktor domyœlny
		/// </summary>
		public MainWindow()
		{
      tulkit = new Tulkit();
      tulkit.MainWindow = this;
      budzet = new DataModule();
      budzet.Tulkit = this.tulkit;
      analizator = new Analizator();
      analizator.Tulkit = this.tulkit;
      
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			inicjujMojeKomponenty();
			
		}
		
    /// <summary>
    /// Inicjuje dodatkowe komponenty zawarte w MainForm
    /// </summary>
		private void inicjujMojeKomponenty()
		{
      gridChronoWplywy.MainWindow = this;
      gridChronWydatki.MainWindow = this;
      gridOperacjiMieszkowych.MainWindow = this;
      gridPlanyWplywow.MainWindow = this;
      gridPlanyWydatkow.MainWindow = this;
      panelMieszkiBilans1.Analizator = analizator;
      panelRealizacjaPlanow1.Analizator = analizator;
      panelChronologii1.Analizator = analizator;
      panelChronologii1.Tulkit = tulkit;
      panelKategorii1.Tulkit = tulkit;
      panelKategorii1.Analizator=analizator;
      
      podlaczDataSety();
      
      verticalBox1 = new VerticalBox(tabPage5,gridChronoWplywy,gridChronWydatki);
      verticalBox2 = new VerticalBox(tabPage7,gridPlanyWplywow,gridPlanyWydatkow);
      refresh();
      verticalBox1.doResize();
      verticalBox2.doResize();
    }

    /// <summary>
    /// Pod³¹cza tabele bazy danych do poszczególnych DataGridów
    /// </summary>
    private void podlaczDataSety()
    {
      tulkit.DebugTextBox = this.debugPanel;
      tulkit.debug("MainFrame.podlaczDataSety()");
      gridChronoWplywy.podlaczDataTable(budzet.ZestawDanych.Tables["Wplywy"]);
      gridChronWydatki.podlaczDataTable(budzet.ZestawDanych.Tables["Wydatki"]);
      gridOperacjiMieszkowych.podlaczDataTable(budzet.ZestawDanych.Tables["Mieszkowe"]);
      gridPlanyWplywow.podlaczDataTable(budzet.ZestawDanych.Tables["PlanowaneWplywy"]);
      gridPlanyWydatkow.podlaczDataTable(budzet.ZestawDanych.Tables["PlanowaneWydatki"]);
      refresh();
    }
    
    /// <summary>
    /// Wpisuje listy kategorii i pozycji do odpowiednich ComboStyle-ów
    /// </summary>
    private void wpiszListy()
    {
      tulkit.debug("MainFrame.wpiszListy()");
      gridChronoWplywy.wpiszListy(analizator.listaMieszkow(),analizator.listaKategoriiWplywow(),analizator.listaPozycjiWplywow());
      gridChronWydatki.wpiszListy(analizator.listaMieszkow(),analizator.listaKategoriiWydatkow(),analizator.listaPozycjiWydatkow());
      gridOperacjiMieszkowych.wpiszListe(analizator.listaMieszkow());
      gridPlanyWplywow.wpiszListe(analizator.listaKategoriiWplywow());
      gridPlanyWydatkow.wpiszListe(analizator.listaKategoriiWydatkow());
//      tulkit.debug("Rezultat:\n"+analizator.rezultat()+"\nKoniec rezultatu");
    }

    /// <summary>
    /// Metoda wywo³ywana w celu odœwie¿enia wszystkich danych bud¿etowych
    /// </summary>
    private void refresh()
    {
      try
      {
        tulkit.debug("MainWindow.refresh()");
        odswiezAnalize(); 
        wpiszListy();
        updateCaption();
        panelMieszkiBilans1.refresh();
        panelRealizacjaPlanow1.refresh();
        panelKategorii1.refresh();
      } 
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message+"\n"+ex.StackTrace);
      }
    }

		/// <summary>
		/// Zwalnia wszystkie u¿ywane zasoby
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Metody u¿ywane przez Form Designera
		/// </summary>
		private void InitializeComponent()
		{
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainWindow));
      this.mainMenu = new System.Windows.Forms.MainMenu();
      this.menuItemFile = new System.Windows.Forms.MenuItem();
      this.menuItemNew = new System.Windows.Forms.MenuItem();
      this.menuItemLoad = new System.Windows.Forms.MenuItem();
      this.menuItemSave = new System.Windows.Forms.MenuItem();
      this.menuItemSaveAs = new System.Windows.Forms.MenuItem();
      this.menuItem6 = new System.Windows.Forms.MenuItem();
      this.menuItemExit = new System.Windows.Forms.MenuItem();
      this.menuItemHelp = new System.Windows.Forms.MenuItem();
      this.menuItemAbout = new System.Windows.Forms.MenuItem();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.debugPanel = new System.Windows.Forms.RichTextBox();
      this.tabControlGlowny = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.tabControlWprowadzanieDanych = new System.Windows.Forms.TabControl();
      this.tabPage5 = new System.Windows.Forms.TabPage();
      this.gridChronWydatki = new WinBud¿et_3.GridChrono();
      this.gridChronoWplywy = new WinBud¿et_3.GridChrono();
      this.tabPage6 = new System.Windows.Forms.TabPage();
      this.gridOperacjiMieszkowych = new WinBud¿et_3.GridOperacjiMieszkowych();
      this.tabPage7 = new System.Windows.Forms.TabPage();
      this.gridPlanyWydatkow = new WinBud¿et_3.GridPlanow();
      this.gridPlanyWplywow = new WinBud¿et_3.GridPlanow();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage8 = new System.Windows.Forms.TabPage();
      this.panelMieszkiBilans1 = new WinBud¿et_3.PanelMieszkiBilans();
      this.tabPage9 = new System.Windows.Forms.TabPage();
      this.panelRealizacjaPlanow1 = new WinBud¿et_3.PanelRealizacjaPlanow();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.tabControlAnalizyDanych = new System.Windows.Forms.TabControl();
      this.tabPageKategorie = new System.Windows.Forms.TabPage();
      this.panelKategorii1 = new WinBud¿et_3.PanelKategorii();
      this.tabPageChronologii = new System.Windows.Forms.TabPage();
      this.panelChronologii1 = new WinBud¿et_3.PanelChronologii();
      this.tabPage4 = new System.Windows.Forms.TabPage();
      this.button1 = new System.Windows.Forms.Button();
      this.tabControlGlowny.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabControlWprowadzanieDanych.SuspendLayout();
      this.tabPage5.SuspendLayout();
      this.tabPage6.SuspendLayout();
      this.tabPage7.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPage8.SuspendLayout();
      this.tabPage9.SuspendLayout();
      this.tabPage3.SuspendLayout();
      this.tabControlAnalizyDanych.SuspendLayout();
      this.tabPageKategorie.SuspendLayout();
      this.tabPageChronologii.SuspendLayout();
      this.tabPage4.SuspendLayout();
      this.SuspendLayout();
      // 
      // mainMenu
      // 
      this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                             this.menuItemFile,
                                                                             this.menuItemHelp});
      // 
      // menuItemFile
      // 
      this.menuItemFile.Index = 0;
      this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                 this.menuItemNew,
                                                                                 this.menuItemLoad,
                                                                                 this.menuItemSave,
                                                                                 this.menuItemSaveAs,
                                                                                 this.menuItem6,
                                                                                 this.menuItemExit});
      this.menuItemFile.Text = "File";
      // 
      // menuItemNew
      // 
      this.menuItemNew.Index = 0;
      this.menuItemNew.Text = "New";
      this.menuItemNew.Click += new System.EventHandler(this.menuItemNew_Click);
      // 
      // menuItemLoad
      // 
      this.menuItemLoad.Index = 1;
      this.menuItemLoad.Text = "Load";
      this.menuItemLoad.Click += new System.EventHandler(this.menuItemLoad_Click);
      // 
      // menuItemSave
      // 
      this.menuItemSave.Index = 2;
      this.menuItemSave.Text = "Save";
      this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
      // 
      // menuItemSaveAs
      // 
      this.menuItemSaveAs.Index = 3;
      this.menuItemSaveAs.Text = "Save as...";
      this.menuItemSaveAs.Click += new System.EventHandler(this.menuItemSaveAs_Click);
      // 
      // menuItem6
      // 
      this.menuItem6.Index = 4;
      this.menuItem6.Text = "-";
      // 
      // menuItemExit
      // 
      this.menuItemExit.Index = 5;
      this.menuItemExit.Text = "Exit";
      this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
      // 
      // menuItemHelp
      // 
      this.menuItemHelp.Index = 1;
      this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                 this.menuItemAbout});
      this.menuItemHelp.Text = "Help";
      // 
      // menuItemAbout
      // 
      this.menuItemAbout.Index = 0;
      this.menuItemAbout.Text = "About";
      this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
      // 
      // saveFileDialog
      // 
      this.saveFileDialog.FileName = "doc1";
      // 
      // debugPanel
      // 
      this.debugPanel.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.debugPanel.Location = new System.Drawing.Point(8, 24);
      this.debugPanel.Name = "debugPanel";
      this.debugPanel.Size = new System.Drawing.Size(752, 400);
      this.debugPanel.TabIndex = 0;
      this.debugPanel.Text = "richTextBox1";
      // 
      // tabControlGlowny
      // 
      this.tabControlGlowny.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.tabControlGlowny.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                   this.tabPage1,
                                                                                   this.tabPage2,
                                                                                   this.tabPage3,
                                                                                   this.tabPage4});
      this.tabControlGlowny.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
      this.tabControlGlowny.Location = new System.Drawing.Point(8, 8);
      this.tabControlGlowny.Name = "tabControlGlowny";
      this.tabControlGlowny.SelectedIndex = 0;
      this.tabControlGlowny.Size = new System.Drawing.Size(776, 488);
      this.tabControlGlowny.TabIndex = 2;
      this.tabControlGlowny.SelectedIndexChanged += new System.EventHandler(this.tabControlGlowny_SelectedIndexChanged);
      // 
      // tabPage1
      // 
      this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
      this.tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.tabControlWprowadzanieDanych});
      this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
      this.tabPage1.Location = new System.Drawing.Point(4, 25);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Size = new System.Drawing.Size(768, 459);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Wprowadzanie danych";
      // 
      // tabControlWprowadzanieDanych
      // 
      this.tabControlWprowadzanieDanych.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.tabControlWprowadzanieDanych.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                               this.tabPage5,
                                                                                               this.tabPage6,
                                                                                               this.tabPage7});
      this.tabControlWprowadzanieDanych.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
      this.tabControlWprowadzanieDanych.Name = "tabControlWprowadzanieDanych";
      this.tabControlWprowadzanieDanych.SelectedIndex = 0;
      this.tabControlWprowadzanieDanych.Size = new System.Drawing.Size(768, 456);
      this.tabControlWprowadzanieDanych.TabIndex = 0;
      this.tabControlWprowadzanieDanych.SelectedIndexChanged += new System.EventHandler(this.tabControlWprowadzanieDanych_SelectedIndexChanged);
      // 
      // tabPage5
      // 
      this.tabPage5.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.gridChronWydatki,
                                                                           this.gridChronoWplywy});
      this.tabPage5.ForeColor = System.Drawing.SystemColors.ControlText;
      this.tabPage5.Location = new System.Drawing.Point(4, 25);
      this.tabPage5.Name = "tabPage5";
      this.tabPage5.Size = new System.Drawing.Size(760, 427);
      this.tabPage5.TabIndex = 0;
      this.tabPage5.Text = "Wplywy i wydatki";
      this.tabPage5.Resize += new System.EventHandler(this.tabPage5_Resize);
      // 
      // gridChronWydatki
      // 
      this.gridChronWydatki.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.gridChronWydatki.CaptionBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.gridChronWydatki.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
      this.gridChronWydatki.CaptionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.gridChronWydatki.CaptionText = "Wydatki - lista chronologiczna";
      this.gridChronWydatki.Location = new System.Drawing.Point(16, 232);
      this.gridChronWydatki.MainWindow = null;
      this.gridChronWydatki.Name = "gridChronWydatki";
      this.gridChronWydatki.Size = new System.Drawing.Size(744, 192);
      this.gridChronWydatki.TabIndex = 1;
      // 
      // gridChronoWplywy
      // 
      this.gridChronoWplywy.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.gridChronoWplywy.CaptionBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.gridChronoWplywy.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
      this.gridChronoWplywy.CaptionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.gridChronoWplywy.CaptionText = "Wp³ywy - lista chronologiczna";
      this.gridChronoWplywy.Location = new System.Drawing.Point(8, 8);
      this.gridChronoWplywy.MainWindow = null;
      this.gridChronoWplywy.Name = "gridChronoWplywy";
      this.gridChronoWplywy.Size = new System.Drawing.Size(752, 224);
      this.gridChronoWplywy.TabIndex = 0;
      // 
      // tabPage6
      // 
      this.tabPage6.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.gridOperacjiMieszkowych});
      this.tabPage6.ForeColor = System.Drawing.Color.Red;
      this.tabPage6.Location = new System.Drawing.Point(4, 25);
      this.tabPage6.Name = "tabPage6";
      this.tabPage6.Size = new System.Drawing.Size(760, 427);
      this.tabPage6.TabIndex = 1;
      this.tabPage6.Text = "Operacje mieszkowe";
      // 
      // gridOperacjiMieszkowych
      // 
      this.gridOperacjiMieszkowych.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.gridOperacjiMieszkowych.CaptionBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.gridOperacjiMieszkowych.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
      this.gridOperacjiMieszkowych.CaptionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.gridOperacjiMieszkowych.CaptionText = "Operacje mieszkowe";
      this.gridOperacjiMieszkowych.Location = new System.Drawing.Point(8, 0);
      this.gridOperacjiMieszkowych.MainWindow = null;
      this.gridOperacjiMieszkowych.Name = "gridOperacjiMieszkowych";
      this.gridOperacjiMieszkowych.Size = new System.Drawing.Size(744, 424);
      this.gridOperacjiMieszkowych.TabIndex = 0;
      // 
      // tabPage7
      // 
      this.tabPage7.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.gridPlanyWydatkow,
                                                                           this.gridPlanyWplywow});
      this.tabPage7.Location = new System.Drawing.Point(4, 25);
      this.tabPage7.Name = "tabPage7";
      this.tabPage7.Size = new System.Drawing.Size(760, 427);
      this.tabPage7.TabIndex = 2;
      this.tabPage7.Text = "Plany bud¿etowe";
      this.tabPage7.Resize += new System.EventHandler(this.tabPage7_Resize);
      // 
      // gridPlanyWydatkow
      // 
      this.gridPlanyWydatkow.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.gridPlanyWydatkow.CaptionBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.gridPlanyWydatkow.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
      this.gridPlanyWydatkow.CaptionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.gridPlanyWydatkow.CaptionText = "Planowane wydatki";
      this.gridPlanyWydatkow.Location = new System.Drawing.Point(8, 224);
      this.gridPlanyWydatkow.MainWindow = null;
      this.gridPlanyWydatkow.Name = "gridPlanyWydatkow";
      this.gridPlanyWydatkow.Size = new System.Drawing.Size(712, 184);
      this.gridPlanyWydatkow.TabIndex = 1;
      // 
      // gridPlanyWplywow
      // 
      this.gridPlanyWplywow.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.gridPlanyWplywow.CaptionBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.gridPlanyWplywow.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
      this.gridPlanyWplywow.CaptionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.gridPlanyWplywow.CaptionText = "Planowane wp³ywy";
      this.gridPlanyWplywow.Location = new System.Drawing.Point(8, 8);
      this.gridPlanyWplywow.MainWindow = null;
      this.gridPlanyWplywow.Name = "gridPlanyWplywow";
      this.gridPlanyWplywow.Size = new System.Drawing.Size(720, 208);
      this.gridPlanyWplywow.TabIndex = 0;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.tabControl1});
      this.tabPage2.Location = new System.Drawing.Point(4, 25);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Size = new System.Drawing.Size(768, 459);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Sytuacja finansowa";
      // 
      // tabControl1
      // 
      this.tabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                              this.tabPage8,
                                                                              this.tabPage9});
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(768, 456);
      this.tabControl1.TabIndex = 0;
      // 
      // tabPage8
      // 
      this.tabPage8.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.panelMieszkiBilans1});
      this.tabPage8.Location = new System.Drawing.Point(4, 25);
      this.tabPage8.Name = "tabPage8";
      this.tabPage8.Size = new System.Drawing.Size(760, 427);
      this.tabPage8.TabIndex = 0;
      this.tabPage8.Text = "Stan mieszków i bilans miesiêczny";
      // 
      // panelMieszkiBilans1
      // 
      this.panelMieszkiBilans1.Analizator = null;
      this.panelMieszkiBilans1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.panelMieszkiBilans1.Name = "panelMieszkiBilans1";
      this.panelMieszkiBilans1.Size = new System.Drawing.Size(760, 424);
      this.panelMieszkiBilans1.TabIndex = 0;
      this.panelMieszkiBilans1.WyroznijKategorieZPoprzedniegoMiesiaca = true;
      // 
      // tabPage9
      // 
      this.tabPage9.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.panelRealizacjaPlanow1});
      this.tabPage9.Location = new System.Drawing.Point(4, 25);
      this.tabPage9.Name = "tabPage9";
      this.tabPage9.Size = new System.Drawing.Size(760, 427);
      this.tabPage9.TabIndex = 1;
      this.tabPage9.Text = "Realizacja planów bud¿etowych";
      // 
      // panelRealizacjaPlanow1
      // 
      this.panelRealizacjaPlanow1.Analizator = null;
      this.panelRealizacjaPlanow1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.panelRealizacjaPlanow1.Name = "panelRealizacjaPlanow1";
      this.panelRealizacjaPlanow1.Size = new System.Drawing.Size(760, 424);
      this.panelRealizacjaPlanow1.TabIndex = 0;
      // 
      // tabPage3
      // 
      this.tabPage3.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.tabControlAnalizyDanych});
      this.tabPage3.Location = new System.Drawing.Point(4, 25);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Size = new System.Drawing.Size(768, 459);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "Analiza danych";
      // 
      // tabControlAnalizyDanych
      // 
      this.tabControlAnalizyDanych.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.tabControlAnalizyDanych.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                          this.tabPageKategorie,
                                                                                          this.tabPageChronologii});
      this.tabControlAnalizyDanych.Name = "tabControlAnalizyDanych";
      this.tabControlAnalizyDanych.SelectedIndex = 0;
      this.tabControlAnalizyDanych.Size = new System.Drawing.Size(768, 456);
      this.tabControlAnalizyDanych.TabIndex = 0;
      // 
      // tabPageKategorie
      // 
      this.tabPageKategorie.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                   this.panelKategorii1});
      this.tabPageKategorie.Location = new System.Drawing.Point(4, 25);
      this.tabPageKategorie.Name = "tabPageKategorie";
      this.tabPageKategorie.Size = new System.Drawing.Size(760, 427);
      this.tabPageKategorie.TabIndex = 1;
      this.tabPageKategorie.Text = "Statystyka kategorii";
      // 
      // panelKategorii1
      // 
      this.panelKategorii1.Analizator = null;
      this.panelKategorii1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.panelKategorii1.Name = "panelKategorii1";
      this.panelKategorii1.Size = new System.Drawing.Size(760, 424);
      this.panelKategorii1.TabIndex = 0;
      this.panelKategorii1.Tulkit = null;
      // 
      // tabPageChronologii
      // 
      this.tabPageChronologii.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                     this.panelChronologii1});
      this.tabPageChronologii.ForeColor = System.Drawing.SystemColors.Desktop;
      this.tabPageChronologii.Location = new System.Drawing.Point(4, 25);
      this.tabPageChronologii.Name = "tabPageChronologii";
      this.tabPageChronologii.Size = new System.Drawing.Size(760, 427);
      this.tabPageChronologii.TabIndex = 0;
      this.tabPageChronologii.Text = "Chronologia";
      // 
      // panelChronologii1
      // 
      this.panelChronologii1.Analizator = null;
      this.panelChronologii1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.panelChronologii1.Name = "panelChronologii1";
      this.panelChronologii1.Size = new System.Drawing.Size(760, 424);
      this.panelChronologii1.TabIndex = 0;
      this.panelChronologii1.Tulkit = null;
      // 
      // tabPage4
      // 
      this.tabPage4.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.button1,
                                                                           this.debugPanel});
      this.tabPage4.Location = new System.Drawing.Point(4, 25);
      this.tabPage4.Name = "tabPage4";
      this.tabPage4.Size = new System.Drawing.Size(768, 459);
      this.tabPage4.TabIndex = 3;
      this.tabPage4.Text = "Diagnostyka";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(8, 432);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(112, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "Co jest grane?";
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // MainWindow
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
      this.ClientSize = new System.Drawing.Size(784, 495);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.tabControlGlowny});
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Menu = this.mainMenu;
      this.Name = "MainWindow";
      this.Text = "MainWindow";
      this.Closing += new System.ComponentModel.CancelEventHandler(this.MainWindow_Closing);
      this.Load += new System.EventHandler(this.MainWindow_Load);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainWindow_Paint);
      this.tabControlGlowny.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabControlWprowadzanieDanych.ResumeLayout(false);
      this.tabPage5.ResumeLayout(false);
      this.tabPage6.ResumeLayout(false);
      this.tabPage7.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.tabControl1.ResumeLayout(false);
      this.tabPage8.ResumeLayout(false);
      this.tabPage9.ResumeLayout(false);
      this.tabPage3.ResumeLayout(false);
      this.tabControlAnalizyDanych.ResumeLayout(false);
      this.tabPageKategorie.ResumeLayout(false);
      this.tabPageChronologii.ResumeLayout(false);
      this.tabPage4.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		#endregion
		
		/// <summary>
		/// Metoda wywo³ywana przez ComboStyle po zmianie danych w tabeli w celu
		/// przebudowania list kategorii i pozycji
		/// </summary>
		public void przeskanujWartosci()
		{
      tulkit.debug("MainWindow.przeskanujWartosci() "+DateTime.Now.ToShortTimeString());
      refresh();		
		}

    #region menu i operacje IO
    /// <summary>
    /// Metoda obs³ugi menu File -> New
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void menuItemNew_Click(object sender, System.EventArgs e)
    { nowaBaza(); refresh(); }
    private void menuItemLoad_Click(object sender, System.EventArgs e)
    { otworzBaze(); refresh(); }
    private void menuItemSave_Click(object sender, System.EventArgs e)
    { zapiszBaze(); refresh(); }
    private void menuItemSaveAs_Click(object sender, System.EventArgs e)
    { zapiszBazeJako(); refresh(); }
    private void menuItemExit_Click(object sender, System.EventArgs e)
    { koniecPracy(); refresh(); }

    private void menuItemAbout_Click(object sender, System.EventArgs e)
    {
      MessageBox.Show("WinBud¿et wersja 3.0\nWritten by BackSlash of Bezsensial 2004","About");
      refresh();
    }

    private bool nowaBaza()
    {
      if (zamknijBaze())
      {
        budzet = new DataModule();
        budzet.Tulkit = this.tulkit;
        podlaczDataSety();
        tulkit.debug("  Utworzono nowa baze");
        return true;
      }
      else tulkit.debug ("  Zrezygnowano z utworzenia nowej bazy.");
      return false;
    }

    private bool zapiszBaze()
    {
      bool zapisany = false;
      tulkit.debug ("Zapisz baze");
      if (budzet==null) return false;
      if (!budzet.IsOpen) return false;
      if (!budzet.IsModified) return false;
      analizator.przeprowadzAnalize(budzet.ZestawDanych);
      if ((budzet.NazwaPliku!=null)&&(!budzet.NazwaPliku.Equals("")))
        {
          tulkit.debug ("  przystepuje do zapisywania pod dotychczasowa nazwa: "+budzet.NazwaPliku);
          zapisany = budzet.saveData(budzet.NazwaPliku);
        }
        else
        {
          tulkit.debug ("  przystepuje do zapisywania pod nowa nazwa");
          zapisany = zapiszBazeJako();
        }
      return zapisany;
    }

    private bool zapiszBazeJako()
    {
      if (budzet==null) return false;
      if (!budzet.IsOpen) return false;
      analizator.przeprowadzAnalize(budzet.ZestawDanych);
      tulkit.debug ("  zapisz jako...");
      saveFileDialog.Filter = "Pliki budzetowe (*.bu)|*.bu|Wszystkie pliki (*.*)|*.*"  ;
      saveFileDialog.FilterIndex = 1 ;
      saveFileDialog.RestoreDirectory = true ;
      if(saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        tulkit.debug ("  wywoluje metode save");
        budzet.NazwaPliku = saveFileDialog.FileName;
        return budzet.saveData(budzet.NazwaPliku);
      }
      else tulkit.debug ("  zrezygnowano z save as");
     
      return false;
    }


    private bool otworzBaze()
    {
      tulkit.debug ("Otworz baze");
      if (zamknijBaze())
      {
        openFileDialog.Filter = "Pliki budzetowe (*.bu)|*.bu|Wszystkie pliki (*.*)|*.*"  ;
        openFileDialog.FilterIndex = 1 ;
        openFileDialog.RestoreDirectory = true ;

        if(openFileDialog.ShowDialog() == DialogResult.OK)
        {
          tulkit.debug ("  wywoluje metode load");
          budzet = new DataModule();
          budzet.Tulkit = this.tulkit;
          bool poszlo = budzet.loadData(openFileDialog.FileName);
          if (poszlo) podlaczDataSety();          
          return poszlo;
        }
        else 
        {
          MessageBox.Show("Ej, no bez sensu. Zrezygnowaleœ z otworzenia drugiej bazy, a pierwsz¹ ju¿ zamkn¹lem.","Warambaram!");
          tulkit.debug ("  zrezygnowano z otworzenia nowej bazy");
        }
      }
      return false;
    }


    private bool zamknijBaze()
    {
      if (budzet==null) return true;
      if (!budzet.IsOpen) return true;
      if (!budzet.IsModified) return true;
      switch (tulkit.dialogTakNieAnuluj("Aktualnie otwarta baza zostala zmodyfikowana. Czy chcesz zachowac zmiany?"))
      {
        case 0 : 
        {
          if (zapiszBaze()) 
          { 
            budzet = null;
            return true;  
          } 
          else return false;
        }
        case 1 : 
        {
          budzet = null;
          return true;
        };
        default : return false;
      }
    }

    private bool koniecPracy()
    {
      bool val = zamknijBaze();
      if (val) Application.Exit();
      return val;
    }
    #endregion
    
    
    private void updateCaption()
    {
      string caption = "WinBud¿et 3 by BackSlash of Bezsensial (2004) "+budzet.Nazwa;
      if (budzet.IsModified) this.Text=caption+"*";else this.Text=caption;
      gridPlanyWplywow.CaptionText="Planowane wp³ywy: "+string.Format("{0,12:C}",analizator.planWplywow());
      gridPlanyWydatkow.CaptionText="Planowane wydatki: "+string.Format("{0,12:C}",analizator.planWydatkow());
    }    
    

    private void MainWindow_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
      updateCaption();
    }

    private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if (koniecPracy()==false) e.Cancel=true;      
    }

    private void button1_Click(object sender, System.EventArgs e)
    {
      tulkit.DebugTextBox.Clear();
      tulkit.debug("Status programu: "+DateTime.Now.ToLongTimeString());
      if (budzet==null)
      {
        tulkit.debug("Baza nie istnieje (budzet==null). Koniec raportu.");
        return;
      }
      
      tulkit.debug("Informacje o bazie danych:");
      if (budzet.IsOpen) tulkit.debug("- Baza jest otwarta.");
        else tulkit.debug("- Baza jest zamkniêta.");
      if (budzet.IsModified) tulkit.debug("- Baza jest zmodyfikowana.");
        else tulkit.debug("- Baza nie jest zmodyfikowana.");
      tulkit.debug("- nazwa: "+budzet.Nazwa);
      tulkit.debug("- nazwa pliku: "+budzet.NazwaPliku);
      tulkit.debug("- data utworzenia: "+budzet.Created.ToShortDateString());
      tulkit.debug("- ostatnio tkniêta: "+budzet.LastAccessed.ToShortDateString());
      tulkit.debug("- ostatnio modyfikowana: "+budzet.LastModivied.ToShortDateString());
      tulkit.debug("- ostatnio zapisana: "+budzet.LastSaved.ToShortDateString());
    }

    private void odswiezAnalize()
    {
      if (!budzet.Analyzed) analizator.przeprowadzAnalize(budzet.ZestawDanych);
    }

    private void tabControlWprowadzanieDanych_SelectedIndexChanged(object sender, System.EventArgs e)
    { refresh(); }
    
    private void tabControlGlowny_SelectedIndexChanged(object sender, System.EventArgs e)
    { refresh();  }

    private void tabPage5_Resize(object sender, System.EventArgs e)
    {
      verticalBox1.doResize();
    }

    private void tabPage7_Resize(object sender, System.EventArgs e)
    {
      verticalBox2.doResize();
    }

    private void MainWindow_Load(object sender, System.EventArgs e)
    {
    
    }
	}
}
