class Versenyzo
{
    public string Nev { get; set; }
    public char Csoport { get; set; }
    public string NemzetEsKod { get; set; }
    public double D1 { get; set; }
    public double D2 { get; set; }
    public double D3 { get; set; }

    public Versenyzo(string sor)
    {
        var data = sor.Split(';');
        Nev = data[0];
        Csoport = char.Parse(data[1]);
        NemzetEsKod = data[2];
        D1 = ParseDobas(data[3]);
        D2 = ParseDobas(data[4]);
        D3 = ParseDobas(data[5]);
    }

    private double ParseDobas(string eredmeny)
    {
        if (eredmeny == "X") return -1.0;
        if (eredmeny == "-") return -2.0;
        return double.Parse(eredmeny);
    }
}

class Program
{
    static void Main()
    {
        List<Versenyzo> versenyzok = Beolvas("Selejtezo2012.txt");

        // 5. feladat
        Console.WriteLine("5. feladat: versenyzők száma a forrásállományban: " + versenyzok.Count);

        // 6. feladat
        int tovabbjutottakSzama = versenyzok.Count(v => v.D1 > 78 || v.D2 > 78);
        Console.WriteLine("6. feladat: automatikusan továbbjutott versenyzők száma: " + tovabbjutottakSzama);
    }

    static List<Versenyzo> Beolvas(string fajlnev)
    {
        List<Versenyzo> versenyzok = new List<Versenyzo>();

        try
        {
            using (StreamReader sr = new StreamReader(fajlnev))
            {
                sr.ReadLine(); 

                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    Versenyzo versenyzo = new Versenyzo(sor);
                    versenyzok.Add(versenyzo);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Hiba a beolvasás során: " + e.Message);
        }

        return versenyzok;
    }
}