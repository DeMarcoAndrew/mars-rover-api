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
                DateTime perseveranceLandDate = DateTime.Parse("2021-02-18T05:17:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind);

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

        public Task<IEnumerable<string>> GetPerseveranceRoverImagesAsync(int? sol = null, string? earthDate = null, bool? latest = null, string? size = null, int? page = null, int? perPage = null, string? camera = null)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRandomPerseveranceRoverImageAsync(string? size = null, string? camera = null)
        {
            throw new NotImplementedException();
        }
    }
}