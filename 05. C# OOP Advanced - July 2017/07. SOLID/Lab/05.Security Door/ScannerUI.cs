namespace _05.Security_Door
{
    using System;

    public class ScannerUI : IKeyCard, IPinCode
    {
        public string RequestKeyCard()
        {
            Console.WriteLine("Slide your key card");
            return Console.ReadLine();
        }

        public int RequestPinCode()
        {
            Console.WriteLine("Enter your pin code:");
            return int.Parse(Console.ReadLine());
        }
    }
}