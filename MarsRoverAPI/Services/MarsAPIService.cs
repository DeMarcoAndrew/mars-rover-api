using MarsRoverAPI.Models;
using MarsRoverAPI.Repositories;

namespace MarsRoverAPI.Services
{
    public class MarsAPIService : IMarsAPIService
    {
        private IMarsAPIRepository _marsAPIRepository;

        public MarsAPIService(IMarsAPIRepository MarsAPIRepository)
        {
            _marsAPIRepository = MarsAPIRepository;
        }

        public async Task<Root> GetMarsAPIDataAsync(string apiPath, int? sol = null, int? page = null, int? per_page = null)
        {
            return await _marsAPIRepository.GetMarsAPIDataAsync(apiPath, sol, page, per_page);
        }
    }
}