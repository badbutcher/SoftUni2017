namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Services;
    using System;
    using System.Linq;
    using Utilities;

    public class CreateAlbumCommand
    {
        private UserService userSurvice;

        private TagService tagService;

        private AlbumService albumService;

        public CreateAlbumCommand(UserService userService, TagService tagService, AlbumService albumService)
        {
            this.albumService = albumService;
            this.userSurvice = userService;
            this.tagService = tagService;
        }

        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public string Execute(string[] data)
        {
            string username = data[0];
            string albumName = data[1];
            string backgroundColor = data[2];
            string[] tags = data.Skip(3).Select(t=> TagUtilities.ValidateOrTransform(t)).ToArray();

            if (!this.userSurvice.IsUserExisting(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            Color color;
            bool isColorValid = Enum.TryParse(backgroundColor, out color);

            if (!isColorValid)
            {
                throw new ArgumentException($"Color {color} not found!");
            }

            if (tags.Any(t => !this.tagService.IsTagExisting(t)))
            {
                throw new ArgumentException("Invalid tags!");
            }

            if (this.albumService.IsAlbumExisting(albumName))
            {
                throw new ArgumentException($"Album {albumName} not found!");
            }

            this.albumService.AddAlbum(albumName, username, color, tags);

            return $"Album {albumName} successfully created!";
        }
    }
}
