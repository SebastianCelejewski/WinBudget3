using System;
using System.Collections;
using System.Data;

namespace WinBud¿et_3
{
	/// <summary>
	/// Klasa zawiera wszystkie informacje na temat bud¿etu
	/// </summary>
	
	public class Analizator
	{
	  private Tulkit tulkit;
	  private bool wyroznicPoprzedni;
	  private DataSet dataSet;
	  private int rok;
	  private int miesiac;
	  
	  public DataSet DataSet
	  {
	    get { return this.dataSet; }
	    set { this.dataSet = value; }
	  }
	  
	  public Tulkit Tulkit
	  {
	    get { return this.tulkit; }
	    set { this.tulkit = value; }
	  }
	  
	  public bool WyroznicKategorieZPoprzedniegoMiesiaca
	  {
	    get { return wyroznicPoprzedni; }
	    set { wyroznicPoprzedni = value; }
	  }
	  
	  // przeanalizowane dane
    private double sumaWplywow;
	  private double sumaWydatkow;
	  private double bilans;
	  private double sumaWplywowPlanowanych;
	  private double sumaWydatkowPlanowanych;
	  private double bilansPlanow;
	  private double bilansMieszkow;
	  private double zPoprzedniegoStan;
    private double zPoprzedniegoPlan;
    private double naNastepnyStan;
    private double naNastepnyPlan;
	  
	  private Hashtable kategorieWplywow;
	  private Hashtable kategorieWydatkow;
	  private Hashtable chronologiaWplywow;
	  private Hashtable chronologiaWydatkow;
	  private Hashtable mieszki;
	  private Hashtable pozycjeWplywow;
	  private Hashtable pozycjeWydatkow;
	  
	  // zmienne pomocnicze dla anlizy
    private enum TypOperacji {Wplyw, Wydatek};
	
		public Analizator()
		{
		}

    public void przeprowadzAnalize()
    {
      if (dataSet!=null) przeprowadzAnalize(dataSet);
    }

		/// <summary>
		/// Wywolywana w celu przeprowadzenia analizy danych budzetowych i stworzenia
		/// wszystkich dodatkowych tabel, raportow itp.
		/// </summary>
		/// <param name="budzet"></param>
		public void przeprowadzAnalize(DataSet budzet) 
		{
      tulkit.debug("Analizator.przeprowadzAnalize()");
		  if (budzet==null)
		  {
		     tulkit.debug(" - brak bazy - koniec analizy");
		     return;
		  }
		  DataTable dtWplywy;
		  DataTable dtWydatki;
		  DataTable dtMieszki;
		  DataTable dtPlWplywy;
		  DataTable dtPlWydatki;
		  try
		  {
        rok = ((DateTime) budzet.Tables["Wplywy"].Rows[0]["Data"]).Year; 
        miesiac = ((DateTime) budzet.Tables["Wplywy"].Rows[0]["Data"]).Month;
		  } catch (Exception ex)
		  {
		    rok = DateTime.Now.Year;
		    miesiac = DateTime.Now.Month;
		  }
      try
      {
        // podpiecie tabeli danych dla uproszczenia
        dtWplywy = budzet.Tables["Wplywy"];
        dtWydatki = budzet.Tables["Wydatki"];
        dtMieszki = budzet.Tables["Mieszkowe"];
        dtPlWplywy = budzet.Tables["PlanowaneWplywy"];
        dtPlWydatki = budzet.Tables["PlanowaneWydatki"];
      } catch (Exception ex)
      {
        tulkit.debug(" - problem z podpieciem tabel - przerwanie analizy");
        return;
      }

      // zresetowanie danych
      sumaWplywow = 0;
      sumaWydatkow = 0;
      sumaWplywowPlanowanych = 0;
      sumaWydatkowPlanowanych = 0;
      bilansPlanow = 0;
      bilansMieszkow = 0;		
      zPoprzedniegoStan = 0;
      zPoprzedniegoPlan = 0;
      kategorieWplywow = new Hashtable();
      kategorieWydatkow = new Hashtable();
      chronologiaWplywow = new Hashtable();
      chronologiaWydatkow = new Hashtable();
      pozycjeWplywow = new Hashtable();
      pozycjeWydatkow = new Hashtable();
      mieszki = new Hashtable();
      
      // analiza tabeli wplywow i wydatkow
      analizujChronologie(dtWplywy,TypOperacji.Wplyw);
      analizujChronologie(dtWydatki,TypOperacji.Wydatek);
      
      // analiza operacji mieszkowych
      analizujMieszki(dtMieszki);
      
      // analiza tabeli planowanych wplywow i planowanych wydatkow
      sumaWplywowPlanowanych = analizujPlany(ref dtPlWplywy, kategorieWplywow, TypOperacji.Wplyw);
      sumaWydatkowPlanowanych = analizujPlany(ref dtPlWydatki, kategorieWydatkow, TypOperacji.Wydatek);
      
      bilans = sumaWplywow - sumaWydatkow;
      bilansPlanow = sumaWplywowPlanowanych - sumaWydatkowPlanowanych;
      naNastepnyStan = bilans;
      naNastepnyPlan = bilansPlanow;
		}
		
