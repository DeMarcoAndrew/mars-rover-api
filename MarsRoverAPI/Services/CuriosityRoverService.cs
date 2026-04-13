using MarsRoverAPI.Calculators;
using MarsRoverAPI.Repositories;

namespace MarsRoverAPI.Services
{
    public class CuriosityRoverService : ICuriosityRoverService
    {
        private IMarsAPIRepository<Models.CuriosityRover.Root> _marsAPIRepository;

        public CuriosityRoverService(IMarsAPIRepository<Models.CuriosityRover.Root> marsAPIRepository)
        {
            _marsAPIRepository = marsAPIRepository;
        }

        public async Task<Models.CuriosityRover.Root> GetCuriosityRoverDataAsync(string apiPath, int? sol = null, DateTime? earth_date = null, bool? latest = null, int? page = null, int? per_page = null)
        {
            //Get a random sol date if all 3 params have no value
            if (!sol.HasValue && !earth_date.HasValue && !latest.HasValue)
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
            else if (!sol.HasValue && earth_date.HasValue)
            {
                sol = (int)DateCalculator.CalculateCuriositySol(earth_date.Value);
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

            return await _marsAPIRepository.GetMarsAPIDataAsync(apiPath, sol.Value, page, per_page);
        }
    }
}