namespace Logger_001.Interfaces
{
    using Logger_001.Enums;

    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; }

        void Append(string timeStamp, string reportLevel, string message);
    }
}