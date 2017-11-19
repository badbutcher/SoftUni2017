namespace LearningSystem.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using LearningSystem.Services.Models;

    public interface ICourseService
    {
        IEnumerable<AllCourseDataModel> All();

        void Add(string name, string description, string trainerId, DateTime startDate, DateTime endDate);
    }
}