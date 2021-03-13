using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class HeurystykaWartosci
    {
        Sudoku sudoku;
        List<int> licznoscWartosciWRzedach;
        List<int> licznoscWartosciWRzedachPosortowana;
        List<int> posortowaneWartosci;

        public HeurystykaWartosci(Sudoku s)
        {
            sudoku = s;
        }

        public void ustalDziedzineZmiennejWgHeusrystyki(Zmienna z, int x, int y)
        {
            licznoscWartosciWRzedach = new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            licznoscWartosciWRzedachPosortowana = new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            posortowaneWartosci = new List<int>();
            wypelnijListy(x, y);
            licznoscWartosciWRzedachPosortowana.Sort();
            sortujWartosci();
            wybierzWartosciDlaZmiennej(z);
           /* if(x == 3 && y == 4)
            {
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(licznoscWartosciWRzedach[i] + " ");
                }
                Console.WriteLine("");
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(posortowaneWartosci[j] + " ");
                }
                Console.WriteLine("");
            }*/
        }

        public void wypelnijListy(int x, int y)
        {
            for (int i = 0; i < 9; i++)
            {
                List<int> tymczasowaDlaZmiennejWRzedzie = sudoku.tabelaProblemu[x, i].dziedzina;
                for (int j = 0; j < tymczasowaDlaZmiennejWRzedzie.Count; j++)
                {
                    licznoscWartosciWRzedach[tymczasowaDlaZmiennejWRzedzie[j] - 1]++;
                    licznoscWartosciWRzedachPosortowana[tymczasowaDlaZmiennejWRzedzie[j] - 1]++;
                }

            }

            for( int k = 0; k < 9; k ++)
            {
                List<int> tymczasowaDlaZmiennejWRzedzie = sudoku.tabelaProblemu[k,y].dziedzina;
                for (int l = 0; l < tymczasowaDlaZmiennejWRzedzie.Count; l++)
                {
                    licznoscWartosciWRzedach[tymczasowaDlaZmiennejWRzedzie[l] - 1]++;
                    licznoscWartosciWRzedachPosortowana[tymczasowaDlaZmiennejWRzedzie[l] - 1]++;
                }
            }
        }

        public void sortujWartosci()
        {
            for (int i = 0; i < 9; i++)
            {
                indexOf(licznoscWartosciWRzedachPosortowana[i]);
            }
        }

        public void indexOf(int numerek)
        {
            for (int i = 0; i < 9; i++)
            {
                if (licznoscWartosciWRzedach[i] == numerek && !posortowaneWartosci.Contains(i + 1))
                {
                    posortowaneWartosci.Add(i + 1);
                }
            }
        }

        public void wybierzWartosciDlaZmiennej(Zmienna z)
        {
            for (int i = 0; i < 9; i ++)
            {
                if(z.dziedzina.Contains(posortowaneWartosci[i]))
                {
                    z.dziedzina2.Add(posortowaneWartosci[i]);
                }
            }
        }
    }
}
