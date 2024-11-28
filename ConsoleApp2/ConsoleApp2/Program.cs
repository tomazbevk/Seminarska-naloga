
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

//tabela za narocnike
string[] NarocnikiStr = File.ReadAllLines("narocniki.txt");
Narocnik[] narocniki = new Narocnik[NarocnikiStr.Length];

for (int i = 0; i < NarocnikiStr.Length; i++)
{
    narocniki[i] = new Narocnik(NarocnikiStr[i]);
}

//tabela za narocnine oz. tipe karte
string[] NarocnineStr = File.ReadAllLines("narocnine.txt");
Narocnine[] narocnine = new Narocnine[NarocnineStr.Length];

for (int i = 0; i < NarocnikiStr.Length; i++)
{
    narocnine[i] = new Narocnine(NarocnineStr[i]);
}

while (true)
{
    string izbiraIzhod = "Izhod"; // TODO: za vse raje naredimo tako
    string izbira = Fancy.Meni(["Izpis", "Uredi", "Iskanje", izbiraIzhod]);

    if (izbira == "Uredi")
    {
        string izbira2 = Fancy.Meni(
            ["Uredi uporabnike", "Uredi naročnine"],
            ConsoleColor.White
        );
        Console.WriteLine("Izbrali ste urejanje: " + izbira2);
        if (izbira2 == "Uredi uporabnike")
        {
            string izbira3 = Fancy.Meni(
            ,
            ConsoleColor.White
        );
        }
        else if (izbira2 == "Uredi naročnine")
        {

        }
    }
    else if (izbira == "Vizitka")
    {
        Console.WriteLine("Jan Robas, PRO1");
    }
    else if (izbira == izbiraIzhod)
    {
        return;
    }
    else if (izbira == "Izpis")
    {
        string izbira2 = Fancy.Meni(
            ["Izpiši uporabnike", "Izpis tipov kart"],
            ConsoleColor.Magenta
        );
        if (izbira2 == "Izpiši uporabnike")
        {
            for (int i = 0; i < narocniki.Length; i++)
            {
                Console.WriteLine("Indeks:\t\t" + i);
                narocniki[i].Izpis();
                Console.WriteLine("-----------------------------------");
            }
        }
        else if (izbira2 == "Izpis tipov kart")
        {
            for (int i = 0; i < narocnine.Length; i++)
            {
                Console.WriteLine("Indeks:\t\t" + i);
                narocnine[i].Izpis();
                Console.WriteLine("-----------------------------------");
            }
        }
        
    }
    Console.ReadKey();
}



class Narocnine
{
    public string tip;
    public int cena;
    public string bonusi;
    public int Trajanje;
    

    public Narocnine()
    {
        
    }
    public Narocnine(string vrstica)
    {
        string[] lastnosti = vrstica.Split(';');
        this.tip = lastnosti[0];
        this.cena = int.Parse(lastnosti[1]);
        this.bonusi = lastnosti[2];
        this.Trajanje = int.Parse(lastnosti[3]);

    }

    public void Izpis()
    {
        Console.WriteLine("Tip karte:\t" + this.tip);
        Console.WriteLine("Cena:\t" + this.cena);
        Console.WriteLine("Bonusi:\t" + this.bonusi);
        Console.WriteLine("Trajanje karte(dni):\t" + this.Trajanje);
    }
}

class Narocnik
{
    public string ime;
    public string priimek;
    public int trajanjeKarte;//trajanje karte se izpiše v dneh
    public DateTime DatumVpisa;
    public string Tip;

    public Narocnik(string vrstica)
    {
        string[] lastnosti = vrstica.Split(';');
        this.ime = lastnosti[0];
        this.priimek = lastnosti[1];
        this.trajanjeKarte = int.Parse(lastnosti[2]);
        this.DatumVpisa = Convert.ToDateTime(lastnosti[3]).Date;
        this.Tip = lastnosti[4];
    }

    public Narocnik() 
    {
    
    }

    public string VrniVrstico()
    {
        return this.ime + ";" + this.priimek + ";" + this.trajanjeKarte + ";" + this.DatumVpisa + ";" + this.Tip;
    }

    public void Izpis()
    {
        Console.WriteLine("Ime:\t" + this.ime);
        Console.WriteLine("Priimek:\t" + this.priimek);
        Console.WriteLine("Trajanje karte(dni):\t" + this.trajanjeKarte);
        Console.WriteLine("Datum vpisa:\t" + this.DatumVpisa);
        Console.WriteLine("Tip karte:\t" + this.Tip);
    }
}

static class Fancy
{
    static public string Meni(string[] postavke, ConsoleColor ozadje = ConsoleColor.Yellow)
    {
        int ixIzbranaPostavka = 0;

        while (true)
        {
            Console.Clear();

            for (int i = 0; i < postavke.Length; i++)
            {
                if (ixIzbranaPostavka == i)
                {
                    Console.BackgroundColor = ozadje;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(" " + postavke[i].PadRight(30, ' '));
                Console.ResetColor();
            }


            ConsoleKeyInfo tipka = Console.ReadKey();
            if (tipka.Key == ConsoleKey.UpArrow && ixIzbranaPostavka > 0)
            {
                ixIzbranaPostavka--;    
            }
            else if (tipka.Key == ConsoleKey.DownArrow && ixIzbranaPostavka < postavke.Length - 1)
            {
                ixIzbranaPostavka++;
            }
            else if (tipka.Key == ConsoleKey.DownArrow && ixIzbranaPostavka == postavke.Length - 1)
            {
                ixIzbranaPostavka = 0;
            }
            else if (tipka.Key == ConsoleKey.UpArrow && ixIzbranaPostavka == 0)
            {
                ixIzbranaPostavka = postavke.Length - 1;
            }
            else if (tipka.Key == ConsoleKey.Enter)
            {
                break;
            }
        }

        return postavke[ixIzbranaPostavka];
    }
}