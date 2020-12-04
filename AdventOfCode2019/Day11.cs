using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Day11
    {
        public static void part1()
        {
            Robot rob = new Robot("day11.txt");
            int x = 49;
            int y = 49;
            int direction = 0; // 0 up, 1 right, 2 down, 3 left
            int[,] map = new int[100, 100];
            long dir = 0;
            while(dir != -1)
            {
                if (map[x,y] > 1)
                {
                    if (rob.run(1) == 0)
                        map[x,y] = 1;
                }
                else
                {
                    if (rob.run(0) == 1)
                        map[x,y] = 2;
                }
                dir = rob.run(0);
                if (dir == 0)
                {
                    if (direction == 0)
                        direction = 3;
                    else
                        direction--;
                    if (direction == 0)
                        y--;
                    else if (direction == 1)
                        x++;
                    else if (direction == 2)
                        y++;
                    else if (direction == 3)
                        x--;
                }
                else if (dir == 1)
                {
                    direction = (direction + 1) % 4;
                    if (direction == 0)
                        y--;
                    else if (direction == 1)
                        x++;
                    else if (direction == 2)
                        y++;
                    else if (direction == 3)
                        x--;
                }
            }

            int count = 0;
            for(int j = 0; j < 100; j++)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (map[i, j] != 0)
                        count++;
                }
            }

            Console.WriteLine(count);
            Console.Read();
        }

        public static void part2()
        {
            Robot rob = new Robot("day11.txt");
            int x = 49;
            int y = 49;
            int direction = 0; // 0 up, 1 right, 2 down, 3 left
            int[,] map = new int[100, 100];
            map[49, 49] = 1;
            long dir = 0;
            while (dir != -1)
            {
                if (map[x, y] == 1)
                {
                    if (rob.run(1) == 0)
                        map[x, y] = 0;
                }
                else
                {
                    if (rob.run(0) == 1)
                        map[x, y] = 1;
                }
                dir = rob.run(0);
                if (dir == 0)
                {
                    if (direction == 0)
                        direction = 3;
                    else
                        direction--;
                    if (direction == 0)
                        y--;
                    else if (direction == 1)
                        x++;
                    else if (direction == 2)
                        y++;
                    else if (direction == 3)
                        x--;
                }
                else if (dir == 1)
                {
                    direction = (direction + 1) % 4;
                    if (direction == 0)
                        y--;
                    else if (direction == 1)
                        x++;
                    else if (direction == 2)
                        y++;
                    else if (direction == 3)
                        x--;
                }
            }

            int count = 0;
            for (int j = 0; j < 100; j++)
            {
                for (int i = 0; i < 100; i++)
                {
                    int val = map[i, j];
                    if (val == 1)
                        Console.Write('#');
                    else
                        Console.Write('.');
                    if (val != 0)
                        count++;
                }
                Console.WriteLine();
            }

            Console.Read();
        }
    }

    class Robot
    {
        string[] numbers;
        long[] mem;
        long pc;
        long relBase;
        bool running;

        public Robot(string program)
        {
            numbers = new StreamReader(program).ReadToEnd().Trim().Split(',');
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
