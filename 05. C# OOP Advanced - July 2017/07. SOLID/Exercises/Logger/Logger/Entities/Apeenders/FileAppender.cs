namespace Logger_001.Entities.Apeenders
{
    using Logger_001.Enums;
    using Logger_001.Interfaces;

    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }

        public LogFile File { get; set; }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string timeStamp, string reportLevel, string message)
        {
            string formattedMsg = this.Layout.FormatMessage(timeStamp, reportLevel, message);
            this.File.Write(formattedMsg);
        }
    }
}