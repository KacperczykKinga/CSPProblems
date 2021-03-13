using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class Zmienna
    {
        public int? wartosc;
        public List<int> dziedzina;
        public List<int> dziedzina2;
        public List<int> nieDoWykorzystaniaZDziedziny;
        public List<int> zablokowaneWDziedzinie;
        public int indeksObecny = 0;
        Random losowacz;

        public Zmienna()
        {
            losowacz = new Random();
            nieDoWykorzystaniaZDziedziny = new List<int>();
            zablokowaneWDziedzinie = new List<int>();
            dziedzina2 = new List<int>();
        }

        public int dajKolejnaWartosc3() //heurystyka
        {
            if (indeksObecny < dziedzina2.Count)
            {
                indeksObecny++;
                return dziedzina2[indeksObecny - 1];
            }
            else
            {
                indeksObecny++;
                return 0;
            }

        }

        public int dajKolejnaWartosc() //heurystyka
        {          
            if (indeksObecny < dziedzina.Count)
            {
                indeksObecny++;
                return dziedzina[indeksObecny - 1];
            }
            else
            {
                indeksObecny++;
                return 0;
            }

        }

        //poczatek do w przod i heurystyka
        public int dajKolejnaWartoscLosowo() 
        {
            if (dziedzina.Count > 0)
            {
                int indeksWylosowanej = losowacz.Next(dziedzina.Count);
                int wylosowanaWartosc = dziedzina[indeksWylosowanej];
                dziedzina.Remove(wylosowanaWartosc);
                nieDoWykorzystaniaZDziedziny.Add(wylosowanaWartosc);
                return wylosowanaWartosc;
            }
            else
            {
                return 0;
            }
        }

        public void usunZDziedziny(int liczba) 
        {
                dziedzina.Remove(liczba);
                zablokowaneWDziedzinie.Add(liczba);
        }

        public void zwrocDoDziedziny(int liczba)
        {
            zablokowaneWDziedzinie.Remove(liczba);
            dziedzina.Add(liczba);
        }

        public void zwrocWszystkoDoDziedziny()
        {
            foreach(int doZwrocenia in nieDoWykorzystaniaZDziedziny)
            {
                    dziedzina.Add(doZwrocenia);
            }
            nieDoWykorzystaniaZDziedziny = new List<int>();
        }
        //koniec do w przod


        //poczatek do w przod i heurystyka
       /* public int dajKolejnaWartoscLosowo()
        {
            if (dziedzina2.Count > 0)
            {
                int indeksWylosowanej = losowacz.Next(dziedzina2.Count);
                int wylosowanaWartosc = dziedzina2[indeksWylosowanej];
                dziedzina2.Remove(wylosowanaWartosc);
                nieDoWykorzystaniaZDziedziny.Add(wylosowanaWartosc);
                return wylosowanaWartosc;
            }
            else
            {
                return 0;
            }
        }

        public void usunZDziedziny(int liczba)
        {
            dziedzina2.Remove(liczba);
            zablokowaneWDziedzinie.Add(liczba);
        }

        public void zwrocDoDziedziny(int liczba)
        {
            zablokowaneWDziedzinie.Remove(liczba);
            dziedzina2.Add(liczba);
        }

        public void zwrocWszystkoDoDziedziny()
        {
            foreach (int doZwrocenia in nieDoWykorzystaniaZDziedziny)
            {
                dziedzina2.Add(doZwrocenia);
            }
            nieDoWykorzystaniaZDziedziny = new List<int>();
        }*/
        //koniec do w przod

        public void resetuj()
        {
            indeksObecny = 0;
        }

    }
}
