using MarsRoverAPI.Models;

namespace MarsRoverAPI.Services
{
    public interface ICuriosityRoverService
    {
        public Task<Root> GetCuriosityRoverDataAsync(int? sol = null, int? page = null, int? per_page = null);
    }
}