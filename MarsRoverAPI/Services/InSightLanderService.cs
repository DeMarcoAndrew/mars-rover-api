using MarsRoverAPI.Calculators;
using MarsRoverAPI.Models.InSightLander;
using MarsRoverAPI.Repositories;

namespace MarsRoverAPI.Services
{
    public class InSightLanderService : IInSightLanderService
    {
        private IMarsAPIRepository<Root> _marsAPIRepository;

        public InSightLanderService(IMarsAPIRepository<Root> marsAPIRepository)
        {
            _marsAPIRepository = marsAPIRepository;
        }

        public async Task<Root> GetInSightLanderDataAsync(int? sol = null, string? earthDate = null, int? page = null, int? perPage = null, string? camera = null)
        {
            DateTime? dtEarthDate = null;

            if (!string.IsNullOrWhiteSpace(earthDate))
            {
                dtEarthDate = DateTime.ParseExact(earthDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            }

            if (!sol.HasValue && dtEarthDate.HasValue)
            {
                sol = (int)DateCalculator.CalculateInSightSol(dtEarthDate.Value);
            }

            return await _marsAPIRepository.GetMarsAPIDataAsync(MarsAPIConstants.InSightLanderPath, sol, page, perPage, camera);
        }

        public async Task<IEnumerable<string>> GetInSightLanderImagesAsync(int? sol = null, string? earthDate = null, int? page = null, int? perPage = null, string? camera = null)
        {
            var result = await GetInSightLanderDataAsync(sol, earthDate, page, perPage, camera);

            if (result != null && result.Items != null)
            {
                return result.Items
                    .Select(item => item?.HttpsUrl)
                    .Where(imageUrl => imageUrl != null)
                    .ToList();
            }
            else
            {
                return [];
            }
        }
    }
}
