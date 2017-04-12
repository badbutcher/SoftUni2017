namespace _05.ExportXml
{
    using _01.CodeFirst;
    using System.Linq;
    using System.Xml.Linq;

    class Startup
    {
        static void Main()
        {
            ExamContext context = new ExamContext();

            ExportStars(context);
        }

        private static void ExportStars(ExamContext context)
        {
            var result = context.Stars
                .Select(a => new
                {
                    Name = a.Name,
                    Temperature = a.Temperature,
                    StarSystem = a.StarSystem.Name                    
                });

            var xmlDocument = new XElement("Stars");
           
            foreach (var item in result)
            {
                var starNode = new XElement("Star");
                starNode.SetElementValue("Name", item.Name);
                starNode.SetElementValue("Temperature", item.Temperature);
                starNode.SetElementValue("StarSystem", item.StarSystem);
            }

            xmlDocument.Save("../../stars.xml");
        }
    }
}