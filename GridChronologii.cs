using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WinBud¿et_3
{
	/// <summary>
	/// Summary description for GridChronologii.
	/// </summary>
	public class GridChronologii : System.Windows.Forms.UserControl
	{
	  private Analizator analizator;	
	  private Tulkit tulkit;
	  private Hashtable numeryKategorii;
	  private double[,] wartosciTabeli;
	  private bool jestemWplywem;
	
    private System.Windows.Forms.DataGrid dataGrid;
    private System.Data.DataSet dataSet;
    private System.Data.DataView dataView;
    private System.Data.DataTable dataTable;
    private System.Data.DataColumn dataColumn1;
    
    private DataGridContextMenu contextMenu;
    private System.Windows.Forms.DataGridTableStyle dataGridTableStyle;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		
		public Tulkit Tulkit
		{
		  get { return this.tulkit; }
		  set { this.tulkit = value; }
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
	
    public Analizator Analizator
    {
      get { return this.analizator; }
      set { this.analizator = value; }
    }		
    
    public bool JestemWplywem
    {
      get { return this.jestemWplywem; }
      set { this.jestemWplywem = value; }
    }

		public GridChronologii()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			numeryKategorii = new Hashtable();
			contextMenu = new DataGridContextMenu(dataTable);
			this.ContextMenu = contextMenu;
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
      this.dataView = new System.Data.DataView();
      this.dataTable = new System.Data.DataTable();
      this.dataColumn1 = new System.Data.DataColumn();
      this.dataGridTableStyle = new System.Windows.Forms.DataGridTableStyle();
      this.dataGridTextBoxColumn = new System.Windows.Forms.DataGridTextBoxColumn();
      this.dataSet = new System.Data.DataSet();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
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
      this.dataGrid.DataSource = this.dataView;
      this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGrid.Location = new System.Drawing.Point(8, 0);
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.Size = new System.Drawing.Size(512, 456);
      this.dataGrid.TabIndex = 0;
      this.dataGrid.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
                                                                                         this.dataGridTableStyle});
      this.dataGrid.Enter += new System.EventHandler(this.dataGrid_Enter);
      // 
      // dataView
      // 
      this.dataView.Table = this.dataTable;
      // 
      // dataTable
      // 
      this.dataTable.Columns.AddRange(new System.Data.DataColumn[] {
                                                                     this.dataColumn1});
      this.dataTable.TableName = "Table";
      // 
      // dataColumn1
      // 
      this.dataColumn1.ColumnName = "Column1";
      // 
      // dataGridTableStyle
      // 
      this.dataGridTableStyle.DataGrid = this.dataGrid;
      this.dataGridTableStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
                                                                                                         this.dataGridTextBoxColumn});
      this.dataGridTableStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGridTableStyle.MappingName = "Table";
      // 
      // dataGridTextBoxColumn
      // 
      this.dataGridTextBoxColumn.Format = "";
      this.dataGridTextBoxColumn.FormatInfo = null;
      this.dataGridTextBoxColumn.HeaderText = "Kliknij aby odœwie¿yæ dane";
      this.dataGridTextBoxColumn.MappingName = "Column1";
      this.dataGridTextBoxColumn.Width = 200;
      // 
      // dataSet
      // 
      this.dataSet.DataSetName = "NewDataSet";
      this.dataSet.Locale = new System.Globalization.CultureInfo("pl-PL");
      this.dataSet.Tables.AddRange(new System.Data.DataTable[] {
                                                                 this.dataTable});
      // 
      // GridChronologii
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.dataGrid});
      this.Name = "GridChronologii";
      this.Size = new System.Drawing.Size(512, 456);
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
      this.ResumeLayout(false);

    }
		#endregion
		
		public void refresh()
	  {
      if (analizator==null) return;
      if (analizator.listaKategoriiWplywow()==null) return;
      numeryKategorii.Clear();
      dataTable.Columns.Clear();
      dataTable.Columns.Add(new DataColumn("Data",typeof(System.DateTime)));
      dataTable.Columns.Add(new DataColumn("Suma",typeof(System.Double)));
      dataGridTableStyle.GridColumnStyles.Clear();
      dataGridTableStyle.MappingName=dataTable.TableName;
      DataGridTextBoxColumn stylDaty = new DataGridTextBoxColumn();
      DataGridTextBoxColumn stylSumy = new DataGridTextBoxColumn();
      stylDaty.MappingName="Data";
      stylDaty.HeaderText="Data";
      stylSumy.MappingName="Suma";
      stylSumy.HeaderText="Suma";
      stylSumy.Format="0.00 z³";
      stylSumy.Alignment=HorizontalAlignment.Right;
      dataGridTableStyle.GridColumnStyles.Add(stylDaty);
      dataGridTableStyle.GridColumnStyles.Add(stylSumy);
      ICollection listaKategorii;
      Hashtable kategorie;
      if (jestemWplywem) 
      { 
        listaKategorii = analizator.listaKategoriiWplywow();
        kategorie = analizator.pobierzAnalizeKategoriiWplywow();
      }
      else
      {
        listaKategorii = analizator.listaKategoriiWydatkow();
        kategorie = analizator.pobierzAnalizeKategoriiWydatkow();
      }   

      ProgressForm pf = new ProgressForm();
      pf.Minimum = 0;
      pf.Maximum = listaKategorii.Count*2;
      pf.Value = 0;
      pf.Show();
      pf.TopMost = true;
                    
      DataColumn dc;
      if (jestemWplywem) pf.LabelText="Wczytywanie kategorii wp³ywów";
                    else pf.LabelText="Wczytywanie kategorii wydatków";
      foreach (String nazwaKategorii in listaKategorii)
      {
        try
        {
          numeryKategorii.Add(nazwaKategorii,numeryKategorii.Count);
          dc = new DataColumn(nazwaKategorii,typeof(System.Double));
          DataGridTextBoxColumn styl = new DataGridTextBoxColumn();
          styl.MappingName=nazwaKategorii;
          styl.HeaderText=nazwaKategorii;
          styl.Format="0.00 z³";
          styl.Alignment=HorizontalAlignment.Right;
          dataGridTableStyle.GridColumnStyles.Add(styl);
          dataTable.Columns.Add(dc);
          pf.Value++;
        } catch (Exception ex)
        {
          MessageBox.Show("Nazwa kategorii = "+nazwaKategorii+"\nException: "+ex.Message+"\nStack trace:"+ex.StackTrace);
        }
      }
      
      wartosciTabeli = new double[numeryKategorii.Count,31];
      String nowaNazwa;
      if (jestemWplywem) pf.LabelText="Analizowanie dziennych wp³ywów";
                    else pf.LabelText="Analizowanie dziennych wydatków";
      foreach (String nazwaKategorii in listaKategorii)
      {
        Kategoria kat = (Kategoria) kategorie[nazwaKategorii];
        nowaNazwa = nazwaKategorii;
        Hashtable dni = kat.Dni;
        ICollection daty = dni.Keys;
        pf.Value++;
        foreach(DateTime data in daty)
        {
          wartosciTabeli[(int) numeryKategorii[nazwaKategorii],data.Day-1] = (double) dni[data];
        }
      }
      
      dataTable.Rows.Clear();
      double d;
      for (int j=0;j<31;j++)
      {
        try
        {
          DataRow dr = dataTable.NewRow();
          dr["Data"]=new DateTime(analizator.jakiRok(),analizator.jakiMiesiac(),j+1);
          double suma = 0;
          foreach(String nazwaKategorii in listaKategorii)
          {
            d = wartosciTabeli[(int) numeryKategorii[nazwaKategorii],j];
            dr[nazwaKategorii]= d;
            suma+=d;
          }
          dr["Suma"]=suma;
          dataTable.Rows.Add(dr);
        } catch (Exception ex) { };
      }
      pf.Hide();
	  }

    private void menuItem2_Click(object sender, System.EventArgs e)
    {

    }

    private void menuItem3_Click(object sender, System.EventArgs e)
    {
    }

    private void dataGrid_Enter(object sender, System.EventArgs e)
    {
      this.refresh();
    }
	}
}
