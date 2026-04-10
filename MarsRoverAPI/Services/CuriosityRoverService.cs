using MarsRoverAPI.Models;
using MarsRoverAPI.Repositories;

namespace MarsRoverAPI.Services
{
    public class CuriosityRoverService : ICuriosityRoverService
    {
        private ICuriosityRoverRepository _curiosityRoverRepository;

        public CuriosityRoverService(ICuriosityRoverRepository curiosityRoverRepository)
        {
            _curiosityRoverRepository = curiosityRoverRepository;
        }

        public async Task<Root> GetCuriosityRoverDataAsync(int? sol = null, int? page = null, int? per_page = null)
        {
            return await _curiosityRoverRepository.GetCuriosityRoverDataAsync(sol, page, per_page);
        }
    }
}