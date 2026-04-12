using MarsRoverAPI.Calculators;
using MarsRoverAPI.Repositories;

namespace MarsRoverAPI.Services
{
    public class CuriosityRoverService : ICuriosityRoverService
    {
        private IMarsAPIRepository<CuriosityRover.Models.Root> _marsAPIRepository;

        public CuriosityRoverService(IMarsAPIRepository<CuriosityRover.Models.Root> marsAPIRepository)
        {
            _marsAPIRepository = marsAPIRepository;
        }

        public async Task<CuriosityRover.Models.Root> GetCuriosityRoverDataAsync(string apiPath, int? sol = null, int? page = null, int? per_page = null)
        {
            if (!sol.HasValue)
            {
                DateTime curiosityLandDate = DateTime.Parse("2012-08-06T05:17:00Z", null, System.Globalization.DateTimeStyles.RoundtripKind);

                //As of 4/12/2026, Curiosity is still active. 
                //If it becomes inactive, the current date below will be replaced with the date of its last activity.  
                DateTime currentDate = DateTime.UtcNow;

                long dateRange = currentDate.Ticks - curiosityLandDate.Ticks;
                long randomTicks = (long)(Random.Shared.NextDouble() * dateRange);
                DateTime randomDate = new DateTime(curiosityLandDate.Ticks + randomTicks, DateTimeKind.Utc);

                var marsSolDate = DateCalculator.GetMarsSolDate(randomDate);

                sol = (int)Math.Floor(marsSolDate);
            }
            return await _marsAPIRepository.GetMarsAPIDataAsync(apiPath, sol.Value, page, per_page);
        }
    }
}