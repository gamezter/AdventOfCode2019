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

        public static void part2()
        {
            Computer[] computers = new Computer []{ new Computer(), new Computer(), new Computer(), new Computer(), new Computer() };

            long max = 0;

            for (int a = 5; a < 10; a++)
            {
                for (int b = 5; b < 10; b++)
                {
                    if (b == a)
                        continue;

                    for (int c = 5; c < 10; c++)
                    {
                        if (c == b || c == a)
                            continue;

                        for (int d = 5; d < 10; d++)
                        {
                            if (d == c || d == b || d == a)
                                continue;

                            for (int e = 5; e < 10; e++)
                            {
                                if (e == d || e == c || e == b || e == a)
                                    continue;

                                computers[0].init(a);
                                computers[1].init(b);
                                computers[2].init(c);
                                computers[3].init(d);
                                computers[4].init(e);
                                int res = 0;
                                for (int i = 0; i < 10; i++)
                                {
                                    res = computers[0].run(res);
                                    res = computers[1].run(res);
                                    res = computers[2].run(res);
                                    res = computers[3].run(res);
                                    res = computers[4].run(res);
                                }

                                if (res > max)
                                    max = res;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(max);
            Console.Read();

        }
    }

    class Computer
    {
        string[] numbers;
        int[] mem;
        int pc;
        int order;
        bool setOrder;

        public Computer()
        {
            numbers = new StreamReader("day7.txt").ReadToEnd().Trim().Split(',');
            mem = new int[numbers.Length];
        }

        public void init(int order)
        {
            this.order = order;
            setOrder = false;
            pc = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                mem[i] = int.Parse(numbers[i]);
            }
        }
        
        public int run(int input)
        {
            while (true)
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
                            if (!setOrder)
                            {
                                mem[mem[pc + 1]] = order;
                                setOrder = true;
                            }
                            else
                                mem[mem[pc + 1]] = input;
                            pc += 2;
                        }
                        break;
                    case 04:
                        {
                            int first = mode0 ? mem[mem[pc + 1]] : mem[pc + 1];
                            pc += 2;
                            return first;
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
                        return -1;
                }
            }
        }
    }
}
