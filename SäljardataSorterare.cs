//Wiktoria Blomgren Strandberg
//wikblo-0@student.ltu.se
//L0002B Uppgift 2

using System;
using System.Collections;
using System.IO;

namespace L0002B_Uppgift_2
{
    internal class SäljardataSorterare
    {
        static ArrayList säljarDataNivå1 = new ArrayList();//ArrayList med säljare som nått nivå 1.
        static ArrayList säljarDataNivå2 = new ArrayList();//ArrayList med säljare som nått nivå 2.
        static ArrayList säljarDataNivå3 = new ArrayList();//ArrayList med säljare som nått nivå 3.
        static ArrayList säljarDataNivå4 = new ArrayList();//ArrayList med säljare som nått nivå 4.

        static void Main(string[] args)//Metod med huvudmeny.
        {
            Console.WriteLine("Välkommen till säljardata-sorteraren!");//Välkomstmeddelande.

            while (true)//Loopar så att man återkommer till huvudmenyn.
            {
                Console.WriteLine("\nTryck 1 för att lägga till personal, 2 för att sortera och skriva ut säljardata, " +
                    "3 för att avsluta:\n");//Instruktioner för menyn.

                //Meny med alternativ:
                string meny = Console.ReadLine();
                int väljMeny;

                if (int.TryParse(meny, out väljMeny))//Kontrollerar att inmatning innehåller, och endast innehåller, siffror.
                {
                    switch (väljMeny)
                    {
                        case 1://Tryck 1 för att lägga till säljare.
                            läggTillSäljare();
                            break;

                        case 2://Tryck 2 för att sortera och skriva ut säljardata.
                            sorteraSkrivaUtSäljardata();
                            break;

                        case 3://Tryck 3 för att avsluta.
                            Environment.Exit(0);
                            break;

                        default://Ger återkoppling vid felinmatning (fel siffra).
                            Console.WriteLine("\nFelinmatning, försök igen.");
                            break;
                    }
                }
                else//Ger återkoppling om inmatning inte innehåller, eller innehåller annat än, siffror.
                {
                    Console.WriteLine("\nFelinmatning, försök igen.");
                }
            }
        }

        private static void läggTillSäljare()//Metod som lägger till säljare.
        {
            Console.WriteLine("\nAnge namn:");//Inmatning av säljarens namn.
            string namn = Console.ReadLine();

            if(namn.Length == 0)//Ger felmeddelande om fältet lämnas tomt.
            {
                Console.WriteLine("\nFältet kan ej lämnas tomt. Försök igen.");//Återkoppling.
            }
            else
            {
                Console.WriteLine("\nAnge personnummer:");//Inmatning av säljarens personnummer.
                string personnummer = Console.ReadLine();

                if(personnummer.Length == 0)//Ger felmeddelande om fältet lämnas tomt.
                {
                    Console.WriteLine("\nFältet kan ej lämnas tomt. Försök igen.");//Återkoppling.
                }
                else
                {
                    Console.WriteLine("\nAnge distrikt:");//Inmatning av säljarens distrikt.
                    string distrikt = Console.ReadLine();

                    if(distrikt.Length == 0)//Ger felmeddelande om fältet lämnas tomt.
                    {
                        Console.WriteLine("\nFältet kan ej lämnas tomt. Försök igen.");//Återkoppling.
                    }
                    else
                    {
                        Console.WriteLine("\nAnge antal sålda artiklar:");//Inmatning av säljarens antal sålda artiklar.
                        string antalSåldaProdukter = Console.ReadLine();
                        int antalSåldaArtiklar;

                        if (!int.TryParse(antalSåldaProdukter, out antalSåldaArtiklar))//Ger felmeddelande om inmatning inte innehåller, eller innehåller annat än, siffror.
                        {
                            Console.WriteLine("\nInmatning ska, och ska endast, innehålla siffor.");//Återkoppling.
                        }
                        else
                        {
                            Säljare säljare = new Säljare(namn, personnummer, distrikt, antalSåldaArtiklar);//Skapar ny säljare baserat på informationen som angivits.

                            if (antalSåldaArtiklar < 50)//Lägger till den nya säljaren i ArrayListen över de som nått nivå 1.
                            {
                                säljarDataNivå1.Add(säljare);
                            }
                            else if (antalSåldaArtiklar <= 99)//Lägger till den nya säljaren i ArrayListen över de som nått nivå 2.
                            {
                                säljarDataNivå2.Add(säljare);
                            }
                            else if (antalSåldaArtiklar <= 199)//Lägger till den nya säljaren i ArrayListen över de som nått nivå 3.
                            {
                                säljarDataNivå3.Add(säljare);
                            }
                            else//Lägger till den nya säljaren i ArrayListen över de som nått nivå 4.
                            {
                                säljarDataNivå4.Add(säljare);
                            }

                            Console.WriteLine("\nSäljardatan:\n" + namn + " " + personnummer + " " + distrikt +
                                " " + antalSåldaProdukter + "\nhar lagts till.");//Bekräftelse på att säljaren har lagts till.
                        }
                    }
                }
            }
        }

