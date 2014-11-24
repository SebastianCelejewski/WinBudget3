using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WinBud¿et_3
{
	/// <summary>
	/// Summary description for GridyKategorii.
	/// </summary>
	public class GridyKategorii : System.Windows.Forms.UserControl
	{
    private string nazwaZaznaczonejKategorii;	
	  private Tulkit tulkit;
	  private Analizator analizator;
	  private bool jestemWplywem;
	  private Hashtable kategorie;
	
    public Tulkit Tulkit
    {
      get { return this.tulkit; }
      set { this.tulkit = value; }
    }
		
    public string CaptionTextKategorii
    {
      get { return this.dataGridKategorii.CaptionText; }
      set { this.dataGridKategorii.CaptionText = value; }
    }

    public string CaptionTextSzczegolow
    {
      get { return this.dataGridSzczegolow.CaptionText; }
      set { this.dataGridSzczegolow.CaptionText = value; }
    }
        
    public Font CaptionFontKategorii
    {
      get { return this.dataGridKategorii.CaptionFont; }
      set { this.dataGridKategorii.CaptionFont = value; }
    }
    
    public Font CaptionFontSzczegolow
    {
      get { return this.dataGridSzczegolow.CaptionFont; }
      set { this.dataGridSzczegolow.CaptionFont = value; }
    }
    
    public Color CaptionForeColorKategorii
    {
      get { return this.dataGridKategorii.CaptionForeColor; }
      set { this.dataGridKategorii.CaptionForeColor = value; }
    }
    
    public Color CaptionForeColorSzczegolow
    {
      get { return this.dataGridSzczegolow.CaptionForeColor; }
      set { this.dataGridSzczegolow.CaptionForeColor = value; }
    }
    
    public Color CaptionBackColorKategorii
    {
      get { return this.dataGridKategorii.CaptionBackColor; }
      set { this.dataGridKategorii.CaptionBackColor = value; }
    }
	
    public Color CaptionBackColorSzczegolow
    {
      get { return this.dataGridSzczegolow.CaptionBackColor; }
      set { this.dataGridSzczegolow.CaptionBackColor = value; }
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
	
    private System.Windows.Forms.DataGrid dataGridKategorii;
    private System.Windows.Forms.DataGrid dataGridSzczegolow;
    private System.Data.DataSet dataSet;
    private System.Data.DataView dataViewKategorii;
    private System.Data.DataView dataViewSzczegolow;
    private System.Data.DataTable dataTableKategorii;
    private System.Data.DataTable dataTableSzczegolow;
    private System.Data.DataColumn dataColumn1;
    private System.Data.DataColumn dataColumn2;
    private System.Data.DataColumn dataColumn3;
    private System.Data.DataColumn dataColumn4;
    private System.Windows.Forms.DataGridTableStyle dataGridTableStyleKategorii;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
    private System.Windows.Forms.DataGridTableStyle dataGridTableStyleSzczegolow;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GridyKategorii()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			nazwaZaznaczonejKategorii = "";
			wczytajSzczegoly();
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
      this.dataGridKategorii = new System.Windows.Forms.DataGrid();
      this.dataGridSzczegolow = new System.Windows.Forms.DataGrid();
      this.dataSet = new System.Data.DataSet();
      this.dataViewKategorii = new System.Data.DataView();
      this.dataViewSzczegolow = new System.Data.DataView();
      this.dataTableKategorii = new System.Data.DataTable();
      this.dataTableSzczegolow = new System.Data.DataTable();
      this.dataColumn1 = new System.Data.DataColumn();
      this.dataColumn2 = new System.Data.DataColumn();
      this.dataColumn3 = new System.Data.DataColumn();
      this.dataColumn4 = new System.Data.DataColumn();
      this.dataGridTableStyleKategorii = new System.Windows.Forms.DataGridTableStyle();
      this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
      this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
      this.dataGridTableStyleSzczegolow = new System.Windows.Forms.DataGridTableStyle();
      this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
      this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridKategorii)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridSzczegolow)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataViewKategorii)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataViewSzczegolow)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataTableKategorii)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataTableSzczegolow)).BeginInit();
      this.SuspendLayout();
      // 
      // dataGridKategorii
      // 
      this.dataGridKategorii.DataMember = "";
      this.dataGridKategorii.DataSource = this.dataViewKategorii;
      this.dataGridKategorii.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGridKategorii.Name = "dataGridKategorii";
      this.dataGridKategorii.ReadOnly = true;
      this.dataGridKategorii.RowHeadersVisible = false;
      this.dataGridKategorii.Size = new System.Drawing.Size(336, 360);
      this.dataGridKategorii.TabIndex = 0;
      this.dataGridKategorii.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
                                                                                                  this.dataGridTableStyleKategorii});
      this.dataGridKategorii.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridKategorii_MouseDown);
      this.dataGridKategorii.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridKategorii_MouseUp);
      this.dataGridKategorii.CurrentCellChanged += new System.EventHandler(this.dataGridKategorii_CurrentCellChanged);
      // 
      // dataGridSzczegolow
      // 
      this.dataGridSzczegolow.DataMember = "";
      this.dataGridSzczegolow.DataSource = this.dataViewSzczegolow;
      this.dataGridSzczegolow.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGridSzczegolow.Location = new System.Drawing.Point(336, 0);
      this.dataGridSzczegolow.Name = "dataGridSzczegolow";
      this.dataGridSzczegolow.ReadOnly = true;
      this.dataGridSzczegolow.RowHeadersVisible = false;
      this.dataGridSzczegolow.Size = new System.Drawing.Size(344, 360);
      this.dataGridSzczegolow.TabIndex = 1;
      this.dataGridSzczegolow.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
                                                                                                   this.dataGridTableStyleSzczegolow});
      this.dataGridSzczegolow.Resize += new System.EventHandler(this.dataGridSzczegolow_Resize);
      // 
      // dataSet
      // 
      this.dataSet.DataSetName = "NewDataSet";
      this.dataSet.Locale = new System.Globalization.CultureInfo("pl-PL");
      this.dataSet.Tables.AddRange(new System.Data.DataTable[] {
                                                                 this.dataTableKategorii,
                                                                 this.dataTableSzczegolow});
      // 
      // dataViewKategorii
      // 
      this.dataViewKategorii.Sort = "Suma DESC";
      this.dataViewKategorii.Table = this.dataTableKategorii;
      // 
      // dataViewSzczegolow
      // 
      this.dataViewSzczegolow.Sort = "Suma DESC";
      this.dataViewSzczegolow.Table = this.dataTableSzczegolow;
      // 
      // dataTableKategorii
      // 
      this.dataTableKategorii.Columns.AddRange(new System.Data.DataColumn[] {
                                                                              this.dataColumn1,
                                                                              this.dataColumn2});
      this.dataTableKategorii.TableName = "TableKategorii";
      // 
      // dataTableSzczegolow
      // 
      this.dataTableSzczegolow.Columns.AddRange(new System.Data.DataColumn[] {
                                                                               this.dataColumn3,
                                                                               this.dataColumn4});
      this.dataTableSzczegolow.TableName = "TableSzczegolow";
      // 
      // dataColumn1
      // 
      this.dataColumn1.ColumnName = "Kategoria";
      // 
      // dataColumn2
      // 
      this.dataColumn2.ColumnName = "Suma";
      this.dataColumn2.DataType = typeof(System.Double);
      // 
      // dataColumn3
      // 
      this.dataColumn3.ColumnName = "Pozycja";
      // 
      // dataColumn4
      // 
      this.dataColumn4.ColumnName = "Suma";
      this.dataColumn4.DataType = typeof(System.Double);
      // 
      // dataGridTableStyleKategorii
      // 
      this.dataGridTableStyleKategorii.DataGrid = this.dataGridKategorii;
      this.dataGridTableStyleKategorii.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
                                                                                                                  this.dataGridTextBoxColumn1,
                                                                                                                  this.dataGridTextBoxColumn2});
      this.dataGridTableStyleKategorii.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGridTableStyleKategorii.MappingName = "TableKategorii";
      this.dataGridTableStyleKategorii.ReadOnly = true;
      this.dataGridTableStyleKategorii.RowHeadersVisible = false;
      // 
      // dataGridTextBoxColumn1
      // 
      this.dataGridTextBoxColumn1.Format = "";
      this.dataGridTextBoxColumn1.FormatInfo = null;
      this.dataGridTextBoxColumn1.HeaderText = "Kategoria";
      this.dataGridTextBoxColumn1.MappingName = "Kategoria";
      this.dataGridTextBoxColumn1.ReadOnly = true;
      this.dataGridTextBoxColumn1.Width = 75;
      // 
      // dataGridTextBoxColumn2
      // 
      this.dataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
      this.dataGridTextBoxColumn2.Format = "0.00 z³";
      this.dataGridTextBoxColumn2.FormatInfo = null;
      this.dataGridTextBoxColumn2.HeaderText = "Suma";
      this.dataGridTextBoxColumn2.MappingName = "Suma";
      this.dataGridTextBoxColumn2.ReadOnly = true;
      this.dataGridTextBoxColumn2.Width = 75;
      // 
      // dataGridTableStyleSzczegolow
      // 
      this.dataGridTableStyleSzczegolow.DataGrid = this.dataGridSzczegolow;
      this.dataGridTableStyleSzczegolow.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
                                                                                                                   this.dataGridTextBoxColumn3,
                                                                                                                   this.dataGridTextBoxColumn4});
      this.dataGridTableStyleSzczegolow.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGridTableStyleSzczegolow.MappingName = "TableSzczegolow";
      this.dataGridTableStyleSzczegolow.ReadOnly = true;
      this.dataGridTableStyleSzczegolow.RowHeadersVisible = false;
      // 
      // dataGridTextBoxColumn3
      // 
      this.dataGridTextBoxColumn3.Format = "";
      this.dataGridTextBoxColumn3.FormatInfo = null;
      this.dataGridTextBoxColumn3.HeaderText = "Pozycja";
      this.dataGridTextBoxColumn3.MappingName = "Pozycja";
      this.dataGridTextBoxColumn3.ReadOnly = true;
      this.dataGridTextBoxColumn3.Width = 75;
      // 
      // dataGridTextBoxColumn4
      // 
      this.dataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
      this.dataGridTextBoxColumn4.Format = "0.00 z³";
      this.dataGridTextBoxColumn4.FormatInfo = null;
      this.dataGridTextBoxColumn4.HeaderText = "Suma";
      this.dataGridTextBoxColumn4.MappingName = "Suma";
      this.dataGridTextBoxColumn4.ReadOnly = true;
      this.dataGridTextBoxColumn4.Width = 75;
      // 
      // GridyKategorii
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.dataGridSzczegolow,
                                                                  this.dataGridKategorii});
      this.Name = "GridyKategorii";
      this.Size = new System.Drawing.Size(680, 360);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridKategorii)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridSzczegolow)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataViewKategorii)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataViewSzczegolow)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataTableKategorii)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataTableSzczegolow)).EndInit();
      this.ResumeLayout(false);

    }
		#endregion
		
		public void refresh()
		{
		  if (jestemWplywem) kategorie = analizator.pobierzAnalizeKategoriiWplywow();
		                else kategorie = analizator.pobierzAnalizeKategoriiWydatkow();
		                
      ICollection nazwyKategorii = kategorie.Keys;
      dataTableKategorii.Rows.Clear();
      foreach (string nazwaKategorii in nazwyKategorii)
      {
        Kategoria kategoria = (Kategoria) kategorie[nazwaKategorii];
        DataRow dr = dataTableKategorii.NewRow();
        dr["Kategoria"] = nazwaKategorii;
        dr["Suma"] = kategoria.Stan;
        dataTableKategorii.Rows.Add(dr);
      }
		}

    private void dataGridSzczegolow_Resize(object sender, System.EventArgs e)
    {
      resize();
    }
    
    public void resize()
    {
      int pol = this.Width/2-1;
      int row = dataGridKategorii.RowHeaderWidth;
      if (!dataGridKategorii.RowHeadersVisible) row = 0;
      int strip = 25;
      dataGridKategorii.Location = new System.Drawing.Point(0,0);
      dataGridSzczegolow.Location= new System.Drawing.Point(pol,0);
      dataGridKategorii.Width=pol;
      dataGridKategorii.Height=this.Height;
      dataGridSzczegolow.Width=pol;
      dataGridKategorii.Height=this.Height;
      
      dataGridTextBoxColumn1.Width=(int) ((pol-row-strip)*0.7);
      dataGridTextBoxColumn2.Width=(int) ((pol-row-strip)*0.3);
      dataGridTextBoxColumn3.Width=(int) ((pol-row-strip)*0.7);
      dataGridTextBoxColumn4.Width=(int) ((pol-row-strip)*0.3);
    }

    private void zaznaczCalyWiersz(DataGrid dg, System.Windows.Forms.MouseEventArgs e)
    {
      System.Drawing.Point pt = new Point(e.X, e.Y);
      DataGrid.HitTestInfo hti = dg.HitTest(pt);
      if(hti.Type == DataGrid.HitTestType.Cell)
      {
        dg.CurrentCell = new DataGridCell(hti.Row, hti.Column);
        dg.Select(hti.Row);
      }     
    }

    private DataRow zaznaczonyWiersz(DataGrid dg)
    {
      BindingManagerBase bm = dg.BindingContext[dg.DataSource, dg.DataMember];
      return ((DataRowView)bm.Current).Row;     
    }

    private void dataGridKategorii_CurrentCellChanged(object sender, System.EventArgs e)
    {
      nazwaZaznaczonejKategorii = (string) zaznaczonyWiersz(dataGridKategorii)["Kategoria"];
      wczytajSzczegoly();
    }

    private void dataGridKategorii_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
      zaznaczCalyWiersz(dataGridKategorii,e);
    }

    private void dataGridKategorii_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
    }
    
    private void wczytajSzczegoly()
    {
      if (kategorie==null)
      {
        dataGridSzczegolow.CaptionText="Szczegó³y: brak";
        dataTableSzczegolow.Rows.Clear();
      }
      else
      {
        dataGridSzczegolow.CaptionText="Szczegó³y: "+nazwaZaznaczonejKategorii;      
        Kategoria kategoria = (Kategoria) kategorie[nazwaZaznaczonejKategorii];
        Hashtable pozycje = kategoria.Pozycje;
        ICollection nazwyPozycji = pozycje.Keys;
        dataTableSzczegolow.Rows.Clear();
        foreach (string nazwaPozycji in nazwyPozycji)
        {
          DataRow dr = dataTableSzczegolow.NewRow();
          dr["Pozycja"] = nazwaPozycji;
          dr["Suma"] = (double) (pozycje[nazwaPozycji]);
          dataTableSzczegolow.Rows.Add(dr);          
        }
      }
    }
	}
}
