namespace _04.ExportJson
{
    using _01.CodeFirst;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            ExamContext context = new ExamContext();
            ////ExportPlanets(context);
            ExportAstronomers(context);
        }

        private static void ExportAstronomers(ExamContext context)
        {
            string input = Console.ReadLine();

            var result = context.Astronomers
                .OrderBy(d => d.LastName)
                .Select(d => new
                {
                    Name = d.FirstName + " " + d.LastName,
                    Role = d.PioneeringDiscoveries
                });
            var json = JsonConvert.SerializeObject(result, Formatting.Indented);
            File.WriteAllText($"../../astronomers-of-{input}.json", json);
        }

        private static void ExportPlanets(ExamContext context)
        {
            string input = Console.ReadLine();

            var result = context.Telescopes
              .Where(a => a.Name == input)
              .Select(d => new
              {
                  Name = d.OrbitingPlanet.Name,
                  Mass = d.OrbitingPlanet.Mass,
                  Orbiting = new
                  {
                      d.OrbitingPlanet.StarSystem.Name
                  }
              })
              .OrderByDescending(q => q.Mass);

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);
            File.WriteAllText($"../../aplanets-by-{input}.json", json);
        }
    }
}