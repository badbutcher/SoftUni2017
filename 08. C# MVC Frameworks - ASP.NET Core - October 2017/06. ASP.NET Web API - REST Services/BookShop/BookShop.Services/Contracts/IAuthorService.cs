namespace BookShop.Services.Contracts
{
    using System.Collections.Generic;
    using BookShop.Services.Models;

    public interface IAuthorService
    {
        AuthorBooksServiceModel AuthorById(int id);

        void CreateAuthor(CreateAuthorServiceModel model);

        List<FullBookInfoServiceModel> BooksByAuthorId(int id);
    }
}