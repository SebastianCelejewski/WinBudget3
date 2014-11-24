using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WinBud¿et_3
{
	/// <summary>
	/// Summary description for PanelChronologii.
	/// </summary>
	public class PanelChronologii : System.Windows.Forms.UserControl
	{
    private Tulkit tulkit;
    private Analizator analizator;
    private VerticalBox verticalBox;

    private WinBud¿et_3.GridChronologii gridChronologii1;
    private WinBud¿et_3.GridChronologii gridChronologii2;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

    public Tulkit Tulkit
    {
      get { return this.tulkit; }
      set
      {
        this.tulkit = value;
        if (gridChronologii1!=null) gridChronologii1.Tulkit = value; 
        if (gridChronologii2!=null) gridChronologii2.Tulkit = value;
      }
    }

    public Analizator Analizator
    {
      get { return this.analizator; }
      set
      {
        this.analizator = value;
        if (gridChronologii1!=null) gridChronologii1.Analizator=value;
        if (gridChronologii2!=null) gridChronologii2.Analizator=value;
      }
    }

		public PanelChronologii()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			verticalBox = new VerticalBox(this,gridChronologii1,gridChronologii2);
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
      this.gridChronologii1 = new WinBud¿et_3.GridChronologii();
      this.gridChronologii2 = new WinBud¿et_3.GridChronologii();
      this.SuspendLayout();
      // 
      // gridChronologii1
      // 
      this.gridChronologii1.Analizator = null;
      this.gridChronologii1.CaptionBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.gridChronologii1.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
      this.gridChronologii1.CaptionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.gridChronologii1.CaptionText = "Chronologia wp³ywów";
      this.gridChronologii1.JestemWplywem = true;
      this.gridChronologii1.Name = "gridChronologii1";
      this.gridChronologii1.Size = new System.Drawing.Size(592, 272);
      this.gridChronologii1.TabIndex = 0;
      // 
      // gridChronologii2
      // 
      this.gridChronologii2.Analizator = null;
      this.gridChronologii2.CaptionBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.gridChronologii2.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
      this.gridChronologii2.CaptionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.gridChronologii2.CaptionText = "Chronologia wydatków";
      this.gridChronologii2.JestemWplywem = false;
      this.gridChronologii2.Location = new System.Drawing.Point(0, 272);
      this.gridChronologii2.Name = "gridChronologii2";
      this.gridChronologii2.Size = new System.Drawing.Size(592, 248);
      this.gridChronologii2.TabIndex = 1;
      // 
      // PanelChronologii
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.gridChronologii2,
                                                                  this.gridChronologii1});
      this.Name = "PanelChronologii";
      this.Size = new System.Drawing.Size(592, 520);
      this.Resize += new System.EventHandler(this.PanelChronologii_Resize);
      this.ResumeLayout(false);

    }
		#endregion
		
		public void refresh()
		{
		  gridChronologii1.refresh();
      gridChronologii2.refresh();
    }

    private void PanelChronologii_Resize(object sender, System.EventArgs e)
    {
      verticalBox.doResize();
    }
	}
}
