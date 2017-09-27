namespace _005
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _005.Models;
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

                //PrintUSersWithFriends(db);
                //PrintUserWithMoreThanFiveFriends(db);
            }
        }

        private static void PrintUserWithMoreThanFiveFriends(MyDbContext db)
        {
            var result = db.Users
                .Where(a => !a.IsDeleted)
                .Where(a => (a.FromFriends.Count + a.ToFriends.Count) > 5)
                .OrderBy(a => a.RegisteredOn)
                .ThenBy(a => a.FromFriends.Count + a.ToFriends.Count)
                .Select(a => new
                {
                    a.Username,
                    TotalFriends = a.FromFriends.Count + a.ToFriends.Count,
                    Period = DateTime.Now.Subtract(a.RegisteredOn.Value)
                })
                .ToList();

            foreach (var user in result)
            {
                Console.WriteLine(user.Username);
                Console.WriteLine(user.TotalFriends);
                Console.WriteLine(user.Period.Days);
                Console.WriteLine("--------");
            }
        }

        private static void PrintUSersWithFriends(MyDbContext db)
        {
            var result = db.Users
                .Select(a => new
                {
                    a.Username,
                    TotalFriends = a.FromFriends.Count + a.ToFriends.Count,
                    Status = a.IsDeleted ? "Inactive" : "Active"
                })
                .OrderByDescending(a => a.TotalFriends)
                .ThenBy(a => a.Username)
                .ToList();

            foreach (var user in result)
            {
                Console.WriteLine(user.Username);
                Console.WriteLine(user.TotalFriends);
                Console.WriteLine(user.Status);
                Console.WriteLine("--------");
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