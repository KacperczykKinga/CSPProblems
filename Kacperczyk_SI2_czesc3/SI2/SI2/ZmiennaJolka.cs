using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class ZmiennaJolka : Zmienna
    {
        public ZmiennaJolka(char w)
        {
            wartosc = w ;
            if (wartosc != '#')
            {
                wartosc = null;
                dziedzina = new List<int>(new int[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l' 
                    ,'m', 'n', 'o', 'p', 'r' ,'s', 't', 'u', 'v','w', 'x', 'y','z', 'A', 'B', 'C', 'D', 'E', 'F', 'G'
                    ,'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'});
            }
            else
            {
                dziedzina = new List<int>();
                dziedzina.Add(w);
            }
        }
    }
}
