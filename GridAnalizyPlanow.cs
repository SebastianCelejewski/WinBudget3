using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WinBud¿et_3
{
	/// <summary>
	/// Summary description for GridAnalizyPlanow.
	/// </summary>
	public class GridAnalizyPlanow : System.Windows.Forms.UserControl
	{
    private System.Windows.Forms.DataGrid dataGrid;
    private System.Data.DataSet dataSet;
    private System.Data.DataTable dataTable;
    private System.Data.DataColumn dataColumn1;
    private System.Data.DataColumn dataColumn2;
    private System.Data.DataColumn dataColumn3;
    private System.Data.DataColumn dataColumn4;
    private System.Data.DataColumn dataColumn5;
    private System.Data.DataView dataView;
    private System.Windows.Forms.DataGridTableStyle dataGridTableStyle;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        
    private PasekStyle pasekStyle;
    private bool jestemWplywem;
    private bool mojeStyle;
    private Analizator analizator;
    private double sumaPrzekroczen;
    private double sumaBrakow;
    private double najwyzszaWartosc;
	
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
	
	  public bool JestemWplywem
	  {
	    get { return this.jestemWplywem; }
	    set 
	    { 
	      this.jestemWplywem = value; 
	      if (pasekStyle!=null) pasekStyle.JestemWplywem=value;
	    }
	  }
	  
	  public Analizator Analizator
	  {
	    get { return this.analizator; }
	    set { this.analizator = value; }
	  }
    
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		private DataGridContextMenu contextMenu;

		public GridAnalizyPlanow()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
      inicjujFajoweStyle();
      setupLayout();
      contextMenu = new DataGridContextMenu(dataTable);
      this.ContextMenu = contextMenu;
    }
		
		private void inicjujFajoweStyle()
	  {
      pasekStyle = new PasekStyle(jestemWplywem);
      pasekStyle.HeaderText="";
      pasekStyle.MappingName="Pasek";
      dataGridTableStyle.GridColumnStyles.Clear();
      dataGridTableStyle.GridColumnStyles.Add(dataGridTextBoxColumn1);
      dataGridTableStyle.GridColumnStyles.Add(dataGridTextBoxColumn2);
      dataGridTableStyle.GridColumnStyles.Add(dataGridTextBoxColumn3);
      dataGridTableStyle.GridColumnStyles.Add(dataGridTextBoxColumn4);
      dataGridTableStyle.GridColumnStyles.Add(pasekStyle);
      
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
      this.dataView = new System.Data.DataView();
      this.dataTable = new System.Data.DataTable();
      this.dataColumn1 = new System.Data.DataColumn();
      this.dataColumn2 = new System.Data.DataColumn();
      this.dataColumn3 = new System.Data.DataColumn();
      this.dataColumn4 = new System.Data.DataColumn();
      this.dataColumn5 = new System.Data.DataColumn();
      this.dataGridTableStyle = new System.Windows.Forms.DataGridTableStyle();
      this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
      this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
      this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
      this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
      this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
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
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.Size = new System.Drawing.Size(600, 464);
      this.dataGrid.TabIndex = 0;
      this.dataGrid.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
                                                                                         this.dataGridTableStyle});
      this.dataGrid.Resize += new System.EventHandler(this.dataGrid_Resize);
      // 
      // dataView
      // 
      this.dataView.Sort = "Plan DESC";
      this.dataView.Table = this.dataTable;
      // 
      // dataTable
      // 
      this.dataTable.Columns.AddRange(new System.Data.DataColumn[] {
                                                                     this.dataColumn1,
                                                                     this.dataColumn2,
                                                                     this.dataColumn3,
                                                                     this.dataColumn4,
                                                                     this.dataColumn5});
      this.dataTable.TableName = "Table";
      // 
      // dataColumn1
      // 
      this.dataColumn1.ColumnName = "Kategoria";
      // 
      // dataColumn2
      // 
      this.dataColumn2.ColumnName = "Plan";
      // 
      // dataColumn3
      // 
      this.dataColumn3.ColumnName = "Stan";
      // 
      // dataColumn4
      // 
      this.dataColumn4.ColumnName = "Ró¿nica";
      // 
      // dataColumn5
      // 
      this.dataColumn5.ColumnName = "Pasek";
      // 
      // dataGridTableStyle
      // 
      this.dataGridTableStyle.DataGrid = this.dataGrid;
      this.dataGridTableStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
                                                                                                         this.dataGridTextBoxColumn1,
                                                                                                         this.dataGridTextBoxColumn2,
                                                                                                         this.dataGridTextBoxColumn3,
                                                                                                         this.dataGridTextBoxColumn4,
                                                                                                         this.dataGridTextBoxColumn5});
      this.dataGridTableStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGridTableStyle.MappingName = "Table";
      this.dataGridTableStyle.ReadOnly = true;
      // 
      // dataGridTextBoxColumn1
      // 
      this.dataGridTextBoxColumn1.Format = "";
      this.dataGridTextBoxColumn1.FormatInfo = null;
      this.dataGridTextBoxColumn1.HeaderText = "Kategoria";
      this.dataGridTextBoxColumn1.MappingName = "Kategoria";
      this.dataGridTextBoxColumn1.Width = 75;
      // 
      // dataGridTextBoxColumn2
      // 
      this.dataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
      this.dataGridTextBoxColumn2.Format = "";
      this.dataGridTextBoxColumn2.FormatInfo = null;
      this.dataGridTextBoxColumn2.HeaderText = "Plan";
      this.dataGridTextBoxColumn2.MappingName = "Plan";
      this.dataGridTextBoxColumn2.Width = 75;
      // 
      // dataGridTextBoxColumn3
      // 
      this.dataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
      this.dataGridTextBoxColumn3.Format = "";
      this.dataGridTextBoxColumn3.FormatInfo = null;
      this.dataGridTextBoxColumn3.HeaderText = "Stan";
      this.dataGridTextBoxColumn3.MappingName = "Stan";
      this.dataGridTextBoxColumn3.Width = 75;
      // 
      // dataGridTextBoxColumn4
      // 
      this.dataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
      this.dataGridTextBoxColumn4.Format = "";
      this.dataGridTextBoxColumn4.FormatInfo = null;
      this.dataGridTextBoxColumn4.HeaderText = "Ró¿nica";
      this.dataGridTextBoxColumn4.MappingName = "Ró¿nica";
      this.dataGridTextBoxColumn4.Width = 75;
      // 
      // dataGridTextBoxColumn5
      // 
      this.dataGridTextBoxColumn5.Format = "";
      this.dataGridTextBoxColumn5.FormatInfo = null;
      this.dataGridTextBoxColumn5.MappingName = "Pasek";
      this.dataGridTextBoxColumn5.Width = 75;
      // 
      // dataSet
      // 
      this.dataSet.DataSetName = "NewDataSet";
      this.dataSet.Locale = new System.Globalization.CultureInfo("pl-PL");
      this.dataSet.Tables.AddRange(new System.Data.DataTable[] {
                                                                 this.dataTable});
      // 
      // GridAnalizyPlanow
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.dataGrid});
      this.Name = "GridAnalizyPlanow";
      this.Size = new System.Drawing.Size(600, 464);
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
      this.ResumeLayout(false);

    }
		#endregion
		
    private void setupLayout()
    {
      int szer = this.Width;
      int szerLewy = this.dataGridTableStyle.RowHeaderWidth;
      int szerPrawy = 25;
      szer-=(szerLewy+szerPrawy);
      dataGridTextBoxColumn1.Width = (int) (szer*0.24);
      dataGridTextBoxColumn2.Width = (int) (szer*0.12);
      dataGridTextBoxColumn3.Width = (int) (szer*0.12);
      dataGridTextBoxColumn4.Width = (int) (szer*0.12);
      if (mojeStyle)
      {
        pasekStyle.Width = (int) (szer*0.4);
        pasekStyle.Podzielnik=najwyzszaWartosc/pasekStyle.Width;
      }
      else
      {
        dataGridTextBoxColumn5.Width = (int) (szer*0.4);
      }
    }

    private void dataGrid_Resize(object sender, System.EventArgs e)
    {
      setupLayout();    
    }
    
    public void refresh()
    {
      dataTable.Rows.Clear();
      if (analizator!=null)
      {
        sumaPrzekroczen = 0;
        sumaBrakow = 0;
        najwyzszaWartosc = 20;
        Hashtable kategorie;
        if (jestemWplywem) kategorie=analizator.pobierzAnalizeKategoriiWplywow();
              else kategorie=analizator.pobierzAnalizeKategoriiWydatkow();
        ICollection nazwyKategorii = kategorie.Keys;
        foreach (String nazwaKategorii in nazwyKategorii)
        {
          Kategoria kat = (Kategoria) kategorie[nazwaKategorii];
          DataRow dr = dataTable.NewRow();
          dr["Kategoria"] = kat.Nazwa;
          dr["Plan"] = String.Format("{0,10:C}",kat.Plan);
          dr["Stan"] = String.Format("{0,10:C}",kat.Stan);
          dr["Ró¿nica"] = String.Format("{0,10:C}",kat.Roznica);
          dr["Pasek"] = ""+kat.Plan+";"+kat.Stan;
          dataTable.Rows.Add(dr);
          if (kat.Plan>kat.Stan) sumaBrakow+=kat.Plan-kat.Stan;
          if (kat.Stan>kat.Plan) sumaPrzekroczen+=kat.Stan-kat.Plan;
          if (kat.Plan>najwyzszaWartosc) najwyzszaWartosc=kat.Plan;
          if (kat.Stan>najwyzszaWartosc) najwyzszaWartosc=kat.Stan;
        }
        
        setupLayout();
        if (jestemWplywem)
        {
          string t = this.CaptionText="Planowane wp³ywy: "+fmt(sumaPrzekroczen)+" przekroczeñ - "+fmt(sumaBrakow)+" braków = "+fmtAbs(sumaPrzekroczen-sumaBrakow);
          if (sumaPrzekroczen>sumaBrakow) t+= " przekroczeñ"; else t+=" do zarobienia";
          this.CaptionText=t;
        }
        else
        {
          string t = this.CaptionText="Planowane wydatki: "+fmt(sumaBrakow)+" zapasów - "+fmt(sumaPrzekroczen)+" przekroczeñ = "+fmtAbs(sumaBrakow-sumaPrzekroczen);
          if (sumaPrzekroczen>sumaBrakow) t+= " przekroczeñ"; else t+=" do wydania";
          this.CaptionText=t;
        }
      }
    }
    private string fmt(double d) { return String.Format("{0,10:C}",d); }
    private string fmtAbs(double d) { return fmt(Math.Abs(d)); }
	}
}
