using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class OgraniczeniaSudoku : Ograniczenia
    {
        Sudoku sudoku;

        public OgraniczeniaSudoku(Sudoku s)
        {
            sudoku = s;
        }

        public Boolean pionowo(int wartosc, int x, int y)
        {
            for (int k = 0; k < 9; k++)
            {
                if( k != x && sudoku.tabelaProblemu[k, y].wartosc == wartosc)
                {
                    return false;
                }
            }
            return true;
        }

        public Boolean poziomo(int wartosc, int x, int y)
        {
            for ( int r = 0; r < 9; r ++)
            {
                if (r != y && sudoku.tabelaProblemu[x, r].wartosc == wartosc)
                {
                    return false;
                }
            }
            return true;
        }

        public Boolean wKwadracie(int wartosc, int x, int y)
        {
            if( x <= 2)
            {
                if( y <=2)
                {
                    for (int k = 0; k < 3; k ++)
                    {
                        for (int r = 0; r < 3; r++)
                        {
                            if ( k != x && r != y && sudoku.tabelaProblemu[k, r].wartosc == wartosc)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
                else if ( y <= 5)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        for (int r = 3; r < 6; r++)
                        {
                            if (k != x && r != y && sudoku.tabelaProblemu[k, r].wartosc == wartosc)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    for (int k = 0; k < 3; k++)
                    {
                        for (int r = 6; r < 9; r++)
                        {
                            if (k != x && r != y && sudoku.tabelaProblemu[k, r].wartosc == wartosc)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
            }
            else if ( x <= 5)
            {
                if (y <= 2)
                {
                    for (int k = 3; k < 6; k++)
                    {
                        for (int r = 0; r < 3; r++)
                        {
                            if (k != x && r != y && sudoku.tabelaProblemu[k, r].wartosc == wartosc)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
                else if (y <= 5)
                {
                    for (int k = 3; k < 6; k++)
                    {
                        for (int r = 3; r < 6; r++)
                        {
                            if (k != x && r != y && sudoku.tabelaProblemu[k, r].wartosc == wartosc)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    for (int k = 3; k < 6; k++)
                    {
                        for (int r = 6; r < 9; r++)
                        {
                            if (k != x && r != y && sudoku.tabelaProblemu[k, r].wartosc == wartosc)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
            }
            else
            {
                if (y <= 2)
                {
                    for (int k = 6; k < 9; k++)
                    {
                        for (int r = 0; r < 3; r++)
                        {
                            if (k != x && r != y && sudoku.tabelaProblemu[k, r].wartosc == wartosc)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
                else if (y <= 5)
                {
                    for (int k = 6; k < 9; k++)
                    {
                        for (int r = 3; r < 6; r++)
                        {
                            if (k != x && r != y && sudoku.tabelaProblemu[k, r].wartosc == wartosc)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    for (int k = 6; k < 9; k++)
                    {
                        for (int r = 6; r < 9; r++)
                        {
                            if (k != x && r != y && sudoku.tabelaProblemu[k, r].wartosc == wartosc)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
            }
        }

    }
}
