using System;
using System.Windows.Forms;

namespace WinBud¿et_3
{
	/// <summary>
	/// Summary description for CellStringExporter.
	/// </summary>
	public class CellStringExporter:CellExporter
	{
    protected override int setMinWidth() { return 0; }
    protected override Type setType() { return typeof(System.String); }
    protected override HorizontalAlignment setAlignment() { return HorizontalAlignment.Left; }
    protected override int updateWidth(Object o, int width) 
    { 
      string s;
      try { s = (String) o; } catch (Exception ex) { s = "(null)"; }
      if (s.Length>width) return s.Length; else return width; 
    }		
    
    protected override string makeString(Object o) 
    { 
      string s;
      try { s = (String) o; } catch (Exception) { s = "(null)"; }
      return textSeparator+s.Clone().ToString().Replace(" ",space)+textSeparator; }
	}
}
