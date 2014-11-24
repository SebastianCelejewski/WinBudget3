using System;
using System.Windows;
using System.Windows.Forms;
using System.Data;

namespace WinBud¿et_3
{

	/// <summary>
	/// Summary description for DataGridContextMenu.
	/// </summary>
	public class DataGridContextMenu : ContextMenu
	{
    private System.Windows.Forms.MenuItem menuItem1;
    private System.Windows.Forms.MenuItem menuItem2;
    private System.Windows.Forms.MenuItem menuItem3;
    
    private DataGridExporter exporter;
    private DataTable dataTable;

    public DataGridContextMenu(DataTable dataTable)
	  {
	    this.dataTable = dataTable;
	    
      this.menuItem1 = new System.Windows.Forms.MenuItem();
      this.menuItem2 = new System.Windows.Forms.MenuItem();
      this.menuItem3 = new System.Windows.Forms.MenuItem();

      this.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                this.menuItem1});
      // 
      // menuItem1
      // 
      this.menuItem1.Index = 0;
      this.menuItem1.Text = "Eksport danych";
      this.menuItem1.Click += new System.EventHandler(this.menuItemExport_Click);
        
	   }
	   
    private void menuItemExport_Click(object sender,System.EventArgs e)
    {
      DataGridExporter exporter = new DataGridExporter();
      exporter.export(dataTable);
    }
	}
}
