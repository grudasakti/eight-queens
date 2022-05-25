using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas2_672019252
{
    class Program
    {
        static void cetakPapan(int[,] papan)
        {
            for (int i=0; i<8; i++)
            {
                for(int j=0; j<8; j++)
                {
                    Console.Write("[" + papan[i, j] + "]");
                }
            Console.WriteLine();
            }
        }
        
        static void Main(string[] args)
        {
            int[,] papan = new int[8, 8];

            for(int i=0; i<8; i++)
            {
                for(int j=0; j<8; j++)
                {
                    papan[i, j] = 0;
                }
            }

            papan[0, 0] = 1;

            if (cariSolusi(1, papan) == 0)
            {
                Console.Write("Tidak Ada Solusi");
            }
            else
            {
                cetakPapan(papan);
            }

            Console.ReadKey();
        }

        static int bolehJalan(int x_next, int y_next, int[,] papan)
        {
            int a, b;

            for(a=0; a<y_next; a++)
            {
                if (papan[x_next,a] != 0)
                {
                    return 0;
                }
            }

            a = x_next;
            b = y_next;
            while (a>=0 && b>=0) {
                if(papan[a,b] != 0)
                {
                    return 0;
                }
                a--;
                b--;
            }

            a = x_next;
            b = y_next;
            while (a<8 && b>=0)
            {
                if(papan[a,b] != 0)
                {
                    return 0;
                }
                a++;
                b--;
            }

            return 1;
        }

        static int cariSolusi(int lkh, int[,] papan)
        {
            if (lkh == 8)
            {
                return 1;
            }
            else
            {
                for(int i=0; i<8; i++)
                {
                    int x_next = i;
                    int y_next = lkh;

                    if (bolehJalan(x_next, y_next, papan) == 1)
                    {
                        papan[x_next, y_next] = lkh + 1;

                        if(cariSolusi(lkh+1, papan) == 1)
                        {
                            return 1;
                        }
                        else
                        {
                            papan[x_next, y_next] = 0;
                        }
                    }
                }
            }

            return 0;
        }
    }
}