using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2019
{
    class Day17
    {

        public static void part1()
        {
            char[,] map = new char[39, 39];
            int x = 0, y = 0;
            Robot rob = new Robot("day17.txt");
            long c = rob.run(0);
            while(c != -1)
            {
                if (c != '\n')
                {
                    map[x, y] = (char)c;
                    x++;
                }
                else
                {
                    y++;
                    x = 0;
                }
                c = rob.run(0);
            }

            x = 4;
            y = 0; // robot position
            int dir = 3; // u:0, r:1, d:2, l:

            HashSet<(int x, int y)> visited = new HashSet<(int x, int y)>();
            List<(int x, int y)> collisions = new List<(int x, int y)>();

            while (true)
            {
                if (!visited.Add((x, y)))
                    collisions.Add((x, y));
                switch (dir)
                {
                    case 0:
                        if (y == 0 || map[x, y - 1] != '#')
                        {
                            if (x - 1 > 0 && map[x - 1, y] == '#')
                            {
                                x--;
                                dir = 3;
                            }
                            else if (x + 1 < 39 && map[x + 1, y] == '#')
                            {
                                x++;
                                dir = 1;
                            }
                            else goto end;
                        }
                        else
                            y--;
                        break;
                    case 1:
                        if(x == 38 || map[x + 1, y] != '#')
                        {
                            if (y - 1 > 0 && map[x, y - 1] == '#')
                            {
                                y--;
                                dir = 0;
                            }
                            else if (y + 1 < 39 && map[x, y + 1] == '#')
                            {
                                y++;
                                dir = 2;
                            }
                            else goto end;
                        }
                        else
                        {
                            x++;
                        }
                        break;
                    case 2:
                        if (y == 38 || map[x, y + 1] != '#')
                        {
                            if (x - 1 > 0 && map[x - 1, y] == '#')
                            {
                                x--;
                                dir = 3;
                            }
                            else if (x + 1 < 39 && map[x + 1, y] == '#')
                            {
                                x++;
                                dir = 1;
                            }
                            else goto end;
                        }
                        else
                            y++;
                        break;
                    case 3:
                        if (x == 0 || map[x - 1, y] != '#')
                        {
                            if (y - 1 > 0 && map[x, y - 1] == '#')
                            {
                                y--;
                                dir = 0;
                            }
                            else if (y + 1 < 39 && map[x, y + 1] == '#')
                            {
                                y++;
                                dir = 2;
                            }
                            else goto end;
                        }
                        else
                            x--;
                        break;
                }
            }

            end:
            int sum = 0;
            foreach(var collision in collisions)
            {
                sum += collision.x * collision.y;
            }
            Console.Write(sum);
            Console.Read();
        }

        public static void part2()
        {
            Robot17 rob = new Robot17("day17.txt");
            long c = rob.run();
            while (c != -1)
            {
                c = rob.run();
                if(c < 512)
                    Console.Write((char)c);
                else
                    Console.Write(c);
            }

            /*
             solution:
                L4L4L10R4 R4L4L4R8R10 L4L4L10R4 R4L10R10 L4L4L10R4 R4L10R10 R4L4L4R8R10 R4L10R10 R4L10R10 R4L4L4R8R10
                ABACACBCCB

                A:L4L4L10R4
                B:R4L4L4R8R10
                C:R4L10R10
             */

            Console.Read();
        }
    }

    class Robot17
    {
        string[] numbers;
        long[] mem;
        long pc;
        long relBase;
        bool running;

        public Robot17(string program)
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
            mem[0] = 2;
        }

        public long run()
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
                            char c = Console.ReadKey().KeyChar;
                            if (c == '\r')
                                c = '\n';
                            mem[first] = c;
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
