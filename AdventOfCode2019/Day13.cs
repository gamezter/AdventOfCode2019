using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Day13
    {
        public static void part1()
        {
            Arcade arcade = new Arcade();

            int[,] matrix = new int[50, 50];
            int count = 0;

            while (true)
            {
                long x = arcade.run(0);
                long y = arcade.run(0);
                long id = arcade.run(0);
                if (id == 2)
                    count++;
                if (x != -1 && y != -1 && id != -1)
                    matrix[x, y] = (int)id;
                else break;
            }

            for(int y = 0; y < 50; y++)
            {
                for(int x = 0; x < 50; x++)
                {
                    if(matrix[x, y] == 0)
                        Console.Write(' ');
                    else
                        Console.Write(matrix[x, y]);
                }
                Console.WriteLine();
            }

            Console.WriteLine(count);
            Console.Read();
        }
    }

    class Arcade
    {
        string[] numbers;
        long[] mem;
        long pc;
        long relBase;
        bool running;

        public Arcade()
        {
            numbers = new StreamReader("day13.txt").ReadToEnd().Trim().Split(',');
            mem = new long[numbers.Length];

            running = true;
            relBase = 0;
            pc = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                mem[i] = long.Parse(numbers[i]);
            }
        }

        public long run(int input)
        {
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
                            mem[first] = input;
                            pc += 2;
                        }
                        break;
                    case 04:
                        {
                            pc += 2;
                            return mem[first];
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
            return -1;
        }
    }
}
