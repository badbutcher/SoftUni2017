namespace _008
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _008.Interfaces;
    using _008.Models;

    public class Program
    {
        private static IList<ISoldier> soldiers;

        public static void Main()
        {
            soldiers = new List<ISoldier>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }
                else
                {
                    string[] data = input.Split();
                    string id = data[1];
                    string firstName = data[2];
                    string lastName = data[3];
                    double salary = double.Parse(data[4]);

                    switch (data[0])
                    {
                        case "Private":
                            soldiers.Add(new Private(id, firstName, lastName, salary));
                            break;
                        case "LeutenantGeneral":
                            var privates = ExtractPrivates(data.Skip(5).ToList());
                            soldiers.Add(new LeutenantGeneral(id, firstName, lastName, salary, privates));
                            break;
                        case "Engineer":
                            if (data[5] != "Airforces" && data[5] != "Marines")
                            {
                                break;
                            }

                            var parts = ExtractParts(data.Skip(6).ToList());
                            soldiers.Add(new Engineer(id, firstName, lastName, salary, data[5], parts));
                            break;
                        case "Commando":
                            if (data[5] != "Airforces" && data[5] != "Marines")
                            {
                                break;
                            }

                            var missions = ExtractMissions(data.Skip(6).ToList());
                            soldiers.Add(new Commando(id, firstName, lastName, salary, data[5], missions));
                            break;
                        case "Spy":
                            soldiers.Add(new Spy(id, firstName, lastName, int.Parse(data[4])));
                            break;
                        default:
                            break;
                    }
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private static IList<IMissions> ExtractMissions(IList<string> missions)
        {
            var list = new List<IMissions>();

            for (int i = 0; i < missions.Count - 1; i += 2)
            {
                if (missions[i + 1] != "inProgress" && missions[i + 1] != "Finished")
                {
                    continue;
                }

                list.Add(new Mission(missions[i], missions[i + 1]));
            }

            return list;
        }

        private static IList<ISoldier> ExtractPrivates(IList<string> soldires)
        {
            var list = new List<ISoldier>();

            foreach (var soldire in soldires)
            {
                list.Add(soldiers.First(a => a.Id == soldire));
            }

            return list;
        }

        private static IList<IRepair> ExtractParts(IList<string> parts)
        {
            var list = new List<IRepair>();

            for (int i = 0; i < parts.Count - 1; i += 2)
            {
                list.Add(new Repair(parts[i], int.Parse(parts[i + 1])));
            }

            return list;
        }
    }
}