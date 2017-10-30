namespace Exam.App.Models.Contests
{
    using Exam.App.Infrastructure.Validation.Contests;

    public class ContestViewModel
    {
        [Title]
        public string Name { get; set; }
    }
}