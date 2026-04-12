using MarsRoverAPI.Models;

namespace MarsRoverAPI.Services
{
    public interface IMarsAPIService
    {
        public Task<Root> GetMarsAPIDataAsync(string apiPath, int? sol = null, int? page = null, int? per_page = null);
    }
}