namespace _012
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            SortedDictionary<string, int> keyMaterials = new SortedDictionary<string, int>();
            keyMaterials["shards"] = 0;
            keyMaterials["motes"] = 0;
            keyMaterials["fragments"] = 0;

            SortedDictionary<string, int> junkMaterials = new SortedDictionary<string, int>();
            bool isInput = true;

            while (isInput)
            {
                string[] materials = Console.ReadLine().ToLower().Split(' ').ToArray();

                for (int i = 0; i < materials.Length; i += 2)
                {
                    int curentQuantiti = int.Parse(materials[i]);
                    string curentMaterial = materials[i + 1];
                    if (curentMaterial == "shards" || curentMaterial == "motes" || curentMaterial == "fragments")
                    {
                        keyMaterials[curentMaterial] += curentQuantiti;
                    }
                    else
                    {
                        if (!junkMaterials.ContainsKey(curentMaterial))
                        {
                            junkMaterials.Add(curentMaterial, 0);
                        }

                        junkMaterials[curentMaterial] += curentQuantiti;
                    }

                    if (keyMaterials["shards"] >= 250 || keyMaterials["motes"] >= 250 || keyMaterials["fragments"] >= 250)
                    {
                        foreach (var item in keyMaterials.OrderByDescending(x => x.Value))
                        {
                            switch (item.Key)
                            {
                                case "motes":
                                    Console.WriteLine("Dragonwrath obtained!");
                                    keyMaterials[item.Key] -= 250;
                                    break;
                                case "shards":
                                    Console.WriteLine("Shadowmourne obtained!");
                                    keyMaterials[item.Key] -= 250;
                                    break;
                                case "fragments":
                                    Console.WriteLine("Valanyr obtained!");
                                    keyMaterials[item.Key] -= 250;
                                    break;
                            }

                            break;
                        }

                        foreach (var item in keyMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                        {
                            Console.WriteLine("{0}: {1}", item.Key, item.Value);
                        }

                        foreach (var item in junkMaterials)
                        {
                            Console.WriteLine("{0}: {1}", item.Key, item.Value);
                        }

                        return;
                    }
                }
            }
        }
    }
}