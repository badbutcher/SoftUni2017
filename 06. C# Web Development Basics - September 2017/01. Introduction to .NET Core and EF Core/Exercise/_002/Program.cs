using System;
using System.Linq;
using _002.Models;

namespace _002
{
    public class Program
    {
        public static void Main()
        {
            MyDbContext context = new MyDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        private static void OnePrintAllStudentsHomework(MyDbContext context)
        {
            
        }

        private static void TwoPrintAllCoursesResources(MyDbContext context)
        {

        }

        private static void ThreePrintAllCoursesWithMoreThanFiveResources(MyDbContext context)
        {

        }

        private static void FourPrintAllCoursesActiveOnAGivenDate(MyDbContext context)
        {

        }

        private static void FivePrintAllStudentPrice(MyDbContext context)
        {

        }
    }
}