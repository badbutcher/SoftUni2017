namespace SimpleMvc.App.Views.Users
{
    using System.Text;
    using SimpleMvc.App.ViewModels;

    public class All : IRenderable<AllUsernamesViewModel>
    {
        public AllUsernamesViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<a href=\"/home/index\">Home</a>");
            sb.Append("<br>");

            sb.AppendLine("<h3> All users</h3>");
            sb.AppendLine("<ul>");

            foreach (var username in this.Model.Users)
            {
                sb.AppendLine($"<li><a href=\"/users/profile/?id={username.Key}\">{username.Value}</a></li>");
            }

            sb.AppendLine("<ul>");
            return sb.ToString();
        }
    }
}