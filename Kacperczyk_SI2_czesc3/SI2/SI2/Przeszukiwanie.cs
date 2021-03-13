using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class Przeszukiwanie
    {
            Problem problem;
            int liczbaWezlowDo1;
            int liczbaNawrotowDo1;
            int liczbaWszystkichWezlow;
            int liczbaWszystkichNawrotow;
            int liczbaRoziwazan;
            Boolean pierwszyZnaleziony;
            DateTime poczatek;
            DateTime znalezienie1;
            DateTime koniec;

            public Przeszukiwanie(Problem p)
            {
                problem = p;
                liczbaNawrotowDo1 = 0;
                liczbaWezlowDo1 = 0;
                liczbaWszystkichNawrotow = 0;
                liczbaWszystkichWezlow = 0;
                liczbaRoziwazan = 0;
                pierwszyZnaleziony = false;
            }

            public String wypiszBadanie()
            {
                return "Czas do znalezienia 1: " + (znalezienie1 - poczatek) +
                        "\nLiczba węzłów do znalezienia 1: " + liczbaWezlowDo1 +
                        "\nLiczba nawrotów do znalezienia 1: " + liczbaNawrotowDo1 +
                        "\nCałkowity czas działania metody: " + (koniec - poczatek) +
                        "\nCałkowita liczba odwiedzonych węzłów: " + liczbaWszystkichWezlow +
                        "\nCałkowita liczba nawrotów: " + liczbaWszystkichNawrotow +
                        "\nCałkowita liczba rozwiązań: " + liczbaRoziwazan;
            }

        public String badanie()
        {
            return (znalezienie1 - poczatek) +
                    "\n" + (koniec - poczatek) +
                    "\n" + liczbaWezlowDo1 +
                    "\n" + liczbaNawrotowDo1 +  
                    "\n" + liczbaWszystkichWezlow +
                    "\n" + liczbaWszystkichNawrotow +
                    "\n" + liczbaRoziwazan;
        }

        public void zacznijBudowac()
            {
                poczatek = DateTime.Now;
                this.budujDrzewo();
                koniec = DateTime.Now;
            }

            public Boolean budujDrzewo()
            {
                Tuple<Zmienna, Tuple<int, int>> z1 = problem.dajKolejnaZmienna();
                if (!pierwszyZnaleziony)
                {
                    liczbaWezlowDo1++;
                }
                liczbaWszystkichWezlow++;
                if (z1 == null)
                {
                    problem.wypisz();
                    liczbaRoziwazan++;
                    if (!pierwszyZnaleziony)
                    {
                        znalezienie1 = DateTime.Now;
                        pierwszyZnaleziony = true;
                    }
                return false;
               // return true;
                }
                else
                {

                //int proponowanaWartosc = z1.Item1.dajKolejnaWartoscLosowo();
                int proponowanaWartosc = z1.Item1.dajKolejnaWartosc();
                while (proponowanaWartosc != 0)
                {
                    //Console.WriteLine("mmm " + proponowanaWartosc + " " + z1.Item2.Item1 + " " + z1.Item2.Item2);
                    // int poprzedniawartosc = (int)z1.Item1.wartosc;
                    List<Zmienna> odchudzoneZmienne = new List<Zmienna>();
                    z1.Item1.wartosc = proponowanaWartosc;
                    odchudzDziedziny(proponowanaWartosc, odchudzoneZmienne);

                    if (czyKtorasPusta())
                    {
                        przywrocDoDziedzin(proponowanaWartosc, odchudzoneZmienne);
                        z1.Item1.wartosc = null;
                    }
                    else
                    {
                      //  Console.WriteLine("kkk "+ proponowanaWartosc + " " + z1.Item2.Item1 + " " + z1.Item2.Item2);
                        Boolean dalszyWezel = budujDrzewo();
                        if (!dalszyWezel)
                        {
                            przywrocDoDziedzin(proponowanaWartosc, odchudzoneZmienne);
                            z1.Item1.wartosc = null;
                            problem.cofnijOJeden();
                            if (!pierwszyZnaleziony)
                            {
                                liczbaNawrotowDo1++;
                            }
                            liczbaWszystkichNawrotow++;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    //proponowanaWartosc = z1.Item1.dajKolejnaWartoscLosowo();
                    proponowanaWartosc = z1.Item1.dajKolejnaWartosc();
                }
                z1.Item1.zwrocWszystkoDoDziedziny();
                //problem.cofnijOJeden();
                z1.Item1.resetuj();
                return false;

                }
            }

        public void odchudzDziedziny(int proponowanaWartosc, List<Zmienna> odchudzone)
        {
            for (int k = 0; k < problem.kolumny; k++)
            {
                for (int r = 0; r < problem.rzedy; r++)
                {
                    if (problem.tabelaProblemu[k, r].wartosc == null && problem.tabelaProblemu[k, r].dziedzina.Contains(proponowanaWartosc))
                    {
                        if (!((problem.ogr.pionowo(proponowanaWartosc, k, r) &&
                         problem.ogr.poziomo(proponowanaWartosc, k, r) &&
                         problem.ogr.wKwadracie(proponowanaWartosc, k, r))))
                        {
                            problem.tabelaProblemu[k, r].usunZDziedziny(proponowanaWartosc);
                            odchudzone.Add(problem.tabelaProblemu[k, r]);
                        }
                    }
                }
            }
        }

        public Boolean czyKtorasPusta()
        {
            for (int k2 = 0; k2 < problem.kolumny; k2++)
            {
                for (int r2 = 0; r2 < problem.rzedy; r2++)
                {
                    if (problem.tabelaProblemu[k2, r2].wartosc == null && problem.tabelaProblemu[k2, r2].dziedzina.Count == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void przywrocDoDziedzin(int proponowanaWartosc, List<Zmienna> odchudzone)
        {
            foreach(Zmienna odch in odchudzone)
            {
                odch.zwrocDoDziedziny(proponowanaWartosc);
            }                       
        }

        //public void napraw(Zmienna z, int x, int y)
        //{
        //    for(int w = 0; w < z.dziedzina.Count; w++)
        //    {
        //        if (!((problem.ogr.pionowo(z.dziedzina[w], x, y) &&
        //                 problem.ogr.poziomo(z.dziedzina[w], x, y) &&
        //                 problem.ogr.wKwadracie(z.dziedzina[w], x, y))))
        //        {
        //            z.usunZDziedziny(z.dziedzina[w]);
        //            w--;
        //        }
        //    }
        //}
    }
   
}
