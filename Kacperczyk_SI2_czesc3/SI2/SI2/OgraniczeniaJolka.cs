using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class OgraniczeniaJolka : Ograniczenia
    {
        Jolka jolka;

        public OgraniczeniaJolka(Jolka j)
        {
            jolka = j;
        }

        public Boolean pionowo(int wartosc, int x, int y)
        {
            String mozeSlowo = "";
            for (int k = 0; k < jolka.kolumny; k++)
            {
                if(jolka.tabelaProblemu[k, y].wartosc == '#')
                {
                    if (mozeSlowo.Length >= 2)
                    {
                        if (!slowoWLiscie(mozeSlowo))
                        {
                            return false;
                        }
                    }
                    mozeSlowo = "";
                }
                else if(k == x)
                {
                    if (wartosc != '#')
                    {
                        mozeSlowo += (char)wartosc;
                    }
                    else
                    {
                        if (mozeSlowo.Length >= 2)
                        {
                            if (!slowoWLiscie(mozeSlowo))
                            {
                                return false;
                            }
                        }
                        mozeSlowo = "";
                    }
                }
                else if (jolka.tabelaProblemu[k, y].wartosc == null)
                {
                    mozeSlowo = "";
                    while (k < jolka.kolumny && jolka.tabelaProblemu[k, y].wartosc != '#' )
                    {
                        k++;
                    }
                }
                else
                {
                    mozeSlowo += (char)jolka.tabelaProblemu[k, y].wartosc;
                }
            }
            if (mozeSlowo.Length <= 1 || slowoWLiscie(mozeSlowo))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean poziomo(int wartosc, int x, int y)
        {
            String mozeSlowo = "";
            for (int r = 0; r < jolka.rzedy; r++)
            {
                if (jolka.tabelaProblemu[x, r].wartosc == '#')
                {
                    if (mozeSlowo.Length >= 2)
                    {
                        if (!slowoWLiscie(mozeSlowo))
                        {
                            return false;
                        }
                    }
                    mozeSlowo = "";
                }
                else if (r == y)
                {
                    if (wartosc != '#')
                    {
                        mozeSlowo += (char)wartosc;
                    }
                    else
                    {
                        if (mozeSlowo.Length >= 2)
                        {
                            if (!slowoWLiscie(mozeSlowo))
                            {
                                return false;
                            }
                        }
                        mozeSlowo = "";
                    }
                }
                else if(jolka.tabelaProblemu[x, r].wartosc == null)
                {
                    mozeSlowo = "";
                    while (r < jolka.rzedy && jolka.tabelaProblemu[x, r].wartosc != '#' )
                    {
                        r++;
                    }
                }
                else 
                {
                    mozeSlowo += (char)jolka.tabelaProblemu[x, r].wartosc;
                }
            }
            if (mozeSlowo.Length <= 1 || slowoWLiscie(mozeSlowo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean wKwadracie(int wartosc, int x, int y)
        {
            return true;
        }

        public Boolean slowoWLiscie(String slowo)
        {
            return jolka.slowa.Contains(slowo);
        }   
    }
}
