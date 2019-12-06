using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2019
{
    class Day6
    {
        public static void part1()
        {
            string[] orbits = new StreamReader("day6.txt").ReadToEnd().Trim().Split();
            //string[] orbits = { "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L" };
            
            Dictionary<string, string> orbitee = new Dictionary<string, string>();

            foreach(string orbit in orbits)
            {
                string[] a = orbit.Split(')');
                orbitee.Add(a[1], a[0]);
            }

            int count = 0;

            foreach(var kvp in orbitee)
            {
                count++;
                if (kvp.Value == "COM")
                    continue;

                string left = orbitee[kvp.Value];
                while (left != "COM")
                {
                    count++;
                    left = orbitee[left];
                }
                count++;
            }

            Console.WriteLine(count);
            Console.Read();
        }

        public static void part2()
        {
            string[] orbits = new StreamReader("day6.txt").ReadToEnd().Trim().Split();
            //string[] orbits = { "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L", "K)YOU", "I)SAN" };

            Dictionary<string, string> orbitee = new Dictionary<string, string>();

            foreach (string orbit in orbits)
            {
                string[] a = orbit.Split(')');
                orbitee.Add(a[1], a[0]);
            }

            HashSet<string> uniquePlanets = new HashSet<string>();
            string last = orbitee["YOU"];
            while (last != "COM")
            {
                uniquePlanets.Add(last);
                last = orbitee[last];
            }

            last = orbitee["SAN"];
            while (last != "COM")
            {
                if (!uniquePlanets.Remove(last))
                    uniquePlanets.Add(last);
                last = orbitee[last];
            }

            Console.WriteLine(uniquePlanets.Count);
            Console.Read();
        }
    }
}
