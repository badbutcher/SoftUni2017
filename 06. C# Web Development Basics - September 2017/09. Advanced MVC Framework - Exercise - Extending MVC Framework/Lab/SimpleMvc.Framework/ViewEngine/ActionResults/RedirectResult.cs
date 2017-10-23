namespace SimpleMvc.Framework.ViewEngine.ActionResults
{
    using SimpleMvc.Framework.Contracts;

    public class RedirectResult : IRedirectable
    {
        public RedirectResult(string redirectUrl)
        {
            this.RedirectUrl = redirectUrl;
        }

        public string RedirectUrl { get; }

        public string Invoke()
        {
            return this.RedirectUrl;
        }
    }
}