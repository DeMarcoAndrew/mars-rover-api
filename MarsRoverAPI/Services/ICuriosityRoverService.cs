using MarsRoverAPI.Models.CuriosityRover;

namespace MarsRoverAPI.Services
{
    public interface ICuriosityRoverService
    {
        public Task<Root> GetCuriosityRoverDataAsync(string apiPath, int? sol = null, DateTime? earth_date = null, bool? latest = null, int? page = null, int? per_page = null);
    }
}