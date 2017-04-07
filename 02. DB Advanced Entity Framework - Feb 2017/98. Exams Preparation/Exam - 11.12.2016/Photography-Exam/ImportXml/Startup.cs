namespace ImportXml
{
    using Exam;
    using Exam.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    class Startup
    {
        private const string AccessoriesPath = "../../Xmls/accessories.xml";

        private const string WorkshopsPath = "../../Xmls/workshops.xml";

        static void Main()
        {
            ImportAccessories();
            InportWorkshops();
        }

        private static void InportWorkshops()
        {
            var xml = XDocument.Load(WorkshopsPath);
            var workshops = xml.XPathSelectElements("workshops/workshop");
            PhotoContext context = new PhotoContext();

            foreach (var workshop in workshops)
            {
                var workshopName = workshop.Attribute("name");
                var workshopStartDate = workshop.Attribute("start-date");
                var workshopEndDate = workshop.Attribute("end-date");
                var workshopLocation = workshop.Attribute("location");
                var workshopPrice = workshop.Attribute("price");
                var trainerName = workshop.XPathSelectElement("trainer");

                if (workshopName == null || workshopLocation == null || workshopPrice == null || trainerName == null)
                {
                    Console.WriteLine("Error. Invalid data provided");
                }
                else
                {
                    var sDate = workshopStartDate;
                    var eDate = workshopEndDate;

                    var trainerFullName = trainerName.Value.Split(' ');
                    var trainerFirstName = trainerFullName[0];
                    var trainerLastName = trainerFullName[1];

                    var trainer = context.Photographers
                        .FirstOrDefault(a => a.FirstName == trainerFirstName && a.LastName == trainerLastName);

                    var workshopEntity = new Workshop
                    {
                        Name = workshopName.Value,
                        Location = workshopLocation.Value,
                        PricePerParticipant = float.Parse(workshopPrice.Value),
                        Trainer = trainer
                    };

                    if (sDate == null && eDate != null)
                    {
                        workshopEntity.EndDate = DateTime.Parse(eDate.Value);
                    }
                    else if (sDate != null && eDate == null)
                    {
                        workshopEntity.StartDate = DateTime.Parse(sDate.Value);
                    }
                    else if (sDate != null && eDate != null)
                    {
                        workshopEntity.StartDate = DateTime.Parse(sDate.Value);
                        workshopEntity.EndDate = DateTime.Parse(eDate.Value);
                    }

                    var participiansList = new HashSet<Photographer>();
                    var participants = workshop.XPathSelectElements("participants/participant");
                    foreach (var participant in participants)
                    {
                        var participantFirstName = participant.Attribute("first-name").Value;
                        var participantLastName = participant.Attribute("last-name").Value;
                        Photographer photographer = context.Photographers.First(p => p.FirstName == participantFirstName && p.LastName == participantLastName);
                        participiansList.Add(photographer);
                    }

                    workshopEntity.Participants = participiansList;
                    context.Workshops.Add(workshopEntity);
                    Console.WriteLine($"Successfully imported {workshopName.Value}");
                }

                context.SaveChanges();

                ////OR----
                ////if (workshop.Attribute("name") == null)
                ////{
                ////    Console.WriteLine("Error. Invalid data provided");
                ////    continue;
                ////}

                ////if (workshop.Attribute("location") == null)
                ////{
                ////    Console.WriteLine("Error. Invalid data provided");
                ////    continue;
                ////}

                ////if (workshop.Attribute("price") == null)
                ////{
                ////    Console.WriteLine("Error. Invalid data provided");
                ////    continue;
                ////}

                ////if (workshop.Element("trainer") == null)
                ////{
                ////    Console.WriteLine("Error. Invalid data provided");
                ////    continue;
                ////}

                ////var workshopName = workshop.Attribute("name").Value;
                ////var workshopLocation = workshop.Attribute("location").Value;
                ////var workshopPrice = workshop.Attribute("price").Value;
                ////DateTime? workshopStartDate = null;
                ////DateTime? workshopEndDate = null;

                ////if (workshop.Attribute("start-date") != null)
                ////{
                ////    workshopStartDate = DateTime.Parse(workshop.Attribute("start-date").Value);
                ////}

                ////if (workshop.Attribute("end-date") != null)
                ////{
                ////    workshopEndDate = DateTime.Parse(workshop.Attribute("end-date").Value);
                ////}

                ////var TrainerFullName = workshop.Element("trainer").Value.Split();
                ////var trainerFirstName = TrainerFullName[0];
                ////var trainerLastName = TrainerFullName[1];

                ////var trainer = context.Photographers
                ////.FirstOrDefault(a => a.FirstName == trainerFirstName && a.LastName == trainerLastName);

                ////var participians = new HashSet<Photographer>();
                ////var participantsXmls = workshop.XPathSelectElements("participants/participant");
                ////foreach (var participant in participantsXmls)
                ////{
                ////    var participantFirstName = participant.Attribute("first-name").Value;
                ////    var participantLastName = participant.Attribute("last-name").Value;

                ////    Photographer photographer = context.Photographers.First(p => p.FirstName == participantFirstName && p.LastName == participantLastName);
                ////}

                ////var workshopEntity = new Workshop
                ////{
                ////    Name = workshopName,
                ////    StartDate = workshopStartDate,
                ////    EndDate = workshopEndDate,
                ////    Location = workshopLocation,
                ////    PricePerParticipant = float.Parse(workshopPrice),
                ////    Participants = participians,
                ////    Trainer = trainer
                ////};

                ////context.Workshops.Add(workshopEntity);
                ////context.SaveChanges();
                ////Console.WriteLine($"Successfully imported {workshopName}");
            }
        }

        private static void ImportAccessories()
        {
            var xml = XDocument.Load(AccessoriesPath);
            var accessories = xml.XPathSelectElements("accessories/accessory");
            PhotoContext context = new PhotoContext();

            foreach (var accessory in accessories)
            {
                var name = accessory.Attribute("name").Value;
                Random r = new Random();
                var photographersCount = context.Photographers.Count();
                var owner = context.Photographers.Find(r.Next(1, photographersCount));

                var acc = new Accessory()
                {
                    Name = name
                };

                acc.Owner = owner;
                context.Accessorys.Add(acc);
                Console.WriteLine($"Successfully imported {name}");
            }

            context.SaveChanges();
        }
    }
}

