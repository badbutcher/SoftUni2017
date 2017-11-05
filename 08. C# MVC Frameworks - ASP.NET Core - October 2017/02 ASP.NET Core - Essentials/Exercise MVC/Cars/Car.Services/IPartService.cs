namespace Car.Services
{
    using System.Collections.Generic;
    using Car.Services.Models;

    public interface IPartService
    {
        IEnumerable<PartModel> AllParts();

        void AddParts(string name, decimal price, int quantity, string supplier);

        void DeletePart(string name);

        PartModel GetPart(string name);
    }
}