namespace SimpleMvc.App.Views.Home
{
    using System.Text;
    using SimpleMvc.Framework.Contracts;

    public class Index : IRenderable
    {
        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<h3>NotesApp</h3>");
            sb.Append("<br>");
            sb.Append("<a href=\"/users/all\">All Users </a>");
            sb.Append("<a href=\"/users/register\"> Register Users</a>");

            return sb.ToString();
        }
    }
}