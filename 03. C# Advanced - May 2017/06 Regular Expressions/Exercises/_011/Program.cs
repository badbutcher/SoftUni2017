namespace _011
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                Match openingMatch = Regex.Match(line, @"<(div)([^>]+)(?:id|class)\s*=\s*""(.*?)""(.*?)>");

                Match closingMatch = Regex.Match(line, @"<\/div>.*<!--\s*(.*?)\s*-->");

                if (openingMatch.Success)
                {
                    line = Regex.Replace(
                        line, 
                        @"<(div)([^>]+)(?:id|class)\s*=\s*""(.*?)""(.*?)>", 
                        @"$3 $2 $4")
                        .Trim();

                    line = "<" + Regex.Replace(line, @"\s+", " ") + ">";
                }
                else if (closingMatch.Success)
                {
                    line = "</" + closingMatch.Groups[1] + ">";
                }

                Console.WriteLine(line);
                line = Console.ReadLine();
            }
        }
    }
}

//<(div)([^>]+)(?:id|class)\s*=\s*"(.*?)"(.*?)>
//<\/div>.*<!--\s*(.*?)\s*-->