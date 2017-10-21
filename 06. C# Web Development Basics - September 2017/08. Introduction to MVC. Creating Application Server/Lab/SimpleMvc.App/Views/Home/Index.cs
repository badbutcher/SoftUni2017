namespace SimpleMvc.App.Views.Home
{
    using SimpleMvc.Framework.Contracts;

    public class Index : IRenderable
    {
        public string Render() => "<h1>Test</h1>";
    }
}