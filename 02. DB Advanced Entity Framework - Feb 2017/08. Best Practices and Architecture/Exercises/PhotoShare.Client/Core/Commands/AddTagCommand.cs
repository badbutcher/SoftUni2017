namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Models;
    using Services;
    using Utilities;

    public class AddTagCommand
    {
        private TagService tagService;

        public AddTagCommand(TagService tagService)
        {
           this.tagService = tagService;
        }

        public string Execute(string[] data)
        {
            string tagName = TagUtilities.ValidateOrTransform(data[0]);

            if (this.tagService.IsTagExisting(tagName))
            {
                throw new ArgumentException($"Tag {tagName} exists!");
            }

            this.tagService.AddTag(tagName);

            return $"Tag {tagName} was added successfully!";
        }
    }
}
