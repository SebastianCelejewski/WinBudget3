using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace WinBud�et_3
{

  public class DataStyle:DataGridColumnStyle
  {
    //
    // Creates a combo box column on a data grid
    // all cells in the column have the same data source

    //
    // UI constants    
    //
    private int xMargin = 2;
    private int yMargin = 1;
    private ComboBox Combo;
		
    //
    // Used to track editing state
    //

    private string OldVal=new string(string.Empty.ToCharArray());
    private bool InEdit= false;

    //
    // Create a new column - DisplayMember, ValueMember
    // Passed by ordinal 

    public DataStyle()
    {
      ArrayList daty = new ArrayList();
      int rok = DateTime.Now.Year;
      int miesiac = DateTime.Now.Month;
      int dzien = DateTime.Now.Day;
      for (int dz=dzien;dz>0;dz--) daty.Add((new DateTime(rok,miesiac,dz)).ToShortDateString());

      Combo = new ComboBox();
      Combo.Visible=false;
      Combo.DataSource = daty;
      Combo.DropDownStyle = ComboBoxStyle.DropDown;
    }

    //------------------------------------------------------
    // Methods overridden from DataGridColumnStyle
    //------------------------------------------------------
    //
    // Abort Changes
    //
    protected override void Abort(int RowNum)
    {
      System.Diagnostics.Debug.WriteLine("Abort()");
      RollBack();
      HideComboBox();
      EndEdit();
    }
    //
    // Commit Changes
    //
    protected override bool Commit(CurrencyManager DataSource,int RowNum)
    {
      HideComboBox();
      if(!InEdit)
      {
        return true;
      }

      try
      {
        SetColumnValueAtRow(DataSource, RowNum, DateTime.Now.Date);
        return true;
      }
      catch (Exception ex)
      {
        MessageBox.Show("Wyjatek przy commit:\n"+ex.Message+"\n"+ex.StackTrace);
        return false;
      }      
/*		
		  DateTime dataDoZwrotu;
		  try 
		  { 
		     dataDoZwrotu = DateTime.Parse(Combo.Text); 
		     SetColumnValueAtRow(DataSource, RowNum, dataDoZwrotu);
         this.EndEdit();
         return true;
      }
		  catch (Exception) 
		  { 
		     RollBack();
		     return false;
		  };
*/		  
		
    }

    //
    // Remove focus
    //
    protected override void ConcedeFocus()
    {
      //HideComboBox();
      Combo.Visible=false;
    }

    //
    // Edit Grid
    //
    protected override void Edit(CurrencyManager Source ,int Rownum,Rectangle Bounds, bool ReadOnly,string InstantText, bool CellIsVisible)
    {
      Combo.Text = string.Empty;
      Rectangle OriginalBounds = Bounds;
      OldVal = Combo.Text;
	
      if(CellIsVisible)
      {
        Bounds.Offset(xMargin, yMargin);
        Bounds.Width -= xMargin * 2;
        Bounds.Height -= yMargin;
        Combo.Bounds = Bounds;
        Combo.Visible = true;
      }
      else
      {
        Combo.Bounds = OriginalBounds;
        Combo.Visible = false;
      }

      string tekst = DateTime.Now.ToShortDateString();
      object wartosc = GetColumnValueAtRow(Source,Rownum);
      if (!wartosc.Equals(System.DBNull.Value))
      tekst = ((DateTime)wartosc).ToShortDateString();
      Combo.Text = tekst;
			
      if(InstantText!=null)
      {
        Combo.Text = InstantText;
      }
      Combo.RightToLeft = this.DataGridTableStyle.DataGrid.RightToLeft;
      Combo.Focus();
			
      if(InstantText==null)
      {
        Combo.SelectAll();
				
        // Pre-selects an item in the combo when user tries to add
        // a new record by moving the columns using tab.

        // Combo.SelectedIndex = 0;
      }
      else
      {
        int End = Combo.Text.Length;
        Combo.Select(End, 0);
      }

      if(Combo.Visible)
      {
        DataGridTableStyle.DataGrid.Invalidate(OriginalBounds);
      }

      InEdit = true;
    }
    protected override int GetMinimumHeight()
    {
      //
      // Set the minimum height to the height of the combobox
      //
      return Combo.PreferredHeight + yMargin;
    }

    protected override int GetPreferredHeight(Graphics g ,object Value)
    {
      System.Diagnostics.Debug.WriteLine("GetPreferredHeight()");
      int NewLineIndex  = 0;
      int NewLines = 0;
      string ValueString = this.GetText(Value);
      do
      {
        NewLineIndex = ValueString.IndexOf("r\n", NewLineIndex + 1);
        NewLines += 1;
      }while(NewLineIndex != -1);
      return FontHeight * NewLines + yMargin;
    }
    protected override Size GetPreferredSize(Graphics g, object Value)
    {
      Size Extents = Size.Ceiling(g.MeasureString(GetText(Value), this.DataGridTableStyle.DataGrid.Font));
      Extents.Width += xMargin * 2 + DataGridTableGridLineWidth ;
      Extents.Height += yMargin;
      return Extents;
    }
    protected override void Paint(Graphics g,Rectangle Bounds,CurrencyManager Source,int RowNum)
    {
      Paint(g, Bounds, Source, RowNum, false);
    }
    protected override void Paint(Graphics g,Rectangle Bounds,CurrencyManager Source,int RowNum,bool AlignToRight)
    {
      string Text = GetText(GetColumnValueAtRow(Source, RowNum));
      PaintText(g, Bounds, Text, AlignToRight);
    }
    protected override void Paint(Graphics g,Rectangle Bounds,CurrencyManager Source,int RowNum,Brush BackBrush ,Brush ForeBrush ,bool AlignToRight)
    {
      string Text = GetText(GetColumnValueAtRow(Source, RowNum));
      PaintText(g, Bounds, Text, BackBrush, ForeBrush, AlignToRight);
    }
    protected override void SetDataGridInColumn(DataGrid Value)
    {
      base.SetDataGridInColumn(Value);
      if(Combo.Parent!=Value)
      {
        if(Combo.Parent!=null)
        {
          Combo.Parent.Controls.Remove(Combo);
        }
      }
      if(Value!=null) 
      {
        Value.Controls.Add(Combo);
      }
    }
    protected override void UpdateUI(CurrencyManager Source,int RowNum, string InstantText)
    {
      Combo.Text = GetText(GetColumnValueAtRow(Source, RowNum));
      if(InstantText!=null)
      {
        Combo.Text = InstantText;
      }
    }															 
    //----------------------------------------------------------------------
    // Helper Methods 
    //----------------------------------------------------------------------
    private int DataGridTableGridLineWidth
    {
      get
      {
        if(this.DataGridTableStyle.GridLineStyle == DataGridLineStyle.Solid) 
        { 
          return 1;
        }
        else
        {
          return 0;
        }
      }
    }
    public void EndEdit()
    {
      InEdit = false;
      Invalidate();
    }

    private string GetText(object Value)
    {
      if(Value==System.DBNull.Value)
      {
        return NullText;
      }
      if(Value!=null)
      {
        return Value.ToString();
      }
      else
      {
        return string.Empty;
      }
    }
		
    private void HideComboBox()
    {
      if(Combo.Focused)
      {
        this.DataGridTableStyle.DataGrid.Focus();
      }
      Combo.Visible = false;
    }
    private void RollBack()
    {
      Combo.Text = OldVal;
      //EndEdit();
    }
    private void PaintText(Graphics g ,Rectangle Bounds,string Text,bool AlignToRight)
    {
      Brush BackBrush = new SolidBrush(this.DataGridTableStyle.BackColor);
      Brush ForeBrush= new SolidBrush(this.DataGridTableStyle.ForeColor);
      PaintText(g, Bounds, Text, BackBrush, ForeBrush, AlignToRight);
    }
    private void PaintText(Graphics g , Rectangle TextBounds, string Text, Brush BackBrush,Brush ForeBrush,bool AlignToRight)
    {	
      Rectangle Rect = TextBounds;
      RectangleF RectF  = Rect; 
      StringFormat Format = new StringFormat();
      if(AlignToRight)
      {
        Format.FormatFlags = StringFormatFlags.DirectionRightToLeft;
      }
      switch(this.Alignment)
      {
        case HorizontalAlignment.Left:
          Format.Alignment = StringAlignment.Near;
          break;
        case HorizontalAlignment.Right:
          Format.Alignment = StringAlignment.Far;
          break;
        case HorizontalAlignment.Center:
          Format.Alignment = StringAlignment.Center;
          break;
      }
      Format.FormatFlags =Format.FormatFlags;
      Format.FormatFlags =StringFormatFlags.NoWrap;
      g.FillRectangle(BackBrush, Rect);
      Rect.Offset(0, yMargin);
      Rect.Height -= yMargin;
      g.DrawString(Text, this.DataGridTableStyle.DataGrid.Font, ForeBrush, RectF, Format);
      Format.Dispose();
    }
  }
}
