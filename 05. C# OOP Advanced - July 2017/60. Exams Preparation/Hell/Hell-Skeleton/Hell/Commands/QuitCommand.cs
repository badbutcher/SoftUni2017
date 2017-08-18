public class QuitCommand : Command
{
    //public QuitCommand()
    //{
    //}

    //public QuitCommand(List<string> args, IManager manager)
    //{
    //}

    //public string Execute()
    //{
    //    //return this.Manager.Quit(this.ArgsList);
    //}

    public override string Execute()
    {
        throw new System.NotImplementedException();
    }

    public IManager Manager { get; private set; }

    public string ArgsList { get; private set; }
}