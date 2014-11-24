using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WinBud¿et_3
{
	/// <summary>
	/// Summary description for DataGridExporter.
	/// </summary>
	public class DataGridExporter : System.Windows.Forms.Form
	{
	  private DataTable dataTable;
    private CellExporter[] eksportery;
	  private int dlugosc;
	  private string sepTekstu, zamiennik, zeraNa, sepLiczb;
	
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.RadioButton radioButton1;
    private System.Windows.Forms.RadioButton radioButton2;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button buttonCopyToClipboard;
    private System.Windows.Forms.Button buttonSaveToFile;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.SaveFileDialog saveFileDialog;
    private System.Windows.Forms.RichTextBox richTextBox;
    private System.Windows.Forms.CheckBox checkBoxSpacja;
    private System.Windows.Forms.CheckBox checkBoxSeparator;
    private System.Windows.Forms.CheckBox checkBoxTekst;
    private System.Windows.Forms.TextBox textBoxSpacja;
    private System.Windows.Forms.TextBox textBoxTekst;
    private System.Windows.Forms.TextBox textBoxSeparator;
    private System.Windows.Forms.CheckBox checkBoxZera;
    private System.Windows.Forms.TextBox textBoxZera;
    private System.Windows.Forms.ProgressBar progressBar1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DataGridExporter()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.radioButton2 = new System.Windows.Forms.RadioButton();
      this.radioButton1 = new System.Windows.Forms.RadioButton();
      this.buttonCopyToClipboard = new System.Windows.Forms.Button();
      this.buttonSaveToFile = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.textBoxZera = new System.Windows.Forms.TextBox();
      this.checkBoxZera = new System.Windows.Forms.CheckBox();
      this.checkBoxSpacja = new System.Windows.Forms.CheckBox();
      this.checkBoxSeparator = new System.Windows.Forms.CheckBox();
      this.checkBoxTekst = new System.Windows.Forms.CheckBox();
      this.textBoxSpacja = new System.Windows.Forms.TextBox();
      this.textBoxTekst = new System.Windows.Forms.TextBox();
      this.textBoxSeparator = new System.Windows.Forms.TextBox();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.richTextBox = new System.Windows.Forms.RichTextBox();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.radioButton2,
                                                                            this.radioButton1});
      this.groupBox1.Location = new System.Drawing.Point(8, 8);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(448, 80);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Format danych";
      // 
      // radioButton2
      // 
      this.radioButton2.Checked = true;
      this.radioButton2.Location = new System.Drawing.Point(8, 48);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new System.Drawing.Size(384, 24);
      this.radioButton2.TabIndex = 1;
      this.radioButton2.TabStop = true;
      this.radioButton2.Text = "Dane w formacie CSV";
      this.radioButton2.CheckedChanged += new System.EventHandler(this.odswiez);
      // 
      // radioButton1
      // 
      this.radioButton1.Location = new System.Drawing.Point(8, 24);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new System.Drawing.Size(384, 24);
      this.radioButton1.TabIndex = 0;
      this.radioButton1.Text = "Tekst sformatowany tabulacjami";
      this.radioButton1.CheckedChanged += new System.EventHandler(this.odswiez);
      // 
      // buttonCopyToClipboard
      // 
      this.buttonCopyToClipboard.Location = new System.Drawing.Point(328, 104);
      this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
      this.buttonCopyToClipboard.Size = new System.Drawing.Size(128, 32);
      this.buttonCopyToClipboard.TabIndex = 8;
      this.buttonCopyToClipboard.Text = "Kopiuj do schowka";
      this.buttonCopyToClipboard.Click += new System.EventHandler(this.button1_Click);
      // 
      // buttonSaveToFile
      // 
      this.buttonSaveToFile.Location = new System.Drawing.Point(328, 144);
      this.buttonSaveToFile.Name = "buttonSaveToFile";
      this.buttonSaveToFile.Size = new System.Drawing.Size(128, 32);
      this.buttonSaveToFile.TabIndex = 3;
      this.buttonSaveToFile.Text = "Zapisz do pliku";
      this.buttonSaveToFile.Click += new System.EventHandler(this.button2_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.textBoxZera,
                                                                            this.checkBoxZera,
                                                                            this.checkBoxSpacja,
                                                                            this.checkBoxSeparator,
                                                                            this.checkBoxTekst,
                                                                            this.textBoxSpacja,
                                                                            this.textBoxTekst,
                                                                            this.textBoxSeparator});
      this.groupBox2.Location = new System.Drawing.Point(8, 96);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(312, 120);
      this.groupBox2.TabIndex = 4;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Znaki formatuj¹ce";
      // 
      // textBoxZera
      // 
      this.textBoxZera.Location = new System.Drawing.Point(264, 88);
      this.textBoxZera.Name = "textBoxZera";
      this.textBoxZera.Size = new System.Drawing.Size(40, 22);
      this.textBoxZera.TabIndex = 9;
      this.textBoxZera.Text = "-";
      this.textBoxZera.TextChanged += new System.EventHandler(this.odswiez);
      // 
      // checkBoxZera
      // 
      this.checkBoxZera.Location = new System.Drawing.Point(16, 88);
      this.checkBoxZera.Name = "checkBoxZera";
      this.checkBoxZera.Size = new System.Drawing.Size(248, 24);
      this.checkBoxZera.TabIndex = 8;
      this.checkBoxZera.Text = "W pola zawieraj¹ce zera wpisz znak:";
      this.checkBoxZera.CheckedChanged += new System.EventHandler(this.odswiez);
      // 
      // checkBoxSpacja
      // 
      this.checkBoxSpacja.Location = new System.Drawing.Point(16, 64);
      this.checkBoxSpacja.Name = "checkBoxSpacja";
      this.checkBoxSpacja.Size = new System.Drawing.Size(232, 24);
      this.checkBoxSpacja.TabIndex = 6;
      this.checkBoxSpacja.Text = "Zamieñ w tekœcie spacje na";
      this.checkBoxSpacja.CheckedChanged += new System.EventHandler(this.odswiez);
      // 
      // checkBoxSeparator
      // 
      this.checkBoxSeparator.Location = new System.Drawing.Point(16, 16);
      this.checkBoxSeparator.Name = "checkBoxSeparator";
      this.checkBoxSeparator.Size = new System.Drawing.Size(232, 24);
      this.checkBoxSeparator.TabIndex = 2;
      this.checkBoxSeparator.Text = "Separator pól";
      this.checkBoxSeparator.CheckedChanged += new System.EventHandler(this.odswiez);
      // 
      // checkBoxTekst
      // 
      this.checkBoxTekst.Checked = true;
      this.checkBoxTekst.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkBoxTekst.Location = new System.Drawing.Point(16, 40);
      this.checkBoxTekst.Name = "checkBoxTekst";
      this.checkBoxTekst.Size = new System.Drawing.Size(232, 24);
      this.checkBoxTekst.TabIndex = 4;
      this.checkBoxTekst.Text = "Pocz¹tek i koniec tekstu";
      this.checkBoxTekst.CheckedChanged += new System.EventHandler(this.odswiez);
      // 
      // textBoxSpacja
      // 
      this.textBoxSpacja.Location = new System.Drawing.Point(264, 64);
      this.textBoxSpacja.Name = "textBoxSpacja";
      this.textBoxSpacja.Size = new System.Drawing.Size(40, 22);
      this.textBoxSpacja.TabIndex = 7;
      this.textBoxSpacja.Text = "_";
      this.textBoxSpacja.TextChanged += new System.EventHandler(this.odswiez);
      // 
      // textBoxTekst
      // 
      this.textBoxTekst.Location = new System.Drawing.Point(264, 40);
      this.textBoxTekst.Name = "textBoxTekst";
      this.textBoxTekst.Size = new System.Drawing.Size(40, 22);
      this.textBoxTekst.TabIndex = 5;
      this.textBoxTekst.Text = "\"";
      this.textBoxTekst.TextChanged += new System.EventHandler(this.odswiez);
      // 
      // textBoxSeparator
      // 
      this.textBoxSeparator.Location = new System.Drawing.Point(264, 16);
      this.textBoxSeparator.Name = "textBoxSeparator";
      this.textBoxSeparator.Size = new System.Drawing.Size(40, 22);
      this.textBoxSeparator.TabIndex = 3;
      this.textBoxSeparator.Text = ";";
      this.textBoxSeparator.TextChanged += new System.EventHandler(this.odswiez);
      // 
      // buttonCancel
      // 
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(328, 184);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(128, 32);
      this.buttonCancel.TabIndex = 5;
      this.buttonCancel.Text = "Anuluj";
      this.buttonCancel.Click += new System.EventHandler(this.button3_Click);
      // 
      // saveFileDialog
      // 
      this.saveFileDialog.DefaultExt = "txt";
      this.saveFileDialog.FileName = "tabela1";
      this.saveFileDialog.Title = "Zapisz dane do pliku";
      // 
      // richTextBox
      // 
      this.richTextBox.Location = new System.Drawing.Point(8, 224);
      this.richTextBox.Name = "richTextBox";
      this.richTextBox.Size = new System.Drawing.Size(448, 160);
      this.richTextBox.TabIndex = 6;
      this.richTextBox.Text = "";
      this.richTextBox.WordWrap = false;
      // 
      // progressBar1
      // 
      this.progressBar1.Location = new System.Drawing.Point(8, 296);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(448, 23);
      this.progressBar1.TabIndex = 9;
      // 
      // DataGridExporter
      // 
      this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
      this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
      this.CancelButton = this.buttonCancel;
      this.ClientSize = new System.Drawing.Size(464, 392);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.richTextBox,
                                                                  this.buttonCancel,
                                                                  this.groupBox2,
                                                                  this.buttonSaveToFile,
                                                                  this.buttonCopyToClipboard,
                                                                  this.groupBox1,
                                                                  this.progressBar1});
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DataGridExporter";
      this.ShowInTaskbar = false;
      this.Text = "Eksport danych z tabeli";
      this.TopMost = true;
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		#endregion
		
		public void export(DataTable dataTable)
		{
      this.Show();
      this.dataTable = dataTable;
      przygotujTekst();
		}

    private void button1_Click(object sender, System.EventArgs e)
    {
      Clipboard.SetDataObject(this.richTextBox.Text,true);
      zamknij();
    }

    private void button2_Click(object sender, System.EventArgs e)
    {
      saveFileDialog.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*"  ;
      saveFileDialog.FilterIndex = 1 ;
      saveFileDialog.RestoreDirectory = true ;
      saveFileDialog.Title="Eksport tabeli do pliku tekstowego";
      if(saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        try
        {
          richTextBox.SaveFile(saveFileDialog.FileName,System.Windows.Forms.RichTextBoxStreamType.PlainText);
        } catch (Exception ex)
        {
          MessageBox.Show("Nie potrafiê zapisaæ danych do pliku.\n"+ex.Message);
        }
        zamknij();
      }
    }

    private void button3_Click(object sender, System.EventArgs e)
    {
      zamknij();
    }
    
    private void zamknij()
    {
      this.Hide();
    }
    
    private void przygotujTekst()
    {
      println("Zaraz bêdzie...");
      richTextBox.Clear();
      richTextBox.Visible=false;
      if (radioButton1.Checked) richTextBox.Font = new System.Drawing.Font("Courier",8);
      else richTextBox.Font = new System.Drawing.Font("Times",8);
      sepLiczb = textBoxSeparator.Text;
      if (!checkBoxSeparator.Checked) sepLiczb = " ";
      progressBar1.Minimum=0;
      progressBar1.Maximum=dataTable.Rows.Count*2;
      progressBar1.Value=0;

      sepTekstu = textBoxTekst.Text;
      if (!checkBoxTekst.Checked) sepTekstu = "";
      
      zamiennik = textBoxSpacja.Text;
      if (!checkBoxSpacja.Checked) zamiennik = " ";
      
      zeraNa = textBoxZera.Text;
      if (!checkBoxZera.Checked) zeraNa = String.Format("{0,10:C}",0);
      
      string[] nazwyKolumn = new string[dataTable.Columns.Count];
      int licznik=0;

      licznik = 0;
      foreach (DataColumn dc in dataTable.Columns)
        nazwyKolumn[licznik++]=dc.Caption;

      eksportery = new CellExporter[dataTable.Columns.Count];
      licznik = 0;
      foreach (DataColumn dc in dataTable.Columns)
      {
        if (dc.DataType.Equals(typeof (System.DateTime))) eksportery[licznik] = new CellDateTimeExporter();
        if (dc.DataType.Equals(typeof (System.Double))) eksportery[licznik] = new CellMoneyExporter();
        if (dc.DataType.Equals(typeof (System.String))) eksportery[licznik] = new CellStringExporter();
        eksportery[licznik].Caption=dc.Caption;
        eksportery[licznik].ColumnSeparator=sepLiczb;
        eksportery[licznik].TextSeparator=sepTekstu;
        eksportery[licznik].SpaceString=zamiennik;
        eksportery[licznik].ZeroString=zeraNa;
        licznik++;
      }
      
      foreach (DataRow dr in dataTable.Rows)
      {
        for (int i=0;i<nazwyKolumn.Length;i++)
        {
          eksportery[i].addObject(dr[nazwyKolumn[i]]);
        }
        progressBar1.Value++;
      }        

      for (int i=0;i<nazwyKolumn.Length;i++)
        if (radioButton1.Checked) print(eksportery[i].formatCaption());
                         else print(eksportery[i].nonFormatCaption());


      println("");

      for (int i=0;i<dataTable.Rows.Count;i++)
      {
        for (int j=0;j<eksportery.Length;j++)
          if (radioButton1.Checked) print(eksportery[j].formatObject(i));
          else print(eksportery[j].nonFormatObject(i));
        println("");
        progressBar1.Value++;
      }
      richTextBox.Visible=true;
    }
    
    private void print(string s) { richTextBox.AppendText(s); }
    private void println(string s) { print(s+"\n"); }

    private void odswiez(object sender, System.EventArgs e)
    {
      przygotujTekst();
    }
    
    private void print(string s, int l)
    {
      string ss = new string(s.ToCharArray());
      while (ss.Length<l) ss=" "+ss;
      print(ss);
    }

    private void p(string s)
    {
      if (radioButton1.Checked) print(s,dlugosc); else print(s);
    }
  }
}
