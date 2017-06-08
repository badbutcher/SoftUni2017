namespace _016
{
    using System;
    using System.Text;

    class Program
    {
        static void Main()
        {
            StringBuilder sb = new StringBuilder();
            string openTag = "<a";
            string closeTag = "</a>";
            string hrefTag = "href";

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                else
                {
                    sb.Append(input);
                }
            }

            string text = sb.ToString();
            int startIndex = text.IndexOf(openTag);
            while (startIndex != -1)
            {
                int endIndex = text.IndexOf(closeTag);
                if (endIndex == -1)
                {
                    break;
                }

                string aTag = text.Substring(startIndex, endIndex - startIndex + closeTag.Length);
                string removeTags = aTag.Replace(openTag, string.Empty).Replace(closeTag, string.Empty);
                text = text.Replace(aTag, removeTags);
                startIndex = text.IndexOf(openTag);

                int hrefIndex = aTag.IndexOf(hrefTag);
                string word = string.Empty;

                for (int i = hrefIndex; i < aTag.Length; i++)
                {
                    word += aTag[i];
                }

                Console.WriteLine(word);
                word = word.Substring(word.IndexOf(hrefTag) + 5);
                word = word.Trim(new char[] { ' ', '=' });
                char tagToRemove = word[0];
                if (tagToRemove == '\"')
                {
                    int nextTag = word.IndexOf(tagToRemove, word.IndexOf(tagToRemove) + 1);
                    word = word.Substring(0, nextTag);
                    Console.WriteLine(word.TrimStart(tagToRemove));
                }
                else if (tagToRemove == '/')
                {
                    int nextTag = 0;
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == '>')
                        {
                            nextTag = word.IndexOf(word[i]);
                            break;
                        }
                    }

                    word = word.Substring(0, nextTag);
                    Console.WriteLine(word);
                }
                else if (tagToRemove == '\'')
                {
                    tagToRemove = word[0];
                    int nextTag = word.IndexOf(tagToRemove, word.IndexOf(tagToRemove) + 1);
                    word = word.Substring(0, nextTag);
                    Console.WriteLine(word.TrimStart(tagToRemove));
                }
                else
                {
                    word = word.Substring(word.IndexOf(hrefTag));
                }
            }
        }
    }
}