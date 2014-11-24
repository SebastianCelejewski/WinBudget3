using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WinBud¿et_3
{
	/// <summary>
	/// Summary description for PanelRealizacjaPlanow.
	/// </summary>
	public class PanelRealizacjaPlanow : System.Windows.Forms.UserControl
	{
    private Analizator analizator;
    private WinBud¿et_3.GridAnalizyPlanow gridAnalizyPlanow1;
    private WinBud¿et_3.GridAnalizyPlanow gridAnalizyPlanow2;
    private VerticalBox verticalBox = new VerticalBox();
    
    public Analizator Analizator
    {
      get { return this.analizator; }
      set 
      { 
        this.analizator = value; 
        if (gridAnalizyPlanow1!=null) gridAnalizyPlanow1.Analizator = value;
        if (gridAnalizyPlanow2!=null) gridAnalizyPlanow2.Analizator = value;
      }
    }
    
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PanelRealizacjaPlanow()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			verticalBox.Parent = this;
			verticalBox.TopElement = gridAnalizyPlanow1;
			verticalBox.BottomElement = gridAnalizyPlanow2;
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
      this.gridAnalizyPlanow1 = new WinBud¿et_3.GridAnalizyPlanow();
      this.gridAnalizyPlanow2 = new WinBud¿et_3.GridAnalizyPlanow();
      this.SuspendLayout();
      // 
      // gridAnalizyPlanow1
      // 
      this.gridAnalizyPlanow1.Analizator = null;
      this.gridAnalizyPlanow1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.gridAnalizyPlanow1.CaptionBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.gridAnalizyPlanow1.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
      this.gridAnalizyPlanow1.CaptionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.gridAnalizyPlanow1.CaptionText = "Analiza planowanych wp³ywów";
      this.gridAnalizyPlanow1.JestemWplywem = true;
      this.gridAnalizyPlanow1.Location = new System.Drawing.Point(0, 16);
      this.gridAnalizyPlanow1.Name = "gridAnalizyPlanow1";
      this.gridAnalizyPlanow1.Size = new System.Drawing.Size(640, 192);
      this.gridAnalizyPlanow1.TabIndex = 0;
      // 
      // gridAnalizyPlanow2
      // 
      this.gridAnalizyPlanow2.Analizator = null;
      this.gridAnalizyPlanow2.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.gridAnalizyPlanow2.CaptionBackColor = System.Drawing.SystemColors.ActiveCaption;
      this.gridAnalizyPlanow2.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
      this.gridAnalizyPlanow2.CaptionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.gridAnalizyPlanow2.CaptionText = "Analiza planowanych wydatków";
      this.gridAnalizyPlanow2.JestemWplywem = false;
      this.gridAnalizyPlanow2.Location = new System.Drawing.Point(0, 232);
      this.gridAnalizyPlanow2.Name = "gridAnalizyPlanow2";
      this.gridAnalizyPlanow2.Size = new System.Drawing.Size(640, 152);
      this.gridAnalizyPlanow2.TabIndex = 1;
      // 
      // PanelRealizacjaPlanow
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.gridAnalizyPlanow2,
                                                                  this.gridAnalizyPlanow1});
      this.Name = "PanelRealizacjaPlanow";
      this.Size = new System.Drawing.Size(640, 480);
      this.Resize += new System.EventHandler(this.PanelRealizacjaPlanow_Resize);
      this.ResumeLayout(false);

    }
		#endregion

		public void refresh()
		{
		  gridAnalizyPlanow1.refresh();
      gridAnalizyPlanow2.refresh();
    }

    private void PanelRealizacjaPlanow_Resize(object sender, System.EventArgs e)
    {
      verticalBox.doResize();    
    }
	}
}
