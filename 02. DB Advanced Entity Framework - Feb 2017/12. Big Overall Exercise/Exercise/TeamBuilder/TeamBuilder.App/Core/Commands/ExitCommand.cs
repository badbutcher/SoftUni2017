namespace TeamBuilder.App.Core.Commands
{
    using System;
    using Utilities;

    class ExitCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLenght(0, inputArgs);

            Environment.Exit(0);

            return "Bye!"; 
        }
    }
}