		private void analizujChronologie(DataTable table, TypOperacji typ)
		{
      tulkit.debug("Analizator.analizujChronologie()");
      if (table==null)
      {
         tulkit.debug(" - brak tabeli - przerywam");
         return;
      }
      if (table.Rows==null)
      {
        tulkit.debug(" - pusta tabela - przerywam");
        return;
      }
      
  	  DataRowCollection rows = table.Rows;
      DateTime data;
      string mieszek;
      string kategoria;
      string pozycja;
      double kwota;
      int mnoznik;
      Hashtable kategorie;
      Hashtable chronologia;
      Hashtable pozycje;
      
      if (typ==TypOperacji.Wplyw)
      {
        mnoznik = 1;
        kategorie = kategorieWplywow;
        chronologia = chronologiaWplywow;
        pozycje = pozycjeWplywow;
        zPoprzedniegoStan = 0;
      }
      else
      {
        mnoznik = -1;
        kategorie = kategorieWydatkow;
        chronologia = chronologiaWydatkow;
        pozycje = pozycjeWydatkow;
      }
      
      foreach (DataRow dr in rows)
      {
        // pobranie danych wiersza
        data = (DateTime) dr["Data"];
        //zbior = (string) dr["Zbior"];
        mieszek = (string) dr["Mieszek"];
        kategoria = (string) dr["Kategoria"];
        pozycja = (string) dr["Pozycja"];
        kwota = (double) dr["Kwota"];


        bilans+=kwota*mnoznik;
        bilansMieszkow+=kwota*mnoznik;
        if (kategoria.ToLower().Replace('¹','a').Equals("z poprzedniego miesiaca")) 
        {
//          System.Windows.Forms.MessageBox.Show("Z poprzedniego:\n"+kategoria+": "+kwota);
          zPoprzedniegoStan+=kwota;
        }
        
        // uzupelniamy dane dotyczase struktury wplywow/wydatkow
        if (!kategorie.Contains(kategoria)) kategorie.Add(kategoria,new Kategoria(kategoria));
        ((Kategoria) kategorie[kategoria]).dodajPozycje(pozycja,kwota);
        ((Kategoria) kategorie[kategoria]).dodajDzien(data,kwota);

        // uzupelniamy dane dotyczace stanu mieszkow
        if (!mieszki.Contains(mieszek)) mieszki.Add(mieszek,kwota*mnoznik);
        else mieszki[mieszek] = (double) mieszki[mieszek] + kwota*mnoznik;

        // uzupelniamy dane dotyczace chronologii wplywow/wydatkow
        if (!chronologia.Contains(data)) chronologia.Add(data,kwota);
        else chronologia[data] = (double) chronologia[data] + kwota;

        // uaktualniamy sume wplywow/wydatkow
        if (typ==TypOperacji.Wplyw) sumaWplywow+=kwota;
        else sumaWydatkow+=kwota;
        
        // uaktualniamy liste pozycji wplywow/wydatkow
        if (!pozycje.Contains(pozycja)) pozycje.Add(pozycja,kwota);
        else pozycje[pozycja]=(double) pozycje[pozycja] + kwota;
      }
		}
		
