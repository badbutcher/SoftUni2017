namespace Photo
{
    using System;
    using System.Data.Entity.Validation;
    using System.Linq;
    using Models;

    class Program
    {
        static void Main()
        {
            PhotoContext context = new PhotoContext();
            Tag tag = new Tag()
            {
                Label = "#kru6i "
            };

            context.Tags.Add(tag);

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                tag.Label = TagTransofrmer.Transform(tag.Label);
                context.SaveChanges();
            }

            Console.WriteLine(context.Photographers.Count());
        }
    }
}