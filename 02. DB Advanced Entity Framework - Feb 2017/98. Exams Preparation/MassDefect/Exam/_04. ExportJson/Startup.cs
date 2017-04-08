namespace _04.ExportJson
{
    using System.IO;
    using System.Linq;
    using _01.CodeFirst;
    using Newtonsoft.Json;

    class Startup
    {
        static void Main()
        {
            ExamContext context = new ExamContext();

            ExportPlanetsWhichAreNotAnomalyOrigins(context);

            ExportPoeopleWhicjHaveNotBennVictims(context);

            ExportTopAnomaly(context);
        }

        private static void ExportTopAnomaly(ExamContext context)
        {
            var result = context.Anomalies
                .Select(a => new
                {
                    id = a.Id,
                    originPlanet = new
                    {
                        name = a.OriginPlanet.Name
                    },
                    teleportPlanet = new
                    {
                        name = a.TeleportPlanet.Name
                    },
                    victimsCount = a.Victims.Count
                })
                .OrderByDescending(a => a.victimsCount)
                .Take(1);

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);
            File.WriteAllText("../../anomaly.json", json);
        }

        private static void ExportPoeopleWhicjHaveNotBennVictims(ExamContext context)
        {
            var result = context.Persons
                .Where(a => a.Anomalies.Count == 0)
                .Select(d => new
                {
                    name = d.Name,
                    homePlanet = new
                    {
                        d.HomePlanet.Name
                    }
                });

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);
            File.WriteAllText("../../people.json", json);
        }

        private static void ExportPlanetsWhichAreNotAnomalyOrigins(ExamContext context)
        {
            var result = context.Planets
                .Where(a => !a.OriginPlanet.Any())
                .Select(a => new
                {
                    a.Name
                });

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);
            File.WriteAllText("../../planets.json", json);
        }
    }
}