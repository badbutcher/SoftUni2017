namespace SimpleMvc.Framework.ViewEngine.ActionResults
{
    using SimpleMvc.Framework.Contracts;

    public class ViewResult : IViewable
    {
        public ViewResult(IRenderable view)
        {
            this.View = view;
        }

        public IRenderable View { get; set; }

        public string Invoke()
        {
            return this.View.Render();
        }
    }
}