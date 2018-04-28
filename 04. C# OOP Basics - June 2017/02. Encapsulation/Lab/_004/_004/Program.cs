//namespace _004
//{
using System;

public class Program
{
    private static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Team team = new Team("My Team");
        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine().Split();
            string firstName = data[0];
            string lastName = data[1];
            int age = int.Parse(data[2]);
            decimal salaty = decimal.Parse(data[3]);

            Person player = new Person(firstName, lastName, age, salaty);
            team.AddPlayer(player);
        }

        Console.WriteLine($"First team has {team.FirstTeam.Count} players");
        Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players");

    }
}

//}