////private static void InportWorkshops()
////{
////    var xml = XDocument.Load(WorkshopsPath);
////    var workshops = xml.XPathSelectElements("workshops/workshop");
////    PhotoContext context = new PhotoContext();

////    foreach (var workshop in workshops)
////    {
////        var workshopName = workshop.Attribute("name");
////        var workshopStartDate = workshop.Attribute("start-date");
////        var workshopEndDate = workshop.Attribute("end-date");
////        var workshopLocation = workshop.Attribute("location");
////        var workshopPrice = workshop.Attribute("price");
////        var trainerName = workshop.XPathSelectElement("trainer");

////        if (workshopName == null || workshopLocation == null || workshopPrice == null || trainerName == null)
////        {
////            Console.WriteLine("Error. Invalid data provided");
////        }
////        else
////        {
////            var sDate = workshopStartDate;
////            var eDate = workshopEndDate;

////            var workshopEntity = new Workshop
////            {
////                Name = workshopName.Value,
////                Location = workshopLocation.Value,
////                PricePerParticipant = float.Parse(workshopPrice.Value),
////            };

////            if (sDate == null && eDate != null)
////            {
////                workshopEntity.EndDate = DateTime.Parse(eDate.Value);
////            }
////            else if (sDate != null && eDate == null)
////            {
////                workshopEntity.StartDate = DateTime.Parse(sDate.Value);
////            }
////            else if (sDate != null && eDate != null)
////            {
////                workshopEntity.StartDate = DateTime.Parse(sDate.Value);
////                workshopEntity.EndDate = DateTime.Parse(eDate.Value);
////            }

////            var participants = workshop.XPathSelectElements("participants/participant");
////            foreach (var participant in participants)
////            {
////                var participantFirstName = participant.Attribute("first-name").Value;
////                var participantLastName = participant.Attribute("last-name").Value;
////                var participantEntity = new Photographer
////                {
////                    FirstName = participantFirstName,
////                    LastName = participantLastName
////                };

////                workshopEntity.Participants.Add(participantEntity);
////            }

////            context.Workshops.Add(workshopEntity);
////            Console.WriteLine($"Successfully imported {workshopName.Value}");

////        }
////        context.SaveChanges();
////    }
////}