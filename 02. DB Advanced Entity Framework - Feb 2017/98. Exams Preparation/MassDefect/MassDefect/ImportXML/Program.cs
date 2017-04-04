namespace ImportXML
{
    using MassDefect;
    using MassDefect.Models;
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    class Program
    {
        private const string NewAnomaliesPath = "../../Xmls/new-anomalies.xml";

        static void Main()
        {
            var xml = XDocument.Load(NewAnomaliesPath);
            var anomalies = xml.XPathSelectElements("anomalies/anomaly");

            MassDefectContext context = new MassDefectContext();

            foreach (var anomaly in anomalies)
            {
                ImportAnomalyAndVictims(anomaly, context);
            }
        }

        private static void ImportAnomalyAndVictims(XElement anomaly, MassDefectContext context)
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
                    Console.WriteLine("Successfully imported anomaly.");
                    var victims = anomaly.XPathSelectElements("victims/victim");
                    foreach (var victim in victims)
                    {
                        ImportVictim(victim, context, anomalyEntity);
                    }
                }
            }

            context.SaveChanges();
        }

        private static void ImportVictim(XElement victim, MassDefectContext context, Anomalie anomalyEntiy)
        {
            var name = victim.Attribute("name");

            var personEntity = GetPersonByName(name.Value, context);

            anomalyEntiy.Victims.Add(personEntity);
        }

        private static Planet GetPlanetName(string value, MassDefectContext context)
        {
            var result = context.Planets.FirstOrDefault(p => p.Name == value);

            return result;
        }

        private static Person GetPersonByName(string person, MassDefectContext context)
        {
            var result = context.Person.FirstOrDefault(p => p.Name == person);

            return result;
        }
    }
}