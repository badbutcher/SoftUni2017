namespace BashSoft.IO.Commands
{
    using Contracts;
    using Execptions;

    public class MakeDirectoryCommand : Command, IExecutable
    {
        public MakeDirectoryCommand(string input, string[] data, IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            var folderName = this.Data[1];
            ////base.
            this.InputOutputManager.CreateDirectoryInCurrentFolder(folderName);
        }
    }
}