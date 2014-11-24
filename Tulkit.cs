using System;
using System.Windows;
using System.Windows.Forms;

namespace WinBud¿et_3
{
	/// <summary>
	/// Summary description for Tulkit.
	/// </summary>
	public class Tulkit
	{
	  private RichTextBox debugTextBox;
	  private MainWindow mainWindow;
	  
	  public MainWindow MainWindow
	  {
	    get { return this.mainWindow; }
	    set 
	    { 
	      mainWindow = value; 
	    }
	  }
	  
	  public RichTextBox DebugTextBox
	  {
	    get { return this.debugTextBox; }
	    set { this.debugTextBox = value; }
	  }
	
		public Tulkit()
		{
		}

    public bool dialogTakNie(string pytanie)
    {
      MessageBoxButtons buttons = MessageBoxButtons.YesNo;
      DialogResult result = MessageBox.Show(pytanie, 
        "Jest pytanie", buttons, MessageBoxIcon.Question,
        MessageBoxDefaultButton.Button1);
      if (result==DialogResult.Yes) return true; else return false;
    }

    public int dialogTakNieAnuluj(string pytanie)
      // 0 - tak
      // 1 - nie
      // 2 - anuluj
    {
      MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
      DialogResult result = MessageBox.Show(pytanie, 
        "Jest pytanie", buttons, MessageBoxIcon.Question,
        MessageBoxDefaultButton.Button1);
      if (result==DialogResult.Yes) return 0; 
      else if (result==DialogResult.No) return 1;
      else return 2;
    }

    public void debug (string s) 
    { 
      debugTextBox.AppendText(s+"\n");  
    }
  
	
	}
}
