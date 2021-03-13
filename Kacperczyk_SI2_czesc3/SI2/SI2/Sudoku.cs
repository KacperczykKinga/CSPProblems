using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class Sudoku : Problem
    {
        HeurestykaProblemu heurystykaDoZmiennych;
        HeurystykaZmiennej heurystykaDoZmiennych2;
        HeurystykaWartosci heurydtykaDlaWartosci;
        int indeks;
        
        public Sudoku( String sudokuNapisem)
        {
            indeks = -1;
            kolumny = 9;
            rzedy = 9;
            tabelaProblemu = new Zmienna[kolumny, rzedy];
            String[] kolejneDane = sudokuNapisem.Split(';');
            for (int i = 0; i < kolumny; i ++)
            {
                for ( int j = 0; j < rzedy; j ++)
                {
                    tabelaProblemu[i,j] = new ZmiennaSudoku(kolejneDane[2][i * 9 + j]);
                }
            }
            ogr = new OgraniczeniaSudoku(this);
            heurystykaDoZmiennych = new HeurestykaProblemu(this);
            heurystykaDoZmiennych2 = new HeurystykaZmiennej(this);
            heurydtykaDlaWartosci = new HeurystykaWartosci(this);
            okreslDziedziny();
            okreslDziedziny2();
          /*  Zmienna z = tabelaProblemu[1, 1];
            for(int i = 0; i < z.dziedzina.Count; i ++)
            {
                Console.Write(z.dziedzina[i] + " ");
            }
            Console.WriteLine("");
            for (int j = 0; j < z.dziedzina2.Count; j++)
            {
                Console.Write(z.dziedzina2[j] + " ");
            }
            Console.WriteLine("");*/
        }

        public void okreslDziedziny2()
        {
            for (int i = 0; i < kolumny; i++)
            {
                for (int j = 0; j < rzedy; j++)
                {
                    if (tabelaProblemu[i, j].wartosc == null)
                    {
                        heurydtykaDlaWartosci.ustalDziedzineZmiennejWgHeusrystyki(tabelaProblemu[i, j], i, j);
                    }
                }
            }
        }
        public void okreslDziedziny()
        {
            for (int i = 0; i < kolumny; i ++)
            {
                for (int j = 0; j < rzedy; j ++)
                {
                    if(tabelaProblemu[i,j].dziedzina.Count != 1)
                    {
                        for (int wart = 0; wart < tabelaProblemu[i, j].dziedzina.Count; wart ++)
                        {
                            if(!ogr.pionowo(tabelaProblemu[i, j].dziedzina[wart], i, j) ||
                             !ogr.poziomo(tabelaProblemu[i, j].dziedzina[wart], i, j) ||
                             !ogr.wKwadracie(tabelaProblemu[i, j].dziedzina[wart], i, j))
                            {
                                tabelaProblemu[i, j].dziedzina.Remove(tabelaProblemu[i, j].dziedzina[wart]);
                                wart--;
                            }


                        }
                    }
                }
            }
        }

        
        public override void wypisz()
        {
            for (int i = 0; i < kolumny; i++)
            {
                for (int j = 0; j < rzedy; j++)
                {
                    Console.Write(tabelaProblemu[i, j].wartosc);
                    if (tabelaProblemu[i, j].wartosc == null)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

       /* public override Tuple<Zmienna, Tuple<int, int>> dajKolejnaZmienna()
        {
            return heurystykaDoZmiennych.dajKolejnaZmienna();
        }

        public override void cofnijOJeden()
        {
            heurystykaDoZmiennych.cofnijOJeden();
        }*/
        
        //heurystyka
        /* public override Tuple<Zmienna, Tuple<int, int>> dajKolejnaZmienna()
          {

              indeks++;
              if (indeks < 81)
              {
                  return new Tuple<Zmienna, Tuple<int, int>>(tabelaProblemu[indeks / 9, indeks % 9], new Tuple<int, int>(indeks / 9, indeks % 9));
              }
              else
              {
                  return null;
              }
          }

          public override void cofnijOJeden()
          {
              indeks--;
          }*/
          
        public override Tuple<Zmienna, Tuple<int, int>> dajKolejnaZmienna()
        {
            return heurystykaDoZmiennych2.dajZmienna();
        }

        public override void cofnijOJeden()
        {
            heurystykaDoZmiennych2.cofnijOJeden();
        }
    }
}
