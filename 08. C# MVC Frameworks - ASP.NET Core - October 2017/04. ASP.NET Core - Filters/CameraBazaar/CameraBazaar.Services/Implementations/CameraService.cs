﻿namespace CameraBazaar.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using CameraBazaar.Data;
    using CameraBazaar.Data.Models;
    using CameraBazaar.Data.Models.Enums;
    using CameraBazaar.Services.Contracts;
    using CameraBazaar.Services.Models.Cameras;

    public class CameraService : ICameraService
    {
        private readonly CameraBazaarDbContext db;

        public CameraService(CameraBazaarDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CameraBasicInfoModel> All()
        {
            var cameras = this.db.Cameras
                .Select(a => new CameraBasicInfoModel
                {
                    Id = a.Id,
                    Make = a.Make,
                    CameraModel = a.Model,
                    Price = a.Price,
                    Quantity = a.Quantity,
                    ImageUrl = a.ImageUrl
                }).ToList();

            return cameras;
        }

        public void Create(CameraMake make, string model, decimal price, int quantity, int minShutterSpeed, int maxShutterSpeed, CameraMinIso minIso, int maxIso, bool isFullFrame, string vdeoResolution, IEnumerable<LightMetering> lightMeterings, string description, string imageUrl, string userId)
        {
            Camera camera = new Camera
            {
                Make = make,
                Model = model,
                Price = price,
                Quantity = quantity,
                MinShutterSpeed = minShutterSpeed,
                MaxShutterSpeed = maxShutterSpeed,
                MinIso = minIso,
                MaxIso = maxIso,
                IsFullFrame = isFullFrame,
                VideoResolution = vdeoResolution,
                LightMetering = (LightMetering)lightMeterings.Cast<int>().Sum(),
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId
            };

            this.db.Cameras.Add(camera);
            this.db.SaveChanges();
        }

        public Camera GetCameraById(int id)
        {
            var camera = this.db.Cameras
                .FirstOrDefault(a => a.Id == id);

            camera.User = this.db.Users.FirstOrDefault(a => a.Id == camera.UserId);

            return camera;
        }
    }
}