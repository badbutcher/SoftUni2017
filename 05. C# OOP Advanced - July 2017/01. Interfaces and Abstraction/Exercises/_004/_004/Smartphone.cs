namespace _004
{
    using System.Linq;

    public class Smartphone : ISmartphone
    {
        private string input;

        public Smartphone(string input)
        {
            this.input = input;
        }

        public string BrowserSite(string site)
        {
            if (site.Any(c => char.IsDigit(c)))
            {
                return $"Invalid URL!";
            }
            else
            {
                return $"Browsing: {site}!";
            }
        }

        public string CallNumber(string number)
        {
            if (number.Any(c => !char.IsDigit(c)))
            {
                return $"Invalid number!";
            }
            else
            {
                return $"Calling... {number}";
            }
        }
    }
}