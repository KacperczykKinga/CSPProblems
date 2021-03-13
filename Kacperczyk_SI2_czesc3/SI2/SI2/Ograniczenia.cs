using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    interface Ograniczenia
    {
        Boolean pionowo( int wartosc, int x, int y);
        Boolean poziomo( int wartosc, int x, int y);
        Boolean wKwadracie( int wartosc, int x, int y);
    }
}
