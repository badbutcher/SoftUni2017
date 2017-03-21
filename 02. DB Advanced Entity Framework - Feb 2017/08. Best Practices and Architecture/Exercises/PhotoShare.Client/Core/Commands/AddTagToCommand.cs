namespace PhotoShare.Client.Core.Commands
{
    using Services;
    using System;
    using Utilities;

    public class AddTagToCommand 
    {
        private TagService tagService;

        private AlbumService albumService;

        public AddTagToCommand(AlbumService albumService, TagService tagService)
        {
            this.albumService = albumService;
            this.tagService = tagService;
        }

        // AddTagTo <albumName> <tag>
        public string Execute(string[] data)
        {
            string albumName = data[0];
            string tagName = TagUtilities.ValidateOrTransform(data[1]);

            if (!this.albumService.IsAlbumExisting(albumName) || 
                !this.tagService.IsTagExisting(tagName))
            {
                throw new ArgumentException("Either tag or album do not exist!");
            }

            this.albumService.AddTagTo(albumName, tagName);

            return $"Tag {tagName} added to {albumName}!";
        }
    }
}
