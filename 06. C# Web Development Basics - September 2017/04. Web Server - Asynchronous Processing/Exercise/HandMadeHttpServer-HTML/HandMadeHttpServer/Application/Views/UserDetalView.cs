namespace HandMadeHttpServer.Application.Views
{
    using HandMadeHttpServer.Server;
    using HandMadeHttpServer.Server.Contracts;

    public class UserDetalView : IView
    {
        private readonly Model model;

        public UserDetalView(Model model)
        {
            this.model = model;
        }

        public string View()
        {
            return $"<body>Hello, {model["name"]}!</body>";
        }
    }
}