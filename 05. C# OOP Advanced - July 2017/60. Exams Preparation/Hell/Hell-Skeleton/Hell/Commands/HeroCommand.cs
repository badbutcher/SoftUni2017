﻿public class HeroCommand : Command
{
    public HeroCommand(string name, string type)
    {
        Name = name;
        Type = type;
    }

    public string Name { get; private set; }

    public string Type { get; private set; }

    public override string Execute()
    {
        throw new System.NotImplementedException();
    }
}