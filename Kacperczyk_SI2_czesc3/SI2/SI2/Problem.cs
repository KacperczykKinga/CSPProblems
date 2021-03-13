using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    abstract class Problem
    {
        public int kolumny;
        public int rzedy;
        public Zmienna[,] tabelaProblemu;
        public Ograniczenia ogr;

        public abstract void wypisz();
        public abstract Tuple<Zmienna, Tuple<int, int>> dajKolejnaZmienna(); //heurestyki
        public abstract void cofnijOJeden();
    }
}
