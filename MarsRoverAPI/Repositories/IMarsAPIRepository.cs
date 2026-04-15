using MarsRoverAPI.Models.CuriosityRover;

namespace MarsRoverAPI.Repositories
{
    public interface IMarsAPIRepository<T> where T : class
    {
        public Task<T> GetMarsAPIDataAsync(string apiPath, int sol, int? page = null, int? per_page = null, string? camera = null);

        public Task<LatestDataRoot> GetLatestCuriosityRoverSolsAsync();

        public Task<LatestDataRoot> GetLatestPerseveranceRoverSolsAsync();

    }
}