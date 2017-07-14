using System;

public class Engine
{
    private Manager manager;

    public Engine()
    {
        this.manager = new Manager();
    }

    public void Run()
    {
        bool exit = false;
        while (!exit)
        {
            string input = Console.ReadLine();
            string[] data = input.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
            switch (data[0])
            {
                case "RegisterCleansingCenter":
                    this.manager.RegisterCleansingCenter(data[1]);
                    break;
                case "RegisterAdoptionCenter":
                    this.manager.RegisterAdoptionCenter(data[1]);
                    break;
                case "RegisterDog":
                    this.manager.RegisterDog(data[1], int.Parse(data[2]), int.Parse(data[3]), data[4]);
                    break;
                case "RegisterCat":
                    this.manager.RegisterCat(data[1], int.Parse(data[2]), int.Parse(data[3]), data[4]);
                    break;
                case "SendForCleansing":
                    this.manager.SendForCleansing(data[1], data[2]);
                    break;
                case "Cleanse":
                    this.manager.Cleanse(data[1]);
                    break;
                case "Adopt":
                    this.manager.Adopt(data[1]);
                    break;
                case "Paw":
                    Console.WriteLine(this.manager.PawPawPawah());
                    exit = true;
                    break;
            }
        }
    }
}