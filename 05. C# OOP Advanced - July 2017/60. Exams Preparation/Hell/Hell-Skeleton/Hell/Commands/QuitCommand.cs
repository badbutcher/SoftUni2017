using System.Collections.Generic;

public class QuitCommand : AbstractCommand
{
    public QuitCommand()
    {
    }

    public QuitCommand(List<string> args, IManager manager)
    {
    }

    public virtual string Execute()
    {
        return base.Manager.Quit(this.ArgsList);
    }

    public string ArgsList { get; set; }
}