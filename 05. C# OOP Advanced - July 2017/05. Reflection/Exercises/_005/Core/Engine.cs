namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;

    internal class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpeter;

        public Engine(ICommandInterpreter commandInterpeter)
        {
            this.commandInterpeter = commandInterpeter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = this.commandInterpeter.InterpretCommand(data, commandName).Execute();
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}