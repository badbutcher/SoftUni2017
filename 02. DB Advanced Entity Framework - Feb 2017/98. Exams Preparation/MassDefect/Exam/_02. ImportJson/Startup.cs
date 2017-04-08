namespace _02.ImportJson
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using _01.CodeFirst;
    using _01.CodeFirst.Models;
    using _01.CodeFirst.Models.Dtos;
    using Newtonsoft.Json;

    class Startup
    {
        private const string ImportSolarSystemsPath = "../../Jsons/solar-systems.json";

        private const string ImportStarsPath = "../../Jsons/stars.json";

        private const string ImportPlanetsPath = "../../Jsons/planets.json";

        private const string ImportPersonsPath = "../../Jsons/persons.json";

        private const string ImportAnomaliesPath = "../../Jsons/anomalies.json";

        private const string ImportAnomalyVictimsPath = "../../Jsons/anomaly-victims.json";

        static void Main()
        {
            ImportSolarSystems();
            ImportStars();
            ImportPlanets();
            ImportPersons();
            ImportAnomalies();
            ImportAnomalyVictims();
        }

        private static void ImportAnomalyVictims()
        {
            ExamContext context = new ExamContext();
            string jsonString = File.ReadAllText(ImportAnomalyVictimsPath);
            var json = JsonConvert.DeserializeObject<IEnumerable<ImportAnomalyVictimsPathDto>>(jsonString);

            foreach (var item in json)
            {
                if (item.Id == null || item.Person == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                }
                else
                {
                    var victimId = GetVictimId(item.Id, context);
                    var personName = GetPersonName(item.Person, context);

                    if (victimId == null || personName == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        victimId.Victims.Add(personName);
                        context.SaveChanges();
                        Console.WriteLine("Victem added");
                    }
                }
            }
        }
        
        private static void ImportAnomalies()
        {
            ExamContext context = new ExamContext();
            string jsonString = File.ReadAllText(ImportAnomaliesPath);
            var json = JsonConvert.DeserializeObject<IEnumerable<ImportAnomaliesPathDto>>(jsonString);

            foreach (var item in json)
            {
                if (item.OriginPlanet == null || item.TeleportPlanet == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                }
                else
                {
                    var originP = GetHomePlanetName(item.OriginPlanet, context);
                    var teleportP = GetHomePlanetName(item.TeleportPlanet, context);

                    if (originP == null || teleportP == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        var anomaly = new Anomalie
                        {
                            OriginPlanet = originP,
                            TeleportPlanet = teleportP
                        };

                        try
                        {
                            context.Anomalies.Add(anomaly);
                            context.SaveChanges();
                            Console.WriteLine("Successfully imported Anomaly");
                        }
                        catch (Exception)
                        {
                            context.Anomalies.Remove(anomaly);
                            Console.WriteLine("Error: Invalid data.");
                        }
                    }
                }
            }
        }

        private static void ImportPersons()
        {
            ExamContext context = new ExamContext();
            string jsonString = File.ReadAllText(ImportPersonsPath);
            var json = JsonConvert.DeserializeObject<IEnumerable<ImportPersonsPathDto>>(jsonString);

            foreach (var item in json)
            {
                if (item.Name == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                }
                else
                {
                    var homeP = GetHomePlanetName(item.HomePlanet, context);

                    if (homeP == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        var person = new Person
                        {
                            Name = item.Name,
                            HomePlanet = homeP
                        };

                        try
                        {
                            context.Persons.Add(person);
                            context.SaveChanges();
                            Console.WriteLine($"Successfully imported Person {person.Name}");
                        }
                        catch (Exception)
                        {
                            context.Persons.Remove(person);
                            Console.WriteLine("Error: Invalid data.");
                        }
                    }                    
                }
            }
        }
      
        private static void ImportPlanets()
        {
            ExamContext context = new ExamContext();
            string jsonString = File.ReadAllText(ImportPlanetsPath);
            var json = JsonConvert.DeserializeObject<IEnumerable<ImportPlanetsPathDto>>(jsonString);

            foreach (var item in json)
            {
                if (item.Name == null || item.SolarSystem == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                }
                else
                {
                    var ss = GetSolarSystemName(item.SolarSystem, context);
                    var sun = GetSunName(item.Sun, context);

                    if (ss == null || sun == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        var planet = new Planet()
                        {
                            Name = item.Name,
                            SolarSystem = ss,
                            Sun = sun
                        };

                        try
                        {
                            context.Planets.Add(planet);
                            context.SaveChanges();
                            Console.WriteLine($"Successfully imported Planet {planet.Name}");
                        }
                        catch (Exception)
                        {
                            context.Planets.Remove(planet);
                            Console.WriteLine("Error: Invalid data.");
                        }
                    }                 
                }
            }
        }

        private static void ImportStars()
        {
            ExamContext context = new ExamContext();
            string jsonString = File.ReadAllText(ImportStarsPath);
            var json = JsonConvert.DeserializeObject<IEnumerable<ImportStarsPathDto>>(jsonString);

            foreach (var item in json)
            {
                if (item.SolarSystem == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                }
                else
                {
                    var star = new Star()
                    {
                        Name = item.Name,
                        SolarSystem = GetSolarSystemName(item.SolarSystem, context)
                    };

                    try
                    {
                        context.Stars.Add(star);
                        context.SaveChanges();
                        Console.WriteLine($"Successfully imported Star {star.Name}");
                    }
                    catch (Exception)
                    {
                        context.Stars.Remove(star);
                        Console.WriteLine("Error: Invalid data.");
                    }
                }
            }
        }

        private static void ImportSolarSystems()
        {
            ExamContext context = new ExamContext();
            string jsonString = File.ReadAllText(ImportSolarSystemsPath);
            var json = JsonConvert.DeserializeObject<IEnumerable<ImportSolarSystemsPathDto>>(jsonString);

            foreach (var item in json)
            {
                if (item.Name == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                }
                else
                {
                    var solarSystem = new SolarSystem
                    {
                        Name = item.Name
                    };

                    try
                    {
                        context.SolarSystems.Add(solarSystem);
                        context.SaveChanges();
                        Console.WriteLine($"Successfully imported Solar System {solarSystem.Name}");
                    }
                    catch (Exception)
                    {
                        context.SolarSystems.Remove(solarSystem);
                        Console.WriteLine("Error: Invalid data.");
                    }
                }
            }
        }

        private static SolarSystem GetSolarSystemName(string solarSystem, ExamContext context)
        {
            var result = context.SolarSystems.Where(a => a.Name == solarSystem).FirstOrDefault();

            return result;
        }

        private static Star GetSunName(string sun, ExamContext context)
        {
            var result = context.Stars.Where(a => a.Name == sun).FirstOrDefault();

            return result;
        }

        private static Planet GetHomePlanetName(string homePlanet, ExamContext context)
        {
            var result = context.Planets.Where(a => a.Name == homePlanet).FirstOrDefault();

            return result;
        }

        private static Anomalie GetVictimId(int? id, ExamContext context)
        {
            var result = context.Anomalies.Where(a => a.Id == id).FirstOrDefault();

            return result;
        }

        private static Person GetPersonName(string person, ExamContext context)
        {
            var result = context.Persons.Where(a => a.Name == person).FirstOrDefault();

            return result;
        }
    }
}