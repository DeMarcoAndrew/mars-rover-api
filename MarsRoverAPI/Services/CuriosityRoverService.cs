using MarsRoverAPI.Calculators;
using MarsRoverAPI.Models.CuriosityRover;
using MarsRoverAPI.Repositories;

namespace MarsRoverAPI.Services
{
    public class CuriosityRoverService : ICuriosityRoverService
    {
        private IMarsAPIRepository<Root> _marsAPIRepository;

        public CuriosityRoverService(IMarsAPIRepository<Root> marsAPIRepository)
        {
            _marsAPIRepository = marsAPIRepository;
        }

        public async Task<Root> GetCuriosityRoverDataAsync(int? sol = null, string? earthDate = null, bool? latest = null, int? page = null, int? perPage = null, string? camera = null)
        {
            DateTime? dtEarthDate = null;

            if (!string.IsNullOrWhiteSpace(earthDate))
            {
                dtEarthDate = DateTime.ParseExact(earthDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            }

            //Get a random sol date if all 3 params have no value
            if (!sol.HasValue && !dtEarthDate.HasValue && !latest.HasValue)
            {
                DateTime curiosityLandDate = DateTime.Parse("2012-08-06T05:17:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind);

                //As of 4/12/2026, Curiosity is still active. 
                //If it becomes inactive, the current date below will be replaced with the date of its last activity.  
                DateTime currentDate = DateTime.UtcNow;

                long dateRange = currentDate.Ticks - curiosityLandDate.Ticks;
                long randomTicks = (long)(Random.Shared.NextDouble() * dateRange);
                DateTime randomDate = new DateTime(curiosityLandDate.Ticks + randomTicks, DateTimeKind.Utc);

                sol = (int)DateCalculator.CalculateCuriositySol(randomDate);
            }
            else if (!sol.HasValue && dtEarthDate.HasValue)
            {
                sol = (int)DateCalculator.CalculateCuriositySol(dtEarthDate.Value);
            }
            else if (!sol.HasValue && latest.HasValue)
            {
                var latestData = await _marsAPIRepository.GetLatestCuriosityRoverSolsAsync();
                if (latestData != null && latestData.Success.HasValue && latestData.Success.Value
                    && latestData.LatestData?.LatestSols != null && latestData.LatestData.LatestSols.Count > 0)
                {
                    sol = latestData.LatestData.LatestSols.Max();
                }
            }

            if (!sol.HasValue)
            {
                throw new InvalidOperationException("Unable to determine 'sol' value for Curiosity rover request.");
            }

            return await _marsAPIRepository.GetMarsAPIDataAsync(MarsAPIConstants.CuriosityRoverPath, sol.Value, page, perPage, camera);
        }

        public async Task<IEnumerable<string>> GetCuriosityRoverImagesAsync(int? sol = null, string? earthDate = null, bool? latest = null, string? size = null, int? page = null, int? perPage = null, string? camera = null)
        {
            var result = await GetCuriosityRoverDataAsync(sol, earthDate, latest, page, perPage, camera);

            var imagesOnlyResult = size?.ToLower() switch
            {
                "small" => result.Images.Select(imgs => imgs.ImageFiles).Select(img => img.Small).ToList(),
                "medium" => result.Images.Select(imgs => imgs.ImageFiles).Select(img => img.Medium).ToList(),
                "large" => result.Images.Select(imgs => imgs.ImageFiles).Select(img => img.Large).ToList(),
                _ => result.Images.Select(imgs => imgs.ImageFiles).Select(img => img.FullRes).ToList()
            };
        
            return imagesOnlyResult;
        }
    
        public async Task<string> GetRandomCuriosityRoverImageAsync(int? sol = null, string? earthDate = null, bool? latest = null, string? size = null, int? page = null, int? perPage = null, string? camera = null)
        {
            var result = await GetCuriosityRoverImagesAsync(sol, earthDate, latest, size, page, perPage, camera);
            if (result != null && result.Any())
            {
                return result.ElementAt(Random.Shared.Next(result.Count()));
            }
            else
            {
                //if results for random sol above don't come back, 
                // we will grab data from sol 4857 which has images for all Curiosity's cameras
                var sol4857Result = await GetCuriosityRoverImagesAsync(sol: 4857, size: size, camera: camera);
                if (sol4857Result != null && sol4857Result.Any())
                {
                    return sol4857Result.ElementAt(Random.Shared.Next(sol4857Result.Count()));
                }
                else
                {
                    throw new InvalidOperationException("Error occurred while fetching random Curiosity rover image.");
                }
            }
        }
    }
}
