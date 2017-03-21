namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Services;
    using System;

    public class ShareAlbumCommand
    {

        private UserService userService;
        private AlbumService albumService;

        public ShareAlbumCommand(UserService userService, AlbumService albumService)
        {
            this.userService = userService;
            this.albumService = albumService;
        }

        public string Execute(string[] data)
        {
            int albumId = int.Parse(data[0]);
            string username = data[1];
            string permission = data[2];

            if (!albumService.IsAlbumExistingById(albumId))
            {
                throw new ArgumentException($"Album {albumId} not found!");
            }

            Album album = this.albumService.AlbumId(albumId);

            if (!this.userService.IsUserExisting(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            return "";
        }
    }
}
