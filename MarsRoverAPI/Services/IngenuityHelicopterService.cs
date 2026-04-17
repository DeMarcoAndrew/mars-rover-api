using MarsRoverAPI.Calculators;
using MarsRoverAPI.Models.PerseveranceRoverAndIngenuityHelicopter;
using MarsRoverAPI.Repositories;

namespace MarsRoverAPI.Services
{
    public class IngenuityHelicopterService : IIngenuityHelicopterService
    {
        private IMarsAPIRepository<IngenuityRoot> _marsAPIRepository;

        public IngenuityHelicopterService(IMarsAPIRepository<IngenuityRoot> marsAPIRepository)
        {
            _marsAPIRepository = marsAPIRepository;
        }

        public async Task<IngenuityRoot> GetIngenuityHelicopterDataAsync(int? sol = null, string? earthDate = null, int? page = null, int? perPage = null, string? camera = null)
        {
            DateTime? dtEarthDate = null;

            if (!string.IsNullOrWhiteSpace(earthDate))
            {
                dtEarthDate = DateTime.ParseExact(earthDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            }

            if (!sol.HasValue && dtEarthDate.HasValue)
            {
                sol = (int)DateCalculator.CalculateIngenuitySol(dtEarthDate.Value);
            }

            return await _marsAPIRepository.GetMarsAPIDataAsync(MarsAPIConstants.IngenuityHelicopterPath, sol.Value, page, perPage, camera);
        }

        public async Task<IEnumerable<string>> GetIngenuityHelicopterImagesAsync(int? sol = null, string? earthDate = null, string? size = null, int? page = null, int? perPage = null, string? camera = null)
        {
            var result = await GetIngenuityHelicopterDataAsync(sol, earthDate, page, perPage, camera);

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