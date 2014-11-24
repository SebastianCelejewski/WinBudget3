using System;
using System.Windows.Forms;

namespace WinBud¿et_3
{
	/// <summary>
	/// Summary description for CellDateTimeExporter.
	/// </summary>
	public class CellDateTimeExporter:CellExporter
	{
	
    protected override int setMinWidth() { return DateTime.Now.ToShortDateString().Length; }
    protected override Type setType() { return typeof(System.DateTime); }
    protected override HorizontalAlignment setAlignment() { return HorizontalAlignment.Left; }
    protected override int updateWidth(Object o, int width) { return width; }
    protected override string makeString(Object o) 
    { 
      try
      {
        return ((DateTime) o).ToShortDateString(); 
      } catch (Exception ex)
      {
        MessageBox.Show("To nie da siê castowaæ!\n"+o.ToString()+"\n"+ex.Message);
        return "!!!";
      }
    }
	}
}
