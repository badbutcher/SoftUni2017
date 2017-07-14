using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        NationsBuilder manager = new NationsBuilder();
        bool exit = false;

        while (!exit)
        {
            string input = Console.ReadLine();

            string[] data = input.Split();
            string command = data[0];
            switch (command)
            {
                case "Bender":
                    manager.AssignBender(data.ToList());
                    break;
                case "Monument":
                    manager.AssignMonument(data.ToList());
                    break;
                case "Status":
                    Console.WriteLine(manager.GetStatus(data[1]));
                    break;
                case "War":
                    manager.IssueWar(data[1]);
                    break;
                case "Quit":
                    Console.WriteLine(manager.GetWarRecords());
                    exit = true;
                    break;
                default:
                    break;
            }
        }
    }
}