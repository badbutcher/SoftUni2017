using PhotoShare.Data;
using PhotoShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoShare.Services
{
    public class AlbumService
    {
        public void AddAlbum(string albumName, string ownerUsername, Color color, string[] tagNames)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                Album album = new Album();
                album.Name = albumName;
                album.BackgroundColor = color;
                album.Tags = context.Tags.Where(t => tagNames.Contains(t.Name)).ToList();

                User owner = context.Users.SingleOrDefault(u => u.Username == ownerUsername);

                if (owner != null)
                {
                    AlbumRole albumRole = new AlbumRole();
                    albumRole.User = owner;
                    albumRole.Album = album;
                    albumRole.Role = Role.Owner;

                    album.AlbumRoles.Add(albumRole);
                    context.Albums.Add(album);
                    context.SaveChanges();
                }
            }
        }

        public void AddTagTo(string albumName, string tagName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                Album album = context.Albums.SingleOrDefault(a => a.Name == albumName);
                Tag tag = context.Tags.SingleOrDefault(t => t.Name == tagName);

                album.Tags.Add(tag);
                context.SaveChanges();
            }
        }

        public bool IsAlbumExisting(string albumName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Albums.Any(a => a.Name == albumName);
            }
        }

        public bool IsAlbumExistingById(int albumId)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Albums.Any(a => a.Id == albumId);
            }
        }

        public Album AlbumId(int albumId)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Albums.SingleOrDefault(a => a.Id == albumId);
            }
        }
    }
}
