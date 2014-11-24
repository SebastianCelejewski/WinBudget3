using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WinBud풽t_3
{
	/// <summary>
	/// Summary description for GridOperacjiMieszkowych.
	/// </summary>
	public class GridOperacjiMieszkowych : System.Windows.Forms.UserControl
	{
    private MainWindow form;
    private bool mojeStyle;
    
    public MainWindow MainWindow
    {
      get { return this.form; }
      set
      {
        this.form = value;
        if (mojeStyle)
        {
          stylComboDokad.MainWindow = value;
          stylComboSkad.MainWindow = value;
        }
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
    
    private ArrayList listaMieszkow = new ArrayList();

    private System.Windows.Forms.DataGrid dataGrid1;
    private System.Data.DataSet dataSet;
    private System.Data.DataTable dataTable;
    private System.Data.DataColumn dataColumn1;
    private System.Data.DataColumn dataColumn2;
    private System.Data.DataColumn dataColumn3;
    private System.Data.DataColumn dataColumn4;
    private System.Data.DataColumn dataColumn5;
    private System.Windows.Forms.DataGridTableStyle dataGridTableStyle;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
  
    private ComboStyle stylComboSkad;
    private ComboStyle stylComboDokad;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GridOperacjiMieszkowych()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			
			mojeStyle = false;
			podlaczMojeStyle();
			
      setupLayout();
		}
		
		private void podlaczMojeStyle()
	  {
      stylComboSkad = new ComboStyle(listaMieszkow);
      stylComboDokad = new ComboStyle(listaMieszkow);
      
      stylComboSkad.HeaderText = "Sk퉐";
      stylComboSkad.MappingName = "Sk퉐";

      stylComboDokad.HeaderText = "Dok퉐";
      stylComboDokad.MappingName = "Dok퉐";

      dataGridTableStyle.GridColumnStyles.Clear();
      dataGridTableStyle.GridColumnStyles.Add(dataGridTextBoxColumn1);
      dataGridTableStyle.GridColumnStyles.Add(dataGridTextBoxColumn2);
      dataGridTableStyle.GridColumnStyles.Add(stylComboSkad);
      dataGridTableStyle.GridColumnStyles.Add(stylComboDokad);
      dataGridTableStyle.GridColumnStyles.Add(dataGridTextBoxColumn5);

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
      this.dataGrid1 = new System.Windows.Forms.DataGrid();
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
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
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
      this.dataGrid1.DataSource = this.dataTable;
      this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGrid1.Name = "dataGrid1";
      this.dataGrid1.Size = new System.Drawing.Size(528, 408);
      this.dataGrid1.TabIndex = 0;
      this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
                                                                                          this.dataGridTableStyle});
      this.dataGrid1.Resize += new System.EventHandler(this.dataGrid1_Resize);
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
      this.dataColumn1.ColumnName = "Data";
      this.dataColumn1.DataType = typeof(System.DateTime);
      // 
      // dataColumn2
      // 
      this.dataColumn2.ColumnName = "Opis";
      // 
      // dataColumn3
      // 
      this.dataColumn3.ColumnName = "Sk퉐";
      // 
      // dataColumn4
      // 
      this.dataColumn4.ColumnName = "Dok퉐";
      // 
      // dataColumn5
      // 
      this.dataColumn5.ColumnName = "Kwota";
      // 
      // dataGridTableStyle
      // 
      this.dataGridTableStyle.DataGrid = this.dataGrid1;
      this.dataGridTableStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
                                                                                                         this.dataGridTextBoxColumn1,
                                                                                                         this.dataGridTextBoxColumn2,
                                                                                                         this.dataGridTextBoxColumn3,
                                                                                                         this.dataGridTextBoxColumn4,
                                                                                                         this.dataGridTextBoxColumn5});
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
      // dataGridTextBoxColumn2
      // 
      this.dataGridTextBoxColumn2.Format = "";
      this.dataGridTextBoxColumn2.FormatInfo = null;
      this.dataGridTextBoxColumn2.HeaderText = "Opis";
      this.dataGridTextBoxColumn2.MappingName = "Opis";
      this.dataGridTextBoxColumn2.Width = 75;
      // 
      // dataGridTextBoxColumn3
      // 
      this.dataGridTextBoxColumn3.Format = "";
      this.dataGridTextBoxColumn3.FormatInfo = null;
      this.dataGridTextBoxColumn3.HeaderText = "Sk퉐";
      this.dataGridTextBoxColumn3.MappingName = "Sk퉐";
      this.dataGridTextBoxColumn3.Width = 75;
      // 
      // dataGridTextBoxColumn4
      // 
      this.dataGridTextBoxColumn4.Format = "";
      this.dataGridTextBoxColumn4.FormatInfo = null;
      this.dataGridTextBoxColumn4.HeaderText = "Dok퉐";
      this.dataGridTextBoxColumn4.MappingName = "Dok퉐";
      this.dataGridTextBoxColumn4.Width = 75;
      // 
      // dataGridTextBoxColumn5
      // 
      this.dataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
      this.dataGridTextBoxColumn5.Format = "0.00 z�";
      this.dataGridTextBoxColumn5.FormatInfo = null;
      this.dataGridTextBoxColumn5.HeaderText = "Kwota";
      this.dataGridTextBoxColumn5.MappingName = "Kwota";
      this.dataGridTextBoxColumn5.Width = 75;
      // 
      // dataSet
      // 
      this.dataSet.DataSetName = "NewDataSet";
      this.dataSet.Locale = new System.Globalization.CultureInfo("pl-PL");
      this.dataSet.Tables.AddRange(new System.Data.DataTable[] {
                                                                 this.dataTable});
      // 
      // GridOperacjiMieszkowych
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.dataGrid1});
      this.Name = "GridOperacjiMieszkowych";
      this.Size = new System.Drawing.Size(528, 408);
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
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
      dataGridTextBoxColumn1.Width = (int) (szer*0.20);
      dataGridTextBoxColumn2.Width = (int) (szer*0.20);
      if (mojeStyle)
      {
        stylComboSkad.Width = (int) (szer*0.20);
        stylComboDokad.Width = (int) (szer*0.20);
      }
      else
      {
        dataGridTextBoxColumn3.Width = (int) (szer*0.20);
        dataGridTextBoxColumn4.Width = (int) (szer*0.20);
      }
      dataGridTextBoxColumn5.Width = (int) (szer*0.20);
    }

    private void dataGrid1_Resize(object sender, System.EventArgs e)
    {
      setupLayout();
    }

    public void wpiszListe(ICollection mieszki)
    {
      this.listaMieszkow.Clear();
      this.listaMieszkow.AddRange(mieszki);
    }		
    
    public void podlaczDataTable(DataTable dataTable)
    {
      this.dataGridTableStyle.MappingName=dataTable.TableName;
      this.dataTable = dataTable;
      this.dataGrid1.DataSource=dataTable;
      this.ContextMenu = new DataGridContextMenu(dataTable);
    }
    
	}
}
