namespace CameraBazaar.Services.Contracts
{
    using System.Collections.Generic;
    using CameraBazaar.Data.Models;
    using CameraBazaar.Data.Models.Enums;
    using CameraBazaar.Services.Models.Cameras;

    public interface ICameraService
    {
        void Create(
            CameraMake make,
            string model,
            decimal price,
            int quantity,
            int minShutterSpeed,
            int maxShutterSpeed,
            CameraMinIso minIso,
            int maxIso,
            bool isFullFrame,
            string vdeoResolution,
            IEnumerable<LightMetering> lightMeterings,
            string description,
            string imageUrl,
            string userId);

        IEnumerable<CameraBasicInfoModel> All();

        Camera GetCameraById(int id);

        bool Edit(
            int id,
            CameraMake make,
            string model,
            decimal price,
            int quantity,
            int minShutterSpeed,
            int maxShutterSpeed,
            CameraMinIso minIso,
            int maxIso,
            bool isFullFrame,
            string vdeoResolution,
            IEnumerable<LightMetering> lightMeterings,
            string description,
            string imageUrl,
            string userId);

        bool CameraExists(int id, string userId);
    }
}