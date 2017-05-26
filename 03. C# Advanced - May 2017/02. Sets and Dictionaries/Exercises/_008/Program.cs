namespace _008
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Dictionary<string, List<string>> cardsDic = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(':');
                string user = input[0];

                if (input[0] == "JOKER")
                {
                    break;
                }
                else
                {
                    List<string> cards = input[1].Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    if (!cardsDic.ContainsKey(user))
                    {
                        cardsDic.Add(user, cards);
                    }
                    else
                    {
                        cardsDic[user].AddRange(cards);
                    }
                }
            }

            var distinctDict = cardsDic.ToDictionary(kv => kv.Key, kv => kv.Value.Distinct());

            foreach (var item in distinctDict)
            {
                Console.Write("{0}: ", item.Key);
                GetCardPoints(item.Value);
            }
        }

        private static void GetCardPoints(IEnumerable<string> value)
        {
            int sum = 0;

            foreach (var item in value)
            {
                string cardPower = item.Substring(0, item.Length - 1);
                string cardType = item.Last().ToString();

                if (cardPower == "1")
                {
                    cardPower = "10";
                }

                int numPower = 0;
                int numType = 0;

                switch (cardPower)
                {
                    case "2":
                        numPower = 2;
                        break;
                    case "3":
                        numPower = 3;
                        break;
                    case "4":
                        numPower = 4;
                        break;
                    case "5":
                        numPower = 5;
                        break;
                    case "6":
                        numPower = 6;
                        break;
                    case "7":
                        numPower = 7;
                        break;
                    case "8":
                        numPower = 8;
                        break;
                    case "9":
                        numPower = 9;
                        break;
                    case "10":
                        numPower = 10;
                        break;
                    case "J":
                        numPower = 11;
                        break;
                    case "Q":
                        numPower = 12;
                        break;
                    case "K":
                        numPower = 13;
                        break;
                    case "A":
                        numPower = 14;
                        break;
                    default:
                        break;
                }

                switch (cardType)
                {
                    case "S":
                        numType = 4;
                        break;
                    case "H":
                        numType = 3;
                        break;
                    case "D":
                        numType = 2;
                        break;
                    case "C":
                        numType = 1;
                        break;
                    default:
                        break;
                }

                sum += numPower * numType;
            }

            Console.WriteLine(sum);
        }
    }
}