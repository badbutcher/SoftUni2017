namespace Cars.Models.Parts
{
    using System.Collections.Generic;
    using Car.Services.Models;

    public class AllPartsModel
    {
        public IEnumerable<PartModel> Parts { get; set; }
    }
}