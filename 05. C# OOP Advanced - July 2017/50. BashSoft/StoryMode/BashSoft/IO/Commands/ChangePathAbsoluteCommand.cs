﻿namespace BashSoft.IO.Commands
{
    using Contracts;
    using Execptions;

    public class ChangePathAbsoluteCommand : Command, IExecutable
    {
        public ChangePathAbsoluteCommand(string input, string[] data, IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            var absPath = this.Data[1];
            this.InputOutputManager.ChangeCurrentDirectoryAbsolute(absPath);
        }
    }
}