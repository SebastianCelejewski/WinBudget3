using System;
using System.Windows.Forms;

namespace WinBud¿et_3
{
	/// <summary>
	/// Summary description for VerticalBox.
	/// </summary>
	public class VerticalBox
	{
	  private Control topElement;
	  private Control bottomElement;
	  private Control parent;
	  
	  public Control TopElement
	  {
	    get { return this.topElement; }
	    set { this.topElement = value; }
	  }
	  
	  public Control BottomElement
	  {
	    get { return this.bottomElement; }
	    set { this.bottomElement = value; }
	  }
	  
	  public Control Parent
	  {
	    get { return this.parent; }
	    set { this.parent = value; }
	  }
	
		public VerticalBox(Control parent, Control topElement, Control bottomElement)
		{
		  this.parent = parent;
		  this.topElement = topElement;
		  this.bottomElement = bottomElement;
		}
		
		public VerticalBox()
	  {
	  
	  }
		
		public void doResize()
		{
		  int szer = parent.Width;
		  int wys = parent.Height;
		  int pol = wys/2;
      topElement.Location = new System.Drawing.Point(0,0);
      bottomElement.Location = new System.Drawing.Point(0,pol);
      topElement.Width=szer;
      topElement.Height=pol;
      bottomElement.Width=szer;
      bottomElement.Height=pol;
		}
	}
}
