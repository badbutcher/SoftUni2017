namespace LearningSystem.Web.Models.ManageViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using LearningSystem.Data;

    public class IndexViewModel
    {
        public string Username { get; set; }

        [Required]
        [MinLength(DataConstants.UserNameMinLenght)]
        [MaxLength(DataConstants.UserNameMaxLenght)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}