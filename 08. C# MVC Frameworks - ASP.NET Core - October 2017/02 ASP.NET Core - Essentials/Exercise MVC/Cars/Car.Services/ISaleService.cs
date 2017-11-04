namespace Car.Services
{
    using System.Collections.Generic;
    using Car.Services.Models;

    public interface ISaleService
    {
        IEnumerable<SalesModel> AllSales();

        IEnumerable<SalesModel> SaleById(int id);

        IEnumerable<SalesModel> SaleWithDiscount();

        IEnumerable<SalesModel> SaleWithGivenDiscount(decimal number);
    }
}