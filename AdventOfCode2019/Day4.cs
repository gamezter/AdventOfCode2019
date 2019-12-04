using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Day4
    {
        public static void part1()
        {
            int count = 0;

            int d0 = 2;
            int d1 = 4;
            int d2 = 8;
            int d3 = 8;
            int d4 = 8;
            int d5 = 8;

            while (d0 * 100000 + d1 * 10000 + d2 * 1000 + d3 * 100 + d4 * 10 + d5 <= 699999)
            {
                if(d0 == d1 || d1 == d2 || d2 == d3 || d3 == d4 || d4 == d5)
                    count++;

                if (d5 != 9)
                    d5++;
                else
                {
                    if (d4 != 9)
                        d4++;
                    else
                    {
                        if (d3 != 9)
                            d3++;
                        else
                        {
                            if (d2 != 9)
                                d2++;
                            else
                            {
                                if (d1 != 9)
                                    d1++;
                                else
                                {
                                    d1 = ++d0;
                                }
                                d2 = d1;
                            }
                            d3 = d2;
                        }
                        d4 = d3;
                    }
                    d5 = d4;
                }
            }
            Console.WriteLine(count);
            Console.Read();
        }

        public static void part2()
        {
            int count = 0;

            int d0 = 2;
            int d1 = 4;
            int d2 = 8;
            int d3 = 8;
            int d4 = 8;
            int d5 = 8;

            while (d0 * 100000 + d1 * 10000 + d2 * 1000 + d3 * 100 + d4 * 10 + d5 <= 699999)
            {
                if ((d0 == d1 && d1 != d2) || (d0 != d1 && d1 == d2 && d2 != d3) || (d1 != d2 && d2 == d3 && d3 != d4) || (d2 != d3 && d3 == d4 && d4 != d5) || (d3 != d4 && d4 == d5))
                    count++;

                if (d5 != 9)
                    d5++;
                else
                {
                    if (d4 != 9)
                        d4++;
                    else
                    {
                        if (d3 != 9)
                            d3++;
                        else
                        {
                            if (d2 != 9)
                                d2++;
                            else
                            {
                                if (d1 != 9)
                                    d1++;
                                else
                                {
                                    d1 = ++d0;
                                } 
                                d2 = d1;
                            }
                            d3 = d2;
                        }
                        d4 = d3;
                    }
                    d5 = d4;
                }
            }
            Console.WriteLine(count);
            Console.Read();
        }
    }
}
