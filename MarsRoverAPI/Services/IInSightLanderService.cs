using MarsRoverAPI.Models.InSightLander;

namespace MarsRoverAPI.Services
{
    public interface IInSightLanderService
    {
        public Task<Root> GetInSightLanderDataAsync(int? sol = null, string? earthDate = null, int? page = null, int? perPage = null, string? camera = null);
        public Task<IEnumerable<string>> GetInSightLanderImagesAsync(int? sol = null, string? earthDate = null, int? page = null, int? perPage = null, string? camera = null);
    }
}