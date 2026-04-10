using MarsRoverAPI.Models;

namespace MarsRoverAPI.Repositories
{
    public interface ICuriosityRoverRepository
    {
        public Task<Root> GetCuriosityRoverDataAsync(int? sol = null, int? page = null, int? per_page = null);
    }
}