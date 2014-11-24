using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WinBud¿et_3
{
	/// <summary>
	/// Summary description for PanelMieszkiBilans.
	/// </summary>
	public class PanelMieszkiBilans : System.Windows.Forms.UserControl
	{
	  private Analizator analizator;
	  private bool wyroznijPoprzedni;
	  private ArrayList wizibloki;
	  
	  public Analizator Analizator
	  {
	    get { return analizator; }
	    set { analizator = value; }
	  }
	  
	  public bool WyroznijKategorieZPoprzedniegoMiesiaca
	  {
	    set { this.wyroznijPoprzedni = value; }
	    get { return this.wyroznijPoprzedni; }
	  }
	
    private System.Windows.Forms.DataGrid dataGrid1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox textBoxWplywyStan;
    private System.Windows.Forms.TextBox textBoxWplywyPlan;
    private System.Windows.Forms.TextBox textBoxWplywyRoznica;
    private System.Windows.Forms.TextBox textBoxWydatkiStan;
    private System.Windows.Forms.TextBox textBoxWydatkiPlan;
    private System.Windows.Forms.TextBox textBoxWydatkiRoznica;
    private System.Windows.Forms.TextBox textBoxBilansStan;
    private System.Windows.Forms.TextBox textBoxBilansPlan;
    private System.Windows.Forms.TextBox textBoxBilansRoznica;
    private System.Data.DataSet dataSet;
    private System.Data.DataTable dataTable;
    private System.Data.DataColumn dataColumn1;
    private System.Data.DataColumn dataColumn2;
    private System.Windows.Forms.DataGridTableStyle dataGridTableStyle;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
    private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
    private System.Windows.Forms.Label labelZPoprzedniego;
    private System.Windows.Forms.Label labelNaNastepny;
    private System.Windows.Forms.Label labelSumaMieszkow;
    private System.Windows.Forms.TextBox textBoxZPoprzedniegoStan;
    private System.Windows.Forms.TextBox textBoxNaNastepnyStan;
    private System.Windows.Forms.TextBox textBoxNaNastepnyPlan;
    private System.Windows.Forms.TextBox textBoxZPoprzedniegoRoznica;
    private System.Windows.Forms.TextBox textBoxNaNastepnyRoznica;
    private System.Windows.Forms.TextBox textBoxZPoprzedniegoPlan;
    private System.Windows.Forms.CheckBox checkBox1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PanelMieszkiBilans()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			
			wizibloki = new ArrayList();

			// TODO: Add any initialization after the InitForm call
			wizibloki.Add(textBoxNaNastepnyPlan);
			wizibloki.Add(textBoxNaNastepnyStan);
			wizibloki.Add(textBoxNaNastepnyRoznica);
			wizibloki.Add(textBoxZPoprzedniegoPlan);
			wizibloki.Add(textBoxZPoprzedniegoRoznica);
			wizibloki.Add(textBoxZPoprzedniegoStan);
			
			wizibloki.Add(labelZPoprzedniego);
			wizibloki.Add(labelNaNastepny);
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
      this.dataGridTableStyle = new System.Windows.Forms.DataGridTableStyle();
      this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
      this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.labelSumaMieszkow = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.textBoxWplywyStan = new System.Windows.Forms.TextBox();
      this.textBoxZPoprzedniegoStan = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.textBoxWplywyPlan = new System.Windows.Forms.TextBox();
      this.textBoxWplywyRoznica = new System.Windows.Forms.TextBox();
      this.textBoxWydatkiStan = new System.Windows.Forms.TextBox();
      this.textBoxWydatkiPlan = new System.Windows.Forms.TextBox();
      this.textBoxWydatkiRoznica = new System.Windows.Forms.TextBox();
      this.textBoxBilansStan = new System.Windows.Forms.TextBox();
      this.textBoxBilansPlan = new System.Windows.Forms.TextBox();
      this.textBoxBilansRoznica = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.dataSet = new System.Data.DataSet();
      this.labelZPoprzedniego = new System.Windows.Forms.Label();
      this.textBoxNaNastepnyStan = new System.Windows.Forms.TextBox();
      this.labelNaNastepny = new System.Windows.Forms.Label();
      this.textBoxNaNastepnyPlan = new System.Windows.Forms.TextBox();
      this.textBoxZPoprzedniegoRoznica = new System.Windows.Forms.TextBox();
      this.textBoxNaNastepnyRoznica = new System.Windows.Forms.TextBox();
      this.textBoxZPoprzedniegoPlan = new System.Windows.Forms.TextBox();
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
      this.SuspendLayout();
      // 
      // dataGrid1
      // 
      this.dataGrid1.DataMember = "";
      this.dataGrid1.DataSource = this.dataTable;
      this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGrid1.Location = new System.Drawing.Point(8, 40);
      this.dataGrid1.Name = "dataGrid1";
      this.dataGrid1.Size = new System.Drawing.Size(224, 136);
      this.dataGrid1.TabIndex = 0;
      this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
                                                                                          this.dataGridTableStyle});
      // 
      // dataTable
      // 
      this.dataTable.Columns.AddRange(new System.Data.DataColumn[] {
                                                                     this.dataColumn1,
                                                                     this.dataColumn2});
      this.dataTable.TableName = "Table";
      // 
      // dataColumn1
      // 
      this.dataColumn1.Caption = "Mieszek";
      this.dataColumn1.ColumnName = "Mieszek";
      // 
      // dataColumn2
      // 
      this.dataColumn2.Caption = "Stan";
      this.dataColumn2.ColumnName = "Stan";
      this.dataColumn2.DataType = typeof(System.Double);
      // 
      // dataGridTableStyle
      // 
      this.dataGridTableStyle.DataGrid = this.dataGrid1;
      this.dataGridTableStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
                                                                                                         this.dataGridTextBoxColumn2,
                                                                                                         this.dataGridTextBoxColumn1});
      this.dataGridTableStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGridTableStyle.MappingName = "Table";
      this.dataGridTableStyle.ReadOnly = true;
      this.dataGridTableStyle.RowHeadersVisible = false;
      // 
      // dataGridTextBoxColumn2
      // 
      this.dataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
      this.dataGridTextBoxColumn2.Format = "0.00 z³";
      this.dataGridTextBoxColumn2.FormatInfo = null;
      this.dataGridTextBoxColumn2.HeaderText = "Stan";
      this.dataGridTextBoxColumn2.MappingName = "Stan";
      this.dataGridTextBoxColumn2.Width = 70;
      // 
      // dataGridTextBoxColumn1
      // 
      this.dataGridTextBoxColumn1.Format = "";
      this.dataGridTextBoxColumn1.FormatInfo = null;
      this.dataGridTextBoxColumn1.HeaderText = "Mieszek";
      this.dataGridTextBoxColumn1.MappingName = "Mieszek";
      this.dataGridTextBoxColumn1.Width = 150;
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
      this.label1.Location = new System.Drawing.Point(8, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(224, 24);
      this.label1.TabIndex = 1;
      this.label1.Text = "Stan mieszków";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label2
      // 
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
      this.label2.Location = new System.Drawing.Point(272, 16);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(376, 23);
      this.label2.TabIndex = 2;
      this.label2.Text = "Bilans miesiêczny";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labelSumaMieszkow
      // 
      this.labelSumaMieszkow.Location = new System.Drawing.Point(8, 184);
      this.labelSumaMieszkow.Name = "labelSumaMieszkow";
      this.labelSumaMieszkow.Size = new System.Drawing.Size(224, 23);
      this.labelSumaMieszkow.TabIndex = 3;
      this.labelSumaMieszkow.Text = "Razem: z³";
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(264, 64);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(64, 23);
      this.label5.TabIndex = 5;
      this.label5.Text = "Wp³ywy:";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label6
      // 
      this.label6.Location = new System.Drawing.Point(264, 96);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(64, 23);
      this.label6.TabIndex = 6;
      this.label6.Text = "Wydatki:";
      this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label7
      // 
      this.label7.Location = new System.Drawing.Point(264, 128);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(64, 23);
      this.label7.TabIndex = 7;
      this.label7.Text = "Bilans:";
      this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // textBoxWplywyStan
      // 
      this.textBoxWplywyStan.BackColor = System.Drawing.Color.White;
      this.textBoxWplywyStan.Location = new System.Drawing.Point(344, 64);
      this.textBoxWplywyStan.Name = "textBoxWplywyStan";
      this.textBoxWplywyStan.ReadOnly = true;
      this.textBoxWplywyStan.Size = new System.Drawing.Size(96, 22);
      this.textBoxWplywyStan.TabIndex = 8;
      this.textBoxWplywyStan.Text = "";
      this.textBoxWplywyStan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // textBoxZPoprzedniegoStan
      // 
      this.textBoxZPoprzedniegoStan.BackColor = System.Drawing.Color.White;
      this.textBoxZPoprzedniegoStan.Location = new System.Drawing.Point(344, 208);
      this.textBoxZPoprzedniegoStan.Name = "textBoxZPoprzedniegoStan";
      this.textBoxZPoprzedniegoStan.ReadOnly = true;
      this.textBoxZPoprzedniegoStan.Size = new System.Drawing.Size(96, 22);
      this.textBoxZPoprzedniegoStan.TabIndex = 18;
      this.textBoxZPoprzedniegoStan.Text = "";
      this.textBoxZPoprzedniegoStan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(344, 40);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(96, 23);
      this.label4.TabIndex = 19;
      this.label4.Text = "Stan obecny";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // textBoxWplywyPlan
      // 
      this.textBoxWplywyPlan.BackColor = System.Drawing.Color.White;
      this.textBoxWplywyPlan.Location = new System.Drawing.Point(448, 64);
      this.textBoxWplywyPlan.Name = "textBoxWplywyPlan";
      this.textBoxWplywyPlan.ReadOnly = true;
      this.textBoxWplywyPlan.Size = new System.Drawing.Size(96, 22);
      this.textBoxWplywyPlan.TabIndex = 20;
      this.textBoxWplywyPlan.Text = "";
      this.textBoxWplywyPlan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // textBoxWplywyRoznica
      // 
      this.textBoxWplywyRoznica.BackColor = System.Drawing.Color.White;
      this.textBoxWplywyRoznica.Location = new System.Drawing.Point(552, 64);
      this.textBoxWplywyRoznica.Name = "textBoxWplywyRoznica";
      this.textBoxWplywyRoznica.ReadOnly = true;
      this.textBoxWplywyRoznica.Size = new System.Drawing.Size(96, 22);
      this.textBoxWplywyRoznica.TabIndex = 21;
      this.textBoxWplywyRoznica.Text = "";
      this.textBoxWplywyRoznica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // textBoxWydatkiStan
      // 
      this.textBoxWydatkiStan.BackColor = System.Drawing.Color.White;
      this.textBoxWydatkiStan.Location = new System.Drawing.Point(344, 96);
      this.textBoxWydatkiStan.Name = "textBoxWydatkiStan";
      this.textBoxWydatkiStan.ReadOnly = true;
      this.textBoxWydatkiStan.Size = new System.Drawing.Size(96, 22);
      this.textBoxWydatkiStan.TabIndex = 22;
      this.textBoxWydatkiStan.Text = "";
      this.textBoxWydatkiStan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // textBoxWydatkiPlan
      // 
      this.textBoxWydatkiPlan.BackColor = System.Drawing.Color.White;
      this.textBoxWydatkiPlan.Location = new System.Drawing.Point(448, 96);
      this.textBoxWydatkiPlan.Name = "textBoxWydatkiPlan";
      this.textBoxWydatkiPlan.ReadOnly = true;
      this.textBoxWydatkiPlan.Size = new System.Drawing.Size(96, 22);
      this.textBoxWydatkiPlan.TabIndex = 23;
      this.textBoxWydatkiPlan.Text = "";
      this.textBoxWydatkiPlan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // textBoxWydatkiRoznica
      // 
      this.textBoxWydatkiRoznica.BackColor = System.Drawing.Color.White;
      this.textBoxWydatkiRoznica.Location = new System.Drawing.Point(552, 96);
      this.textBoxWydatkiRoznica.Name = "textBoxWydatkiRoznica";
      this.textBoxWydatkiRoznica.ReadOnly = true;
      this.textBoxWydatkiRoznica.Size = new System.Drawing.Size(96, 22);
      this.textBoxWydatkiRoznica.TabIndex = 24;
      this.textBoxWydatkiRoznica.Text = "";
      this.textBoxWydatkiRoznica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // textBoxBilansStan
      // 
      this.textBoxBilansStan.BackColor = System.Drawing.Color.White;
      this.textBoxBilansStan.Location = new System.Drawing.Point(344, 128);
      this.textBoxBilansStan.Name = "textBoxBilansStan";
      this.textBoxBilansStan.ReadOnly = true;
      this.textBoxBilansStan.Size = new System.Drawing.Size(96, 22);
      this.textBoxBilansStan.TabIndex = 25;
      this.textBoxBilansStan.Text = "";
      this.textBoxBilansStan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // textBoxBilansPlan
      // 
      this.textBoxBilansPlan.BackColor = System.Drawing.Color.White;
      this.textBoxBilansPlan.Location = new System.Drawing.Point(448, 128);
      this.textBoxBilansPlan.Name = "textBoxBilansPlan";
      this.textBoxBilansPlan.ReadOnly = true;
      this.textBoxBilansPlan.Size = new System.Drawing.Size(96, 22);
      this.textBoxBilansPlan.TabIndex = 26;
      this.textBoxBilansPlan.Text = "";
      this.textBoxBilansPlan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // textBoxBilansRoznica
      // 
      this.textBoxBilansRoznica.BackColor = System.Drawing.Color.White;
      this.textBoxBilansRoznica.Location = new System.Drawing.Point(552, 128);
      this.textBoxBilansRoznica.Name = "textBoxBilansRoznica";
      this.textBoxBilansRoznica.ReadOnly = true;
      this.textBoxBilansRoznica.Size = new System.Drawing.Size(96, 22);
      this.textBoxBilansRoznica.TabIndex = 27;
      this.textBoxBilansRoznica.Text = "";
      this.textBoxBilansRoznica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label8
      // 
      this.label8.Location = new System.Drawing.Point(448, 40);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(96, 23);
      this.label8.TabIndex = 28;
      this.label8.Text = "Planowane";
      this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label9
      // 
      this.label9.Location = new System.Drawing.Point(552, 40);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(96, 23);
      this.label9.TabIndex = 29;
      this.label9.Text = "Ró¿nica";
      this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // dataSet
      // 
      this.dataSet.DataSetName = "NewDataSet";
      this.dataSet.Locale = new System.Globalization.CultureInfo("pl-PL");
      this.dataSet.Tables.AddRange(new System.Data.DataTable[] {
                                                                 this.dataTable});
      // 
      // labelZPoprzedniego
      // 
      this.labelZPoprzedniego.Location = new System.Drawing.Point(176, 208);
      this.labelZPoprzedniego.Name = "labelZPoprzedniego";
      this.labelZPoprzedniego.Size = new System.Drawing.Size(160, 23);
      this.labelZPoprzedniego.TabIndex = 30;
      this.labelZPoprzedniego.Text = "Z poprzedniego miesi¹ca";
      this.labelZPoprzedniego.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // textBoxNaNastepnyStan
      // 
      this.textBoxNaNastepnyStan.BackColor = System.Drawing.Color.White;
      this.textBoxNaNastepnyStan.Location = new System.Drawing.Point(344, 240);
      this.textBoxNaNastepnyStan.Name = "textBoxNaNastepnyStan";
      this.textBoxNaNastepnyStan.ReadOnly = true;
      this.textBoxNaNastepnyStan.Size = new System.Drawing.Size(96, 22);
      this.textBoxNaNastepnyStan.TabIndex = 31;
      this.textBoxNaNastepnyStan.Text = "";
      this.textBoxNaNastepnyStan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // labelNaNastepny
      // 
      this.labelNaNastepny.Location = new System.Drawing.Point(176, 240);
      this.labelNaNastepny.Name = "labelNaNastepny";
      this.labelNaNastepny.Size = new System.Drawing.Size(160, 23);
      this.labelNaNastepny.TabIndex = 32;
      this.labelNaNastepny.Text = "Na nastêpny miesi¹c";
      this.labelNaNastepny.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // textBoxNaNastepnyPlan
      // 
      this.textBoxNaNastepnyPlan.BackColor = System.Drawing.Color.White;
      this.textBoxNaNastepnyPlan.Location = new System.Drawing.Point(448, 240);
      this.textBoxNaNastepnyPlan.Name = "textBoxNaNastepnyPlan";
      this.textBoxNaNastepnyPlan.ReadOnly = true;
      this.textBoxNaNastepnyPlan.Size = new System.Drawing.Size(96, 22);
      this.textBoxNaNastepnyPlan.TabIndex = 34;
      this.textBoxNaNastepnyPlan.Text = "";
      this.textBoxNaNastepnyPlan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // textBoxZPoprzedniegoRoznica
      // 
      this.textBoxZPoprzedniegoRoznica.BackColor = System.Drawing.Color.White;
      this.textBoxZPoprzedniegoRoznica.Location = new System.Drawing.Point(552, 208);
      this.textBoxZPoprzedniegoRoznica.Name = "textBoxZPoprzedniegoRoznica";
      this.textBoxZPoprzedniegoRoznica.ReadOnly = true;
      this.textBoxZPoprzedniegoRoznica.Size = new System.Drawing.Size(96, 22);
      this.textBoxZPoprzedniegoRoznica.TabIndex = 35;
      this.textBoxZPoprzedniegoRoznica.Text = "";
      this.textBoxZPoprzedniegoRoznica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // textBoxNaNastepnyRoznica
      // 
      this.textBoxNaNastepnyRoznica.BackColor = System.Drawing.Color.White;
      this.textBoxNaNastepnyRoznica.Location = new System.Drawing.Point(552, 240);
      this.textBoxNaNastepnyRoznica.Name = "textBoxNaNastepnyRoznica";
      this.textBoxNaNastepnyRoznica.ReadOnly = true;
      this.textBoxNaNastepnyRoznica.Size = new System.Drawing.Size(96, 22);
      this.textBoxNaNastepnyRoznica.TabIndex = 36;
      this.textBoxNaNastepnyRoznica.Text = "";
      this.textBoxNaNastepnyRoznica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // textBoxZPoprzedniegoPlan
      // 
      this.textBoxZPoprzedniegoPlan.BackColor = System.Drawing.Color.White;
      this.textBoxZPoprzedniegoPlan.Location = new System.Drawing.Point(448, 208);
      this.textBoxZPoprzedniegoPlan.Name = "textBoxZPoprzedniegoPlan";
      this.textBoxZPoprzedniegoPlan.ReadOnly = true;
      this.textBoxZPoprzedniegoPlan.Size = new System.Drawing.Size(96, 22);
      this.textBoxZPoprzedniegoPlan.TabIndex = 33;
      this.textBoxZPoprzedniegoPlan.Text = "";
      this.textBoxZPoprzedniegoPlan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // checkBox1
      // 
      this.checkBox1.Checked = true;
      this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkBox1.Location = new System.Drawing.Point(264, 168);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(304, 24);
      this.checkBox1.TabIndex = 37;
      this.checkBox1.Text = "Wyró¿nij kategoriê \"Z poprzedniego miesi¹ca\"";
      this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
      // 
      // PanelMieszkiBilans
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.checkBox1,
                                                                  this.textBoxNaNastepnyRoznica,
                                                                  this.textBoxZPoprzedniegoRoznica,
                                                                  this.textBoxNaNastepnyPlan,
                                                                  this.textBoxZPoprzedniegoPlan,
                                                                  this.labelNaNastepny,
                                                                  this.textBoxNaNastepnyStan,
                                                                  this.labelZPoprzedniego,
                                                                  this.label9,
                                                                  this.label8,
                                                                  this.textBoxBilansRoznica,
                                                                  this.textBoxBilansPlan,
                                                                  this.textBoxBilansStan,
                                                                  this.textBoxWydatkiRoznica,
                                                                  this.textBoxWydatkiPlan,
                                                                  this.textBoxWydatkiStan,
                                                                  this.textBoxWplywyRoznica,
                                                                  this.textBoxWplywyPlan,
                                                                  this.label4,
                                                                  this.textBoxZPoprzedniegoStan,
                                                                  this.textBoxWplywyStan,
                                                                  this.label7,
                                                                  this.label6,
                                                                  this.label5,
                                                                  this.labelSumaMieszkow,
                                                                  this.label2,
                                                                  this.label1,
                                                                  this.dataGrid1});
      this.Name = "PanelMieszkiBilans";
      this.Size = new System.Drawing.Size(664, 448);
      this.Enter += new System.EventHandler(this.PanelMieszkiBilans_Enter);
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
      this.ResumeLayout(false);

    }
		#endregion

    public void refresh()
    {
      if (analizator==null) wyzerujWszystko();
      else
      {
        if (checkBox1.Checked==true)
        {
          analizator.WyroznicKategorieZPoprzedniegoMiesiaca = true;  
          odkryjWizibloki();
          textBoxZPoprzedniegoStan.Text=d2s(analizator.stanZPoprzedniegoMiesiaca());
          textBoxZPoprzedniegoPlan.Text=d2s(analizator.planZPoprzedniegoMiesiaca());
          textBoxZPoprzedniegoRoznica.Text=d2s(analizator.roznicaZPoprzedniegoMiesiaca());
          
          textBoxNaNastepnyStan.Text=d2s(analizator.stanNaNastepnyMiesiac());
          textBoxNaNastepnyPlan.Text=d2s(analizator.planNaNastepnyMiescia());
          textBoxNaNastepnyRoznica.Text=d2s(analizator.roznicaNaNastepnyMiesiac());
        }
        else
        {
          analizator.WyroznicKategorieZPoprzedniegoMiesiaca = false;  
          ukryjWizibloki();
        }

        textBoxWplywyStan.Text=d2s(analizator.stanWplywow());
        textBoxWplywyPlan.Text=d2s(analizator.planWplywow());
        textBoxWplywyRoznica.Text=d2s(analizator.roznicaWplywow());
        textBoxWydatkiStan.Text=d2s(analizator.stanWydatkow());
        textBoxWydatkiPlan.Text=d2s(analizator.planWydatkow());
        textBoxWydatkiRoznica.Text=d2s(analizator.roznicaWydatkow());
        textBoxBilansStan.Text=d2s(analizator.stanBilans());
        textBoxBilansPlan.Text=d2s(analizator.planBilans());
        textBoxBilansRoznica.Text=d2s(analizator.roznicaBilansu());
        
        Hashtable mieszki = analizator.pobierzAnalizeMieszkow();
        dataTable.Rows.Clear();
        ICollection keys = mieszki.Keys;
        foreach(string mieszek in keys)
        {
          DataRow r = dataTable.NewRow();
          r["Mieszek"] = mieszek;
          r["Stan"] = (double) mieszki[mieszek];
          dataTable.Rows.Add(r);
        }
      labelSumaMieszkow.Text="Razem: "+d2s(analizator.stanMieszkow());        
      }
    }
    
    private void wyzerujWszystko()
    {
      textBoxWplywyStan.Text="";
      textBoxWplywyPlan.Text="";
      textBoxWplywyRoznica.Text="";
      textBoxWydatkiStan.Text="";
      textBoxWydatkiPlan.Text="";
      textBoxWydatkiRoznica.Text="";
      textBoxBilansStan.Text="";
      textBoxBilansPlan.Text="";
      textBoxBilansRoznica.Text="";
      labelSumaMieszkow.Text="Razem:     z³";
    }
    
    private string d2s(double d)
    {
      return String.Format("{0,10:C}",d);
    }

    private void PanelMieszkiBilans_Enter(object sender, System.EventArgs e)
    {
      refresh();
    }
    
    private void ukryjWizibloki()
    {
      foreach (Control c in wizibloki) c.Visible=false;
    }
    
    private void odkryjWizibloki()
    {
      foreach (Control c in wizibloki) c.Visible=true;
    }

    private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
    {
      refresh();    
    }
	}
}
