namespace _01Do04.Migrations
{
    using Models;
    using Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_01Do04.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "_01Do04.StudentSystemContext";
        }

        protected override void Seed(_01Do04.StudentSystemContext context)
        {
            //    Students s1 = new Students()
            //    {
            //        Name = "pavel",
            //        PhoneNumber = "+359 1234567",
            //        RegistrationDate = DateTime.Now,
            //        Birthday = DateTime.Now,
            //    };

            //    Students s2 = new Students()
            //    {
            //        Name = "pesho",
            //        PhoneNumber = "+099 sadasdasd",
            //        RegistrationDate = DateTime.Now,
            //        Birthday = DateTime.Now,
            //    };

            //    context.Students.AddOrUpdate(s => s.Name, s1, s2);
            //    context.SaveChanges();

            //    Homework h1 = new Homework()
            //    {
            //        Content = "C#",
            //        ContentType = HomeworkContentType.application,
            //        SubmissionDate = DateTime.Now,
            //        Student = s1
            //    };

            //    Homework h2 = new Homework()
            //    {
            //        Content = "Java",
            //        ContentType = HomeworkContentType.pdf,
            //        SubmissionDate = DateTime.Now,
            //        Student = s2
            //    };

            //    context.Homework.AddOrUpdate(h => h.Content, h1, h2);
            //    context.SaveChanges();

            //    Resources r1 = new Resources()
            //    {
            //        Name = "Wood",
            //        Type = TypeOfResource.other,
            //        Url = "www.asd.bg",
            //    };

            //    Resources r2 = new Resources()
            //    {
            //        Name = "Stone",
            //        Type = TypeOfResource.document,
            //        Url = "www.dontgoogle.bg",
            //    };

            //    context.Resources.AddOrUpdate(h => h.Name, r1, r2);
            //    context.SaveChanges();

            //    Courses c1 = new Courses()
            //    {
            //        Name = "C#",
            //        Description = "Work",
            //        StartDate = DateTime.Now,
            //        EndDate = DateTime.Now,
            //        Price = 123.45m,
            //        Homework = new List<Homework>
            //            {
            //                h1, h2
            //            },
            //        Students = new List<Students>
            //            {
            //                s1, s2
            //            },
            //        Resources = new List<Resources>
            //            {
            //                r1, r2
            //            }
            //    };

            //    context.Courses.AddOrUpdate(c => c.Name);
            //    context.SaveChanges();
            //}
            context.Courses.AddOrUpdate(c => c.Name,

            new Courses()
            {
                Name = "C#",
                Description = "Work",
                EndDate = DateTime.Now,
                Price = 2,
                Homework = new List<Homework>()
                    {
                    new Homework()
                    {
                    Content = "C# hw",
                    ContentType = HomeworkContentType.pdf,
                    SubmissionDate = DateTime.Now,
                    Student = new Students()
                    {
                        Name = "Gosoho",
                        RegistrationDate = DateTime.Now,
                        PhoneNumber = "254365746856754"
                    }
                    },
                    new Homework()
                    {
                       Content = "Java hw",
                    ContentType = HomeworkContentType.application,
                    SubmissionDate = DateTime.Now,
                    Student = new Students()
                    {
                        Name = "Toro",
                        RegistrationDate = DateTime.Now,
                        PhoneNumber = "2345682334"
                    }
                    }
                    },
                StartDate = DateTime.Now,
                Students = new List<Students>()
                    {
                    new Students()
                    {
                        Name = "Pavel",
                        RegistrationDate = DateTime.Now,
                        PhoneNumber = "+359 72495023899"
                    } ,
                     new Students()
                    {
                        Name = "Pesho",
                        RegistrationDate = DateTime.Now,
                        PhoneNumber = "32532 62359"
                    }
                    },
                Resources = new List<Resources>()
                    {
                    new Resources()
                    {
                        Name = "Wood",
                        Type = TypeOfResource.document,
                        Url = "www.asd.asd"
                    },
                    new Resources()
                    {
                         Name = "Stone",
                         Type = TypeOfResource.other,
                         Url = ".com"
                    }
                    }
            });
        }
    }
}
