using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class HeurestykaProblemu
    {
        Problem omawianyProblem;
        int wykorzystaneZmienne;
        List<Tuple<int,int>> licznoscDziedziny;

        private static int porownajKrotki(Tuple<int, int> pierwsza, Tuple<int,int> druga)
        {
            return pierwsza.Item2.CompareTo(druga.Item2);
        }

        public HeurestykaProblemu(Problem sudoku)
        {
            omawianyProblem = sudoku;
            wykorzystaneZmienne = 0;
            licznoscDziedziny = new List<Tuple<int,int>>();
            policzLicznosci();
            licznoscDziedziny.Sort(porownajKrotki);
        }

        public void policzLicznosci()
        {
            for(int zm = 0; zm <omawianyProblem.rzedy * omawianyProblem.kolumny; zm ++)
            {
                licznoscDziedziny.Add(new Tuple<int, int>(zm, omawianyProblem.tabelaProblemu[zm/ omawianyProblem.rzedy, zm% omawianyProblem.rzedy].dziedzina.Count));
            }
        }

        public Tuple<Zmienna,Tuple<int,int>> dajKolejnaZmienna()
        {
            wykorzystaneZmienne++;
            if (wykorzystaneZmienne <= omawianyProblem.rzedy * omawianyProblem.kolumny)
            {
                return new Tuple<Zmienna, Tuple<int, int>>(omawianyProblem.tabelaProblemu[(licznoscDziedziny[wykorzystaneZmienne - 1].Item1) / omawianyProblem.rzedy, (licznoscDziedziny[wykorzystaneZmienne - 1].Item1) % omawianyProblem.rzedy],
                                                            new Tuple<int, int>((licznoscDziedziny[wykorzystaneZmienne - 1].Item1) / omawianyProblem.rzedy, (licznoscDziedziny[wykorzystaneZmienne - 1].Item1) % omawianyProblem.rzedy));
            }
            else
            {
                return null;
            }
        }

        public void cofnijOJeden()
        {
            wykorzystaneZmienne--;
        }

    }
}
