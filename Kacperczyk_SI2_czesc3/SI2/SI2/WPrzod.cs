using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class WPrzod
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

        public WPrzod(Problem p)
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
            }
            else
            {

                int proponowanaWartosc = z1.Item1.dajKolejnaWartosc();
                while (proponowanaWartosc != 0)
                {
                    if ((problem.ogr.pionowo(proponowanaWartosc, z1.Item2.Item1, z1.Item2.Item2) &&
                             problem.ogr.poziomo(proponowanaWartosc, z1.Item2.Item1, z1.Item2.Item2) &&
                             problem.ogr.wKwadracie(proponowanaWartosc, z1.Item2.Item1, z1.Item2.Item2)))
                    {
                        z1.Item1.wartosc = proponowanaWartosc;
                        Boolean dalszyWezel = budujDrzewo();
                        if (!dalszyWezel)
                        {
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
                    proponowanaWartosc = z1.Item1.dajKolejnaWartosc();
                }

                z1.Item1.resetuj();
                return false;

            }
        }
    }
}
}
