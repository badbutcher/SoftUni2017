namespace BashSoft.Models
{
    using BashSoft.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        private string username;
        private Dictionary<string, Course> enrolledCourses;
        private Dictionary<string, double> marksByCourseName;

        public Student(string userName)
        {
            this.Username = userName;
            this.enrolledCourses = new Dictionary<string, Course>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.username = value;
            }
        }

        public IReadOnlyDictionary<string, Course> EnrolledCourses
        {
            get { return this.enrolledCourses; }
        }

        public IReadOnlyDictionary<string, double> MarksByCourseName
        {
            get { return this.marksByCourseName; }
        }

        public void EnrollInCourse(Course course)
        {
            if (this.enrolledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(this.Username, course.Name);
            }

            this.enrolledCourses.Add(course.Name, course);
        }

        public void SetMarkOnCourse(string courseName, params int[] scores)
        {
            if (!this.enrolledCourses.ContainsKey(courseName))
            {
                throw new Exception(ExceptionMessages.NotEnrolledInCourse);
            }

            if (scores.Length > Course.NumberOfTasksOnExam)
            {
                throw new Exception(ExceptionMessages.InvalidNumberOfScores);
            }

            this.marksByCourseName.Add(courseName, this.CalculateMark(scores));
        }

        private double CalculateMark(int[] scores)
        {
            var percentageOfSolvedExam = scores.Sum() /
                (double)(Course.NumberOfTasksOnExam * Course.MaxScoreOnExamTask);
            var mark = percentageOfSolvedExam * 4 + 2;

            return mark;
        }
    }
}