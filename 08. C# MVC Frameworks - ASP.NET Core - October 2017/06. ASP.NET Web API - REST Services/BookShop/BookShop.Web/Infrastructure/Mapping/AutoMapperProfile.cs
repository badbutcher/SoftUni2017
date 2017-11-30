namespace BookShop.Web.Infrastructure.Mapping
{
    using System.Linq;
    using AutoMapper;
    using BookShop.Data.Models;
    using BookShop.Services.Models;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Author, AuthorBooksServiceModel>()
                .ForMember(a => a.Books, cfg => cfg.MapFrom(a => a.Books.Select(b => b.Title).ToList()));

            this.CreateMap<Book, FullBookInfoServiceModel>()
                .ForMember(a => a.BooksCategory, cfg => cfg.MapFrom(a => a.Categories.Select(c => c.Categorie.Name).ToList()));

            this.CreateMap<Book, BookDataServiceModel>()
                .ForMember(a => a.BooksCategory, cfg => cfg.MapFrom(a => a.Categories.Select(c => c.Categorie.Name).ToList()))
                .ForMember(a => a.AuthorName, cfg => cfg.MapFrom(c => c.Author.FirstName + " " + c.Author.LastName));

            this.CreateMap<Book, BasicBookInfoServiceModel>();

            this.CreateMap<Book, EditBookServiceModel>();

            this.CreateMap<Categorie, CategorieServiceModel>();
        }
    }
}