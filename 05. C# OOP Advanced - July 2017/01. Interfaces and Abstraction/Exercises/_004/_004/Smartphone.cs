namespace _004
{
    using System.Linq;

    public class Smartphone : ISmartphone
    {
        public Smartphone(string input)
        {
            this.Input = input;
        }

        public string Input { get; set; }

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