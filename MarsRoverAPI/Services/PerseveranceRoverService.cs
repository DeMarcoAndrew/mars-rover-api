using MarsRoverAPI.Repositories;

namespace MarsRoverAPI.Services
{
    public class PerseveranceRoverService : IPerseveranceRoverService
    {
        private IMarsAPIRepository<PerseveranceRover.Models.Root> _marsAPIRepository;

        public PerseveranceRoverService(IMarsAPIRepository<PerseveranceRover.Models.Root> marsAPIRepository)
        {
            _marsAPIRepository = marsAPIRepository;
        }

        public async Task<PerseveranceRover.Models.Root> GetCuriosityRoverDataAsync(string apiPath, int? sol = null, int? page = null, int? per_page = null)
        {
            return await _marsAPIRepository.GetMarsAPIDataAsync(apiPath, sol.Value, page, per_page);
        }
    }
}