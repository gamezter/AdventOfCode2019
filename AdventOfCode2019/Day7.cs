using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Day7
    {
        public static void part1()
        {
            Func<int, int>[] f = new Func<int, int>[5];
            f[0] = x => 4 * x + 16;
            f[1] = x => 32 * x + 22;
            f[2] = x => 5 * x + 25;
            f[3] = x => 24 * x + 60;
            f[4] = x => 3 * x + 6;

            int max = 0;

            for(int a = 0; a < 5; a++)
            {
                for(int b = 0; b < 5; b++)
                {
                    if (b == a)
                        continue;

                    for(int c = 0; c < 5; c++)
                    {
                        if (c == b || c == a)
                            continue;

                        for(int d = 0; d < 5; d++)
                        {
                            if (d == c || d == b || d == a)
                                continue;

                            for(int e = 0; e < 5; e++)
                            {
                                if (e == d || e == c || e == b || e == a)
                                    continue;

                                int val = f[e](f[d](f[c](f[b](f[a](0)))));
                                if (val > max)
                                    max = val;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(max);
            Console.Read();
        }
    }
}
