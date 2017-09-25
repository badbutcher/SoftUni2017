namespace _003
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _003.Models;
    using _003.Models.Enums;
    using _003.Models.ManyToMany;
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
                //SeedLicinses(db);

                //OnePrintCoursesWithResources(db);
                //TwoPrintStudentLicenses(db);
            }
        }

        private static void TwoPrintStudentLicenses(MyDbContext db)
        {
            var result = db.Students
                .Where(a => a.Courses.Any())
                .Select(a => new
                {
                    a.Name,
                    a.Courses.Count,
                    Resources = a.Courses.Sum(b => b.Course.Resources.Count),
                    Licenses = a.Courses.Sum(b => b.Course.Resources.Sum(c => c.Licenses.Count()))
                })
                .ToList();

            foreach (var student in result)
            {
                Console.WriteLine(student.Name);
                Console.WriteLine($"{student.Count} courses count");
                Console.WriteLine($"{student.Resources} total resources");
                Console.WriteLine($"{student.Licenses} total licenses");
                Console.WriteLine("-----------");
            }
        }

        private static void OnePrintCoursesWithResources(MyDbContext db)
        {
            var result = db.Courses
                .OrderByDescending(a => a.Resources.Count)
                .ThenBy(a => a.Name)
                .Select(a => new
                {
                    a.Name,
                    Resources = a.Resources
                    .OrderByDescending(d => d.Licenses.Count)
                    .ThenBy(d => d.Name)
                    .Select(b => new
                    {
                        b.Name,
                        Licenses = b.Licenses.Select(c => c.Name)
                    })
                })
                .ToList();

            foreach (var course in result)
            {
                Console.WriteLine(course.Name);

                foreach (var resource in course.Resources)
                {
                    Console.WriteLine($"--{resource.Name}");

                    foreach (var license in resource.Licenses)
                    {
                        Console.WriteLine($"--{license}");
                    }
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

        private static void SeedLicinses(MyDbContext db)
        {
            List<int> resourceIds = db.Resources
                .Select(a => a.Id)
                .ToList();

            for (int i = 0; i < resourceIds.Count; i++)
            {
                int totalLicenses = random.Next(1, 4);

                for (int j = 0; j < totalLicenses; j++)
                {
                    db.Licenses.Add(new License
                    {
                        Name = $"License {i} {j}",
                        ResourceId = resourceIds[i]
                    });
                }
            }

            db.SaveChanges();
        }
    }
}