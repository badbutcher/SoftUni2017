namespace LearningSystem.Services.Models
{
    using System;
    using AutoMapper;
    using LearningSystem.Common.Mapping;
    using LearningSystem.Data.Models;

    public class CourseDetailsServiceModel : IMapFrom<Course>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Trainer { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Students { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper.CreateMap<Course, CourseDetailsServiceModel>()
            .ForMember(a => a.Trainer, cfg => cfg.MapFrom(c => c.Trainer.UserName))
            .ForMember(a => a.Students, cfg => cfg.MapFrom(c => c.Students.Count));
    }
}