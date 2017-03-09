namespace Photo.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Photo.PhotoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Photo.PhotoContext context)
        {
            Photographer p1 = new Photographer()
            {
                Username = "Camerata",
                Password = "2134567uty",
                Email = "asdas.abv.asd",
                BirthDate = DateTime.Now,
                RegisterDate = DateTime.Now,
            };

            Photographer p2 = new Photographer()
            {
                Username = "Lentata",
                Password = "7855742346537",
                Email = "bnnghn.abv.agfhsd",
                RegisterDate = DateTime.Now,
                BirthDate = DateTime.Now
            };

            Photographer p3 = new Photographer()
            {
                Username = "Filma",
                Password = "afegshdjmhfb",
                Email = "56f.abv.dsf",
                RegisterDate = DateTime.Now,
                BirthDate = DateTime.Now
            };

            context.Photographers.AddOrUpdate(p => p.Username, p1, p2, p3);
            context.SaveChanges();

            Picture f1 = new Picture()
            {
                Title = "Tree",
                Caption = "So good",
                PathOfFile = "../../asd.png",
            };

            Picture f2 = new Picture()
            {
                Title = "Rock",
                Caption = "So good",
                PathOfFile = "../../rock.png",
            };

            Picture f3 = new Picture()
            {
                Title = "Glass",
                Caption = "Not good",
                PathOfFile = "../../NO.png",
            };

            context.Pictures.AddOrUpdate(f => f.Title, f1, f2, f3);
            context.SaveChanges();

            Album a1 = new Album()
            {
                Name = "Nature",
                BackgroundColor = "Green",
                IsPublic = true,
            };

            Album a2 = new Album()
            {
                Name = "Rocks",
                BackgroundColor = "Grey",
                IsPublic = false,

            };
            a1.Photographers.Add(p1);
            a2.Photographers.Add(p2);
            context.Albums.AddOrUpdate(a => a.Name, a1, a2);
            context.SaveChanges();

            a1.Pictures.Add(f1);
            a2.Pictures.Add(f2);

            Tag t = new Tag()
            {
                Label = "#gogreen"
            };

            context.Tags.AddOrUpdate(a => a.Label, t);
            t.Albums.Add(a1);
            context.SaveChanges();
        }
    }
}
