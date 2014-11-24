using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WinBud¿et_3
{
	/// <summary>
	/// Summary description for ProgressForm.
	/// </summary>
	public class ProgressForm : System.Windows.Forms.Form
	{
	
	  public int Minimum
	  {
	    get { return progressBar.Minimum; }
	    set { progressBar.Minimum = value; }
	  }
	  
	  public int Maximum
	  {
	    get { return progressBar.Maximum; }
	    set { progressBar.Maximum = value; }
	  }
	  
	  public int Value
	  {
	    get { return progressBar.Value; }
	    set 
	    { 
	      progressBar.Value = value; 
	      this.Refresh();
	    }
	  }
	  
	  public string LabelText
	  {
	    get { return label.Text; }
	    set 
	    { 
	      label.Text = value; 
	      this.Refresh();
	    }
	  }
	
    private System.Windows.Forms.Label label;
    private System.Windows.Forms.ProgressBar progressBar;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ProgressForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.label = new System.Windows.Forms.Label();
      this.progressBar = new System.Windows.Forms.ProgressBar();
      this.SuspendLayout();
      // 
      // label
      // 
      this.label.Location = new System.Drawing.Point(8, 0);
      this.label.Name = "label";
      this.label.Size = new System.Drawing.Size(448, 32);
      this.label.TabIndex = 0;
      this.label.Text = "Proszê czekaæ - analizowanie danych";
      this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // progressBar
      // 
      this.progressBar.Location = new System.Drawing.Point(0, 32);
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(464, 32);
      this.progressBar.TabIndex = 1;
      // 
      // ProgressForm
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
      this.ClientSize = new System.Drawing.Size(464, 64);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.progressBar,
                                                                  this.label});
      this.Name = "ProgressForm";
      this.Text = "ProgressForm";
      this.ResumeLayout(false);

    }
		#endregion
	}
}
