using System;

public class Engine
{
    private SystemManager systemManager;

    public Engine()
    {
        this.systemManager = new SystemManager();
    }

    public void Run()
    {
        bool exit = false;
        while (!exit)
        {
            string input = Console.ReadLine();
            string[] data = input.Split(new char[] { ' ', ',', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            switch (data[0])
            {
                case "RegisterPowerHardware":
                    this.systemManager.RegisterPowerHardware(data[1], int.Parse(data[2]), int.Parse(data[3]));
                    break;
                case "RegisterHeavyHardware":
                    this.systemManager.RegisterHeavyHardware(data[1], int.Parse(data[2]), int.Parse(data[3]));
                    break;
                case "RegisterExpressSoftware":
                    this.systemManager.RegisterExpressSoftwar(data[1], data[2], int.Parse(data[3]), int.Parse(data[4]));
                    break;
                case "RegisterLightSoftware":
                    this.systemManager.RegisterLightSoftware(data[1], data[2], int.Parse(data[3]), int.Parse(data[4]));
                    break;
                case "ReleaseSoftwareComponent":
                    this.systemManager.ReleaseSoftwareComponent(data[1], data[2]);
                    break;
                case "Analyze":
                    Console.WriteLine(this.systemManager.Analyze());
                    break;
                case "System":
                    Console.WriteLine(this.systemManager.SystemSplit());
                    exit = true;
                    break;
                default:
                    break;
            }
        }
    }
}