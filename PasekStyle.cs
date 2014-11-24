using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;

namespace WinBud¿et_3
{
	/// <summary>
	/// Summary description for PasekStyle.
	/// </summary>
	public class PasekStyle:DataGridColumnStyle 
	{
    private double podzielnik;
    private bool jestemWplywem = false;
    
    public double Podzielnik
    {
      get { return podzielnik; }
      set { podzielnik = value; }
    }
    
    public bool JestemWplywem
    {
      get { return jestemWplywem; }
      set { this.jestemWplywem = value; }
    }

    public PasekStyle(PropertyDescriptor pcol) 
    {  }
    
    public PasekStyle()
    {  }
    
    public PasekStyle(bool jestemWplywem)
    {
      this.jestemWplywem = jestemWplywem;
    }
    protected override void Abort(int RowNum) 
    {  }    
    protected override bool Commit(CurrencyManager DataSource,int RowNum) 
    {  return true; }
    protected override void Edit(CurrencyManager Source ,int Rownum,Rectangle Bounds, bool ReadOnly,string InstantText, bool CellIsVisible) 
    { }
    protected override int GetMinimumHeight() 
    {  return 5; }
    protected override int GetPreferredHeight(Graphics g ,object Value) 
    {  return 20;  }
    protected override Size GetPreferredSize(Graphics g, object Value) 
    {  return new Size(200,60);  }

    
    private void rysuj(Graphics g, Rectangle Bounds, CurrencyManager Source, int RowNum)
    {
      g.FillRectangle(new SolidBrush(Color.White), Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);
      try 
      { 
        string tekst = GetColumnValueAtRow(Source, RowNum).ToString();
        string[] stringi = tekst.Split(';');
        double plan, stan;
        try { plan = double.Parse(stringi[0]); } catch (Exception) {plan = 0; };
        try { stan = double.Parse(stringi[1]); } catch (Exception) {stan = 0; };
        Console.Error.WriteLine(tekst+" plan:"+plan+" stan:"+stan);
        
        if (podzielnik==0) podzielnik = 500;
        int planPx = (int) (plan/podzielnik);
        int stanPx = (int) (stan/podzielnik);
      
        if (jestemWplywem)
        {
          if (plan>=stan)
          {
            g.FillRectangle(System.Drawing.Brushes.Red,Bounds.X,Bounds.Y,planPx,Bounds.Height);
            g.FillRectangle(System.Drawing.Brushes.Blue,Bounds.X,Bounds.Y,stanPx,Bounds.Height);
          }
          else
          {
            g.FillRectangle(System.Drawing.Brushes.Green,Bounds.X,Bounds.Y,stanPx,Bounds.Height);
            g.FillRectangle(System.Drawing.Brushes.Blue,Bounds.X,Bounds.Y,planPx,Bounds.Height);
          }
        }
        else
        {
          if (plan>=stan)
          {
            g.FillRectangle(System.Drawing.Brushes.Green,Bounds.X,Bounds.Y,planPx,Bounds.Height);
            g.FillRectangle(System.Drawing.Brushes.Blue,Bounds.X,Bounds.Y,stanPx,Bounds.Height);
          }
          else
          {
            g.FillRectangle(System.Drawing.Brushes.Red,Bounds.X,Bounds.Y,stanPx,Bounds.Height);
            g.FillRectangle(System.Drawing.Brushes.Blue,Bounds.X,Bounds.Y,planPx,Bounds.Height);
          }
        }
        
        for (int i=0;i<(int) System.Math.Max(plan,stan);i+=100)
          g.DrawLine(System.Drawing.Pens.Yellow,Bounds.X+(int) (i/podzielnik),Bounds.Y+2,Bounds.X+(int) (i/podzielnik),Bounds.Y+Bounds.Height-3);

      }
      catch (Exception ex) 
      {
        g.DrawString(ex.Message+ex.StackTrace,new Font("Courier",5),System.Drawing.Brushes.Black,Bounds);
      }

    }

    protected override void Paint(Graphics g,Rectangle Bounds,CurrencyManager Source,int RowNum,bool AlignToRight) 
    {
      rysuj(g,Bounds,Source,RowNum);
    }

    protected override void Paint(Graphics g,Rectangle Bounds,CurrencyManager Source,int RowNum, Brush BackBrush ,Brush ForeBrush ,bool AlignToRight) 
    {
      rysuj(g,Bounds,Source,RowNum);
    }

    protected override void Paint(Graphics g,Rectangle Bounds,CurrencyManager Source,int RowNum) 
    {
      rysuj(g,Bounds,Source,RowNum);
    }

  }
}

 

