namespace Gringotts
{
    using Microsoft.SqlServer.Server;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            _15DeleteProjectById();
        }

        private static void _15DeleteProjectById()
        {
            //var context = new GringottsContext();

            //var linq = context.WizzardDeposits
            //    .Where(w => w.DepositGroup == "Troll Chest")
            //    .OrderBy(w => w.FirstName);

            //List<char> letter = new List<char>();

            //foreach (var item in linq)
            //{
            //    letter.Add(item.FirstName[0]);
            //}

            //List<char> result = letter.Distinct().ToList();
            //result.Sort();

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            // OR

            //var context = new GringottsContext();

            //var letters = context.WizzardDeposits
            //    .Where(w => w.DepositGroup == "Troll Chest")
            //    .Select(w => w.FirstName)
            //    .ToList()
            //    .Select(f => f[0])
            //    .Distinct()
            //    .OrderBy(c => c);

            //foreach (var letter in letters)
            //{
            //    Console.WriteLine(letter);
            //}

            // OR

            GringottsContext context = new GringottsContext();
            var wizzards = context.WizzardDeposits.Where(x => x.DepositGroup == "Troll Chest").Distinct();
            SortedSet<Char> unqSet = new SortedSet<char>();
            foreach (var wizzard in wizzards)
            {
                unqSet.Add(wizzard.FirstName[0]);
            }

            Console.WriteLine(string.Join(Environment.NewLine, unqSet));
        }
    }
}
