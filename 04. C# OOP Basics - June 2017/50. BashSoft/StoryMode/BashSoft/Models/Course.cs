namespace BashSoft.Models
{
    using BashSoft.Exceptions;
    using System.Collections.Generic;

    public class Course
    {
        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        private string name;
        private Dictionary<string, Student> studentsByName;

        public Course(string name)
        {
            this.Name = name;
            this.studentsByName = new Dictionary<string, Student>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.name = value;
            }
        }

        public IReadOnlyDictionary<string, Student> StudentsByName
        {
            get { return this.studentsByName; }
        }

        public void EnrollStudent(Student student)
        {
            if (this.studentsByName.ContainsKey(student.Username))
            {
                throw new DuplicateEntryInStructureException(student.Username, this.name);
            }

            this.studentsByName.Add(student.Username, student);
        }
    }
}