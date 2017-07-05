namespace _003
{
    using System;

    public class Program
    {
        public static void Main()
        {
            try
            {
                string[] studentInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Student student = new Student(studentInput[0], studentInput[1], studentInput[2]);

                string[] workerInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Worker worker = new Worker(workerInput[0], workerInput[1], double.Parse(workerInput[2]), double.Parse(workerInput[3]));

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