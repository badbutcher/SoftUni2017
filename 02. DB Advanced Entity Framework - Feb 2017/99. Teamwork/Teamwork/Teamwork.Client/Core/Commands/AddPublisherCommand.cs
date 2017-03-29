namespace Teamwork.Client.Core.Commands
{
    using System;
    using Services;

    public class AddPublisherCommand
    {
        private PublisherService publisherService;

        public AddPublisherCommand(PublisherService publisherService)
        {
            this.publisherService = publisherService;
        }

        public string Execute(string data)
        {
            Console.Write("Enter publisher name: ");
            string name = Console.ReadLine();

            Console.Write("Enter publisher founded location: ");
            string countryName = Console.ReadLine();

            Console.Write("Enter city founded location: ");
            string cityName = Console.ReadLine();

            Console.Write("Enter founded date: ");
            DateTime founded = DateTime.Parse(Console.ReadLine());

            if (this.publisherService.DoesPublisherExist(name))
            {
                throw new ArgumentException("Publisher already exist");
            }

            this.publisherService.GreatePublisher(name, countryName, cityName, founded);

            return $"Publisher {name} was added";
        }
    }
}