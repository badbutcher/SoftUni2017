namespace _001
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string bracketsPattern = @"\[.*?\]";
            string wordPattern = @"^\[[^\s]*<[0-9]+[^\s]*[0-9]+>[^\s]*\]$";
            string getNumbersPattern = @"^.*<([0-9]+)[^\s]*?([0-9]+)>.*$";
            string input = Console.ReadLine();
            string result = string.Empty;
            int indexSum = 0;

            Regex regex = new Regex(bracketsPattern);
            MatchCollection matches = regex.Matches(input);

            foreach (Match item in matches)
            {
                int start = 0;
                string word = item.Value;
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == '[' && i > start)
                    {
                        start = i;
                    }
                }

                word = word.Substring(start);

                Regex regexWord = new Regex(wordPattern);
                Match match = regexWord.Match(word);

                if (match.Success)
                {
                    int firstNum = 0;
                    int lastNum = 0;
                    Regex regexNumbers = new Regex(getNumbersPattern);
                    MatchCollection matchNumbers = regexNumbers.Matches(match.Value);
                    foreach (Match m in matchNumbers)
                    {
                        firstNum = int.Parse(m.Groups[1].Value);
                        lastNum = int.Parse(m.Groups[2].Value);
                    }

                    if (indexSum + firstNum > input.Length)
                    {
                        while (indexSum + firstNum > input.Length)
                        {
                            indexSum = Math.Abs(indexSum + firstNum - input.Length);
                        }

                        result += input[indexSum+1];
                        indexSum += firstNum;
                    }
                    else
                    {
                        result += input[firstNum + indexSum];
                        indexSum += firstNum;
                    }  

                    if (indexSum + lastNum > input.Length)
                    {
                        while (indexSum + lastNum > input.Length)
                        {
                            indexSum = Math.Abs(indexSum + lastNum - input.Length);
                        }

                        result += input[indexSum+1];
                        indexSum += lastNum;
                    }
                    else
                    {
                        result += input[lastNum + indexSum];
                        indexSum += lastNum;
                    }
                    
                }
            }

            Console.WriteLine(result);
        }
    }
}