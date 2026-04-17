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

            if (!sol.HasValue && dtEarthDate.HasValue)
            {
                sol = (int)DateCalculator.CalculateCuriositySol(dtEarthDate.Value);
            }
            else if (!sol.HasValue && latest.HasValue && latest == true)
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
