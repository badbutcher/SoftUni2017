namespace _009
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string[] wordsToBan = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] text = Console.ReadLine().Split();

            for (int i = 0; i < wordsToBan.Length; i++)
            {
                for (int k = 0; k < text.Length; k++)
                {
                    if (text[k].Contains(wordsToBan[i]))
                    {
                        string word = text[k];
                        int startIndex = 0;
                        for (int j = 0; j < word.Length; j++)
                        {
                            if (word[j] == wordsToBan[i].First())
                            {
                                startIndex = j;
                                break;
                            }
                        }

                        word = word.Substring(startIndex, wordsToBan[i].Length);
                        string replace = text[k].Replace(word, new string('*', word.Length));
                        text[k] = replace;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", text));
        }
    }
}