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

            for(int i = 248345; i <= 746315; i++)
            {
                int d0 = i / 100000;
                int d1 = i / 10000 - d0 * 10;
                int d2 = i / 1000 - d1 * 10 - d0 * 100;
                int d3 = i / 100 - d2 * 10 - d1 * 100 - d0 * 1000;
                int d4 = i / 10 - d3 * 10 - d2 * 100 - d1 * 1000 - d0 * 10000;
                int d5 = i - d4 * 10 - d3 * 100 - d2 * 1000 - d1 * 10000 - d0 * 100000;

                if(d0 <= d1 && d1 <= d2 && d2 <= d3 && d3 <= d4 && d4 <= d5)
                {
                    if(d0 == d1 || d1 == d2 || d2 == d3 || d3 == d4 || d4 == d5)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
            Console.Read();
        }

        public static void part2()
        {
            int count = 0;

            for (int i = 248345; i <= 746315; i++)
            {
                int d0 = i / 100000;
                int d1 = i / 10000 - d0 * 10;
                int d2 = i / 1000 - d1 * 10 - d0 * 100;
                int d3 = i / 100 - d2 * 10 - d1 * 100 - d0 * 1000;
                int d4 = i / 10 - d3 * 10 - d2 * 100 - d1 * 1000 - d0 * 10000;
                int d5 = i - d4 * 10 - d3 * 100 - d2 * 1000 - d1 * 10000 - d0 * 100000;

                if (d0 <= d1 && d1 <= d2 && d2 <= d3 && d3 <= d4 && d4 <= d5)
                {
                    if ((d0 == d1 && d1 != d2) || (d0 != d1 && d1 == d2 && d2 != d3) || (d1 != d2 && d2 == d3 && d3 != d4) || (d2 != d3 && d3 == d4 && d4 != d5) || (d3 != d4 && d4 == d5))
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
            Console.Read();
        }
    }
}
