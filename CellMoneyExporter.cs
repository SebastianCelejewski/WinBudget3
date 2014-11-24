using System;
using System.Windows.Forms;

namespace WinBud¿et_3
{
	/// <summary>
	/// Summary description for CellMoneyExporter.
	/// </summary>
  public class CellMoneyExporter:CellExporter
  {
    protected override int setMinWidth() { return String.Format("{0,10:C}",0.0).Length; }
    protected override Type setType() { return typeof(System.Double); }
    protected override HorizontalAlignment setAlignment() { return HorizontalAlignment.Right; }
    protected override int updateWidth(Object o, int width) { return width; }
    protected override string makeString(Object o) 
    { 
      string s = String.Format("{0,10:C}",(double) o);
      if ((double) o==0) s = zero;
      if (s.Equals("-")) s=zero;
      return s;  
    }
	}
}
