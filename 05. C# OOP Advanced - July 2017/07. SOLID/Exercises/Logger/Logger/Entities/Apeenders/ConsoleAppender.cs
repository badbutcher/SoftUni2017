namespace Logger_001.Entities.Apeenders
{
    using System;
    using Logger_001.Enums;
    using Logger_001.Interfaces;

    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string timeStamp, string reportLevel, string message)
        {
            string formatterMsg = this.Layout.FormatMessage(timeStamp, reportLevel, message);
            Console.WriteLine(formatterMsg);
        }
    }
}