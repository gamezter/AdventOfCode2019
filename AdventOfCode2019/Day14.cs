using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    struct Ingredient
    {
        public string name;
        public long count;

        public Ingredient(string name, long count)
        {
            this.name = name;
            this.count = count;
        }
    }

    class Day14
    {
        public static void part1()
        {
            string[] lines = new StreamReader("day14.txt").ReadToEnd().Trim().Split('\n');
            Dictionary<string, (int count, Ingredient[] components)> recipes = new Dictionary<string, (int count, Ingredient[] components)>();
            foreach(string line in lines)
            {
                string[] a = line.Split(new[] { ' ', ',', '=', '>' }, StringSplitOptions.RemoveEmptyEntries);
                Ingredient[] components = new Ingredient[a.Length / 2 - 1];

                for(int i = 0; i < a.Length - 2; i += 2)
                {
                    components[i / 2] = new Ingredient(a[i + 1], int.Parse(a[i]));
                }

                recipes[a[a.Length - 1]] = (int.Parse(a[a.Length - 2]), components);
            }

            Queue<Ingredient> ingredients = new Queue<Ingredient>();
            ingredients.Enqueue(new Ingredient("FUEL", 1));
            Dictionary<string, int> surplus = new Dictionary<string, int>();

            int ore = 0;
            while(ingredients.Count > 0)
            {
                Ingredient current = ingredients.Dequeue();
                string name = current.name;
                int count = (int)current.count;

                if(surplus.TryGetValue(name, out int leftOver))
                {
                    if (count < leftOver)
                    {
                        surplus[name] -= count;
                        continue;
                    }
                    else
                    {
                        count -= leftOver;
                        surplus.Remove(name);
                    } 
                }

                if (name == "ORE")
                    ore += count;
                else
                {
                    int min = recipes[name].count;
                    int multiplier = (int)Math.Ceiling(count / (float)min);

                    if (multiplier * min > count)
                        surplus.Add(name, multiplier * min - count);

                    foreach (var i in recipes[name].components)
                    {
                        ingredients.Enqueue(new Ingredient(i.name, i.count * multiplier));
                    }
                }
            }

            Console.WriteLine(ore);
            Console.Read();
        }

        public static void part2()
        {
            string[] lines = new StreamReader("day14.txt").ReadToEnd().Trim().Split('\n');
            //string[] lines = { "157 ORE => 5 NZVS", "165 ORE => 6 DCFZ", "44 XJWVT, 5 KHKGT, 1 QDVJ, 29 NZVS, 9 GPVTF, 48 HKGWZ => 1 FUEL", "12 HKGWZ, 1 GPVTF, 8 PSHF => 9 QDVJ", "179 ORE => 7 PSHF", "177 ORE => 5 HKGWZ", "7 DCFZ, 7 PSHF => 2 XJWVT", "165 ORE => 2 GPVTF", "3 DCFZ, 7 NZVS, 5 HKGWZ, 10 PSHF => 8 KHKGT" };
            Dictionary<string, (int count, Ingredient[] components)> recipes = new Dictionary<string, (int count, Ingredient[] components)>();
            foreach (string line in lines)
            {
                string[] a = line.Split(new[] { ' ', ',', '=', '>' }, StringSplitOptions.RemoveEmptyEntries);
                Ingredient[] components = new Ingredient[a.Length / 2 - 1];

                for (int i = 0; i < a.Length - 2; i += 2)
                {
                    components[i / 2] = new Ingredient(a[i + 1], int.Parse(a[i]));
                }

                recipes[a[a.Length - 1]] = (int.Parse(a[a.Length - 2]), components);
            }

            Queue<Ingredient> ingredients = new Queue<Ingredient>();
            Dictionary<string, long> surplus = new Dictionary<string, long>();

            long lowerBound = 0;
            long upperBound = int.MaxValue;
            while(lowerBound != upperBound)
            {
                long ore = 0;
                long mid = (upperBound - lowerBound) / 2L + lowerBound;
                ingredients.Enqueue(new Ingredient("FUEL", mid));
                surplus.Clear();
                while (ingredients.Count > 0)
                {
                    Ingredient current = ingredients.Dequeue();
                    string name = current.name;
                    long count = current.count;

                    if (surplus.TryGetValue(name, out long leftOver))
                    {
                        if (count < leftOver)
                        {
                            surplus[name] -= count;
                            continue;
                        }
                        else
                        {
                            count -= leftOver;
                            surplus.Remove(name);
                        }
                    }

                    if (name == "ORE")
                        ore += count;
                    else
                    {
                        int min = recipes[name].count;
                        long multiplier = (long)Math.Ceiling(count / (double)min);

                        if (multiplier * min > count)
                            surplus.Add(name, multiplier * min - count);

                        foreach (var i in recipes[name].components)
                        {
                            ingredients.Enqueue(new Ingredient(i.name, i.count * multiplier));
                        }
                    }
                }

                Console.WriteLine(lowerBound + " : " + mid + " : " + upperBound);
                Console.Read();

                if (ore < 1000000000000)
                {
                    lowerBound = mid;
                }
                else
                {
                    upperBound = mid;
                }
            }
        }
    }
}
