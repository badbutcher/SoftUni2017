using System;

public class InspectCommand : Command
{
    public InspectCommand(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }

    public override string Execute()
    {
        throw new System.NotImplementedException();
    }
}