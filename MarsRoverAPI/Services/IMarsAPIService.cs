using MarsRoverAPI.Models;

namespace MarsRoverAPI.Services
{
    public interface IMarsAPIService
    {
        public Task<Root> GetCuriosityRoverDataAsync(string apiPath, int? sol = null, int? page = null, int? per_page = null);
    }
}