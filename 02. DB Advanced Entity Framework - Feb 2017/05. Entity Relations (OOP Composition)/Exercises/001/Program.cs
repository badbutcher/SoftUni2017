namespace _01Do04
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            StudentSystemContext context = new StudentSystemContext();
            context.Database.Initialize(true);
            //Treta nqma da raboti s tezi usloviq za moqta baza
            //Part1(context);
            //Part2(context);
            //Part3(context);
            Part4(context);
            //Part5(context);

        }

        private static void Part5(StudentSystemContext context)
        {
            var result = context.Students;

            foreach (var s in result)
            {
                var totalPrice = s.Courses.Sum(p => p.Price);
                
                if (s.Courses.Count == 0)
                {
                    Console.WriteLine("Name:{0}  Count:{1}  Total:{2}  Avrage:{3}", s.Name, s.Courses.Count, totalPrice, totalPrice);
                }
                else
                {
                    var averagePrice = s.Courses.Average(p => p.Price);
                    Console.WriteLine("Name:{0}  Count:{1}  Total:{2}  Avrage:{3}", s.Name, s.Courses.Count, totalPrice, averagePrice);
                }                
            }               
        }

        private static void Part4(StudentSystemContext context)
        {
            throw new NotImplementedException();
        }

        private static void Part3(StudentSystemContext context)
        {
            var result = context.Courses
                            .Where(c => c.Resources.Count > 5)
                            .OrderBy(c => c.Resources.Count)
                            .ThenBy(c => c.StartDate);

            foreach (var item in result)
            {
                Console.WriteLine(item.Name + " " + item.Resources.Count);
            }
        }

        private static void Part2(StudentSystemContext context)
        {
            var result = context.Courses
                            .OrderByDescending(c => c.StartDate)
                            .ThenByDescending(c => c.EndDate);

            foreach (var c in result)
            {
                Console.WriteLine("{0} {1}", c.Name, c.Description);

                foreach (var r in c.Resources)
                {
                    Console.WriteLine(" -- {0} = {1}, {2}, {3}", r.Id, r.Name, r.Type, r.Url);
                }
            }
        }

        private static void Part1(StudentSystemContext context)
        {
            var result = context.Students;

            foreach (var studentName in result)
            {
                Console.WriteLine(studentName.Name);

                foreach (var hw in studentName.Homework)
                {
                    Console.WriteLine(" -- {0} {1}", hw.Content, hw.ContentType);
                }
            }
        }
    }
}