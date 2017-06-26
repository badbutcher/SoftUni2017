using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, List<string>>> hospital = new Dictionary<string, Dictionary<string, List<string>>>();
            Dictionary<string, string> patients = new Dictionary<string, string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Output")
                {
                    break;
                }
                else
                {
                    string[] data = input.Split();
                    string department = data[0];
                    string doctor = data[1] + " " + data[2];
                    string patient = data[3];

                    if (!hospital.ContainsKey(department))
                    {
                        hospital.Add(department, new Dictionary<string, List<string>>());
                    }

                    if (!hospital[department].ContainsKey(doctor))
                    {
                        hospital[department].Add(doctor, new List<string>());
                    }

                    if (hospital[department][doctor].Count <= 60)
                    {
                        hospital[department][doctor].Add(patient);
                    }
                }
            }

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

                    if (data.Length == 1)
                    {
                        var result = hospital.Where(a => a.Key == data[0]);

                        foreach (var item in result)
                        {
                            foreach (var a in item.Value)
                            {
                                Console.WriteLine(string.Join(" ", a.Value));
                            }
                        }
                    }
                    else
                    {
                        int num = 0;
                        bool isNumerical = int.TryParse(data[1], out num);

                        if (!isNumerical)
                        {
                            string name = data[0] + " " + data[1];
                            List<string> people = new List<string>();
                            foreach (var doctor in hospital)
                            {
                                var where = doctor.Value.Where(a => a.Key == name);

                                foreach (var item in where)
                                {
                                    people.AddRange(item.Value);
                                }


                            }
                            people.Sort();
                            foreach (var item in people)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            string department = data[0];
                            int room = num;
                            var result = hospital.Where(a => a.Key == data[0]);
                            List<string> people = new List<string>();
                            foreach (var item in result)
                            {
                                foreach (var a in item.Value)
                                {
                                    people.AddRange(a.Value);
                                }

                                people.Sort();

                                foreach (var p in people)
                                {
                                    Console.WriteLine(p);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}