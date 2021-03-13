using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class Czytacz
    {
        public static String czytajZPliku(String sciezka)
        {
            String daneSudokuWNapisie = File.ReadAllText(sciezka);
            return daneSudokuWNapisie;
        }

        public static String[] pokazPosplitowane(String napis)
        {
            return napis.Split('\n');
        }

    }
}
