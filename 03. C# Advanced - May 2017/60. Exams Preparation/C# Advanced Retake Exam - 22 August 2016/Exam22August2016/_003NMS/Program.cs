namespace _003NMS
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            List<string> result = new List<string>();
            char nextChar = char.ToLower('a');
            string text = string.Empty;
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "---NMS SEND---")
                {
                    break;
                }
                else
                {
                    text += input;
                }
            }

            text = text.Trim();
            string word = string.Empty;
            char prevChar = '@';

            foreach (char item in text)
            {
                char currChar = char.ToLower(item);
                if (currChar >= char.ToLower(prevChar))
                {
                    word += item.ToString();
                    prevChar = item;
                }
                else
                {
                    result.Add(word);
                    word = item.ToString();
                    prevChar = item;
                }
            }

            result.Add(word);
            string delimiter = Console.ReadLine();
            Console.WriteLine(string.Join(delimiter, result));
        }
    }
}