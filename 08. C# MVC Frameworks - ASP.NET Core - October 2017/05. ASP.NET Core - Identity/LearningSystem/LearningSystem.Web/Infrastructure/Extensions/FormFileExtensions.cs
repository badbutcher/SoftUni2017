namespace LearningSystem.Web.Infrastructure.Extensions
{
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public static class FormFileExtensions
    {
        public static async Task<byte[]> ToByteArrayAsync(this IFormFile formfile)
        {
            using (var memorySteam = new MemoryStream())
            {
                await formfile.CopyToAsync(memorySteam);
                return memorySteam.ToArray();
            }
        }
    }
}