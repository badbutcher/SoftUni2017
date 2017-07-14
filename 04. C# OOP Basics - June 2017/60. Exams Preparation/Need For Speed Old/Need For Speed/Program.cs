using System;

public class Program
{
    public static void Main()
    {
        CarManager carManager = new CarManager();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "Cops Are Here")
            {
                break;
            }
            else
            {
                string[] data = input.Split();
                string command = data[0];

                switch (command)
                {
                    case "register":
                        carManager.Register(int.Parse(data[1]), data[2], data[3], data[4], int.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7]), int.Parse(data[8]), int.Parse(data[9]));
                        break;
                    case "check":
                        Console.WriteLine(carManager.Check(int.Parse(data[1])));
                        break;
                    case "open":
                        carManager.Open(int.Parse(data[1]), data[2], int.Parse(data[3]), data[4], int.Parse(data[5]));
                        break;
                    case "participate":
                        carManager.Participate(int.Parse(data[1]), int.Parse(data[2]));
                        break;
                    case "start":
                        Console.WriteLine(carManager.Start(int.Parse(data[1])));
                        break;
                    case "park":
                        carManager.Park(int.Parse(data[1]));
                        break;
                    case "unpark":
                        carManager.Unpark(int.Parse(data[1]));
                        break;
                    case "tune":
                        carManager.Tune(int.Parse(data[1]), data[2]);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}