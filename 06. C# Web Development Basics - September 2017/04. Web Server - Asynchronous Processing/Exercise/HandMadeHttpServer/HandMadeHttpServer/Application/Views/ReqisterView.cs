namespace HandMadeHttpServer.Application.Views
{
    using HandMadeHttpServer.Server.Contracts;
    public class ReqisterView : IView
    {
        public string View()
        {
            return
                "<body>" +
                "<form method=\"POST\">" +
                "Name</br>" +
                "<input type=\"text\" name=\"name\"/><br/>" +
                "<input type=\"submit\" />" +
                "</form>" +
                "</body>";
        }
    }
}