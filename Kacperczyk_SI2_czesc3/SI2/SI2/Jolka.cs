using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class Jolka : Problem
    {
        public List<String> slowa;
        int ktoraZmienna = 0;
        HeurestykaProblemu heurystykaDoZmiennych;

        public Jolka(String jolkaNapisem, String slowaNapisem) 
        {
            String[] kolejneDane = jolkaNapisem.Split('\n');
            kolumny = kolejneDane.Length;
            rzedy = kolejneDane[0].Length;
           // Console.WriteLine(kolumny + " " + rzedy);
            kolumny--;
            tabelaProblemu = new Zmienna[kolumny, rzedy];

            for (int i = 0; i < kolumny; i++)
            {
                for (int j = 0; j < rzedy ;j++)
                {
                    tabelaProblemu[i, j]  = new ZmiennaJolka(kolejneDane[i][j]);
                }
            }

            slowa = new List<String>(slowaNapisem.Split('\n'));
            ogr = new OgraniczeniaJolka(this);
            heurystykaDoZmiennych = new HeurestykaProblemu(this);
            okreslDziedziny();
          
        }

        public void okreslDziedziny()
        {
            for (int i = 0; i < kolumny; i++)
            {
                for (int j = 0; j < rzedy; j++)
                {
                    if (tabelaProblemu[i, j].dziedzina.Count != 1)
                    {
                        for (int wart = 0; wart < tabelaProblemu[i, j].dziedzina.Count; wart++)
                        {
                            if (!czyLiteraWSlowach(tabelaProblemu[i, j].dziedzina[wart]))
                            {
                                tabelaProblemu[i, j].dziedzina.Remove(tabelaProblemu[i, j].dziedzina[wart]);
                                wart--;
                            }
                        }
                    }
                }
            }
        }

        public Boolean czyLiteraWSlowach(int wartosc)
        {
            char szukany = (char)wartosc;
            foreach(String slowo in slowa)
            {
                if(slowo.Contains(szukany))
                {
                    return true;
                }
            }
            return false;
        }

        public override void wypisz()
        {
            for (int i = 0; i < kolumny; i++)
            {
                for (int j = 0; j < rzedy; j++)
                {

                    if (tabelaProblemu[i, j].wartosc == null)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write((char)tabelaProblemu[i, j].wartosc);
                    }
                }
                Console.WriteLine();
            }
        }

        
        public override Tuple<Zmienna, Tuple<int, int>> dajKolejnaZmienna()
        {
            return heurystykaDoZmiennych.dajKolejnaZmienna();
        }

        public override void cofnijOJeden()
        {
            heurystykaDoZmiennych.cofnijOJeden();
        }
    }
}
