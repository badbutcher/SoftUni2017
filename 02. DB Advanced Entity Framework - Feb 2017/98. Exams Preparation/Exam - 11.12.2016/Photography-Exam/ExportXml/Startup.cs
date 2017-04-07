namespace ExportXml
{
    using Exam;
    using System.Linq;
    using System.Xml.Linq;

    class Startup
    {
        static void Main()
        {
            PhotoContext context = new PhotoContext();

            PhotographersWithSameCameraMake(context);

            WorkshopsByLocation(context);
        }

        private static void WorkshopsByLocation(PhotoContext context)
        {
            ////var linq = context.Workshops
            ////    .Where(c => c.Participants.Count >= 5)
            ////    .Select(a => new
            ////    {
            ////        a.Location,
            ////        a.Name,
            ////        totalPrice = (a.Participants.Count * a.PricePerParticipant) - (a.Participants.Count * a.PricePerParticipant) * 0.2f,
            ////        count = a.Participants.Count,
            ////        a.Participants,
            ////    });

            var linq = context.Workshops
                    .GroupBy(loc => loc.Location, ws => ws, (location, workshops) => new
                    {
                        Location = location,
                        Workshops = workshops.Where(ws => ws.Participants.Count >= 5)
                    })
                    .Where(ws => ws.Workshops.Count() > 0)
                    .Select(wsByLocation => new
                    {
                        Location = wsByLocation.Location,
                        WorkShops = wsByLocation.Workshops
                    });

            var xmlDocument = new XElement("locations");

            foreach (var item in linq)
            {
                var location = new XElement("location");
                location.Add(new XAttribute("name", item.Location));

                var a = item;

                foreach (var ws in item.WorkShops)
                {
                    var workshop = new XElement("workshop");
                    workshop.Add(new XAttribute("name", ws.Name));
                    workshop.Add(new XAttribute("total-profit", (ws.Participants.Count * ws.PricePerParticipant) - ((ws.Participants.Count * ws.PricePerParticipant) * 0.2f)));

                    var participants = new XElement("participants");
                    participants.Add(new XAttribute("count", ws.Participants.Count));

                    foreach (var Participant in ws.Participants)
                    {
                        participants.Add(new XElement("participant", Participant.FirstName + " " + Participant.LastName));
                    }

                    workshop.Add(participants);
                    location.Add(workshop);
                    xmlDocument.Add(location);
                }
            }

            xmlDocument.Save("../../workshops-by-location.xml");

            ////foreach (var item in linq)
            ////{
            ////    var location = new XElement("location");
            ////    location.Add(new XAttribute("name", item.Location));

            ////    var workshop = new XElement("workshop");
            ////    workshop.Add(new XAttribute("name", item.Name));
            ////    workshop.Add(new XAttribute("total-profit", item.totalPrice));

            ////    var participants = new XElement("participants");
            ////    participants.Add(new XAttribute("count", item.count));

            ////    foreach (var Participant in item.Participants)
            ////    {
            ////        participants.Add(new XElement("participant", Participant.FirstName + " " + Participant.LastName));
            ////    }

            ////    workshop.Add(participants);
            ////    location.Add(workshop);
            ////    xmlDocument.Add(location);
            ////}

            ////xmlDocument.Save("../../workshops-by-location.xml");
        }

        private static void PhotographersWithSameCameraMake(PhotoContext context)
        {
            var linq = context.Photographers
                .Select(c => new
                {
                    name = c.FirstName + " " + c.LastName,
                    primaryCamera = c.PrimaryCamera.Make + " " + c.PrimaryCamera.Model,
                    lenses = c.Lenses
                });

            var xmlDocument = new XElement("photographers");

            foreach (var item in linq)
            {
                var photographers = new XElement("photographer");
                photographers.Add(new XAttribute("name", item.name));
                photographers.Add(new XAttribute("primary-camera", item.primaryCamera));

                var lenses = new XElement("lenses");
                var lensElement = new XElement("lens");

                foreach (var lens in item.lenses)
                {
                    var res = $"{lens.Make} {lens.FocalLength}mm f{lens.MaxAperture}";
                    lensElement.Add(new XElement("lens", res));
                }

                if (item.lenses.Count != 0)
                {
                    lenses.Add(lensElement);
                    photographers.Add(lenses);
                }

                xmlDocument.Add(photographers);
            }

            xmlDocument.Save("../../same-cameras-photographers.xml");
        }
    }
}