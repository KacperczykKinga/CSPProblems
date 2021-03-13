using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class HeurystykaZmiennej
    {
        Sudoku sudoku;
        List<int> kwadratyDoWykorzystania;
        List<int> posortowaneKwadraty;
        List<int> posortowaneIndeksy;
        int indeksWKwadracie = -1;
        int indeksWSudoku;
        int indeksWSudokuOgolnie = 0;


        public HeurystykaZmiennej(Sudoku s)
        {
            sudoku = s;
            kwadratyDoWykorzystania = new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0});
            posortowaneKwadraty = new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            posortowaneIndeksy = new List<int>();
            policzIleUzupelnionych();
            posortowaneKwadraty.Sort();
            sortujIndeksy();
            indeksWSudoku = kwadratyDoWykorzystania.IndexOf(posortowaneKwadraty[indeksWSudokuOgolnie]);
        }

        public void policzIleUzupelnionych()
        {
            for (int x = 0; x < 9; x ++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (sudoku.tabelaProblemu[x, y].wartosc == null)
                    {
                        kwadratyDoWykorzystania[((x / 3) * 3 + y / 3)]++;
                        posortowaneKwadraty[((x / 3) * 3 + y / 3)]++;
                    }
                }
            }
        }

        public void sortujIndeksy()
        {
            for (int i = 0; i < 9; i ++)
            {
                indexOf(posortowaneKwadraty[i]);
            }
        }

        public void indexOf(int numerek)
        {
            for(int i = 0; i < 9; i ++)
            {
                if(kwadratyDoWykorzystania[i] == numerek && !posortowaneIndeksy.Contains(i))
                {
                    posortowaneIndeksy.Add(i);
                }
            }
        }

        public Tuple<Zmienna, Tuple<int, int>> dajZmienna()
        {
            indeksWKwadracie ++;
            if(indeksWKwadracie == 9)
            {
                indeksWKwadracie = 0;
                indeksWSudokuOgolnie ++;
                if(indeksWSudokuOgolnie == 9)
                {
                    return null;
                }
               // Console.WriteLine(indeksWSudokuOgolnie);
                
                indeksWSudoku = posortowaneIndeksy [indeksWSudokuOgolnie];
            }
            int x = (indeksWSudoku / 3) * 3 + indeksWKwadracie / 3;
            int y = (indeksWSudoku % 3) * 3 + indeksWKwadracie % 3;
            //Console.WriteLine(indeksWSudokuOgolnie + " " + indeksWSudoku+ " " + indeksWKwadracie + " " + x + " " + y);
            Zmienna zmiennaNaTeraz = sudoku.tabelaProblemu[x, y];

            return new Tuple<Zmienna, Tuple<int, int>>(zmiennaNaTeraz, new Tuple<int, int>(x, y));
        }

        public void cofnijOJeden()
        {
            indeksWKwadracie--;
            if(indeksWKwadracie == -1)
            {
                indeksWKwadracie = 8;
                indeksWSudokuOgolnie--;
                indeksWSudoku = posortowaneIndeksy[indeksWSudokuOgolnie];
            }
        }
    }
}
