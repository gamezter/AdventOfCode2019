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

            List<string> you = new List<string>();
            string last = orbitee["YOU"];
            while (last != "COM")
            {
                you.Add(last);
                last = orbitee[last];
            }

            List<string> san = new List<string>();
            last = orbitee["SAN"];
            while (last != "COM")
            {
                san.Add(last);
                last = orbitee[last];
            }

            string common = "";
            foreach(string p in you)
            {
                if (san.Contains(p))
                {
                    common = p;
                    break;
                }
            }

            int count = 0;

            for(int i = 0; i < you.Count; i++)
            {
                if (you[i] == common)
                    break;
                count++;
            }

            for (int i = 0; i < san.Count; i++)
            {
                if (san[i] == common)
                    break;
                count++;
            }

            Console.WriteLine(count);
            Console.Read();
        }
    }
}
