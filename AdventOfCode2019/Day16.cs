using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                for(int j = 0; j < digits.Length; j++) // current number being processed
                {
                    for(int k = j; k < digits.Length; k += (j + 1) * 3)
                    {
                        for (int l = 0; l <= j && k < digits.Length; l++)
                            buffer[j] += digits[k++];
                    }
                }

                for (int j = 0; j < digits.Length; j++) // current number being processed
                {
                    for (int k = j * 3 + 2; k < digits.Length; k += (j + 1) * 3)
                    {
                        for (int l = 0; l <= j && k < digits.Length; l++)
                            buffer[j] -= digits[k++];
                    }

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
    }
}
