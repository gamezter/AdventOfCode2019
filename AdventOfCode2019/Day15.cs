using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Day15
    {
        public static void part1()
        {
            Robot rob = new Robot("day15.txt");
            int x = 25; 
            int y = 25;

            Stack<(int x, int y)> past = new Stack<(int, int)>();
            past.Push((0, 0));
            past.Push((x, y));

            Console.SetCursorPosition(x, y);
            Console.Write('D');
            Console.SetCursorPosition(x, y);

            while (true)
            {
                var input = Console.ReadKey(true);
                long status;
                switch (input.Key)
                {
                    case ConsoleKey.LeftArrow:
                        status = rob.run(3);
                        moveX(x - 1, status);
                        break;
                    case ConsoleKey.UpArrow:
                        status = rob.run(1);
                        moveY(y - 1, status);
                        break;
                    case ConsoleKey.RightArrow:
                        status = rob.run(4);
                        moveX(x + 1, status);
                        break;
                    case ConsoleKey.DownArrow:
                        status = rob.run(2);
                        moveY(y + 1, status);
                        break;
                }
                Console.SetCursorPosition(0, 0);
                Console.Write(past.Count - 2);
            }

            void moveX(int newX, long status)
            {
                if (status == 0)
                {
                    Console.SetCursorPosition(newX, y);
                    Console.Write('#');
                }
                else if (status == 1)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write('.');
                    x = newX;
                    var current = past.Pop();
                    if (past.Peek().x != x)
                    {
                        past.Push(current);
                        past.Push((x, y));
                    }
                    Console.SetCursorPosition(x, y);
                    Console.Write('D');
                }
                else if (status == 2)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write('.');
                    x = newX;
                    Console.SetCursorPosition(x, y);
                    Console.Write('O');
                }
            }

            void moveY(int newY, long status)
            {
                if (status == 0)
                {
                    Console.SetCursorPosition(x, newY);
                    Console.Write('#');
                }
                else if (status == 1)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write('.');
                    y = newY;
                    var current = past.Pop();
                    if (past.Peek().y != y)
                    {
                        past.Push(current);
                        past.Push((x, y));
                    }
                    Console.SetCursorPosition(x, y);
                    Console.Write('D');
                }
                else if (status == 2)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write('.');
                    y = newY;
                    Console.SetCursorPosition(x, y);
                    Console.Write('O');
                }
            }
        }
    }
}