        private static void sorteraSkrivaUtSäljardata()//Metod som sorterar och skriver ut säljardata.
        {
            säljarDataNivå1.Sort(new Sorterare());//Sorterar säljardatan för de som nått nivå 1.
            säljarDataNivå2.Sort(new Sorterare());//Sorterar säljardatan för de som nått nivå 2.
            säljarDataNivå3.Sort(new Sorterare());//Sorterar säljardatan för de som nått nivå 3.
            säljarDataNivå4.Sort(new Sorterare());//Sorterar säljardatan för de som nått nivå 4.

            using (StreamWriter skrivTillFil = new StreamWriter("Säljardata"))//Skapar fil "Säljardata".
            {
                if (säljarDataNivå1.Count == 0 && säljarDataNivå2.Count == 0 && säljarDataNivå3.Count == 0 &&
                    säljarDataNivå4.Count == 0)//Ger felmeddelande om ingen säljare har lagts till.
                {
                    Console.WriteLine("\nLägg till säljare och försök sedan igen.");//Återkoppling.
                }
                else
                {
                    Console.WriteLine("\nNamn   Personnummer   Distrikt   Antal sålda artiklar\n");//Skriver ut rubrik.
                    skrivTillFil.WriteLine("\nNamn   Personnummer   Distrikt   Antal sålda artiklar\n");//Skriver rubrik i fil.

                    if (säljarDataNivå1.Count != 0)//Skriver ut information om en eller flera säljare nått nivå 1.
                    {
                        foreach (Säljare item in säljarDataNivå1)//Skriver ut information för respektive säljare.
                        {
                            Console.WriteLine("{0}   {1}   {2}   {3}",
                                item.Namn, item.Personnummer, item.Distrikt, item.AntalSåldaArtiklar);//Skriver ut säljardata.
                            skrivTillFil.WriteLine("{0}   {1}   {2}   {3}",
                                item.Namn, item.Personnummer, item.Distrikt, item.AntalSåldaArtiklar);//Skriver säljardata i fil.
                        }

                        Console.WriteLine(säljarDataNivå1.Count + " säljare har nått nivå 1: under 50 artiklar.\n");//Skriver ut antalet säljare som nått nivå 1.
                        skrivTillFil.WriteLine(säljarDataNivå1.Count + " säljare har nått nivå 1: under 50 artiklar.\n");//Skriver antalet säljare som nått nivå 1 i fil.
                    }

                    if (säljarDataNivå2.Count != 0)//Skriver ut information om en eller flera säljare nått nivå 2.
                    {
                        foreach (Säljare item in säljarDataNivå2)//Skriver ut information för respektive säljare.
                        {
                            Console.WriteLine("{0}   {1}   {2}   {3}",
                                item.Namn, item.Personnummer, item.Distrikt, item.AntalSåldaArtiklar);//Skriver ut säljardata.
                            skrivTillFil.WriteLine("{0}   {1}   {2}   {3}",
                                item.Namn, item.Personnummer, item.Distrikt, item.AntalSåldaArtiklar);//Skriver säljardata i fil.
                        }

                        Console.WriteLine(säljarDataNivå2.Count + " säljare har nått nivå 2: 50-99 artiklar.\n");//Skriver ut antalet säljare som nått nivå 2.
                        skrivTillFil.WriteLine(säljarDataNivå2.Count + " säljare har nått nivå 2: 50-99 artiklar.\n");//Skriver antalet säljare som nått nivå 2 i fil.
                    }

                    if (säljarDataNivå3.Count != 0)//Skriver ut information om en eller flera säljare nått nivå 3.
                    {
                        foreach (Säljare item in säljarDataNivå3)//Skriver ut information för respektive säljare.
                        {
                            Console.WriteLine("{0}   {1}   {2}   {3}",
                                item.Namn, item.Personnummer, item.Distrikt, item.AntalSåldaArtiklar);//Skriver ut säljardata.
                            skrivTillFil.WriteLine("{0}   {1}   {2}   {3}",
                                item.Namn, item.Personnummer, item.Distrikt, item.AntalSåldaArtiklar);//Skriver säljardata i fil.
                        }

                        Console.WriteLine(säljarDataNivå3.Count + " säljare har nått nivå 3: 100-199 artiklar.\n");//Skriver ut antalet säljare som nått nivå 3.
                        skrivTillFil.WriteLine(säljarDataNivå3.Count + " säljare har nått nivå 3: 100-199 artiklar.\n");//Skriver antalet säljare som nått nivå 3 i fil.
                    }

                    if (säljarDataNivå4.Count != 0)//Skriver ut information om en eller flera säljare nått nivå 4.
                    {
                        foreach (Säljare item in säljarDataNivå4)//Skriver ut information för respektive säljare.
                        {
                            Console.WriteLine("{0}   {1}   {2}   {3}",
                                item.Namn, item.Personnummer, item.Distrikt, item.AntalSåldaArtiklar);//Skriver ut säljardata.
                            skrivTillFil.WriteLine("{0}   {1}   {2}   {3}",
                                item.Namn, item.Personnummer, item.Distrikt, item.AntalSåldaArtiklar);//Skriver säljardata i fil.
                        }

                        Console.WriteLine(säljarDataNivå4.Count + " säljare har nått nivå 4: över 199 artiklar.\n");//Skriver ut antalet säljare som nått nivå 4.
                        skrivTillFil.WriteLine(säljarDataNivå4.Count + " säljare har nått nivå 4: över 199 artiklar.\n");//Skriver antalet säljare som nått nivå 4 i fil.
                    }
                }
            }
        }
    }
}