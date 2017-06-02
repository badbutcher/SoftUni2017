namespace _003
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            List<string> words = new List<string>();
            List<string> texts = new List<string>();
            using (StreamReader wordsRead = new StreamReader("../../words.txt"))
            {
                using (StreamReader textsRead = new StreamReader("../../text.txt"))
                {
                    string word = wordsRead.ReadLine().ToLower();
                    string text = textsRead.ReadLine().ToLower();
                    while (word != null)
                    {                 
                        string[] split = text.Split(new char[] { ' ', '.', ',', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);
                        words.Add(word);

                        if (!result.ContainsKey(word))
                        {
                            result.Add(word, 0);
                        }

                        foreach (var item in split)
                        {
                            texts.Add(item.ToLower());
                        }

                        word = wordsRead.ReadLine();
                        text = textsRead.ReadLine();
                    }
                }
            }

            for (int i = 0; i < words.Count; i++)
            {
                for (int j = 0; j < texts.Count; j++)
                {
                    if (words[i] == texts[j])
                    {
                        result[words[i]]++;
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter("../../result.txt"))
            {
                foreach (var item in result.OrderByDescending(a => a.Value))
                {
                    writer.WriteLine("{0} - {1}", item.Key, item.Value);
                }
            }
        }
    }
}