using Exam;
using Exam.Models;
using Exam.Models.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportJson
{
    class Startup
    {
        private const string ImportLensesPath = "../../Jsons/lenses.json";

        private const string ImportCamerasPath = "../../Jsons/cameras.json";

        static void Main()
        {
            ////ImportLenses();
            ////ImportCameras();

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
                    LocalLenght = lens.LocalLength,
                    MaxAperture = lens.MaxAperture,
                    CompatibleWith = lens.CompatibleWith
                };

                context.Lenses.Add(lensEntity);
                Console.WriteLine($"Successfully imported {lensEntity.Make} {lensEntity.LocalLenght}mm f{lensEntity.MaxAperture}");
            }

            context.SaveChanges();
        }
    }
}
