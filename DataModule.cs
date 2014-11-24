using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace WinBud¿et_3
{
	/// <summary>
	/// Summary description for DataModule.
	/// </summary>
	public class DataModule
	{
	  private Tulkit tulkit;
	  
	  public Tulkit Tulkit
	  {
	    get { return this.tulkit; }
	    set { this.tulkit = value; }
	  }
	
    // pola dodatkowe
    private string nazwaPliku="";
    private bool zmodyfikowany=false;
    private bool otwarty=false;
    private string status="";
    private DateTime created;
    private DateTime lastAccessed;
    private DateTime lastModified;
    private DateTime lastSaved;
    private bool przeanalizowany=false;
    
    private string log="Starting DataModule log.\n";

    #region pola stricte bazodanowe

    // kolumny tabeli Wplywy
    private DataColumn wydData = new DataColumn("Data",typeof(System.DateTime));
    private DataColumn wydMieszek = new DataColumn("Mieszek",typeof(System.String));
    private DataColumn wydKategoria = new DataColumn("Kategoria",typeof(System.String));
    private DataColumn wydPozycja = new DataColumn("Pozycja",typeof(System.String));
    private DataColumn wydKwota = new DataColumn("Kwota",typeof(System.Double));

    // kolumny tabeli Wydatki
    private DataColumn wplData = new DataColumn("Data",typeof(System.DateTime));
    private DataColumn wplMieszek = new DataColumn("Mieszek",typeof(System.String));
    private DataColumn wplKategoria = new DataColumn("Kategoria",typeof(System.String));
    private DataColumn wplPozycja = new DataColumn("Pozycja",typeof(System.String));
    private DataColumn wplKwota = new DataColumn("Kwota",typeof(System.Double));
    
    // kolumny tabeli operacje mieszkowe
    private DataColumn dataColumn3 = new DataColumn("Data",typeof(System.DateTime));
    private DataColumn dataColumn4 = new DataColumn("Opis",typeof(System.String));
    private DataColumn dataColumn5 = new DataColumn("Sk¹d",typeof(System.String));
    private DataColumn dataColumn6 = new DataColumn("Dok¹d",typeof(System.String));
    private DataColumn dataColumn7 = new DataColumn("Kwota",typeof(System.Double));
    
    // kolumny tabeli planowanych wplywow
    private DataColumn dataColumn8 = new DataColumn("Kategoria",typeof(System.String));
    private DataColumn dataColumn10 = new DataColumn("Plan",typeof(System.Double));
    private DataColumn dataColumn12 = new DataColumn("Komentarz",typeof(System.String));
    
    // kolumny tabeli planowanych wydatkow
    private DataColumn dataColumn9 = new DataColumn("Kategoria",typeof(System.String));
    private DataColumn dataColumn11 = new DataColumn("Plan",typeof(System.Double));
    private DataColumn dataColumn17 = new DataColumn("Komentarz",typeof(System.String));

    // tabele
    private DataTable dataTableWplywy = new DataTable("Wplywy");
    private DataTable dataTableWydatki = new DataTable("Wydatki");
    private DataTable dataTableOperacjeMieszkowe = new DataTable("Mieszkowe");
    private DataTable dataTablePlanowaneWplywy = new DataTable("PlanowaneWplywy");
    private DataTable dataTablePlanowaneWydatki = new DataTable("PlanowaneWydatki");

    private DataSet dataSet = new DataSet("NewDataSet");
    #endregion
      
    #region properties
    public DateTime Created {  get { return created; }  }
    public DateTime LastAccessed { get { return lastAccessed; } }
    public DateTime LastModivied { get { return lastModified; } }
    public DateTime LastSaved { get { return lastSaved; }}
    public bool Analyzed
    { 
      get { return this.przeanalizowany; }
      set { this.przeanalizowany = value; }
    }
    public string NazwaPliku
    {
      get { return nazwaPliku; }
      set { nazwaPliku = value; }
    }
      
    public string Nazwa
    {
      get 
      { 
        if (dataSet!=null) return dataSet.DataSetName;
        else return "";
      }
      set { this.dataSet.DataSetName = value; }
      
    }
    
    public string Status
    {
      get { return status; }
    }
    
    public bool IsOpen
    {
      get { return otwarty; }
    }
    
    public bool IsModified
    {
      get { return zmodyfikowany; }
    }
    
    public DataSet ZestawDanych
    {
      get { return dataSet; }
    }
    
    #endregion  

    # region metody inicjalizacji i tworzenia
		
		public DataModule()
		{
		  init("Nowy zbior");
		}
		
		private void init(string nazwaZbioru)
		{
      // Tworzymy nowe tabele i dataset
      dataTableWplywy = new DataTable("Wplywy");
      dataTableWydatki = new DataTable("Wydatki");
      dataTableOperacjeMieszkowe = new DataTable("Mieszkowe");
      dataTablePlanowaneWplywy = new DataTable("PlanowaneWplywy");
      dataTablePlanowaneWydatki = new DataTable("PlanowaneWydatki");

      dataSet = new DataSet(nazwaZbioru);
      
      // dataTableWplywy
      dataTableWplywy.Columns.Add(wplData);
      dataTableWplywy.Columns.Add(wplMieszek);
      dataTableWplywy.Columns.Add(wplKategoria);
      dataTableWplywy.Columns.Add(wplPozycja);
      dataTableWplywy.Columns.Add(wplKwota);
      
      // dataTableWydatki
      dataTableWydatki.Columns.Add(wydData);
      dataTableWydatki.Columns.Add(wydMieszek);
      dataTableWydatki.Columns.Add(wydKategoria);
      dataTableWydatki.Columns.Add(wydPozycja);
      dataTableWydatki.Columns.Add(wydKwota);
      
      // dataTableOperacjeMieszkowe;
      dataTableOperacjeMieszkowe.Columns.Add(dataColumn3);
      dataTableOperacjeMieszkowe.Columns.Add(dataColumn4);
      dataTableOperacjeMieszkowe.Columns.Add(dataColumn5);
      dataTableOperacjeMieszkowe.Columns.Add(dataColumn6);
      dataTableOperacjeMieszkowe.Columns.Add(dataColumn7);
      
      // dataTablePlanowaneWplywy
      dataTablePlanowaneWplywy.Columns.Add(dataColumn8);
      dataTablePlanowaneWplywy.Columns.Add(dataColumn10);
      dataTablePlanowaneWplywy.Columns.Add(dataColumn12);
		
      // dataTablePlanowaneWydatki
      dataTablePlanowaneWydatki.Columns.Add(dataColumn9);
      dataTablePlanowaneWydatki.Columns.Add(dataColumn11);
      dataTablePlanowaneWydatki.Columns.Add(dataColumn17);
      
      // dataSet
      dataSet.Locale = new System.Globalization.CultureInfo("pl-PL");
      dataSet.Tables.Add(dataTableWplywy);
      dataSet.Tables.Add(dataTableWydatki);
      dataSet.Tables.Add(dataTablePlanowaneWplywy);
      dataSet.Tables.Add(dataTablePlanowaneWydatki);
      dataSet.Tables.Add(dataTableOperacjeMieszkowe);
      
      // rozne sprawy dodatkowe na koniec
      nazwaPliku = "";
      zmodyfikowany = false;
      otwarty = true;
      status = "Nowa baza danych przygotowana "+System.DateTime.Now.ToShortDateString()+"  "+System.DateTime.Now.ToShortTimeString();
      created = System.DateTime.Now;
      przeanalizowany = false;
      
      podlaczListenery();
    }

    private void podlaczDataSet(DataSet ds)
    {
      dataTableWplywy = dataSet.Tables["Wplywy"];
      dataTableWydatki = dataSet.Tables["Wydatki"];
      dataTableOperacjeMieszkowe = dataSet.Tables["Mieszkowe"];
      dataTablePlanowaneWplywy = dataSet.Tables["PlanowaneWplywy"];
      dataTablePlanowaneWydatki = dataSet.Tables["PlanowaneWydatki"];
      
      podlaczListenery();
      
    }
    
    private void podlaczListenery()
    {
      foreach (DataTable t in dataSet.Tables)
      {
        t.ColumnChanged+=new DataColumnChangeEventHandler(zmieniono);
        t.RowDeleted+=new DataRowChangeEventHandler(zmieniono);
      }
    
    }
    
    #endregion
  
    # region metody IO  
    public bool loadData(string nazwaPliku)
    {
      debug("Zaraz bede wczytywac dane.");
      ProgressForm pf = new ProgressForm();
      pf.Show();
      pf.LabelText="Wczytujê dane - proszê czekaæ";
      try
      {
        this.nazwaPliku = nazwaPliku;
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(nazwaPliku, FileMode.Open, FileAccess.Read, FileShare.Read);
        dataSet = (DataSet) formatter.Deserialize(stream);
        podlaczDataSet(dataSet);
        stream.Close();
        zmodyfikowany=false;
        otwarty = true;
        this.status = "Wczytana baza danych z pliku: "+nazwaPliku;
        updateLastAccessed();
        return true;
      }
      catch (Exception e)
      {
        this.status = e.Message+"\n"+e.Source;
        return false;
      }      
      finally
      {
        pf.Hide();
      }
    }
    
    public bool saveData(string nazwaPliku)
    {
      try
      {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(nazwaPliku, FileMode.Create, FileAccess.Write, FileShare.None);
        formatter.Serialize(stream, dataSet);
        stream.Close();
        zmodyfikowany = false;
        this.status = "Baza danych zapisana do pliku: "+nazwaPliku;
        updateLastSaved();
        return true;
      } 
      catch (Exception e) 
      {
        this.status = e.Message+"\n"+e.Source;
        return false;
      }
    }
    
    # endregion
    
    # region metody uaktualniania statusu
    private void updateLastAccessed() { this.lastAccessed = System.DateTime.Now; }
    private void updateLastModified() { this.lastModified = System.DateTime.Now; }
    private void updateLastSaved()    { this.lastSaved = System.DateTime.Now; }
    private void modified(object sender)
    {
      try
      {
        tulkit.debug("Modified: "+DateTime.Now.ToLongDateString()+"  "+DateTime.Now.ToLongTimeString());
        tulkit.debug("Sender "+sender.ToString());
        zmodyfikowany = true;
        przeanalizowany = false;
        updateLastModified();      
      } catch (Exception ex)
      {
        System.Windows.Forms.MessageBox.Show("DataModule exception\nMessage:"+ex.Message+"\nStack trace:\n"+ex.StackTrace);
      }
    }
    # endregion
    
    private void debug(string s) { log+=s+"\n"; }
    public string getLog() { return log; }
    private void zmieniono(object sender, DataColumnChangeEventArgs e )
    {  modified(sender);   }
    private void zmieniono(object sender, DataRowChangeEventArgs e )
    {  modified(sender);   }

	}
}
