namespace Car.Services
{
    using System.Collections.Generic;
    using Car.Services.Models;
    using Cars.Data.Models;

    public interface IPartService
    {
        IEnumerable<PartModel> AllParts();

        void AddParts(string name, decimal price, int quantity, string supplier);

        void DeletePart(string name);

        PartModel GetPart(string name);

        void Edit(string name, decimal price, int quantity);

        List<PartCars> GetPartsByName(List<string> parts, string make, string model, long travelledDistance);
    }
}