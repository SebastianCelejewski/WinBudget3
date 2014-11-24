using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WinBud¿et_3
{
	/// <summary>
	/// Summary description for TableGrid.
	/// </summary>
	public class GridChrono : UserControl
	{
	  private MainWindow mainWindow;
	  private bool mojeStyle;
	  
	  public MainWindow MainWindow
	  {
	    get { return this.mainWindow; }
	    set 
	    { 
	      this.mainWindow = value; 
        if (stylComboMieszek!=null) stylComboMieszek.MainWindow = this.mainWindow;
        if (stylComboKategoria!=null) stylComboKategoria.MainWindow = this.mainWindow;
        if (stylComboPozycja!=null) stylComboPozycja.MainWindow = this.mainWindow;
	    }
	  }

    public string CaptionText
    {
      get { return this.dataGrid.CaptionText; }
      set { this.dataGrid.CaptionText = value; }
    }
    
    public Font CaptionFont
    {
      get { return this.dataGrid.CaptionFont; }
      set { this.dataGrid.CaptionFont = value; }
    }
    
    public Color CaptionForeColor
    {
      get { return this.dataGrid.CaptionForeColor; }
      set { this.dataGrid.CaptionForeColor = value; }
    }
    
    public Color CaptionBackColor
    {
      get { return this.dataGrid.CaptionBackColor; }
      set { this.dataGrid.CaptionBackColor = value; }
    }
    
	  private ArrayList listaMieszkow = new ArrayList();
	  private ArrayList listaKategorii = new ArrayList();
	  private ArrayList listaPozycji = new ArrayList();
	
    private System.Windows.Forms.DataGrid dataGrid;
    private System.Data.DataSet dataSet;
    private System.Data.DataTable dataTable;
    private System.Windows.Forms.DataGridTableStyle dataGridTableStyle;
    private System.Data.DataColumn dataColumn1;
    private System.Data.DataColumn dataColumn3;
    private System.Data.DataColumn dataColumn4;
    private System.Data.DataColumn dataColumn5;
    private System.Data.DataColumn dataColumn6;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;

    private ComboStyle stylComboMieszek;
    private ComboStyle stylComboKategoria;
    private ComboStyle stylComboPozycja;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GridChrono()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			mojeStyle = false;
			inicjujFajoweStyle();
      setupLayout();
		}

    private void inicjujFajoweStyle()
    {
      stylComboMieszek = new ComboStyle(listaMieszkow);
      stylComboKategoria = new ComboStyle(listaKategorii);
      stylComboPozycja = new ComboStyle(listaPozycji);
      
      stylComboMieszek.HeaderText = "Mieszek";
      stylComboMieszek.MappingName = "Mieszek";
      stylComboKategoria.HeaderText = "Kategoria";
      stylComboKategoria.MappingName = "Kategoria";
      stylComboPozycja.HeaderText = "Pozycja";
      stylComboPozycja.MappingName = "Pozycja";

      dataGridTableStyle.GridColumnStyles.Clear();
      dataGridTableStyle.GridColumnStyles.Add(dataGridTextBoxColumn1);
      dataGridTableStyle.GridColumnStyles.Add(stylComboMieszek);
      dataGridTableStyle.GridColumnStyles.Add(stylComboKategoria);
      dataGridTableStyle.GridColumnStyles.Add(stylComboPozycja);
      dataGridTableStyle.GridColumnStyles.Add(dataGridTextBoxColumn6);
      
      mojeStyle = true;
    }

		/// <summary> 
		/// Clean up any resources being used.
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.dataGrid = new System.Windows.Forms.DataGrid();
      this.dataTable = new System.Data.DataTable();
      this.dataColumn1 = new System.Data.DataColumn();
      this.dataColumn3 = new System.Data.DataColumn();
      this.dataColumn4 = new System.Data.DataColumn();
      this.dataColumn5 = new System.Data.DataColumn();
      this.dataColumn6 = new System.Data.DataColumn();
      this.dataGridTableStyle = new System.Windows.Forms.DataGridTableStyle();
      this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
      this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
      this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
      this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
      this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
      this.dataSet = new System.Data.DataSet();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
      this.SuspendLayout();
      // 
      // dataGrid
      // 
      this.dataGrid.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.dataGrid.DataMember = "";
      this.dataGrid.DataSource = this.dataTable;
      this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.Size = new System.Drawing.Size(352, 312);
      this.dataGrid.TabIndex = 0;
      this.dataGrid.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
                                                                                         this.dataGridTableStyle});
      // 
      // dataTable
      // 
      this.dataTable.Columns.AddRange(new System.Data.DataColumn[] {
                                                                     this.dataColumn1,
                                                                     this.dataColumn3,
                                                                     this.dataColumn4,
                                                                     this.dataColumn5,
                                                                     this.dataColumn6});
      this.dataTable.TableName = "Table";
      // 
      // dataColumn1
      // 
      this.dataColumn1.ColumnName = "Data";
      this.dataColumn1.DataType = typeof(System.DateTime);
      // 
      // dataColumn3
      // 
      this.dataColumn3.ColumnName = "Mieszek";
      // 
      // dataColumn4
      // 
      this.dataColumn4.ColumnName = "Kategoria";
      // 
      // dataColumn5
      // 
      this.dataColumn5.ColumnName = "Pozycja";
      // 
      // dataColumn6
      // 
      this.dataColumn6.ColumnName = "Kwota";
      this.dataColumn6.DataType = typeof(System.Double);
      // 
      // dataGridTableStyle
      // 
      this.dataGridTableStyle.DataGrid = this.dataGrid;
      this.dataGridTableStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
                                                                                                         this.dataGridTextBoxColumn1,
                                                                                                         this.dataGridTextBoxColumn3,
                                                                                                         this.dataGridTextBoxColumn4,
                                                                                                         this.dataGridTextBoxColumn5,
                                                                                                         this.dataGridTextBoxColumn6});
      this.dataGridTableStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGridTableStyle.MappingName = "Table";
      // 
      // dataGridTextBoxColumn1
      // 
      this.dataGridTextBoxColumn1.Format = "";
      this.dataGridTextBoxColumn1.FormatInfo = null;
      this.dataGridTextBoxColumn1.HeaderText = "Data";
      this.dataGridTextBoxColumn1.MappingName = "Data";
      this.dataGridTextBoxColumn1.Width = 75;
      // 
      // dataGridTextBoxColumn3
      // 
      this.dataGridTextBoxColumn3.Format = "";
      this.dataGridTextBoxColumn3.FormatInfo = null;
      this.dataGridTextBoxColumn3.HeaderText = "Mieszek";
      this.dataGridTextBoxColumn3.MappingName = "Mieszek";
      this.dataGridTextBoxColumn3.Width = 75;
      // 
      // dataGridTextBoxColumn4
      // 
      this.dataGridTextBoxColumn4.Format = "";
      this.dataGridTextBoxColumn4.FormatInfo = null;
      this.dataGridTextBoxColumn4.HeaderText = "Kategoria";
      this.dataGridTextBoxColumn4.MappingName = "Kategoria";
      this.dataGridTextBoxColumn4.Width = 75;
      // 
      // dataGridTextBoxColumn5
      // 
      this.dataGridTextBoxColumn5.Format = "";
      this.dataGridTextBoxColumn5.FormatInfo = null;
      this.dataGridTextBoxColumn5.HeaderText = "Pozycja";
      this.dataGridTextBoxColumn5.MappingName = "Pozycja";
      this.dataGridTextBoxColumn5.Width = 75;
      // 
      // dataGridTextBoxColumn6
      // 
      this.dataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
      this.dataGridTextBoxColumn6.Format = "0.00 z³";
      this.dataGridTextBoxColumn6.FormatInfo = null;
      this.dataGridTextBoxColumn6.HeaderText = "Kwota";
      this.dataGridTextBoxColumn6.MappingName = "Kwota";
      this.dataGridTextBoxColumn6.Width = 75;
      // 
      // dataSet
      // 
      this.dataSet.DataSetName = "NewDataSet";
      this.dataSet.Locale = new System.Globalization.CultureInfo("pl-PL");
      this.dataSet.Tables.AddRange(new System.Data.DataTable[] {
                                                                 this.dataTable});
      // 
      // GridChrono
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.dataGrid});
      this.Name = "GridChrono";
      this.Size = new System.Drawing.Size(352, 312);
      this.Resize += new System.EventHandler(this.GridChrono_Resize);
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
      this.ResumeLayout(false);

    }
		#endregion
		
    public void podlaczDataTable(DataTable dataTable)
    {
      try
      {
        this.dataGridTableStyle.MappingName=dataTable.TableName;
        this.dataTable = dataTable;
        this.dataGrid.DataSource=dataTable;
        this.ContextMenu = new DataGridContextMenu(dataTable);
      } 
      catch (Exception ex)
      {
        MessageBox.Show("Nie mogê podlaczyæ:\n"+ex.Message+"\n"+ex.StackTrace);
      }
    }
    
    private void setupLayout()
    {
      int szer = this.Width;
      int szerLewy = this.dataGridTableStyle.RowHeaderWidth;
      int szerPrawy = 25;
      szer-=(szerLewy+szerPrawy);
      dataGridTextBoxColumn1.Width = (int) (szer*0.15);
      if (mojeStyle)
      {
        stylComboMieszek.Width = (int) (szer*0.20);
        stylComboKategoria.Width = (int) (szer*0.25);
        stylComboPozycja.Width = (int) (szer*0.25);
      }
      else
      {
        dataGridTextBoxColumn3.Width = (int) (szer*0.20);
        dataGridTextBoxColumn4.Width = (int) (szer*0.25);
        dataGridTextBoxColumn5.Width = (int) (szer*0.25);
      }
      dataGridTextBoxColumn6.Width = (int) (szer*0.15);
    }

    private void GridChrono_Resize(object sender, System.EventArgs e)
    {
      setupLayout();
    }
    
    public void wpiszListy(ICollection mieszki, ICollection kategorie, ICollection pozycje)
    {
      this.listaMieszkow.Clear();
      this.listaKategorii.Clear();
      this.listaPozycji.Clear();
      
      this.listaMieszkow.AddRange(mieszki);
      this.listaKategorii.AddRange(kategorie);
      this.listaPozycji.AddRange(pozycje);
      
      this.stylComboKategoria.wpiszListe(listaKategorii);
      this.stylComboMieszek.wpiszListe(listaMieszkow);
      this.stylComboPozycja.wpiszListe(listaPozycji);
    }
	}
}
