namespace _03.ImportXml
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using _01.CodeFirst;
    using _01.CodeFirst.Models;

    class Startup
    {
        private const string ImportNewAnomaliesPath = "../../Xmls/new-anomalies.xml";

        static void Main()
        {
            ImportNewAnomalies();
        }

        private static void ImportNewAnomalies()
        {
            ExamContext context = new ExamContext();
            var xml = XDocument.Load(ImportNewAnomaliesPath);
            var anomalies = xml.XPathSelectElements("anomalies/anomaly");

            foreach (var anomaly in anomalies)
            {
                var orginPlanetName = anomaly.Attribute("origin-planet");
                var teleportPlanetName = anomaly.Attribute("teleport-planet");

                if (orginPlanetName == null || teleportPlanetName == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                }
                else
                {
                    var anomalyEntity = new Anomalie
                    {
                        OriginPlanet = GetPlanetName(orginPlanetName.Value, context),
                        TeleportPlanet = GetPlanetName(teleportPlanetName.Value, context)
                    };

                    if (anomalyEntity.OriginPlanet == null || anomalyEntity.TeleportPlanet == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        context.Anomalies.Add(anomalyEntity);
                        Console.WriteLine("Successfully imported anomaly.");
                        var victims = anomaly.XPathSelectElements("victims/victim");

                        foreach (var victim in victims)
                        {
                            AddVictim(victim, context, anomalyEntity);
                        }

                        context.SaveChanges();
                    }
                }
            }
        }

        private static void AddVictim(XElement victimName, ExamContext context, Anomalie anomalyEntity)
        {
            var name = victimName.Attribute("name");

            var personEntity = GetPersonName(name.Value, context);

            anomalyEntity.Victims.Add(personEntity);
        }

        private static Person GetPersonName(string value, ExamContext context)
        {
            var result = context.Persons.Where(a => a.Name == value).FirstOrDefault();

            return result;
        }

        private static Planet GetPlanetName(string homePlanet, ExamContext context)
        {
            var result = context.Planets.Where(a => a.Name == homePlanet).FirstOrDefault();

            return result;
        }
    }
}