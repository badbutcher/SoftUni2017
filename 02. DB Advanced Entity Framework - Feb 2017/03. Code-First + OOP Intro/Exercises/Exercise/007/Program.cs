namespace _007
{
    using System;

    class Program
    {
        static void Main()
        {
            WizardDeposits dumbledore = new WizardDeposits()
            {
                FirstName = "Albus",
                LastName = "Dumbledore",
                Age = 150,
                MagicWandCreator = "Antioch Peverell",
                MagicWandSize = 15,
                DepositStartDate = new DateTime(2016, 10, 20),
                DepositExpirationDate = new DateTime(2020, 10, 20),
                DepositAmount = 20000.24m,
                DepositCharge = 0.2m,
                IsDepositExpired = false,
            };

            var conext = new WizardContext();
            conext.WizardDeposits.Add(dumbledore);
            conext.SaveChanges();
        }
    }
}