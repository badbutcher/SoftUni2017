namespace CameraBazaar.Services.Contracts
{
    using System.Collections.Generic;
    using CameraBazaar.Data.Models.Enums;

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
    }
}