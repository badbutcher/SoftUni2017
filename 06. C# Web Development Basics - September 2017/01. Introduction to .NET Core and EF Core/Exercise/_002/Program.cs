using System;
using System.Linq;
using _002.Models;

namespace _002
{
    public class Program
    {
        //FIX
        public static void Main()
        {
            MyDbContext context = new MyDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Course c = new Course() { Name = "asdasdsad" };
            context.Courses.Add(c);
            context.SaveChanges();

            Student s = new Student() { Name = "Pavel" };
            context.Students.Add(s);
            context.SaveChanges();

            Homework h = new Homework() {StudentId = 1, CourseId=1,  Content = "ASDSADASD", ContentType = Models.Enums.ContentType.Pdf };
            context.Homework.Add(h);
            s.Homework.Add(h);
            context.SaveChanges();
            OnePrintAllStudents(context);
        }

        private static void OnePrintAllStudents(MyDbContext context)
        {
            var filter = context.Students
                .Select(a => new
                {
                    Name = a.Name,
                    Content = a.Homework.Select(c => c.Content),
                    ContentType = a.Homework.Select(t => t.ContentType)
                });

            foreach (var item in filter)
            {
                Console.WriteLine($"Name: {item.Name}, Content: {item.Content}, ContentType: {item.ContentType}");
            }

            Console.WriteLine(context.Students.FirstOrDefault());
        }
    }
}