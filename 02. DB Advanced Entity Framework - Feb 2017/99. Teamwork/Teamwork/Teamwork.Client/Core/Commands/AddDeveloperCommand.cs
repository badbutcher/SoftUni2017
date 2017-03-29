namespace Teamwork.Client.Core.Commands
{
    using System;
    using Services;

    public class AddDeveloperCommand
    {
        private DeveloperService developerService;

        public AddDeveloperCommand(DeveloperService developerService)
        {
            this.developerService = developerService;
        }

        public string Execute(string data)
        {
            Console.Write("Enter developer name: ");
            string name = Console.ReadLine();

            Console.Write("Enter country founded location: ");
            string countryName = Console.ReadLine();

            Console.Write("Enter city founded location: ");
            string cityName = Console.ReadLine();

            Console.Write("Enter founded date: ");
            DateTime founded = DateTime.Parse(Console.ReadLine());

            if (this.developerService.DoesDeveloperExist(name))
            {
                throw new ArgumentException("Developer already exist");
            }

            this.developerService.GreateDeveloper(name, countryName, cityName, founded);

            return $"Developer {name} was added";
        }
    }
}