namespace MarsRoverAPI.Services
{
    public interface ICuriosityRoverService
    {
        public Task<CuriosityRover.Models.Root> GetCuriosityRoverDataAsync(string apiPath, int? sol = null, int? page = null, int? per_page = null);
    }
}