		private void analizujMieszki(DataTable table)
		{
      tulkit.debug("Analizator.analizujMieszki()");
      if (table==null)
      {
        tulkit.debug(" - brak tabeli - przerywam");
        return;
      }
      if (table.Rows==null)
      {
        tulkit.debug(" - pusta tabela - przerywam");
        return;
      }

      DataRowCollection rows = table.Rows;
      DateTime data;
      string opis;
      string skad;
      string dokad;
      double kwota;
      
      foreach (DataRow dr in rows)
      {
        data = (DateTime) dr["Data"];
        opis = (string) dr["Opis"];
        skad = (string) dr["Sk¹d"];
        dokad = (string) dr["Dok¹d"];
        kwota = (double) dr["Kwota"];

        // uzupelniamy dane dotyczace stanu mieszkow
        if (!mieszki.Contains(skad)) mieszki.Add(skad,-kwota);
        else mieszki[skad] = (double) mieszki[skad] - kwota;

        if (!mieszki.Contains(dokad)) mieszki.Add(dokad,kwota);
        else mieszki[dokad] = (double) mieszki[dokad] +kwota ;
      }
		}
		
    private double analizujPlany(ref DataTable table, Hashtable hashTable, TypOperacji typ)
    {
      tulkit.debug("Analizator.analizujPlany()");
      if (table==null)
      {
        tulkit.debug(" - brak tabeli - przerywam");
        return 0;
      }
      if (table.Rows==null)
      {
        tulkit.debug(" - pusta tabela - przerywam");
        return 0;
      }
      Hashtable kategoriePlanowane = new Hashtable();
      DataRowCollection rows = table.Rows;
      string kategoria;
      double plan, stan;
      double sumaPlanow = 0;
      Hashtable kategorie;
      if (typ == TypOperacji.Wplyw)
      { 
        kategorie = kategorieWplywow;
        naNastepnyPlan = 0;
      }
      else kategorie = kategorieWydatkow;
      
      foreach (DataRow dr in rows)
      {
        kategoria = (string) dr["Kategoria"];
        plan = (double) dr["Plan"];
        if (kategoria.ToLower().Replace('¹','a').Equals("z poprzedniego miesiaca")) zPoprzedniegoPlan+=plan;
        sumaPlanow+=plan;
        if (hashTable.Contains(kategoria)) stan = ((Kategoria) hashTable[kategoria]).Stan;
        else stan = 0;
      
        if (!kategorie.Contains(kategoria)) kategorie.Add(kategoria,new Kategoria(kategoria));
        ((Kategoria) kategorie[kategoria]).Plan = plan;

//        dr["Stan"] = stan;
//        dr["Roznica"] = plan - stan;
//        dr["Komentarz"]= ""+plan+";"+stan;

        if (!kategoriePlanowane.Contains(kategoria)) kategoriePlanowane.Add(kategoria, new Kategoria(kategoria));
        ((Kategoria) kategoriePlanowane[kategoria]).Plan = plan;
      }
      
      // dopisujemy do planu te kategorie, ktore sa we wplywach/wydatkach, a ktorych
      // jeszcze nie ma w planach
      ICollection katPl = kategorie.Keys;
      foreach (string ka in katPl)
      {
        if (!kategoriePlanowane.Contains(ka))
        {
          DataRow nowyWiersz = table.NewRow();
          stan = (double) ((Kategoria) kategorie[ka]).Stan;
          nowyWiersz["Kategoria"] = ka;
          nowyWiersz["Plan"] = 0;
//          nowyWiersz["Stan"] = stan;
//          nowyWiersz["Roznica"] = stan;
//          nowyWiersz["Komentarz"] = "0;"+stan; 
          nowyWiersz["Komentarz"] = "Dodane automatycznie "+DateTime.Now.ToShortDateString();
          table.Rows.Add(nowyWiersz);
        }
      }
      return sumaPlanow;
		}
		
		public string rezultat()
		{
      string wynik = "";
      wynik += prezentujChrono(kategorieWplywow);
      wynik += prezentujChrono(kategorieWydatkow);
      return wynik;
		}
		
