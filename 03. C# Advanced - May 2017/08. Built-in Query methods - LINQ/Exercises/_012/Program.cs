namespace _012
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string pattern = "(>----->)|(>>----->)|(>>>----->>)";
            Regex reg = new Regex(pattern);
            int small = 0;
            int medium = 0;
            int large = 0;
            for (int i = 0; i < 4; i++)
            {
                string input = Console.ReadLine();
                MatchCollection match = reg.Matches(input);
                foreach (Match m in match)
                {
                    if (m.Value == ">----->")
                    {
                        small++;
                    }
                    else if (m.Value == ">>----->")
                    {
                        medium++;
                    }
                    else if (m.Value == ">>>----->>")
                    {
                        large++;
                    }
                }
            }

            int number = int.Parse(small.ToString() + medium.ToString() + large.ToString());
            string binary = Convert.ToString(number, 2);
            string newBinary = new string(binary.Reverse().ToArray());

            string conc = binary + newBinary;
            long result = Convert.ToInt64(conc, 2);
            Console.WriteLine(result);
        }
    }
}