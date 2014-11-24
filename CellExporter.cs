using System;
using System.Collections;
using System.Windows.Forms;

namespace WinBud¿et_3
{
	/// <summary>
	/// Summary description for CellExporter.
	/// </summary>
	public abstract class CellExporter
	{
    protected Type dataType;
    protected int minWidth;
    protected int width;
    protected string caption;
    protected ArrayList objects;
    protected HorizontalAlignment alignment;
    protected string space;
    protected string zero;
    protected string textSeparator;
    protected string columnSeparator;
    
    public CellExporter()
    {
      objects = new ArrayList();
      minWidth = setMinWidth();
      width = minWidth;
      dataType = setType();
      alignment = setAlignment();
      space = " ";
      zero = string.Format("0,C:10",0);
      textSeparator = "";
      columnSeparator = "";
    }
    
    protected abstract int setMinWidth();
    protected abstract Type setType();
    protected abstract HorizontalAlignment setAlignment();
    protected abstract int updateWidth(Object o, int width);
    protected abstract string makeString(Object o);
   
    public Type DataType
    {
      get { return dataType; }
    }
    
    public int MinWidth
    {
      get { return minWidth; }
    }
    
    public string Caption
    {
      get { return caption; }
      set 
      { 
        caption = value; 
        if (caption.Length>width) width = caption.Length;
      }
    }
    
    public HorizontalAlignment HorizontalAlignment
    {
      get { return alignment; }
      set { alignment = value; }
    }
    
    public String SpaceString
    {
      set { space = value; }
      get { return space; }
    }
    
    public String ZeroString
    {
      set { zero = value; }
      get { return zero; }
    }
    
    public String TextSeparator
    {
      get { return textSeparator; }
      set { textSeparator = value; }
    }
    
    public String ColumnSeparator
    {
      get { return columnSeparator;}
      set { columnSeparator = value; }
    }
    
    public void addObject(Object o)
    {
      objects.Add(o);
      width = updateWidth(o,width);
    }
    
    public string formatCaption()
    {
      return align(textSeparator+caption.Clone().ToString().Replace(" ",space)+textSeparator,alignment,width+textSeparator.Length*2+columnSeparator.Length);
    }
    
    public string formatObject(int i)
    {
      if (i<objects.Count) return align(makeString(objects[i]),alignment,width+textSeparator.Length*2+columnSeparator.Length);
      else return "idx to big!";
    }
    
    public string nonFormatObject(int i)
    {
      if (i<objects.Count) return makeString(objects[i])+columnSeparator;
      else return "idx to big!";
    }
    
    public string nonFormatCaption()
    {
      return textSeparator+caption.Clone().ToString().Replace(" ",space)+textSeparator+columnSeparator;
    }

    private string align(string s, HorizontalAlignment alignment, int width)
    {
      if (alignment.Equals(HorizontalAlignment.Left)) return s.PadLeft(width,' ')+columnSeparator;
      if (alignment.Equals(HorizontalAlignment.Right)) return s.PadRight(width,' ')+columnSeparator;
      return s+columnSeparator; // nie dokoñczone...
    }    
    
    
  }
}
