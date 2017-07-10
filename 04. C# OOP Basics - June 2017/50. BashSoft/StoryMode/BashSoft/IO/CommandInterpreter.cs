namespace BashSoft
{
    using BashSoft.Exceptions;
    using BashSoft.IO.Commands;
    using System;
    using System.IO;

    public class CommandInterpreter
    {
        private Tester judge;
        private StudentsRepository repository;
        private IOManager inputOutputManager;

        public CommandInterpreter(Tester judge, StudentsRepository repository, IOManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpredCommand(string input)
        {
            string[] data = input.Split();
            string commandName = data[0];

            Command command = this.ParseCommand(input, data, commandName);
            command.Execute();

            try
            {
                this.ParseCommand(input, data, commandName);
            }
            catch (DirectoryNotFoundException aoore)
            {
                OutputWriter.DisplayException(aoore.Message);
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                OutputWriter.DisplayException(aoore.Message);
            }
            catch (ArgumentException ae)
            {
                OutputWriter.DisplayException(ae.Message);
            }
            catch (Exception e)
            {
                OutputWriter.DisplayException(e.Message);
            }
        }

        private Command ParseCommand(string input, string[] data, string command)
        {
            switch (command)
            {
                case "open":
                    return new OpenFileCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "mkdir":
                    return new MakeDirectoryCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "ls":
                    return new TraverseFoldersCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "cmp":
                    return new CompareFilesCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "cdRel":
                    return new ChangeRelativePathCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "cdAbs":
                    return new ChangeAbsolutePathCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "readDb":
                    return new ReadDatabaseCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "help":
                    return new GetHelpCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "filter":
                    return new PrintFilteredStudentsCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "order":
                    return new PrintOrderedStudentsCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "dropdb":
                    return new DropDatabaseCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                //case "decOrder":
                //    break;
                //case "download":
                //    break;
                //case "downloadAsynch":
                //    break;
                case "show":
                    return new ShowCourseCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                default:
                    throw new InvalidCommandException(input);
            }
        }
    }
}