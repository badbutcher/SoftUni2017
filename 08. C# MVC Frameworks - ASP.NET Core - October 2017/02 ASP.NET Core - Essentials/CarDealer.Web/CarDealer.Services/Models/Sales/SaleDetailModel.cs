namespace CarDealer.Services.Models.Sales
{
    using CarDealer.Services.Models.Cars;

    public class SaleDetailModel : SaleListModel
    {
        public CarModel Car { get; set; }
    }
}