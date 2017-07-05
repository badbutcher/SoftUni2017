using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                string[] studentInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Student student = new Student(studentInput[0], studentInput[1], studentInput[2]);

                string[] workerInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Worker worker = new Worker(workerInput[0], workerInput[1], decimal.Parse(workerInput[2]), int.Parse(workerInput[3]));

                Console.WriteLine(student.ToString());
                Console.WriteLine(worker.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}