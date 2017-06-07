namespace _006
{
    using System;

    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine().ToLower();
            string word = Console.ReadLine().ToLower();
            int counter = 0;
            string currentWord = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                currentWord += text[i];
                if (currentWord.Length == word.Length)
                {
                    if (currentWord.Equals(word))
                    {
                        counter++;
                        currentWord = string.Empty;
                        i -= word.Length - 1;
                    }
                }

                if (currentWord.Length > word.Length)
                {
                    currentWord = "";
                    i -= word.Length;
                }
            }

            Console.WriteLine(counter);


            //string text = Console.ReadLine();
            //string searchString = Console.ReadLine();
            //int counter = 0;
            //for (int i = 0; i < text.Length - searchString.Length; i++)
            //{
            //    if (text.Substring(i, searchString.Length).ToLower() == searchString.ToLower())
            //    {
            //        counter++;
            //    }
            //}

            //Console.WriteLine(counter);
        }
    }
}