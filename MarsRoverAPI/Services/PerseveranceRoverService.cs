using MarsRoverAPI.Calculators;
using MarsRoverAPI.Models.PerseveranceRover;
using MarsRoverAPI.Repositories;

namespace MarsRoverAPI.Services
{
    public class PerseveranceRoverService : IPerseveranceRoverService
    {
        private IMarsAPIRepository<Root> _marsAPIRepository;

        public PerseveranceRoverService(IMarsAPIRepository<Root> marsAPIRepository)
        {
            _marsAPIRepository = marsAPIRepository;
        }

        public async Task<Root> GetPerseveranceRoverDataAsync(int? sol = null, string? earthDate = null, bool? latest = null, int? page = null, int? perPage = null, string? camera = null)
        {
            DateTime? dtEarthDate = null;

            if (!string.IsNullOrWhiteSpace(earthDate))
            {
                dtEarthDate = DateTime.ParseExact(earthDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            }

            //Get a random sol date if all 3 params have no value
            if (!sol.HasValue && !dtEarthDate.HasValue && !latest.HasValue)
            {
                DateTime perseveranceLandDate = DateTime.Parse("2021-02-18T17:55:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind);

                //As of 4/12/2026, Perseverance is still active. 
                //If it becomes inactive, the current date below will be replaced with the date of its last activity.  
                DateTime currentDate = DateTime.UtcNow;

                long dateRange = currentDate.Ticks - perseveranceLandDate.Ticks;
                long randomTicks = (long)(Random.Shared.NextDouble() * dateRange);
                DateTime randomDate = new DateTime(perseveranceLandDate.Ticks + randomTicks, DateTimeKind.Utc);

                sol = (int)DateCalculator.CalculatePerseveranceSol(randomDate);
            }
            else if (!sol.HasValue && dtEarthDate.HasValue)
            {
                sol = (int)DateCalculator.CalculatePerseveranceSol(dtEarthDate.Value);
            }
            else if (!sol.HasValue && latest.HasValue)
            {
                var latestData = await _marsAPIRepository.GetLatestPerseveranceRoverSolsAsync();
                if (latestData != null && latestData.Success.HasValue && latestData.Success.Value
                    && latestData.LatestData?.LatestSols != null && latestData.LatestData.LatestSols.Count > 0)
                {
                    sol = latestData.LatestData.LatestSols.Max();
                }
            }

            if (!sol.HasValue)
            {
                throw new InvalidOperationException("Unable to determine 'sol' value for Perseverance rover request.");
            }

            return await _marsAPIRepository.GetMarsAPIDataAsync(MarsAPIConstants.PerseveranceRoverPath, sol.Value, page, perPage, camera);
        }

        public async Task<IEnumerable<string>> GetPerseveranceRoverImagesAsync(int? sol = null, string? earthDate = null, bool? latest = null, string? size = null, int? page = null, int? perPage = null, string? camera = null)
        {
            var result = await GetPerseveranceRoverDataAsync(sol, earthDate, latest, page, perPage, camera);

            var imagesOnlyResult = size?.ToLower() switch
            {
                "small" => result.Images.Select(imgs => imgs.ImageFiles).Select(img => img.Small).ToList(),
                "medium" => result.Images.Select(imgs => imgs.ImageFiles).Select(img => img.Medium).ToList(),
                "large" => result.Images.Select(imgs => imgs.ImageFiles).Select(img => img.Large).ToList(),
                _ => result.Images.Select(imgs => imgs.ImageFiles).Select(img => img.FullRes).ToList()
            };
        
            return imagesOnlyResult;        
        }

        public async Task<IEnumerable<string>> GetPerseveranceRoverImagesAsync(string? size = null, string? camera = null)
        {
            var result = await GetPerseveranceRoverDataAsync(camera: camera);

            var imagesOnlyResult = size?.ToLower() switch
            {
                "small" => result.Images.Select(imgs => imgs.ImageFiles).Select(img => img.Small).ToList(),
                "medium" => result.Images.Select(imgs => imgs.ImageFiles).Select(img => img.Medium).ToList(),
                "large" => result.Images.Select(imgs => imgs.ImageFiles).Select(img => img.Large).ToList(),
                _ => result.Images.Select(imgs => imgs.ImageFiles).Select(img => img.FullRes).ToList()
            };
        
            return imagesOnlyResult;        
        }

        public async Task<string> GetRandomPerseveranceRoverImageAsync(string? size = null, string? camera = null)
        {
            var result = await GetPerseveranceRoverImagesAsync(size: size, camera: camera);
            if (result != null && result.Any())
            {
                return result.ElementAt(Random.Shared.Next(result.Count()));
            }
            else if ((result == null || !result.Any()) && !string.IsNullOrWhiteSpace(camera))
            {
                var randomCameraResult = await _marsAPIRepository.GetMarsAPIDataAsync(MarsAPIConstants.CuriosityRoverPath, camera: camera);
                if (randomCameraResult != null && randomCameraResult.Images != null && randomCameraResult.Images.Any())
                {
                    var randomIndex = Random.Shared.Next(randomCameraResult.Images.Count);

                    var randomCameraImage = randomCameraResult.Images[randomIndex].ImageFiles;

                    return randomCameraImage switch
                    {
                        { Small: not null } => randomCameraImage.Small,
                        { Medium: not null } => randomCameraImage.Medium,
                        { Large: not null } => randomCameraImage.Large,
                        { FullRes: not null } => randomCameraImage.FullRes,
                        _ => throw new InvalidOperationException("No valid image size found for the randomly selected camera image.")
                    };
                }
                else
                {
                    throw new InvalidOperationException("Error occurred while fetching random Perseverance rover image.");
                }
            }
            else
            {
                //we will grab data from sol 200 which has images if the random sol above doesn't come back with images
                var sol200Result = await GetPerseveranceRoverImagesAsync(sol: 200, size: size);

                if (sol200Result != null && sol200Result.Any())
                {
                    return sol200Result.ElementAt(Random.Shared.Next(sol200Result.Count()));
                }
                else
                {
                    throw new InvalidOperationException("Error occurred while fetching random Perseverance rover image.");
                }
            }
        }
    }
}