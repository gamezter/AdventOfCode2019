using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Day8
    {
        public static void part1()
        {
            string numbers = new StreamReader("day8.txt").ReadToEnd().Trim();
            int area = 25 * 6;
            int layers = numbers.Length / area;

            int minZeros = int.MaxValue;
            int minLayer = 0;

            for(int i = 0; i < layers; i++)
            {
                int start = i * area;
                int end = start + area;

                int count = 0;
                for(int j = start; j < end; j++)
                {
                    if (numbers[j] == '0')
                        count++;
                }

                if (count < minZeros)
                {
                    minZeros = count;
                    minLayer = i;
                }
            }

            int lStart = minLayer * area;
            int lEnd = lStart + area;

            int oneCount = 0;
            int twoCount = 0;

            for(int i = lStart; i < lEnd; i++)
            {
                if (numbers[i] == '1')
                    oneCount++;
                else if (numbers[i] == '2')
                    twoCount++;
            }

            Console.WriteLine(oneCount * twoCount);
            Console.Read();
        }

        public static void part2()
        {
            string numbers = new StreamReader("day8.txt").ReadToEnd().Trim();
            int area = 25 * 6;
            int layers = numbers.Length / area;

            char[,] image = new char[25, 6];

            for(int x = 0; x < 25; x++)
            {
                for(int y = 0; y < 6; y++)
                {
                    for(int z = layers - 1; z >= 0; z--)
                    {
                        char c = numbers[(x + 25 * y) + z * area];
                        if (c != '2')
                            image[x, y] = c;
                    }
                }
            }

            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 25; x++)
                {
                    if(image[x, y] == '1')
                        Console.Write('#');
                    else
                        Console.Write(' ');
                }
                Console.WriteLine();
            }

            Console.Read();
        }
    }
}
