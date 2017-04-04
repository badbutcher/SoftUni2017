namespace ImportJSON
{
    using MassDefect;
    using MassDefect.Models;
    using MassDefect.Models.Dtos;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        private const string SolarSystemsPath = "../../Jsons/solar-systems.json";

        private const string StarsPath = "../../Jsons/stars.json";

        private const string PlanetsPath = "../../Jsons/planets.json";

        private const string PersonsPath = "../../Jsons/persons.json";

        private const string AnomaliesPath = "../../Jsons/anomalies.json";

        private const string AnomalyVictimsPath = "../../Jsons/anomaly-victims.json";

        static void Main()
        {
            ////ImportSolarSystems();
            ////ImportStars();
            ////ImportPlanets();
            ////ImportPersons();
            ////ImportAnomalies();
            ////ImportAnomalyVictims();
        }

        private static void ImportAnomalyVictims()
        {
            MassDefectContext context = new MassDefectContext();
            var json = File.ReadAllText(AnomalyVictimsPath);
            var anomalyVictims = JsonConvert.DeserializeObject<IEnumerable<AnomalyVictumsDto>>(json);

            foreach (var anomalyVictim in anomalyVictims)
            {
                if (anomalyVictim.Id == null || anomalyVictim.Person == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                }
                else
                {
                    var anomalyEntity = GetAnomalyById(anomalyVictim.Id, context);
                    var personEntity = GetPersonByName(anomalyVictim.Person, context);

                    if (anomalyEntity == null || personEntity == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        anomalyEntity.Victims.Add(personEntity);
                        Console.WriteLine($"Successfully imported anomaly victim {anomalyVictim.Person}.");
                    }
                }
            }

            context.SaveChanges();
        }

        private static void ImportAnomalies()
        {
            MassDefectContext context = new MassDefectContext();
            var json = File.ReadAllText(AnomaliesPath);
            var anomalies = JsonConvert.DeserializeObject<IEnumerable<AnomalieDto>>(json);

            foreach (var anomalie in anomalies)
            {
                if (anomalie.OriginPlanet == null || anomalie.TeleportPlanet == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                }
                else
                {
                    var anomalieEntity = new Anomalie
                    {
                        OriginPlanet = GetPlanetName(anomalie.OriginPlanet, context),
                        TeleportPlanet = GetPlanetName(anomalie.TeleportPlanet, context)
                    };

                    if (anomalie.OriginPlanet == null || anomalie.TeleportPlanet == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        context.Anomalies.Add(anomalieEntity);
                        Console.WriteLine($"Successfully imported Anomalie {anomalieEntity}.");
                    }
                }
            }

            context.SaveChanges();
        }

        private static void ImportPersons()
        {
            MassDefectContext context = new MassDefectContext();
            var json = File.ReadAllText(PersonsPath);
            var people = JsonConvert.DeserializeObject<IEnumerable<PersonDto>>(json);

            foreach (var person in people)
            {
                if (person.Name == null || person.HomePlanet == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                }
                else
                {
                    var personEntity = new Person
                    {
                        Name = person.Name,
                        HomePlanet = GetPlanetName(person.HomePlanet, context)
                    };

                    if (personEntity.HomePlanet == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        context.Person.Add(personEntity);
                        Console.WriteLine($"Successfully imported Person {personEntity.Name}.");
                    }
                }
            }

            context.SaveChanges();
        }

        private static void ImportPlanets()
        {
            MassDefectContext context = new MassDefectContext();
            var json = File.ReadAllText(PlanetsPath);
            var planets = JsonConvert.DeserializeObject<IEnumerable<PlanetDto>>(json);

            foreach (var planet in planets)
            {
                if (planet.Name == null || planet.Sun == null || planet.SolarSystem == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                }
                else
                {
                    var planetEntity = new Planet
                    {
                        Name = planet.Name,
                        Sun = GetSunByName(planet.Sun, context),
                        SolarSystem = GetSolarSystemByName(planet.SolarSystem, context)
                    };

                    if (planetEntity.Sun == null || planetEntity.SolarSystem == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        context.Planets.Add(planetEntity);
                        Console.WriteLine($"Successfully imported Planet {planetEntity.Name}.");
                    }
                }
            }

            context.SaveChanges();
        }

        private static void ImportStars()
        {
            MassDefectContext context = new MassDefectContext();
            var json = File.ReadAllText(StarsPath);
            var stars = JsonConvert.DeserializeObject<IEnumerable<StarDto>>(json);

            foreach (var star in stars)
            {
                if (star.Name == null || star.SolarSystem == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                }
                else
                {
                    var starEntity = new Star
                    {
                        Name = star.Name,
                        SolarSystem = GetSolarSystemByName(star.SolarSystem, context)
                    };

                    if (starEntity.SolarSystem == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        context.Stars.Add(starEntity);
                        Console.WriteLine($"Successfully imported Star {starEntity.Name}.");
                    }
                }
            }

            context.SaveChanges();
        }

        private static void ImportSolarSystems()
        {
            MassDefectContext context = new MassDefectContext();
            var json = File.ReadAllText(SolarSystemsPath);
            var solarSystems = JsonConvert.DeserializeObject<IEnumerable<SolarSystemDto>>(json);

            foreach (var solarSystem in solarSystems)
            {
                if (solarSystem.Name == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                }
                else
                {
                    var solarSystemEntity = new SolarSystem
                    {
                        Name = solarSystem.Name
                    };

                    context.SolarSystem.Add(solarSystemEntity);
                    Console.WriteLine($"Successfully imported Solar System {solarSystem.Name}.");
                }
            }

            context.SaveChanges();
        }

        private static SolarSystem GetSolarSystemByName(string solarSystem, MassDefectContext context)
        {
            var result = context.SolarSystem.FirstOrDefault(s => s.Name == solarSystem);

            return result;
        }

        private static Star GetSunByName(string sun, MassDefectContext context)
        {
            var result = context.Stars.FirstOrDefault(s => s.Name == sun);

            return result;
        }

        private static Planet GetPlanetName(string homePlanet, MassDefectContext context)
        {
            var result = context.Planets.FirstOrDefault(p => p.Name == homePlanet);

            return result;
        }

        private static Person GetPersonByName(string person, MassDefectContext context)
        {
            var result = context.Person.FirstOrDefault(p => p.Name == person);

            return result;
        }

        private static Anomalie GetAnomalyById(int? id, MassDefectContext context)
        {
            var result = context.Anomalies.FirstOrDefault(p => p.Id == id);

            return result;
        }
    }
}
