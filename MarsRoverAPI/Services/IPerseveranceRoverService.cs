namespace MarsRoverAPI.Services
{
    public interface IPerseveranceRoverService
    {
        public Task<PerseveranceRover.Models.Root> GetPerseveranceRoverDataAsync(string apiPath, int? sol = null, int? page = null, int? per_page = null);
    }
}