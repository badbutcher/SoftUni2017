namespace ExportJson
{
    using Exam;
    using Exam.Models;
    using Exam.Models.Dtos;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            PhotoContext context = new PhotoContext();

            ////OrderedPhotographers(context);

            ////LandscapePhotographers(context);
        }

        private static void LandscapePhotographers(PhotoContext context)
        {
            ////var result = context.Photographers
            ////    .OrderBy(w => w.FirstName)
            ////    .Where(q => q.PrimaryCamera is DslrCamera/* && q.Lenses.All(r => r.FocalLength <= 30)*/)

            ////    .Select(a => new ExportLandscapePhotographersDto
            ////    {
            ////        FirstName = a.FirstName,
            ////        LastName = a.LastName,
            ////        Make = a.PrimaryCamera.Make,
            ////        LensesCount = a.Lenses.Count
            ////    });

            var photographers = context.Photographers
                .Where(a => a.Lenses.All(l => l.FocalLength <= 30))
                .Select(p => new
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    PrimaryCameraMake = p.PrimaryCamera.Make,
                    NumberOfLenses = p.Lenses.Count(),
                    Type = p.PrimaryCamera
                })
                .OrderBy(p => p.FirstName);

            var result = photographers
                .Where(p => p.Type is DslrCamera)
                .Select(p => new
                {
                    p.FirstName,
                    p.LastName,
                    p.PrimaryCameraMake,
                    p.NumberOfLenses
                });

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);
            File.WriteAllText("../../landscape-photographers.json", json);
        }

        private static void OrderedPhotographers(PhotoContext context)
        {
            var result = context.Photographers
                .Select(a => new ExportPhotographersDto()
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Phone = a.Phone
                })
                .OrderBy(s => s.FirstName)
                .ThenByDescending(q => q.LastName);

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);
            File.WriteAllText("../../photographers-ordered.json", json);
        }
    }
}
