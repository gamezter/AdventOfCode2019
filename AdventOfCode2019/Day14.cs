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
        public int count;

        public Ingredient(string name, int count)
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
                int count = current.count;

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
    }
}
