using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Day5
    {
        public static void part1()
        {
            string[] numbers = new StreamReader("day5.txt").ReadToEnd().Trim().Split(',');
            int[] mem = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                mem[i] = int.Parse(numbers[i]);
            }

            bool running = true;

            int pc = 0;

            while (running)
            {
                int op = mem[pc];
                bool mode0 = (op / 100) % 10 == 0;
                bool mode1 = (op / 1000) % 10 == 0;

                switch (op % 100)
                {
                    case 01:
                        {
                            int first = mode0 ? mem[mem[pc + 1]] : mem[pc + 1];
                            int second = mode1 ? mem[mem[pc + 2]] : mem[pc + 2];
                            mem[mem[pc + 3]] = first + second;
                            pc += 4;
                        }
                        break;
                    case 02:
                        {
                            int first = mode0 ? mem[mem[pc + 1]] : mem[pc + 1];
                            int second = mode1 ? mem[mem[pc + 2]] : mem[pc + 2];
                            mem[mem[pc + 3]] = first * second;
                            pc += 4;
                        }
                        break;
                    case 03:
                        {
                            mem[mem[pc + 1]] = Console.ReadKey(true).KeyChar - '0';
                            pc += 2;
                        }
                        break;
                    case 04:
                        {
                            int first = mode0 ? mem[mem[pc + 1]] : mem[pc + 1];
                            Console.Write(first);
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

        public static void part2()
        {
            string[] numbers = new StreamReader("day5.txt").ReadToEnd().Trim().Split(',');
            int[] mem = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                mem[i] = int.Parse(numbers[i]);
            }

            bool running = true;

            int pc = 0;

            while (running)
            {
                int op = mem[pc];
                bool mode0 = (op / 100) % 10 == 0;
                bool mode1 = (op / 1000) % 10 == 0;

                switch (op % 100)
                {
                    case 01:
                        {
                            int first = mode0 ? mem[mem[pc + 1]] : mem[pc + 1];
                            int second = mode1 ? mem[mem[pc + 2]] : mem[pc + 2];
                            mem[mem[pc + 3]] = first + second;
                            pc += 4;
                        }
                        break;
                    case 02:
                        {
                            int first = mode0 ? mem[mem[pc + 1]] : mem[pc + 1];
                            int second = mode1 ? mem[mem[pc + 2]] : mem[pc + 2];
                            mem[mem[pc + 3]] = first * second;
                            pc += 4;
                        }
                        break;
                    case 03:
                        {
                            mem[mem[pc + 1]] = Console.ReadKey(true).KeyChar - '0';
                            pc += 2;
                        }
                        break;
                    case 04:
                        {
                            int first = mode0 ? mem[mem[pc + 1]] : mem[pc + 1];
                            Console.Write(first);
                            pc += 2;
                        }
                        break;
                    case 05:
                        {
                            int first = mode0 ? mem[mem[pc + 1]] : mem[pc + 1];
                            int second = mode1 ? mem[mem[pc + 2]] : mem[pc + 2];
                            pc = first != 0 ? second : pc + 3;
                        }
                        break;
                    case 06:
                        {
                            int first = mode0 ? mem[mem[pc + 1]] : mem[pc + 1];
                            int second = mode1 ? mem[mem[pc + 2]] : mem[pc + 2];
                            pc = first == 0 ? second : pc + 3;
                        }
                        break;
                    case 07:
                        {
                            int first = mode0 ? mem[mem[pc + 1]] : mem[pc + 1];
                            int second = mode1 ? mem[mem[pc + 2]] : mem[pc + 2];
                            mem[mem[pc + 3]] = first < second ? 1 : 0;
                            pc += 4;
                        }
                        break;
                    case 08:
                        {
                            int first = mode0 ? mem[mem[pc + 1]] : mem[pc + 1];
                            int second = mode1 ? mem[mem[pc + 2]] : mem[pc + 2];
                            mem[mem[pc + 3]] = first == second ? 1 : 0;
                            pc += 4;
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
