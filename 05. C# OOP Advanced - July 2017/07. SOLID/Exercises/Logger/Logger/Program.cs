namespace Logger_001
{
    using System;
    using System.Collections.Generic;
    using Logger_001.Interfaces;

    public class Program
    {
        public static void Main()
        {
            int appenderCount = int.Parse(Console.ReadLine());
            List<IAppender> appender = new List<IAppender>();

            for (int i = 0; i < appenderCount; i++)
            {
            }
        }
    }
}