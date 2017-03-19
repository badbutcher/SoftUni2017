namespace Gringotts
{
    using System;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            GringottsContext context = new GringottsContext();

            ////_019(context);
            ////_020(context);
        }

        private static void _020(GringottsContext context)
        {
            var rusult = context.WizzardDeposits
                .Where(a => a.MagicWandCreator == "Ollivander family")
                .GroupBy(g => g.DepositGroup)
                .Select(w => new
                {
                    Group = w.Key,
                    Sum = w.Sum(s => s.DepositAmount)
                })
                .Where(s => s.Sum < 150000)
                .OrderByDescending(o => o.Sum);

            foreach (var item in rusult)
            {
                Console.WriteLine("{0} - {1:F2}", item.Group, item.Sum);
            }
        }

        private static void _019(GringottsContext context)
        {
            var rusult = context.WizzardDeposits
                .Where(a => a.MagicWandCreator == "Ollivander family")
                .GroupBy(g => g.DepositGroup)
                .Select(w => new
                {
                    Group = w.Key,
                    Sum = w.Sum(s => s.DepositAmount)
                });

            foreach (var item in rusult)
            {
                Console.WriteLine("{0} - {1:F2}", item.Group, item.Sum);
            }
        }
    }
}