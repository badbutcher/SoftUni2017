using PhotoShare.Data;
using PhotoShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoShare.Services
{
    public class TagService
    {
        public bool IsTagExisting(string tagName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Tags.Any(t => t.Name == tagName);
            }
        }

        public void AddTag(string tagName)
        {
            Tag tag = new Tag();
            tag.Name = tagName;

            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Tags.Add(tag);
                context.SaveChanges();
            }
        }
    }
}
