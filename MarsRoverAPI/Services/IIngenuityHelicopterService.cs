using MarsRoverAPI.Models.PerseveranceRoverAndIngenuityHelicopter;

namespace MarsRoverAPI.Services
{
    public interface IIngenuityHelicopterService
    {
        public Task<IngenuityRoot> GetIngenuityHelicopterDataAsync(int? sol = null, string? earthDate = null, bool? latest = null, int? page = null, int? perPage = null, string? camera = null);
        public Task<IEnumerable<string>> GetIngenuityHelicopterImagesAsync(int? sol = null, string? earthDate = null, bool? latest = null, string? size = null, int? page = null, int? perPage = null, string? camera = null);
    }
}