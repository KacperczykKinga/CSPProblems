using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class ZmiennaSudoku : Zmienna
    {
        public ZmiennaSudoku(char w)
        {
            wartosc = w - '0';
            if (!(wartosc >= 1 && wartosc <= 9))
            {
                wartosc = null;
                dziedzina = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            }
            else
            {
                dziedzina = new List<int>();
                dziedzina.Add(w - '0');
                dziedzina2.Add(w - '0');
            }
        }
    }
}