		public string prezentujChrono(Hashtable hashTable)
		{
      string wynik = "";
      ICollection katWpl = hashTable.Keys;
      foreach (string kat in katWpl)
      {
        wynik+="Kategoria: "+kat+"\n";
        Kategoria k = (Kategoria) hashTable[kat];
        wynik+="Plan: "+k.Plan+"  Stan: "+k.Stan+"\n";
        ICollection pozWpl = k.Pozycje.Keys;
        foreach (string poz in pozWpl)
        {
          wynik+="  pozycja: "+poz+"  "+k.Pozycje[poz]+"\n";
        }
      }
      return wynik;		
		}
		
		public ICollection listaMieszkow() 
		{ 
  		return mieszki.Keys; 
  	}
		public ICollection listaKategoriiWplywow() { return kategorieWplywow.Keys; }
		public ICollection listaKategoriiWydatkow(){ return kategorieWydatkow.Keys; }
		public ICollection listaPozycjiWplywow() { return pozycjeWplywow.Keys; }
		public ICollection listaPozycjiWydatkow() { return pozycjeWydatkow.Keys; }
		public ArrayList listaPozycjiWplywow(string kategoria)
		{ 
		  return new ArrayList(((Kategoria) kategorieWplywow[kategoria]).Pozycje);
		}
		
    public ArrayList listaPozycjiWydatkow(string kategoria)
    { return new ArrayList(((Kategoria) kategorieWydatkow[kategoria]).Pozycje);  }
		
		private string[] hashTable2stringTable(Hashtable hashTable)
		{
		  string[] zwrot = new string[hashTable.Keys.Count];
		  IEnumerator ie = hashTable.Keys.GetEnumerator();
		  int i=0;
		  while (ie.MoveNext()) zwrot[i++]=ie.Current.ToString();
		  return zwrot;
		}
		
		// odczyt danych
    public double stanWplywow() 
    { 
      if (wyroznicPoprzedni) return sumaWplywow-zPoprzedniegoStan; 
      else return sumaWplywow;
    }
    public double stanWydatkow() { return sumaWydatkow; }
    public double stanBilans() 
    { 
      if (wyroznicPoprzedni) return bilans-zPoprzedniegoStan; 
      else return bilans;
    }
    public double planWplywow() 
    { 
      if (wyroznicPoprzedni) return sumaWplywowPlanowanych-zPoprzedniegoPlan;
      else return sumaWplywowPlanowanych; 
    }
    public double planWydatkow() { return sumaWydatkowPlanowanych; }
    public double planBilans() 
    {
      if (wyroznicPoprzedni) return bilansPlanow - zPoprzedniegoPlan;
      else return bilansPlanow; 
    }
    public double roznicaWplywow() 
    { 
       return stanWplywow() - planWplywow();
    }
    public double roznicaWydatkow() 
    { 
       return stanWydatkow() - planWydatkow();
    }
    
    public double roznicaBilansu() 
    { 
      return stanBilans() - planBilans();
    }
    
    public double stanZPoprzedniegoMiesiaca() { return zPoprzedniegoStan; }
		public double planZPoprzedniegoMiesiaca() { return zPoprzedniegoPlan;}
		public double roznicaZPoprzedniegoMiesiaca() { return zPoprzedniegoStan-zPoprzedniegoPlan;}
		public double stanNaNastepnyMiesiac() { return naNastepnyStan;}
		public double planNaNastepnyMiescia() { return naNastepnyPlan; }
		public double roznicaNaNastepnyMiesiac() { return naNastepnyStan-naNastepnyPlan; }
    public double stanMieszkow() { return bilansMieszkow; } 		
		public Hashtable pobierzAnalizeMieszkow() { return mieszki; }
		public Hashtable pobierzAnalizeKategoriiWplywow() { return this.kategorieWplywow; }
    public Hashtable pobierzAnalizeKategoriiWydatkow() { return this.kategorieWydatkow; }
    public int jakiRok() { return rok; }
    public int jakiMiesiac() { return miesiac; }
  }
}
