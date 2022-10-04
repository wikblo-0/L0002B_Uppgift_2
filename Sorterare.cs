//Wiktoria Blomgren Strandberg
//wikblo-0@student.ltu.se
//L0002B Uppgift 2

using System;
using System.Collections;

namespace L0002B_Uppgift_2
{
    internal class Sorterare : IComparer//Sorterar säljardatan baserat på antalet sålda artiklar.
    {
        int IComparer.Compare(Object xx, Object yy)
        {
            Säljare x = (Säljare)xx;
            Säljare y = (Säljare)yy;
            return x.AntalSåldaArtiklar.CompareTo(y.AntalSåldaArtiklar);
        }
    }
}
