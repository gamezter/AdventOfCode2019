using System;
using System.IO;

namespace AdventOfCode2019
{
    class Day16
    {
        public static void part1()
        {
            string number = new StreamReader("day16.txt").ReadToEnd().Trim();
            int[] digits = new int[number.Length];
            for(int i = 0; i < digits.Length; i++)
            {
                digits[i] = number[i] - '0';
            }

            for(int i = 0; i < 100; i++)
            {
                int[] buffer = new int[digits.Length];
                for (int j = 0; j < digits.Length; j++) // current number being processed
                {
                    int inc = j * 3 + 3;
                    for (int k = j; k < digits.Length; k += inc)
                    {
                        int n = j + 1 < digits.Length - k ? j + 1 : digits.Length - k;

                        for (int l = 0; l < n; l++)
                        {
                            buffer[j] += digits[k++];
                        }
                    }

                    for (int k = j * 3 + 2; k < digits.Length; k += inc)
                    {
                        int n = j + 1 < digits.Length - k ? j + 1 : digits.Length - k;

                        for (int l = 0; l < n; l++)
                        {
                            buffer[j] -= digits[k++];
                        }
                    }
                }

                for (int j = 0; j < digits.Length; j++) // current number being processed
                {
                    buffer[j] = Math.Abs(buffer[j]) % 10;
                }
                digits = buffer;
            }

            for (int i = 0; i < 8; i++)
            {
                Console.Write(digits[i]);
            }
            Console.Read();
        }

        public static void part2()
        {
            string number = new StreamReader("day16.txt").ReadToEnd().Trim();
            int offset = int.Parse(number.Substring(0, 7));
            int length = number.Length * 10000 - offset;
            int[] digits = new int[length];
            for (int i = 0; i < digits.Length; i++)
            {
                digits[i] = number[(i + offset) % number.Length] - '0';
            }

            for (int i = 0; i < 100; i++)
            {
                for (int j = length - 2; j >= 0; --j) // current number being processed
                {
                    digits[j] = (digits[j + 1] + digits[j]) % 10;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                Console.Write(digits[i]);
            }
            Console.Read();
        }
    }
}
