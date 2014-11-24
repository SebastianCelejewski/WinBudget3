using System;
using System.Collections;

namespace WinBud¿et_3
{
	/// <summary>
	/// Summary description for Kategoria.
	/// </summary>
	public class Kategoria
	{
	  private string nazwa;
	  private double stan;
	  private double plan;
	  private Hashtable pozycje;
	  private Hashtable dni;
	  
	  public string Nazwa
	  {
	    get { return nazwa; }
	    set { nazwa = value; }
	  }
	  
	  public double Stan
	  {
	    get { return stan; }
	  }
	  
	  public double Plan
	  {
	    get { return plan; }
	    set { plan = value; }
	  }
	  
	  public double Roznica
	  {
	    get { return plan - stan; }
	  }
	  
	  public bool PowyzejPlanu
	  {
	    get { return stan>plan; }
	  }
	  
	  public Hashtable Pozycje
	  {
	    get { return pozycje; }
	  }
	  
	  public Hashtable Dni
	  {
	    get { return dni; }
	  }

		public Kategoria()
		{
      nazwa = "";
      plan = 0;
      stan = 0;
      pozycje = new Hashtable();
      dni = new Hashtable();
    }
		
		public Kategoria(String nazwaKategorii)
		{
      nazwa = nazwaKategorii;
      plan = 0;
      stan = 0;
      pozycje = new Hashtable();
      dni = new Hashtable();
		}
		
		public void dodajPozycje(string nazwa, double kwota)
		{
		  if (pozycje.Contains(nazwa))  pozycje[nazwa] = (double) (pozycje[nazwa])+kwota;
		  else  pozycje.Add(nazwa,kwota);
		  this.stan += kwota;
		}
		
		public void dodajDzien(DateTime data, double kwota)
		{
		  if (dni.Contains(data)) dni[data] = (double) (dni[data])+kwota;
		  else dni.Add(data,kwota);
		}
	}
}
