using System;
using System.IO;

namespace AdventOfCode2018
{
    class Day2
    {
        public static void part1()
        {
            string[] numbers = new StreamReader("day2.txt").ReadToEnd().Trim().Split(',');
            int[] prog = new int[numbers.Length];
            for(int i = 0; i < numbers.Length; i++)
            {
                prog[i] = int.Parse(numbers[i]);
            }
            prog[1] = 12;
            prog[2] = 2;

            bool running = true;

            int pc = 0;

            while (running)
            {
                int op = prog[pc];

                switch (op)
                {
                    case 1:
                        prog[prog[pc + 3]] = prog[prog[pc + 1]] + prog[prog[pc + 2]];
                        break;
                    case 2:
                        prog[prog[pc + 3]] = prog[prog[pc + 1]] * prog[prog[pc + 2]];
                        break;
                    case 99:
                        running = false;
                        break;
                }

                pc += 4;
            }


            Console.WriteLine(prog[0]);
            Console.Read();
        }

        public static void part2()
        {
            //done manually, simple math;
            //for my case noun = 82, verb = 26, answer = 8226
        }
    }
}
