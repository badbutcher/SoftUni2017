namespace Logger_001.Entities.Layouts
{
    using Logger_001.Interfaces;
    using System.Text;

    public class XmlLayout : ILayout
    {
        public string FormatMessage(string timeStamp, string reportLevel, string message)
        {
            StringBuilder msg = new StringBuilder();

            return msg.AppendLine($"<log>")
                .AppendLine($"   <date>{timeStamp}</date>")
                .AppendLine($"   <level>{reportLevel}</level>")
                .AppendLine($"   <message>{message}</message>")
                .Append($"</log>")
                .ToString();
        }
    }
}