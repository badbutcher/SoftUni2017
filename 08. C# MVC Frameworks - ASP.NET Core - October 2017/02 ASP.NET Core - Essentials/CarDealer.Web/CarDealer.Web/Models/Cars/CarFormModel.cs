namespace CarDealer.Web.Models.Cars
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class CarFormModel
    {
        [Required]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Display(Name = "Traveled Distance")]
        [Range(0, long.MaxValue, ErrorMessage = "Must be positive number.")]
        public long TravelledDistance { get; set; }

        public IEnumerable<int> SelectedParts { get; set; }

        [Display(Name = "Parts")]
        public IEnumerable<SelectListItem> AllParts { get; set; }
    }
}