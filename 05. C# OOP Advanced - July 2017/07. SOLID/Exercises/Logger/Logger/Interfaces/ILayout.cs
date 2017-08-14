namespace Logger_001.Interfaces
{
    public interface ILayout
    {
        string FormatMessage(string timeStamp, string reportLevel, string message);
    }
}