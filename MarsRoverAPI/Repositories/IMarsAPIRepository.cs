using MarsRoverAPI.Models;

namespace MarsRoverAPI.Repositories
{
    public interface IMarsAPIRepository
    {
        public Task<Root> GetMarsAPIDataAsync(string apiPath, int? sol = null, int? page = null, int? per_page = null);
    }
}