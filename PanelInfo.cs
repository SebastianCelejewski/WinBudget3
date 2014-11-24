using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WinBud¿et_3
{
	/// <summary>
	/// Summary description for PanelInfo.
	/// </summary>
	public class PanelInfo : System.Windows.Forms.UserControl
	{
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PanelInfo()
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
      this.label1 = new System.Windows.Forms.Label();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(8, 8);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(136, 24);
      this.label1.TabIndex = 0;
      this.label1.Text = "Nazwa bazy danych:";
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(160, 8);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(384, 22);
      this.textBox1.TabIndex = 1;
      this.textBox1.Text = "textBox1";
      // 
      // PanelInfo
      // 
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.textBox1,
                                                                  this.label1});
      this.Name = "PanelInfo";
      this.Size = new System.Drawing.Size(552, 472);
      this.ResumeLayout(false);

    }
		#endregion
	}
}
