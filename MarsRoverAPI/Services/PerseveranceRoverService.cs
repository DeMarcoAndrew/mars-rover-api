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

        public async Task<Root> GetPerseveranceRoverDataAsync(string apiPath, int? sol = null, int? page = null, int? per_page = null)
        {
            if (!sol.HasValue)
            {
                throw new ArgumentNullException(nameof(sol), "The 'sol' parameter is required for Perseverance rover requests.");
            }

            return await _marsAPIRepository.GetMarsAPIDataAsync(apiPath, sol.Value, page, per_page);
        }
    }
}