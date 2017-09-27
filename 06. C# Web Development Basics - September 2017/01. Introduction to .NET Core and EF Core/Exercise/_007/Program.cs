namespace _007
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _007.Logic;
    using _007.Models;
    using Microsoft.EntityFrameworkCore;

    public class Program
    {
        private static Random random = new Random();

        public static void Main()
        {
            using (MyDbContext db = new MyDbContext())
            {
                db.Database.Migrate();

                //SeedUsers(db);
                //SeedAlbumsAndPictures(db);
                //SeedTags(db);

                //PrintAlbumsByTag(db);
                //PrintUsersWithMoreThanThreeAlbums(db);
            }
        }

        private static void PrintUsersWithMoreThanThreeAlbums(MyDbContext db)
        {
            var result = db.Users
                .Where(a => a.Albums.Any(b => b.Tags.Count > 3))
                .Select(a => new
                {
                    a.Username,
                    Albums = a.Albums
                    .Where(d => d.Tags.Count > 3)
                    .Select(b => new
                    {
                        b.Name,
                        Tags = b.Tags.Select(c => c.Tag.Name)
                    })
                    .ToList(),
                })
                .OrderByDescending(a => a.Albums.Count)
                .ThenBy(a => a.Albums.Sum(b => b.Tags.Count()))
                .ThenBy(a => a.Username)
                .ToList();

            foreach (var user in result)
            {
                Console.WriteLine(user.Username);

                foreach (var album in user.Albums)
                {
                    Console.WriteLine(album.Name);

                    Console.WriteLine(string.Join(", ", album.Tags));
                }
            }
        }

        private static void PrintAlbumsByTag(MyDbContext db)
        {
            var tag = "#tag0";

            var result = db.Albums
                .Where(a => a.Tags.Any(t => t.Tag.Name == tag))
                .OrderByDescending(a => a.Tags.Count())
                .ThenBy(a => a.Name)
                .Select(a => new
                {
                    a.Name,
                    Ownder = a.User.Username
                })
                .ToList();

            foreach (var album in result)
            {
                Console.WriteLine(album.Name);
                Console.WriteLine(album.Ownder);
                Console.WriteLine("----------");
            }
        }

        private static void SeedTags(MyDbContext db)
        {
            int totalTags = db.Albums.Count() * 11;

            List<Tag> tags = new List<Tag>();

            for (int i = 0; i < totalTags; i++)
            {
                Tag tag = new Tag
                {
                    Name = TagTransformer.Transform($"tag{i}")
                };

                db.Tags.Add(tag);
                tags.Add(tag);
            }

            db.SaveChanges();

            List<int> albumIds = db.Albums.Select(a => a.Id).ToList();

            foreach (var tag in tags)
            {
                int totalAlbums = random.Next(0, 11);

                for (int i = 0; i < totalAlbums; i++)
                {
                    int albumId = albumIds[random.Next(0, albumIds.Count)];

                    bool tagExistsFromAlbum = db.Albums
                        .Any(a => a.Id == albumId && a.Tags.Any(b => b.TagId == tag.Id));

                    if (tagExistsFromAlbum)
                    {
                        i--;
                        continue;
                    }

                    tag.Albums.Add(new AlbumTag
                    {
                        AlbumId = albumId
                    });

                    db.SaveChanges();
                }
            }
        }

        private static void SeedAlbumsAndPictures(MyDbContext db)
        {
            const int totalAlbums = 50;
            const int totalPictures = 250;

            int biggestAlbumId = db.Albums
                .OrderByDescending(a => a.Id)
                .Select(a => a.Id)
                .FirstOrDefault() + 1;

            List<int> userIds = db.Users
                .Select(a => a.Id)
                .ToList();

            List<Album> albums = new List<Album>();

            for (int i = biggestAlbumId; i < biggestAlbumId + totalAlbums; i++)
            {
                Album album = new Album
                {
                    Name = $"Album {i}",
                    BackgroundColor = $"Color {i}",
                    IsPublic = random.Next(0, 2) == 0 ? true : false,
                    UserId = userIds[random.Next(0, userIds.Count)]
                };

                db.Albums.Add(album);
                albums.Add(album);
            }

            db.SaveChanges();

            int biggestPictureId = db.Pictures
                .OrderByDescending(a => a.Id)
                .Select(a => a.Id)
                .FirstOrDefault() + 1;

            List<Picture> pictures = new List<Picture>();

            for (int i = biggestPictureId; i < biggestPictureId + totalPictures; i++)
            {
                Picture picture = new Picture
                {
                    Title = $"Picture {i}",
                    Caption = $"Caption {i}",
                    Path = $"Path {i}"
                };

                pictures.Add(picture);
                db.Pictures.Add(picture);
            }

            db.SaveChanges();

            List<int> albumIds = albums.Select(a => a.Id).ToList();

            for (int i = 0; i < pictures.Count; i++)
            {
                Picture picture = pictures[i];

                int numberOfAlbums = random.Next(1, 11);

                for (int j = 0; j < numberOfAlbums; j++)
                {
                    int albumId = albumIds[random.Next(0, albumIds.Count)];

                    bool pictureExistsInAlbum = db.Pictures
                        .Any(a => a.Id == picture.Id && a.Albums.Any(b => b.AlbumId == albumId));

                    if (pictureExistsInAlbum)
                    {
                        j--;
                        continue;
                    }

                    picture.Albums.Add(new AlbumPicture
                    {
                        AlbumId = albumId
                    });

                    db.SaveChanges();
                }
            }
        }

        private static void SeedUsers(MyDbContext db)
        {
            const int TotalUsers = 50;

            int biggestUserId = db.Users
                .OrderByDescending(a => a.Id)
                .Select(a => a.Id)
                .FirstOrDefault() + 1;

            List<User> allUsers = new List<User>();

            for (int i = biggestUserId; i < biggestUserId + TotalUsers; i++)
            {
                User user = new User
                {
                    Username = $"Username {i}",
                    Password = $"Passwo0rd123$%",
                    Email = $"Pes{i}o@abv.bg",
                    RegisteredOn = DateTime.Now.AddDays(-(100 + i * 10)),
                    LastTimeLoggedIn = DateTime.Now.AddDays(-i),
                    Age = i
                };

                allUsers.Add(user);
                db.Users.Add(user);
            }

            db.SaveChanges();

            List<int> userIds = allUsers.Select(a => a.Id).ToList();

            for (int i = 0; i < userIds.Count; i++)
            {
                int currentUserId = userIds[i];

                int totalFriends = random.Next(5, 11);

                for (int j = 0; j < totalFriends; j++)
                {
                    int friendUserId = userIds[random.Next(0, userIds.Count)];

                    bool validFriendship = true;

                    if (friendUserId == currentUserId)
                    {
                        validFriendship = false;
                    }

                    bool friendshipExists = db.Friendship
                        .Any(a => (a.FromUserId == currentUserId && a.ToUserId == friendUserId) ||
                        (a.FromUserId == friendUserId && a.ToUserId == currentUserId));

                    if (friendshipExists)
                    {
                        validFriendship = false;
                    }

                    if (!validFriendship)
                    {
                        j--;
                        continue;
                    }

                    db.Friendship.Add(new Friendship
                    {
                        FromUserId = currentUserId,
                        ToUserId = friendUserId
                    });

                    db.SaveChanges();
                }
            }
        }
    }
}