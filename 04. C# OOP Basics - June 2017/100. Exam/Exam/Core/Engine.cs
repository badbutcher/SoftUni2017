using System;
using System.Linq;

public class Engine
{
    private DraftManager manager;
    private bool exit;

    public Engine()
    {
        this.manager = new DraftManager();
        this.exit = false;
    }

    public void Run()
    {
        try
        {
            while (!exit)
            {
                var cmdArgs = Console.ReadLine().Split(' ').ToList();
                var command = cmdArgs[0];
                cmdArgs.RemoveAt(0);

                switch (command)
                {
                    case "RegisterHarvester":
                        Console.WriteLine(manager.RegisterHarvester(cmdArgs));
                        break;
                    case "RegisterProvider":
                        Console.WriteLine(manager.RegisterProvider(cmdArgs));
                        break;
                    case "Day":
                        Console.WriteLine(manager.Day());
                        break;
                    case "Mode":
                        Console.WriteLine(manager.Mode(cmdArgs));
                        break;
                    case "Check":
                        Console.WriteLine(manager.Check(cmdArgs));
                        break;
                    case "Shutdown":
                        exit = true;
                        Console.WriteLine(manager.ShutDown());
                        break;
                    default:
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}