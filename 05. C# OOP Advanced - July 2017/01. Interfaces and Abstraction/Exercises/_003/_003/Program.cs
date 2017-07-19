namespace _003
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string ferrariName = typeof(Ferrari).Name;
            string iCarInterfaceName = typeof(ICar).Name;

            bool isCreated = typeof(ICar).IsInterface;
            if (!isCreated)
            {
                throw new Exception("No interface ICar was created");
            }

            string driver = Console.ReadLine();
            ICar ferrarie = new Ferrari(driver);
            Console.WriteLine(ferrarie.ToString());
        }
    }
}