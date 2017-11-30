namespace BookShop.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using BookShop.Data;
    using BookShop.Data.Models;
    using BookShop.Services.Contracts;
    using BookShop.Services.Models;

    public class CategorieService : ICategorieService
    {
        private readonly BookShopDbContext db;

        public CategorieService(BookShopDbContext db)
        {
            this.db = db;
        }

        public bool Add(CategorieServiceModel model)
        {
            var exists = this.db.Categories.Any(a => a.Name == model.Name);

            if (exists)
            {
                return false;
            }
            else
            {
                var category = new Categorie
                {
                    Name = model.Name
                };

                this.db.Categories.Add(category);
                this.db.SaveChanges();

                return true;
            }
        }

        public List<CategorieServiceModel> All()
        {
            var categories = this.db.Categories
                .ProjectTo<CategorieServiceModel>()
                .ToList();

            return categories;
        }

        public CategorieServiceModel ById(int id)
        {
            var categorie = this.db.Categories
                .ProjectTo<CategorieServiceModel>()
                .FirstOrDefault(a => a.Id == id);

            return categorie;
        }

        public void Delete(int id)
        {
            var categorie = this.db.Categories.FirstOrDefault(a => a.Id == id);

            this.db.Remove(categorie);
            this.db.SaveChanges();
        }

        public bool Edit(int id, CategorieServiceModel model)
        {
            var exists = this.db.Categories.Any(a => a.Name == model.Name);

            if (exists)
            {
                return false;
            }
            else
            {
                var categorie = this.db.Categories.FirstOrDefault(a => a.Id == id);

                categorie.Name = model.Name;
                this.db.SaveChanges();

                return true;
            }
        }
    }
}