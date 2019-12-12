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
                int op = (int)mem[pc];
                int mode0 = (op / 100) % 10;
                int mode1 = (op / 1000) % 10;
                int mode2 = (op / 10000) % 10;

                long first = pc + 1;
                if (mode0 == 0)
                    first = mem[first];
                else if (mode0 == 2)
                    first = relBase + mem[first];

                long second = pc + 2;
                if (mode1 == 0)
                    second = mem[second];
                else if (mode1 == 2)
                    second = relBase + mem[second];

                long third = mem[pc + 3];
                if (mode2 == 2)
                    third = relBase + third;

                long max = Math.Max(Math.Max(first, second), third);

                if (max >= mem.Length)
                    Array.Resize(ref mem, (int)max + 1);

                switch (op % 100)
                {
                    case 01:
                        {
                            mem[third] = mem[first] + mem[second];
                            pc += 4;
                        }
                        break;
                    case 02:
                        {
                            mem[third] = mem[first] * mem[second];
                            pc += 4;
                        }
                        break;
                    case 03:
                        {
                            mem[first] = Console.ReadKey(true).KeyChar - '0';
                            pc += 2;
                        }
                        break;
                    case 04:
                        {
                            Console.Write(mem[first]);
                            pc += 2;
                        }
                        break;
                    case 05:
                        {
                            pc = mem[first] != 0 ? mem[second] : pc + 3;
                        }
                        break;
                    case 06:
                        {
                            pc = mem[first] == 0 ? mem[second] : pc + 3;
                        }
                        break;
                    case 07:
                        {
                            mem[third] = mem[first] < mem[second] ? 1 : 0;
                            pc += 4;
                        }
                        break;
                    case 08:
                        {
                            mem[third] = mem[first] == mem[second] ? 1 : 0;
                            pc += 4;
                        }
                        break;
                    case 09:
                        {
                            relBase += mem[first];
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
