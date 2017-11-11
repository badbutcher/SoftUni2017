namespace CarDealer.Services
{
    using System.Collections.Generic;
    using CarDealer.Services.Models.Sales;

    public interface ISaleService
    {
        IEnumerable<SaleListModel> All();

        SaleDetailModel Details(int id);
    }
}