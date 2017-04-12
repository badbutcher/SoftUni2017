namespace _02.ImportJson
{
    using _01.CodeFirst;
    using _01.CodeFirst.Models;
    using _01.CodeFirst.Models.Dtos;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Startup
    {
        private const string ImportAstronomersPath = "../../Jsons/astronomers.json";

        private const string ImportTelescopesPath = "../../Jsons/telescopes.json";

        private const string ImportPlanetsPath = "../../Jsons/planets.json";

        static void Main()
        {
            ImportAstronomers();

            ImportTelescopes();

            ImportPlanets();
        }

        private static void ImportPlanets()
        {
            ExamContext context = new ExamContext();
            string jsonString = File.ReadAllText(ImportPlanetsPath);
            var json = JsonConvert.DeserializeObject<IEnumerable<ImportPlanetsDto>>(jsonString);

            foreach (var item in json)
            {
                string name = item.Name;
                float? mass = item.Mass;
                string starSystem = item.StarSystem;

                InsertStartSystem(starSystem, context);

                if (name == null || mass == null || starSystem == null)
                {
                    Console.WriteLine("Invalid data format.");
                }
                else
                {
                    var planet = new Planet
                    {
                        Name = name,
                        Mass = mass,
                        StarSystem = GetStarSystemName(starSystem, context)
                    };

                    try
                    {
                        context.Planet.Add(planet);
                        context.SaveChanges();
                        Console.WriteLine($"Record {planet.Name} successfully imported.");
                        Console.WriteLine($"Record {starSystem} successfully imported.");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                }
            }
        }

        private static void ImportTelescopes()
        {
            ExamContext context = new ExamContext();
            string jsonString = File.ReadAllText(ImportTelescopesPath);
            var json = JsonConvert.DeserializeObject<IEnumerable<ImportTelescopesDto>>(jsonString);

            foreach (var item in json)
            {
                string name = item.Name;
                string location = item.Location;
                float? mirrorDiameter = item.MirrorDiameter;

                if (name == null || location == null || mirrorDiameter == null)
                {
                    Console.WriteLine("Invalid data format.");
                }
                else
                {
                    var telescope = new Telescope
                    {
                        Name = name,
                        Location = location,
                        MirrorDiameter = mirrorDiameter
                    };

                    try
                    {
                        context.Telescopes.Add(telescope);
                        context.SaveChanges();
                        Console.WriteLine($"Record {telescope.Name} successfully imported.");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                }
            }
        }

        private static void ImportAstronomers()
        {
            ExamContext context = new ExamContext();
            string jsonString = File.ReadAllText(ImportAstronomersPath);
            var json = JsonConvert.DeserializeObject<IEnumerable<ImportAstronomersDto>>(jsonString);

            foreach (var item in json)
            {
                var firstName = item.FirstName;
                var lastName = item.LastName;

                if (firstName == null || lastName == null)
                {
                    Console.WriteLine("Invalid data format.");
                }
                else
                {
                    var astronomer = new Astronomer
                    {
                        FirstName = firstName,
                        LastName = lastName
                    };

                    try
                    {
                        context.Astronomers.Add(astronomer);
                        context.SaveChanges();
                        Console.WriteLine($"Record {astronomer.FirstName} {astronomer.LastName} successfully imported.");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                }
            }
        }

        private static StarSystem GetStarSystemName(string starSystem, ExamContext context)
        {
            var result = context.StarSystems.Where(a => a.Name == starSystem).FirstOrDefault();
            return result;
        }

        private static void InsertStartSystem(string starSystem, ExamContext context)
        {
            var starSystemImport = new StarSystem
            {
                Name = starSystem
            };

            if (!context.StarSystems.Any(a => a.Name == starSystem))
            {
                context.StarSystems.Add(starSystemImport);
                context.SaveChanges();
            }
        }
    }
}