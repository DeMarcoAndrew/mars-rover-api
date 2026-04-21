using MarsRoverAPI.Calculators;
using MarsRoverAPI.Models.PerseveranceRoverAndIngenuityHelicopter;
using MarsRoverAPI.Repositories;

namespace MarsRoverAPI.Services
{
    public class PerseveranceRoverService : IPerseveranceRoverService
    {
        private IMarsAPIRepository<PerseveranceRoot> _marsAPIRepository;

        public PerseveranceRoverService(IMarsAPIRepository<PerseveranceRoot> marsAPIRepository)
        {
            _marsAPIRepository = marsAPIRepository;
        }

        public async Task<PerseveranceRoot> GetPerseveranceRoverDataAsync(int? sol = null, string? earthDate = null, bool? latest = null, int? page = null, int? perPage = null, string? camera = null)
        {
            DateTime? dtEarthDate = null;

            if (!string.IsNullOrWhiteSpace(earthDate))
            {
                dtEarthDate = DateTime.ParseExact(earthDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            }

            if (!sol.HasValue && dtEarthDate.HasValue)
            {
                sol = (int)DateCalculator.CalculatePerseveranceSol(dtEarthDate.Value);
            }
            else if (!sol.HasValue && latest.HasValue && latest == true)
            {
                var latestData = await _marsAPIRepository.GetLatestPerseveranceRoverSolsAsync();
                if (latestData != null && latestData.LatestSols != null && latestData.LatestSols.Count > 0)
                {
                    sol = latestData.LatestSols.Max();
                }
            }

            return await _marsAPIRepository.GetMarsAPIDataAsync(MarsAPIConstants.PerseveranceRoverPath, sol, page, perPage, camera);
        }

        public async Task<IEnumerable<string>> GetPerseveranceRoverImagesAsync(int? sol = null, string? earthDate = null, bool? latest = null, string? size = null, int? page = null, int? perPage = null, string? camera = null)
        {
            var result = await GetPerseveranceRoverDataAsync(sol, earthDate, latest, page, perPage, camera);

            if (result != null && result.Images != null)
            {
                var validResults = result.Images
                    .Where(p => p != null && p.ImageFiles != null && p.ImageFiles.Small != null && p.ImageFiles.Medium != null && p.ImageFiles.Large != null && p.ImageFiles.FullRes != null)
                    .Select(p => p?.ImageFiles)
                    .ToList();

                var imagesOnlyResult = size?.ToLower() switch
                {
                    "small" => validResults.Select(img => img?.Small).OfType<string>().ToList(),
                    "medium" => validResults.Select(img => img?.Small).OfType<string>().ToList(),
                    "large" => validResults.Select(img => img?.Small).OfType<string>().ToList(),
                    _ => validResults.Select(img => img?.Small).OfType<string>().ToList()
                };

                return imagesOnlyResult;
            }
            else
            {
                return [];
            }
        
        }
    }
}