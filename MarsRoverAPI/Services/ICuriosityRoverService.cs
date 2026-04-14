using MarsRoverAPI.Models.CuriosityRover;

namespace MarsRoverAPI.Services
{
    public interface ICuriosityRoverService
    {
        public Task<Root> GetCuriosityRoverDataAsync(int? sol = null, string? earthDate = null, bool? latest = null, int? page = null, int? perPage = null);
        public Task<IEnumerable<string>> GetCuriosityRoverImagesAsync(int? sol = null, string? earthDate = null, bool? latest = null, string? size = null, int? page = null, int? perPage = null);
        public Task<string> GetRandomCuriosityRoverImageAsync(string? size = null);

    }
}