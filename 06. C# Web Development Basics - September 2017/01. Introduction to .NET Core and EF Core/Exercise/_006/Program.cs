namespace _006
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _006.Models;
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

                //PrintAlbumsWithTotalPictures(db);
                //PrintPicturesInfo(db);
                //PrintAlbumsByUser(db);
            }
        }

        private static void PrintAlbumsByUser(MyDbContext db)
        {
            int userId = 10;

            var result = db.Albums
                .Where(a => a.UserId == userId)
                .Select(a => new
                {
                    Owner = a.User.Username,
                    a.IsPublic,
                    a.Name,
                    Pictures = a.Pictures.Select(b => new
                    {
                        b.Picture.Title,
                        b.Picture.Path
                    })
                })
                .OrderBy(a => a.Name)
                .ToList();

            foreach (var album in result)
            {
                Console.WriteLine(album.Name);

                if (album.IsPublic)
                {
                    foreach (var picture in album.Pictures)
                    {
                        Console.WriteLine($"--{picture.Title}");
                        Console.WriteLine($"--{picture.Path}");
                    }
                }
                else
                {
                    Console.WriteLine("Private content!");
                }

                Console.WriteLine("---------");
            }
        }

        private static void PrintPicturesInfo(MyDbContext db)
        {
            var result = db.Pictures
                .Where(a => a.Albums.Count > 2)
                .Select(a => new
                {
                    a.Title,
                    Albums = a.Albums.Select(b => b.Album.Name),
                    Owners = a.Albums.Select(b => b.Album.User.Username)
                })
                .OrderByDescending(a => a.Albums.Count())
                .ThenBy(a => a.Title)
                .ToList();

            foreach (var picture in result)
            {
                Console.WriteLine(picture.Title);
                Console.WriteLine(string.Join(", ", picture.Albums));
                Console.WriteLine(string.Join(", ", picture.Owners));
                Console.WriteLine("-------------");
            }
        }

        private static void PrintAlbumsWithTotalPictures(MyDbContext db)
        {
            var result = db.Albums
                .Select(a => new
                {
                    a.Name,
                    Owner = a.User.Username,
                    TotalPictures = a.Pictures.Count
                })
                .OrderByDescending(a => a.TotalPictures)
                .ThenBy(a => a.Owner)
                .ToList();

            foreach (var album in result)
            {
                Console.WriteLine(album.Owner);
                Console.WriteLine(album.Name);
                Console.WriteLine(album.TotalPictures);
                Console.WriteLine("-------------");
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