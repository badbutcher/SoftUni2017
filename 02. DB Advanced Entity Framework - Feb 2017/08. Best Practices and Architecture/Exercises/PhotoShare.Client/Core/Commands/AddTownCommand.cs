namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Services;
    using System;

    public class AddTownCommand
    {
        private TownService townService;

        public AddTownCommand(TownService townService)
        {
            this.townService = townService;
        }

        // AddTown <townName> <countryName>
        public string Execute(string[] data)
        {
            string townName = data[0];
            string countryName = data[1];

            if (this.townService.IsTownExisting(townName))
            {
                throw new ArgumentException($"Town {townName} already added!");
            }

            this.townService.AddTown(townName, countryName);

            return $"Town {townName} was added successfully!";
        }
    }
}
