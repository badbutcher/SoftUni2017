namespace BookShop.Services.Contracts
{
    using System.Collections.Generic;
    using BookShop.Services.Models;

    public interface ICategorieService
    {
        bool Add(CategorieServiceModel model);

        void Delete(int id);

        bool Edit(int id, CategorieServiceModel model);

        List<CategorieServiceModel> All();

        CategorieServiceModel ById(int id);
    }
}