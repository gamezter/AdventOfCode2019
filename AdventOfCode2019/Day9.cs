using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Day9
    {
        public static void part1()
        {
            string[] numbers = new StreamReader("day9.txt").ReadToEnd().Trim().Split(',');
            long[] mem = new long[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                mem[i] = long.Parse(numbers[i]);
            }

            bool running = true;

            long relBase = 0;
            long pc = 0;



            while (running)
            {
                if(pc == 187)
                {
                    int a = 9;
                }
                int op = (int)mem[pc];
                int mode0 = (op / 100) % 10;
                int mode1 = (op / 1000) % 10;
                int mode2 = (op / 10000) % 10;

                long first = mem[pc + 1];
                if (mode0 == 0)
                    first = first >= mem.Length ? 0 : mem[first];
                else if (mode0 == 2)
                    first = relBase + first >= mem.Length ? 0 : mem[relBase + first];

                long second = mem[pc + 2];
                if (mode1 == 0)
                    second = second >= mem.Length ? 0 : mem[second];
                else if (mode1 == 2)
                    second = relBase + second >= mem.Length ? 0 : mem[relBase + second];

                switch (op % 100)
                {
                    case 01:
                        {
                            long third = mem[pc + 3];
                            if (mode2 == 2)
                                third = relBase + third;

                            if (third >= mem.Length)
                                Array.Resize(ref mem, (int)third + 1);

                            mem[third] = first + second;
                            pc += 4;
                        }
                        break;
                    case 02:
                        {
                            long third = mem[pc + 3];
                            if (mode2 == 2)
                                third = relBase + third;

                            if (third >= mem.Length)
                                Array.Resize(ref mem, (int)third + 1);

                            mem[third] = first * second;
                            pc += 4;
                        }
                        break;
                    case 03:
                        {
                            first = mem[pc + 1];
                            if (mode0 == 2)
                                first = relBase + first;

                            if (first >= mem.Length)
                                Array.Resize(ref mem, (int)first + 1);

                            mem[first] = Console.ReadKey(true).KeyChar - '0';
                            pc += 2;
                        }
                        break;
                    case 04:
                        {
                            Console.Write(first);
                            pc += 2;
                        }
                        break;
                    case 05:
                        {
                            pc = first != 0 ? second : pc + 3;
                        }
                        break;
                    case 06:
                        {
                            pc = first == 0 ? second : pc + 3;
                        }
                        break;
                    case 07:
                        {
                            long third = mem[pc + 3];
                            if (mode2 == 2)
                                third = relBase + third;

                            if (third >= mem.Length)
                                Array.Resize(ref mem, (int)third + 1);

                            mem[third] = first < second ? 1 : 0;
                            pc += 4;
                        }
                        break;
                    case 08:
                        {
                            long third = mem[pc + 3];
                            if (mode2 == 2)
                                third = relBase + third;

                            if (third >= mem.Length)
                                Array.Resize(ref mem, (int)third + 1);

                            mem[third] = first == second ? 1 : 0;
                            pc += 4;
                        }
                        break;
                    case 09:
                        {
                            relBase += first;
                            pc += 2;
                        }
                        break;
                    case 99:
                        running = false;
                        break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("HALT");
            Console.Read();
        }
    }
}
