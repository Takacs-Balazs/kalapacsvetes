using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace kalapacsvet
{
    internal class Versenyzo
    {
        public string Nev { get; set; }
        public string Csoport { get; set; }
        public string Nemzet { get; set; }
        public double D1 { get; set; }
        public double D2 { get; set; }
        public double D3 { get; set; }
        public double Eredmeny { get; set; }

        public string Kód => Nemzet.Substring(Nemzet.IndexOf('(') + 1, 3);
        public string CsakNemzet => Nemzet.Substring(0, Nemzet.IndexOf('(') - 1);

        public float Eredmény() => (float)Math.Max(Math.Max(D1, D2), D3);

        public static ObservableCollection<Versenyzo> Beolvasas(string fajlnev)
        {
            return new ObservableCollection<Versenyzo>(
                File.ReadLines(fajlnev)
                    .Skip(1)
                    .Select(sor => new Versenyzo(sor))
            );
        }

        public Versenyzo(string sor)
        {
            var adatok = sor.Split(';');
            Nev = adatok[0];
            Csoport = adatok[1];
            Nemzet = adatok[2];
            D1 = ParseResult(adatok[3]);
            D2 = ParseResult(adatok[4]);
            D3 = ParseResult(adatok[5]);
            Eredmeny = Math.Max(D1, Math.Max(D2, D3));
        }

        private double ParseResult(string eredmeny) =>
            eredmeny == "X" ? -1.0 :
            eredmeny == "-" ? -2.0 :
            double.Parse(eredmeny);
    }
}