namespace LearningSystem.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using LearningSystem.Services.Models;

    public interface ICourseService
    {
        Task<IEnumerable<CourseListingServiceModel>> Active();
    }
}