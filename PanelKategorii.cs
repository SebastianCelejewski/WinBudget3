using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WinBud¿et_3
{
	/// <summary>
	/// Summary description for PanelKategorii.
	/// </summary>
	public class PanelKategorii : System.Windows.Forms.UserControl
	{
	  private Tulkit tulkit;
	  private Analizator analizator;
	  private VerticalBox verticalBox;
	  
	  public Tulkit Tulkit
	  {
	    get { return tulkit; }
	    set
	    {
	      tulkit = value;
	      gridyKategoriiWplywow.Tulkit = value;
	      gridyKategoriiWydatkow.Tulkit = value;
	    }
    }
    
    public Analizator Analizator
    {
      get { return analizator; }
      set 
      {
        analizator = value;
        gridyKategoriiWplywow.Analizator = value;
        gridyKategoriiWydatkow.Analizator = value;
      }
     }
	   
	
    private WinBud¿et_3.GridyKategorii gridyKategoriiWplywow;
    private WinBud¿et_3.GridyKategorii gridyKategoriiWydatkow;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PanelKategorii()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			verticalBox = new VerticalBox(this,gridyKategoriiWplywow,gridyKategoriiWydatkow);
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
      this.gridyKategoriiWplywow = new WinBud¿et_3.GridyKategorii();
      this.gridyKategoriiWydatkow = new WinBud¿et_3.GridyKategorii();
      this.SuspendLayout();
      // 
      // gridyKategoriiWplywow
      // 
      this.gridyKategoriiWplywow.Analizator = null;
      this.gridyKategoriiWplywow.CaptionBackColorKategorii = System.Drawing.SystemColors.ActiveCaption;
      this.gridyKategoriiWplywow.CaptionBackColorSzczegolow = System.Drawing.SystemColors.ActiveCaption;
      this.gridyKategoriiWplywow.CaptionFontKategorii = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
      this.gridyKategoriiWplywow.CaptionFontSzczegolow = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
      this.gridyKategoriiWplywow.CaptionForeColorKategorii = System.Drawing.SystemColors.ActiveCaptionText;
      this.gridyKategoriiWplywow.CaptionForeColorSzczegolow = System.Drawing.SystemColors.ActiveCaptionText;
      this.gridyKategoriiWplywow.CaptionTextKategorii = "Kategorie wp³ywów";
      this.gridyKategoriiWplywow.CaptionTextSzczegolow = "Szczegó³y";
      this.gridyKategoriiWplywow.JestemWplywem = true;
      this.gridyKategoriiWplywow.Name = "gridyKategoriiWplywow";
      this.gridyKategoriiWplywow.Size = new System.Drawing.Size(568, 200);
      this.gridyKategoriiWplywow.TabIndex = 0;
      this.gridyKategoriiWplywow.Tulkit = null;
      // 
      // gridyKategoriiWydatkow
      // 
      this.gridyKategoriiWydatkow.Analizator = null;
      this.gridyKategoriiWydatkow.CaptionBackColorKategorii = System.Drawing.SystemColors.ActiveCaption;
      this.gridyKategoriiWydatkow.CaptionBackColorSzczegolow = System.Drawing.SystemColors.ActiveCaption;
      this.gridyKategoriiWydatkow.CaptionFontKategorii = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
      this.gridyKategoriiWydatkow.CaptionFontSzczegolow = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
      this.gridyKategoriiWydatkow.CaptionForeColorKategorii = System.Drawing.SystemColors.ActiveCaptionText;
      this.gridyKategoriiWydatkow.CaptionForeColorSzczegolow = System.Drawing.SystemColors.ActiveCaptionText;
      this.gridyKategoriiWydatkow.CaptionTextKategorii = "Kategorie wydatków";
      this.gridyKategoriiWydatkow.CaptionTextSzczegolow = "Szczegó³y";
      this.gridyKategoriiWydatkow.JestemWplywem = false;
      this.gridyKategoriiWydatkow.Location = new System.Drawing.Point(0, 216);
      this.gridyKategoriiWydatkow.Name = "gridyKategoriiWydatkow";
      this.gridyKategoriiWydatkow.Size = new System.Drawing.Size(560, 224);
      this.gridyKategoriiWydatkow.TabIndex = 1;
      this.gridyKategoriiWydatkow.Tulkit = null;
      // 
      // PanelKategorii
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.gridyKategoriiWydatkow,
                                                                  this.gridyKategoriiWplywow});
      this.Name = "PanelKategorii";
      this.Size = new System.Drawing.Size(568, 440);
      this.Resize += new System.EventHandler(this.PanelKategorii_Resize);
      this.ResumeLayout(false);

    }
		#endregion
    
    public void refresh()
    {
      gridyKategoriiWplywow.refresh();
      gridyKategoriiWydatkow.refresh();
    }

    private void PanelKategorii_Resize(object sender, System.EventArgs e)
    {
      verticalBox.doResize();
      gridyKategoriiWplywow.resize();
      gridyKategoriiWydatkow.resize();
    }
	}
}
