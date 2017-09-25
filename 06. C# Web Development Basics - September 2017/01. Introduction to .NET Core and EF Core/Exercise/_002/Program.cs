namespace _002
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _002.Models;
    using _002.Models.Enums;
    using _002.Models.ManyToMany;
    using Microsoft.EntityFrameworkCore;

    public class Program
    {
        private static Random random = new Random();

        public static void Main()
        {
            using (MyDbContext db = new MyDbContext())
            {
                db.Database.Migrate();

                //SeedData(db);

                //OnePrintStudentsWithHomework(db);
                //TwoPrintCoursesInfo(db);
                //ThreePrintCoursesResources(db);
                //FourPrintCoursesActiveOnADate(db);
                //FivePrintCoursesPrice(db);
            }
        }

        private static void FivePrintCoursesPrice(MyDbContext db)
        {
            var result = db.Students
                .Where(a => a.Courses.Any())
                .Select(a => new
                {
                    a.Name,
                    Count = a.Courses.Count,
                    TotalPrice = a.Courses.Sum(c => c.Course.Price),
                    AveragePrice = a.Courses.Average(c => c.Course.Price)
                })
                .OrderByDescending(a => a.AveragePrice)
                .ThenByDescending(a => a.AveragePrice)
                .ThenBy(a => a.Name)
                .ToList();

            foreach (var student in result)
            {
                Console.WriteLine(student.Name);
                Console.WriteLine($"{student.Count} count");
                Console.WriteLine($"{student.TotalPrice} max");
                Console.WriteLine($"{student.AveragePrice} avr");
                Console.WriteLine("----------");
            }
        }

        private static void FourPrintCoursesActiveOnADate(MyDbContext db)
        {
            DateTime date = DateTime.Now.AddDays(25);

            var result = db.Courses
                .Where(c => c.StartDate < date && date < c.EndDate)
                .Select(a => new
                {
                    a.Name,
                    a.StartDate,
                    a.EndDate,
                    CourseDuratiton = a.EndDate.Subtract(a.StartDate),
                    a.Students.Count
                })
                .OrderByDescending(b => b.Count)
                .ThenByDescending(b => b.CourseDuratiton)
                .ToList();

            foreach (var course in result)
            {
                Console.WriteLine(course.Name);
                Console.WriteLine($"{course.StartDate.ToShortDateString()} - {course.EndDate.ToShortDateString()}");
                Console.WriteLine(course.CourseDuratiton.Days);
            }
        }

        private static void ThreePrintCoursesResources(MyDbContext db)
        {
            var result = db.Courses
                .OrderByDescending(b => b.Resources.Count)
                .ThenByDescending(b => b.StartDate)
                .Where(c => c.Resources.Count > 5)
                .Select(a => new
                {
                    a.Name,
                    a.Resources
                })
                .ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Resources.Count);
                Console.WriteLine("---");
            }
        }

        private static void TwoPrintCoursesInfo(MyDbContext db)
        {
            var result = db.Courses
                .OrderBy(b => b.StartDate)
                .ThenByDescending(c => c.EndDate)
                .Select(a => new
                {
                    CourseName = a.Name,
                    Description = a.Description,
                    Resourses = a.Resources.Select(d => new
                    {
                        d.Name,
                        d.Url,
                        d.ResourseType
                    })
                })
                .ToList();

            foreach (var course in result)
            {
                Console.WriteLine($"{course.CourseName} -> {course.Description}");

                foreach (var resourse in course.Resourses)
                {
                    Console.WriteLine(resourse.Name);
                    Console.WriteLine(resourse.ResourseType);
                    Console.WriteLine(resourse.Url);
                    Console.WriteLine("---");
                }
            }
        }

        private static void OnePrintStudentsWithHomework(MyDbContext db)
        {
            var result = db.Students
                .Select(s => new
                {
                    s.Name,
                    Homeworks = s.Homeworks.Select(h => new
                    {
                        h.Content,
                        h.ContentType
                    })
                })
                .ToList();

            foreach (var student in result)
            {
                Console.WriteLine(student.Name);

                foreach (var homework in student.Homeworks)
                {
                    Console.WriteLine($"{homework.Content} - {homework.ContentType}");
                }
            }
        }

        private static void SeedData(MyDbContext db)
        {
            const int TotalStudents = 25;
            const int TotalCourses = 10;
            DateTime currentDate = DateTime.Now;

            // Students
            for (int i = 0; i < TotalStudents; i++)
            {
                db.Students.Add(new Student
                {
                    Name = $"Student {i}",
                    RegistrationDate = currentDate.AddDays(i),
                    Birthday = currentDate.AddYears(-20).AddDays(i),
                    Phone = $"Random Phone {i}"
                });
            }

            db.SaveChanges();

            // Corses
            List<Course> addedCourses = new List<Course>();

            for (int i = 0; i < TotalCourses; i++)
            {
                Course course = new Course
                {
                    Name = $"Course {i}",
                    Description = $"Course Details {i}",
                    Price = 100 * i,
                    StartDate = currentDate.AddDays(i),
                    EndDate = currentDate.AddDays(20 + i)
                };

                addedCourses.Add(course);

                db.Courses.Add(course);
            }

            db.SaveChanges();

            //Students in Courses
            List<int> studentIds = db.Students
                        .Select(s => s.Id)
                        .ToList();

            for (int i = 0; i < TotalCourses; i++)
            {
                Course currentCourse = addedCourses[i];
                int studentsInCourse = random.Next(2, TotalStudents / 2);

                for (int j = 0; j < studentsInCourse; j++)
                {
                    int studentId = studentIds[random.Next(0, studentIds.Count)];

                    if (!currentCourse.Students.Any(s => s.StudentId == studentId))
                    {
                        currentCourse.Students.Add(new StudentCourse
                        {
                            StudentId = studentId
                        });
                    }
                    else
                    {
                        j--;
                    }
                }

                int resourcesInCourse = random.Next(2, 20);
                int[] types = new[] { 0, 1, 2, 999 };

                for (int j = 0; j < resourcesInCourse; j++)
                {
                    currentCourse.Resources.Add(new Resource
                    {
                        Name = $"Resource {i} {j}",
                        Url = $"URL {i} {j}",
                        ResourseType = (ResourseType)types[random.Next(0, types.Length)]
                    });
                }
            }

            db.SaveChanges();

            // Homeworks
            for (int i = 0; i < TotalCourses; i++)
            {
                Course currentCourse = addedCourses[i];

                List<int> studentsInCourseIds = currentCourse.Students.Select(s => s.StudentId).ToList();

                for (int j = 0; j < studentsInCourseIds.Count; j++)
                {
                    int totalHomeworks = random.Next(2, 5);

                    for (int k = 0; k < totalHomeworks; k++)
                    {
                        db.Homeworks.Add(new Homework
                        {
                            Content = $"Content Homework {i}",
                            SubmissionDate = currentDate.AddDays(-i),
                            ContentType = ContentType.Zip,
                            StudentId = studentsInCourseIds[j],
                            CourseId = currentCourse.Id
                        });
                    }
                }

                db.SaveChanges();
            }
        }
    }
}