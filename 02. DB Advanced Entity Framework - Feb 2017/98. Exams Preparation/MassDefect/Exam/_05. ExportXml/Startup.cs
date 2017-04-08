namespace _05.ExportXml
{
    using System.Linq;
    using System.Xml.Linq;
    using _01.CodeFirst;

    class Startup
    {
        static void Main()
        {
            ExamContext context = new ExamContext();

            var exportedAnomalies = context.Anomalies
                .Where(e => e.Victims.Count != 0)
                .Select(a => new
                {
                    id = a.Id,
                    originPlanetsName = a.OriginPlanet.Name,
                    teleportPlanetsName = a.TeleportPlanet.Name,
                    people = a.Victims
                })
                .OrderBy(a => a.id);

            var xmlDocument = new XElement("anomalies");

            foreach (var exportedAnomaly in exportedAnomalies)
            {
                var anomalyNode = new XElement("anomaly");
                anomalyNode.Add(new XAttribute("id", exportedAnomaly.id));
                anomalyNode.Add(new XAttribute("origin-planet", exportedAnomaly.originPlanetsName));
                anomalyNode.Add(new XAttribute("teleport-planet", exportedAnomaly.teleportPlanetsName));

                var victims = new XElement("victims");
                foreach (var item in exportedAnomaly.people)
                {
                    var victim = new XElement("victim");
                    victim.SetAttributeValue("name", item.Name);
                    victims.Add(victim);
                }

                anomalyNode.Add(victims);
                xmlDocument.Add(anomalyNode);
            }

            xmlDocument.Save("../../anomalies.xml");
        }
    }
}