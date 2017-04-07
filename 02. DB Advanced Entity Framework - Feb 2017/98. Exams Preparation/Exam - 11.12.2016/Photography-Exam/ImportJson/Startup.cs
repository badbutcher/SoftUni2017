namespace ImportJson
{
    using Exam;
    using Exam.Models;
    using Exam.Models.Dtos;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Startup
    {
        private const string ImportLensesPath = "../../Jsons/lenses.json";

        private const string ImportCamerasPath = "../../Jsons/cameras.json";

        private const string ImportPhotographersPath = "../../Jsons/photographers.json";

        static void Main()
        {
            ImportLenses();
            ImportCameras();
            ImportPhotographers();
        }

        private static void ImportPhotographers()
        {
            Regex regex = new Regex(@"\+[0-9]{1,3}\/[0-9]{1,10}");

            PhotoContext context = new PhotoContext();
            var json = File.ReadAllText(ImportPhotographersPath);
            var photographers = JsonConvert.DeserializeObject<IEnumerable<ImportPhotographersDto>>(json);

            foreach (var photographer in photographers)
            {
                if (photographer.FirstName == null || photographer.LastName == null || photographer.Phone == null || !regex.IsMatch(photographer.Phone))
                {
                    Console.WriteLine("Error. Invalid data provided");
                }
                else
                {
                    var PhotographerEntity = new Photographer
                    {
                        FirstName = photographer.FirstName,
                        LastName = photographer.LastName,
                        Phone = photographer.Phone
                    };

                    PhotographerEntity.PrimaryCamera = GetRandomCamera(context);
                    PhotographerEntity.SecondaryCamera = GetRandomCamera(context);

                    foreach (var lensId in photographer.Lenses)
                    {
                        var lens = context.Lenses.Find(lensId);

                        if (CheckIfLensExists(context, lensId))
                        {
                            PhotographerEntity.Lenses.Add(lens);
                        }
                    }

                    Console.WriteLine($"Successfully imported {PhotographerEntity.FirstName} {PhotographerEntity.LastName} | Lenses: {PhotographerEntity.Lenses.Count}");
                    context.Photographers.Add(PhotographerEntity);
                }

                context.SaveChanges();
            }
        }

        private static bool CheckIfLensExists(PhotoContext context, int lens)
        {
            var result = context.Lenses.Any(a => a.Id == lens);

            return result;
        }

        private static void ImportCameras()
        {
            PhotoContext context = new PhotoContext();
            var json = File.ReadAllText(ImportCamerasPath);
            var cameras = JsonConvert.DeserializeObject<IEnumerable<ImportCameraDto>>(json);

            foreach (var camera in cameras)
            {
                if (camera.Type == null || camera.Make == null || camera.Model == null /*|| camera.MinISO == null*/)
                {
                    Console.WriteLine("Error. Invalid data provided");
                }
                else
                {
                    if (camera.Type == "DSLR")
                    {
                        var DslrCamera = new DslrCamera
                        {
                            Make = camera.Make,
                            Model = camera.Model,
                            IsFullFrame = camera.IsFullFrame,
                            MinIso = camera.MinISO,
                            MaxIso = camera.MaxISO,
                            MaxShutterSpeed = camera.MaxShutterSpeed
                        };

                        context.Cameras.Add(DslrCamera);
                        Console.WriteLine($"Successfully imported DSLR {DslrCamera.Make} {DslrCamera.Model}");
                    }
                    else if (camera.Type == "Mirrorless")
                    {
                        var MirrorlessCamera = new MirrorlessCamera
                        {
                            Make = camera.Make,
                            Model = camera.Model,
                            IsFullFrame = camera.IsFullFrame,
                            MinIso = camera.MinISO,
                            MaxIso = camera.MaxISO,
                            MaxVidoeResolution = camera.MaxVideoResolution,
                            MaxFrameRate = camera.MaxFrameRate
                        };

                        context.Cameras.Add(MirrorlessCamera);
                        Console.WriteLine($"Successfully imported Mirrorless {MirrorlessCamera.Make} {MirrorlessCamera.Model}");
                    }
                }
            }

            context.SaveChanges();
        }

        private static void ImportLenses()
        {
            PhotoContext context = new PhotoContext();
            var json = File.ReadAllText(ImportLensesPath);
            var lenses = JsonConvert.DeserializeObject<IEnumerable<ImportLensesDto>>(json);

            foreach (var lens in lenses)
            {
                var lensEntity = new Lens
                {
                    Make = lens.Make,
                    FocalLength = lens.FocalLength,
                    MaxAperture = lens.MaxAperture,
                    CompatibleWith = lens.CompatibleWith
                };

                context.Lenses.Add(lensEntity);
                Console.WriteLine($"Successfully imported {lensEntity.Make} {lensEntity.FocalLength}mm f{lensEntity.MaxAperture}");
            }

            context.SaveChanges();
        }

        private static Camera GetRandomCamera(PhotoContext context)
        {
            Random r = new Random();
            var cameraCount = context.Cameras.Count() + 1;
            var result = context.Cameras.Find(r.Next(1, cameraCount));

            return result;
        }
    }
}
