using MarsRoverAPI.Models.PerseveranceRover;

namespace MarsRoverAPI.Services
{
    public interface IPerseveranceRoverService
    {
        public Task<Root> GetPerseveranceRoverDataAsync(string apiPath, int? sol = null, int? page = null, int? per_page = null);
    }
}