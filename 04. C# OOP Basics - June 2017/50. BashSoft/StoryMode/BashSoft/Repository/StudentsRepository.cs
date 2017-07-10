namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using BashSoft.Exceptions;
    using BashSoft.Models;

    public class StudentsRepository
    {
        private Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;
        private bool isDataInilized;
        private RepositoryFilter filter;
        private RepositorySorter sorter;
        private Dictionary<string, Course> courses;
        private Dictionary<string, Student> students;

        public StudentsRepository(RepositoryFilter filter, RepositorySorter sorter)
        {
            this.filter = filter;
            this.sorter = sorter;
            this.studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
        }

        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (this.IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName].StudentsByName.ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                this.filter.FilterAndTake(marks, givenFilter, studentsToTake.Value);
            }
        }

        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (this.IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName].StudentsByName.ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                this.sorter.OrderAndTake(marks, comparison, studentsToTake.Value);
            }
        }

        public void LoadData(string fileName)
        {
            if (this.isDataInilized)
            {
                throw new ArgumentException(ExceptionMessages.DataAlreadyInitialisedException);
            }

            OutputWriter.WriteMessageOnNewLine("Reading data...");
            this.students = new Dictionary<string, Student>();
            this.courses = new Dictionary<string, Course>();
            this.ReadData(fileName);
        }

        public void UnloadData()
        {
            if (!this.isDataInilized)
            {
                throw new ArgumentException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            this.students = null;
            this.courses = null;
            this.isDataInilized = false;
        }

        public void GetStudentScoresFromCourse(string courseName, string username)
        {
            OutputWriter.PrintStudent(
                 new KeyValuePair<string, double>(username, this.courses[courseName].StudentsByName[username].MarksByCourseName[courseName]));
        }

        public void GetAllStudentsFromCourse(string courseName)
        {
            if (this.IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}");
                foreach (var studetMarksEntry in this.courses[courseName].StudentsByName)
                {
                    this.GetStudentScoresFromCourse(courseName, studetMarksEntry.Key);
                }
            }
        }

        private void ReadData(string fileName)
        {
            string path = SessionData.CurrentPath + "\\" + fileName;
            if (File.Exists(path))
            {
                //([A-Z][A-Za-z+#]*_[A-Z][a-z]{2}_201[4-9])\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d{1,3})
                var rgx = new Regex(@"([A-Z][a-zA-Z#\++]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s0-9]+)");
                var allInputLines = File.ReadAllLines(path);
                for (int i = 0; i < allInputLines.Length; i++)
                {
                    if (!string.IsNullOrEmpty(allInputLines[i]) && rgx.IsMatch(allInputLines[i]))
                    {
                        var currentMatch = rgx.Match(allInputLines[i]);
                        var courseName = currentMatch.Groups[1].Value;
                        var username = currentMatch.Groups[2].Value;
                        var scoreStr = currentMatch.Groups[3].Value;

                        try
                        {
                            var scores = scoreStr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

                            if (scores.Any(x => x > 100 && x < 0))
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidScore);
                                //continue;??
                            }

                            if (scores.Length > Course.NumberOfTasksOnExam)
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                                continue;
                            }

                            if (!this.students.ContainsKey(username))
                            {
                                this.students.Add(username, new Student(username));
                            }

                            if (!this.courses.ContainsKey(courseName))
                            {
                                this.courses.Add(courseName, new Course(courseName));
                            }

                            Course course = this.courses[courseName];
                            Student student = this.students[username];

                            student.EnrollInCourse(course);
                            student.SetMarkOnCourse(courseName, scores);
                            course.EnrollStudent(student);
                        }
                        catch (FormatException fex)
                        {
                            OutputWriter.DisplayException(fex.Message + $"at line : {i}");
                        }
                    }
                }
            }
            else
            {
                throw new InvalidPathException();
            }

            this.isDataInilized = true;
            OutputWriter.WriteMessageOnNewLine("Data read!");
        }

        private bool IsQueryForCoursePossible(string courseName)
        {
            //if (isDataInilized)
            if (this.courses.ContainsKey(courseName))
            {
                if (this.courses.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            return false;
        }

        private bool IsQueryForStudentPossible(string courseName, string studentUserName)
        {
            //if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentUserName))
            if (this.IsQueryForCoursePossible(courseName) && this.courses[courseName].StudentsByName.ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }

            return false;
        }
    }
}