//Wiktoria Blomgren Strandberg
//wikblo-0@student.ltu.se
//L0002B Uppgift 2

namespace L0002B_Uppgift_2
{
    internal class Säljare
    {
        private string namn, personnummer, distrikt;//Säljarens namn, personnummer och distrikt.
        private int antalSåldaArtiklar;//Antalet artiklar säljaren har sålt.

        public Säljare(string namn, string personnummer, string distrikt, int antalSåldaArtiklar)//Konstruktor.
        {
            Namn = namn;
            Personnummer = personnummer;
            Distrikt = distrikt;
            AntalSåldaArtiklar = antalSåldaArtiklar;
        }

        public string Namn//Setter och getter för säljarens namn.
        {
            get => namn;
            set => namn = value;
        }

        public string Personnummer//Setter och getter för säljarens personnummer.
        {
            get => personnummer;
            set => personnummer = value;
        }

        public string Distrikt//Setter och getter för säljarens distrikt.
        {
            get => distrikt;
            set => distrikt = value;
        }

        public int AntalSåldaArtiklar//Setter och getter för säljarens antal sålda artiklar.
        {
            get => antalSåldaArtiklar;
            set => antalSåldaArtiklar = value;
        }
    }
}
