namespace _003CubicMessages
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string pattern = @"^([0-9]+)([A-Za-z]+)([^A-Za-z]*)$";
            Regex regex = new Regex(pattern);

            while (true)
            {
                string input = Console.ReadLine().Trim();
                if (input == "Over!")
                {
                    break;
                }
                else
                {
                    int numbrer = int.Parse(Console.ReadLine());
                    Match match = regex.Match(input);

                    if (match.Groups[2].Length == numbrer)
                    {
                        string result = match.Groups[2].Value + " == ";
                        string leftSide = match.Groups[1].Value;
                        string middleSide = match.Groups[2].Value;
                        string rightSide = match.Groups[3].Value;

                        for (int i = 0; i < leftSide.Length; i++)
                        {
                            int index = (int)Char.GetNumericValue(leftSide[i]);

                            if (index >= middleSide.Length)
                            {
                                result += " ";
                            }
                            else
                            {
                                result += middleSide[index];
                            }
                        }

                        for (int i = 0; i < rightSide.Length; i++)
                        {
                            int index = (int)Char.GetNumericValue(rightSide[i]);

                            if (index != -1)
                            {
                                if (index >= middleSide.Length)
                                {
                                    result += " ";
                                }
                                else
                                {
                                    result += middleSide[index];
                                }
                            }
                        }

                        Console.WriteLine(result);
                    }   
                }
            }
        }
    }
}