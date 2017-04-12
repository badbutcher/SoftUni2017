namespace _03.ImportXml
{
    using _01.CodeFirst;
    using _01.CodeFirst.Models;
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    class Startup
    {
        private const string ImportStarsPath = "../../Xmls/stars.xml";

        private const string ImportDiscoveriesPath = "../../Xmls/discoveries.xml";

        static void Main()
        {
            ImportStars();

            ImportDiscoveries();
        }

        private static void ImportDiscoveries()
        {
            var xml = XDocument.Load(ImportDiscoveriesPath);
            var discoveries = xml.XPathSelectElements("Discoveries/Discovery");

            foreach (var discovery in discoveries)
            {
                ExamContext context = new ExamContext();
            
                var dateMade = discovery.Attribute("DateMade").Value;
                var telescope = discovery.Attribute("Telescope").Value;

                var discoviryImport = new Discovery
                {
                    DateDiscovered = DateTime.Parse(dateMade),
                    TelescopeUsed = FindTelescope(telescope, context)
                };

                var starsXml = discovery.XPathSelectElements("Stars/Star");

                foreach (var star in starsXml)
                {
                    var temperatureAttribute = star.Attribute("Temperature");
                    int temperature = 0;
                    if (temperatureAttribute != null)
                    {
                        temperature = int.Parse(temperatureAttribute.Value);
                    }

                    var starName = star.Value;

                    var starImport = new Star
                    {
                        Name = starName,
                        Temperature = temperature
                    };

                    discoviryImport.Stars.Add(starImport);
                }

                var planetsXml = discovery.XPathSelectElements("Planets/Planet");
                foreach (var planet in planetsXml)
                {
                    var planetName = planet.Value;

                    var planetImport = new Planet
                    {
                        Name = planetName
                    };

                    discoviryImport.Planets.Add(planetImport);
                }

                var pioneersXml = discovery.XPathSelectElements("Pioneers/Astronomer");
                foreach (var pioneer in pioneersXml)
                {
                    var pioneerName = pioneer.Value.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    var pioneerImport = new Astronomer
                    {
                        FirstName = pioneerName[0],
                        LastName = pioneerName[1]
                    };

                    discoviryImport.Pioneers.Add(pioneerImport);
                }

                var observersXml = discovery.XPathSelectElements("Observers/Astronomer");
                foreach (var observer in observersXml)
                {
                    var observerName = observer.Value.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    var observerImport = new Astronomer
                    {
                        FirstName = observerName[0],
                        LastName = observerName[1]
                    };

                    discoviryImport.Observers.Add(observerImport);
                }

                try
                {
                    context.Discoveries.Add(discoviryImport);
                    context.SaveChanges();
                    Console.WriteLine($"Discovery {discoviryImport.DateDiscovered} with {discoviryImport.Stars.Count} star(s), {discoviryImport.Planets.Count} planet(s), {discoviryImport.Pioneers.Count} pioneer(s) and {discoviryImport.Observers.Count} observers successfully  imported.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Invalid data format.");
                }
            }
        }
  
        private static void ImportStars()
        {
            var xml = XDocument.Load(ImportStarsPath);
            var stars = xml.XPathSelectElements("Stars/Star");

            foreach (var star in stars)
            {
                ExamContext context = new ExamContext();
                string name = star.Element("Name").Value;
                int? temperature = int.Parse(star.Element("Temperature").Value);
                string starSystem = star.Element("StarSystem").Value;

                InsertStartSystem(starSystem, context);

                if (name == null || temperature == null || starSystem == null)
                {
                    Console.WriteLine("Invalid data format.");
                }
                else
                {
                    var starImport = new Star
                    {
                        Name = name,
                        Temperature = temperature,
                        StarSystem = GetStarSystemName(starSystem, context)
                    };

                    try
                    {
                        context.Stars.Add(starImport);
                        context.SaveChanges();
                        Console.WriteLine($"Record {starImport.Name} successfully imported.");
                        Console.WriteLine($"Record {starSystem} successfully imported.");
                    }
                    catch (Exception)
                    {
                        context.Stars.Remove(starImport);
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

        private static Telescope FindTelescope(string telescope, ExamContext context)
        {
            var result = context.Telescopes.Where(a => a.Name == telescope).FirstOrDefault();
            return result;
        }
    }
}