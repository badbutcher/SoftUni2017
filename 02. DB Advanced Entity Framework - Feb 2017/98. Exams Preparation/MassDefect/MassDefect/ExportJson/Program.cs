namespace ExportJson
{
    using MassDefect;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            MassDefectContext context = new MassDefectContext();

            ////ExportPlanetsWitchAreNotAnomaluOrigins(context);

            ////ExportPeopleWhichHaveNotBeenVictims(context);

            ////ExportTopAnomaly(context);
        }

        private static void ExportTopAnomaly(MassDefectContext context)
        {
            var result = context.Anomalies
                .Select(a => new
                {
                    id = a.Id,
                    originPlanet = new { a.OriginPlanet.Name },
                    teleportPlanet = new { a.TeleportPlanet.Name },
                    victimsCount = a.Victims.Count
                })
                .OrderByDescending(v => v.victimsCount)
                .Take(1);

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);
            File.WriteAllText("../../anomaly.json", json);
        }

        private static void ExportPeopleWhichHaveNotBeenVictims(MassDefectContext context)
        {
            var result = context.Person
                .Where(p => p.Anomalies.Count() == 0)
                .Select(u => new
                {
                    name = u.Name,
                    homePlanet = new { name = u.HomePlanet.Name },
                    u.Anomalies.Count
                });
                
            var json = JsonConvert.SerializeObject(result, Formatting.Indented);
            File.WriteAllText("../../victims.json", json);
        }

        private static void ExportPlanetsWitchAreNotAnomaluOrigins(MassDefectContext context)
        {
            var exportedPlanets = context.Planets
                .Where(p => !p.OriginPlanet.Any())
                .Select(p => new
                {
                    name = p.Name
                });

            var planetsASJson = JsonConvert.SerializeObject(exportedPlanets, Formatting.Indented);
            File.WriteAllText("../../planets.json", planetsASJson);
        }
    }
}
