﻿//namespace _002
//{
using System.Text;

public class Tesla : ICar, IElectricCar
{
    public Tesla(string model, string color, int battery)
    {
        this.Model = model;
        this.Color = color;
        this.Battery = battery;
    }

    public string Model { get; private set; }

    public string Color { get; private set; }

    public int Battery { get; private set; }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Color} {GetType().Name} {this.Model} with {this.Battery} Batteries");
        sb.AppendLine(Start());
        sb.Append(Stop());

        return sb.ToString();
    }
}

//}