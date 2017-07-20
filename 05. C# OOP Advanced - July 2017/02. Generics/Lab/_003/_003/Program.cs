//namespace _003
//{
    using System;

    public class Program
    {
        public static void Main()
        {
            Scale<string> stringScale = new Scale<string>("a", "c");
            Console.WriteLine(stringScale.GetHavier());

            Scale<int> integerScale = new Scale<int>(2, 1);
            Console.WriteLine(integerScale.GetHavier());
        }
    }
//}