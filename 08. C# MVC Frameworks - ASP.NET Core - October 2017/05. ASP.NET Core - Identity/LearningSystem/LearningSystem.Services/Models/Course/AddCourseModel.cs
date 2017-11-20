namespace LearningSystem.Services.Models.Course
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class AddCourseModel : AllCourseDataModel
    {
        public string TrainerId { get; set; }

        public IEnumerable<SelectListItem> Trainers { get; set; }
    }
}