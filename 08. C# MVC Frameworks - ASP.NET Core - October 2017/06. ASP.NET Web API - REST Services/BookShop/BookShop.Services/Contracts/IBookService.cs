namespace BookShop.Services.Contracts
{
    using System.Collections.Generic;
    using BookShop.Services.Models;

    public interface IBookService
    {
        BookDataServiceModel BookDataById(int id);

        List<BasicBookInfoServiceModel> TopBooksBySubstring(string text);

        void EditBookById(int id, EditBookServiceModel model);

        void DeleteBookById(int id);

        void AddNewBook(FullBookInfoServiceModel model);
    }
}