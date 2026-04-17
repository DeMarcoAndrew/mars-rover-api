using MarsRoverAPI.Models.PerseveranceRoverAndIngenuityHelicopter;

namespace MarsRoverAPI.Services
{
    public interface IPerseveranceRoverService
    {
        public Task<PerseveranceRoot> GetPerseveranceRoverDataAsync(int? sol = null, string? earthDate = null, bool? latest = null, int? page = null, int? perPage = null, string? camera = null);
        public Task<IEnumerable<string>> GetPerseveranceRoverImagesAsync(int? sol = null, string? earthDate = null, bool? latest = null, string? size = null, int? page = null, int? perPage = null, string? camera = null);
    }
}