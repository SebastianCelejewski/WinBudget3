using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WinBud¿et_3
{
	/// <summary>
	/// Summary description for GridPlanow.
	/// </summary>
	public class GridPlanow : System.Windows.Forms.UserControl
	{
    private MainWindow form;
    
    public MainWindow MainWindow
    {
      get { return this.form; }
      set
      {
        this.form = value;
        stylComboKategoria.MainWindow = value;
      }
    } 
    public string CaptionText
    {
      get { return this.dataGrid1.CaptionText; }
      set { this.dataGrid1.CaptionText = value; }
    }
    
    public Font CaptionFont
    {
      get { return this.dataGrid1.CaptionFont; }
      set { this.dataGrid1.CaptionFont = value; }
    }
    
    public Color CaptionForeColor
    {
      get { return this.dataGrid1.CaptionForeColor; }
      set { this.dataGrid1.CaptionForeColor = value; }
    }
    
    public Color CaptionBackColor
    {
      get { return this.dataGrid1.CaptionBackColor; }
      set { this.dataGrid1.CaptionBackColor = value; }
    }    
    private ArrayList listaKategorii = new ArrayList();
    private ComboStyle stylComboKategoria;
	
    private System.Windows.Forms.DataGrid dataGrid1;
    private System.Data.DataSet dataSet;
    private System.Data.DataTable dataTable;
    private System.Data.DataColumn dataColumn1;
    private System.Data.DataColumn dataColumn2;
    private System.Windows.Forms.DataGridTableStyle dataGridTableStyle;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
    private System.Data.DataView dataView;
    private System.Data.DataColumn dataColumn5;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GridPlanow()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
      stylComboKategoria = new ComboStyle(listaKategorii);
      stylComboKategoria.HeaderText = "Kategoria";
      stylComboKategoria.MappingName = "Kategoria";
      dataGridTableStyle.GridColumnStyles.Clear();
      dataGridTableStyle.GridColumnStyles.Add(dataGridTextBoxColumn2);
      dataGridTableStyle.GridColumnStyles.Add(stylComboKategoria);
      dataGridTableStyle.GridColumnStyles.Add(this.dataGridTextBoxColumn5);
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
      this.dataGrid1 = new System.Windows.Forms.DataGrid();
      this.dataView = new System.Data.DataView();
      this.dataTable = new System.Data.DataTable();
      this.dataColumn1 = new System.Data.DataColumn();
      this.dataColumn2 = new System.Data.DataColumn();
      this.dataColumn5 = new System.Data.DataColumn();
      this.dataGridTableStyle = new System.Windows.Forms.DataGridTableStyle();
      this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
      this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
      this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
      this.dataSet = new System.Data.DataSet();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
      this.SuspendLayout();
      // 
      // dataGrid1
      // 
      this.dataGrid1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.dataGrid1.DataMember = "";
      this.dataGrid1.DataSource = this.dataView;
      this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGrid1.Name = "dataGrid1";
      this.dataGrid1.Size = new System.Drawing.Size(480, 384);
      this.dataGrid1.TabIndex = 0;
      this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
                                                                                          this.dataGridTableStyle});
      this.dataGrid1.Resize += new System.EventHandler(this.dataGrid1_Resize);
      // 
      // dataView
      // 
      this.dataView.Table = this.dataTable;
      // 
      // dataTable
      // 
      this.dataTable.Columns.AddRange(new System.Data.DataColumn[] {
                                                                     this.dataColumn1,
                                                                     this.dataColumn2,
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
      this.dataColumn2.DataType = typeof(System.Double);
      // 
      // dataColumn5
      // 
      this.dataColumn5.ColumnName = "Komentarz";
      // 
      // dataGridTableStyle
      // 
      this.dataGridTableStyle.DataGrid = this.dataGrid1;
      this.dataGridTableStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
                                                                                                         this.dataGridTextBoxColumn2,
                                                                                                         this.dataGridTextBoxColumn1,
                                                                                                         this.dataGridTextBoxColumn5});
      this.dataGridTableStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGridTableStyle.MappingName = "Table";
      // 
      // dataGridTextBoxColumn2
      // 
      this.dataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
      this.dataGridTextBoxColumn2.Format = "0.00 z³";
      this.dataGridTextBoxColumn2.FormatInfo = null;
      this.dataGridTextBoxColumn2.HeaderText = "Plan";
      this.dataGridTextBoxColumn2.MappingName = "Plan";
      this.dataGridTextBoxColumn2.Width = 75;
      // 
      // dataGridTextBoxColumn1
      // 
      this.dataGridTextBoxColumn1.Format = "Plan";
      this.dataGridTextBoxColumn1.FormatInfo = null;
      this.dataGridTextBoxColumn1.HeaderText = "Kategoria";
      this.dataGridTextBoxColumn1.MappingName = "Kategoria";
      this.dataGridTextBoxColumn1.Width = 75;
      // 
      // dataGridTextBoxColumn5
      // 
      this.dataGridTextBoxColumn5.Format = "";
      this.dataGridTextBoxColumn5.FormatInfo = null;
      this.dataGridTextBoxColumn5.HeaderText = "Komentarz";
      this.dataGridTextBoxColumn5.MappingName = "Komentarz";
      this.dataGridTextBoxColumn5.NullText = "brak komentarza";
      this.dataGridTextBoxColumn5.Width = 75;
      // 
      // dataSet
      // 
      this.dataSet.DataSetName = "NewDataSet";
      this.dataSet.Locale = new System.Globalization.CultureInfo("pl-PL");
      this.dataSet.Tables.AddRange(new System.Data.DataTable[] {
                                                                 this.dataTable});
      // 
      // GridPlanow
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.dataGrid1});
      this.Name = "GridPlanow";
      this.Size = new System.Drawing.Size(480, 384);
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
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
      stylComboKategoria.Width = (int) (szer*0.25);
      dataGridTextBoxColumn2.Width = (int) (szer*0.15);
      dataGridTextBoxColumn5.Width = (int) (szer*0.60);
    }
		
    public void wpiszListe(ICollection kategorie)
    {
      this.listaKategorii.Clear();
      this.listaKategorii.AddRange(kategorie);
    }		
    
    public void podlaczDataTable(DataTable dataTable)
    {
      this.dataTable = dataTable;
      this.dataView.Table = dataTable;
//      this.dataView.Sort = "Plan DESC";
      this.dataGridTableStyle.MappingName=dataTable.TableName;
      this.dataGrid1.DataSource=dataView;
      this.ContextMenu = new DataGridContextMenu(this.dataTable);
    }

    private void dataGrid1_Resize(object sender, System.EventArgs e)
    {
      setupLayout();
    }		
	}
}
