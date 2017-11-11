namespace CarDealer.Services
{
    using System.Collections.Generic;
    using CarDealer.Services.Models.Parts;

    public interface IPartService
    {
        IEnumerable<PartListingModel> AllListings(int page = 1, int pageSize = 25);

        IEnumerable<PartBasicModel> All();

        PartDetailsModel ById(int id);

        int Total();

        void Create(string name, decimal price, int quantity, int supplierId);

        void Delete(int id);

        void Edit(int id, decimal price, int quantity);
    }
}