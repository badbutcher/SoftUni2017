using _03BarracksFactory.Attributes;
using _03BarracksFactory.Contracts;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace _03BarracksFactory.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandSuffix = "Command";
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            string commandCompleteName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + CommandSuffix;

            Type commandType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == commandCompleteName);

            object[] commandParams =
            {
                data
            };

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            IExecutable currentCommand = (IExecutable)Activator.CreateInstance(commandType, commandParams);

            currentCommand = this.InJectDependencies(currentCommand);

            return currentCommand;
        }

        private IExecutable InJectDependencies(IExecutable currentCommand)
        {
            FieldInfo[] commandFields = currentCommand.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.GetCustomAttribute<InjectAttribute>() != null)
                .ToArray();

            FieldInfo[] interpeterFields = this.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo commandField in commandFields)
            {
                FieldInfo interepterField = interpeterFields
                    .First(f => f.FieldType == commandField.FieldType);

                object valueToInject = interepterField.GetValue(this);

                commandField.SetValue(currentCommand, valueToInject);
            }

            return currentCommand;
        }
    }
}