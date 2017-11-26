namespace LearningSystem.Services.Models
{
    using System.Linq;
    using AutoMapper;
    using LearningSystem.Common.Mapping;
    using LearningSystem.Data.Models;

    public class UserProfileCourseServiceModel : IMapFrom<Course>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Grade? Grade { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            string studentId = null;

            mapper.CreateMap<Course, UserProfileCourseServiceModel>()
                .ForMember(a => a.Grade, cfg => cfg
                .MapFrom(c => c.Students
                .Where(s => s.StudentId == studentId)
                .Select(s => s.Grade).FirstOrDefault()));
        }
    }
}