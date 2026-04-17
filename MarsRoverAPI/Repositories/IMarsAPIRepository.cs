using MarsRoverAPI.Models.CuriosityRover;
using MarsRoverAPI.Models.PerseveranceRover;

namespace MarsRoverAPI.Repositories
{
    public interface IMarsAPIRepository<T> where T : new()
    {
        public Task<T> GetMarsAPIDataAsync(string apiPath, int? sol, int? page = null, int? per_page = null, string? camera = null);

        public Task<Models.CuriosityRover.LatestDataRoot> GetLatestCuriosityRoverSolsAsync();

        public Task<Models.PerseveranceRover.LatestDataRoot> GetLatestPerseveranceRoverSolsAsync();

    }
}