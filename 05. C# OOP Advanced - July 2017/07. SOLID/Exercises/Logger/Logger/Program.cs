namespace Logger_001
{
    using Logger_001.Interfaces;
    using System;
    using System.Collections.Generic;

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