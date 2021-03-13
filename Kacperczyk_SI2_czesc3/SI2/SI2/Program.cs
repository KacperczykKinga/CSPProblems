using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class Program
    {
        static void Main(string[] args)
        {
            String sudoki = @"D:\SI\ai-lab2-2020-dane\ai-lab2-2020-dane\Sudoku.csv"; 
            String pliczek = Czytacz.czytajZPliku(sudoki);
            String[] podzielone = Czytacz.pokazPosplitowane(pliczek);
            //for (int i = 0; i < 10; i++)
          /*  {
                Sudoku s1 = new Sudoku(podzielone[43]);
                s1.wypisz();
                Drzewo d = new Drzewo(s1);
                d.zacznijBudowac();
                Console.Write(d.badanie());
                Console.WriteLine("");
            }*/
            /*  String puzzle = @"D:\SI\ai-lab2-2020-dane\ai-lab2-2020-dane\Jolka\puzzle0";
              String puzelki = Czytacz.czytajZPliku(puzzle);
              String slowa = @"D:\SI\ai-lab2-2020-dane\ai-lab2-2020-dane\Jolka\words0";
              String slowka = Czytacz.czytajZPliku(slowa);
              Jolka j1 = new Jolka(puzelki, slowka);
              j1.wypisz();
              Drzewo d2 = new Drzewo(j1);
              d2.zacznijBudowac();
              Console.WriteLine(d2.wypiszBadanie());*/

          // for (int i = 0; i < 3; i++)
            {
                Sudoku s12 = new Sudoku(podzielone[45]);
                s12.wypisz();
                Przeszukiwanie p = new Przeszukiwanie(s12);
                p.zacznijBudowac();
                Console.Write(p.badanie());
                Console.WriteLine("");
            }
              //  Console.WriteLine(i);*/
           // }
               // Console.WriteLine(i);

        }
    }
}
