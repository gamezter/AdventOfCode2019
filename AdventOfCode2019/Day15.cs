﻿using System;
using System.Collections.Generic;

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
            past.Push((x, y));

            Console.SetCursorPosition(x, y);
            Console.Write('D');
            Console.SetCursorPosition(x, y);

            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.LeftArrow:
                        move(x - 1, y, rob.run(3));
                        break;
                    case ConsoleKey.UpArrow:
                        move(x, y - 1, rob.run(1));
                        break;
                    case ConsoleKey.RightArrow:
                        move(x + 1, y, rob.run(4));
                        break;
                    case ConsoleKey.DownArrow:
                        move(x, y + 1, rob.run(2));
                        break;
                }
                Console.SetCursorPosition(0, 0);
                Console.Write(past.Count);
            }

            void move(int newX, int newY, long status)
            {
                if (status == 0)
                {
                    Console.SetCursorPosition(newX, newY);
                    Console.Write('█');
                }
                else if (status == 1)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write('.');
                    var previous = past.Pop();
                    if (previous.x != newX || previous.y != newY)
                    {
                        past.Push(previous);
                        past.Push((x, y));
                    }
                    x = newX;
                    y = newY;
                    Console.SetCursorPosition(x, y);
                    Console.Write('D');
                }
                else if (status == 2)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write('.');
                    x = newX;
                    y = newY;
                    Console.SetCursorPosition(x, y);
                    Console.Write('O');
                }
            }
        }

        public static void part2()
        {
            Robot rob = new Robot("day15.txt");
            int x = 25, y = 25;
            int Ox = 0, Oy = 0;
            char[,] map = new char[50,50];
            map[x, y] = ' ';

            Stack<(int x, int y)> past = new Stack<(int, int)>();
            past.Push((x, y));

            void move(int newX, int newY, long status)
            {
                if (status == 0)
                {
                    map[newX, newY] = '█';
                }
                else if (status == 1)
                {
                    past.Push((x, y));
                    x = newX;
                    y = newY;
                    map[newX, newY] = ' ';
                }
                else if (status == 2)
                {
                    past.Push((x, y));
                    x = newX;
                    y = newY;
                    map[newX, newY] = 'O';
                    Ox = x; Oy = y;
                }
            }

            while (past.Count > 0)
            {
                if (map[x - 1, y] == 0)
                    move(x - 1, y, rob.run(3));
                else if (map[x, y - 1] == 0)
                    move(x, y - 1, rob.run(1));
                else if (map[x + 1, y] == 0)
                    move(x + 1, y, rob.run(4));
                else if (map[x, y + 1] == 0)
                    move(x, y + 1, rob.run(2));
                else
                {
                    // backtrack
                    var last = past.Pop();
                    if (x > last.x)
                        rob.run(3);
                    else if (last.x > x)
                        rob.run(4);
                    else if (y > last.y)
                        rob.run(1);
                    else
                        rob.run(2);
                    x = last.x;
                    y = last.y;
                }

                printMap(map);
                Console.SetCursorPosition(x, y);
                Console.Write('D');
            }

            Console.Read();
            //start oxygen flooding
            int minutes = 0;
            Queue<(int x, int y)> oxygenFronts = new Queue<(int x, int y)>();
            oxygenFronts.Enqueue((Ox, Oy));

            int count = oxygenFronts.Count;

            while(count > 0)
            {
                for(int i = 0; i < count; ++i)
                {
                    (int ox, int oy) = oxygenFronts.Dequeue();

                    if (map[ox + 1, oy] == ' ')
                    {
                        map[ox + 1, oy] = 'O';
                        oxygenFronts.Enqueue((ox + 1, oy));
                    }
                    if (map[ox - 1, oy] == ' ')
                    {
                        map[ox - 1, oy] = 'O';
                        oxygenFronts.Enqueue((ox - 1, oy));
                    }
                    if (map[ox, oy + 1] == ' ')
                    {
                        map[ox, oy + 1] = 'O';
                        oxygenFronts.Enqueue((ox, oy + 1));
                    }
                    if (map[ox, oy - 1] == ' ')
                    {
                        map[ox, oy - 1] = 'O';
                        oxygenFronts.Enqueue((ox, oy - 1));
                    }
                }
                count = oxygenFronts.Count;
                printMap(map);
                minutes++;
            }

            Console.SetCursorPosition(0, 0);
            Console.Write("minutes: " + (minutes - 1));
            Console.Read();
            Console.Read();
        }

        public static void printMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                Console.SetCursorPosition(0, i);
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[j, i]);
                }
            }
        }
    }
}
