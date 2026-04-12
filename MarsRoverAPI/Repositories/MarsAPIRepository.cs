using MarsRoverAPI.Models;

namespace MarsRoverAPI.Repositories
{
    public class MarsAPIRepository : IMarsAPIRepository
    {
        private readonly string _marsRoverBaseUrl;

        public MarsAPIRepository(string MarsRoverBaseUrl)
        {
            _marsRoverBaseUrl = MarsRoverBaseUrl;
        }

        public async Task<Root> GetMarsAPIDataAsync(string apiPath, int sol, int? page = null, int? per_page = null)
        {
            try 
            {
                using HttpClient client = new HttpClient();

                var queryString = string.Empty;

                var queryParams = new List<string> { $"sol={sol}" };

                if (page.HasValue || per_page.HasValue)
                {
                    if (page.HasValue)
                        queryParams.Add($"page={page.Value}");
                    if (per_page.HasValue)
                        queryParams.Add($"per_page={per_page.Value}");
                }
                
                queryString = "&" + string.Join("&", queryParams);

                return await client.GetFromJsonAsync<Root>(_marsRoverBaseUrl + apiPath + queryString) ?? throw new Exception();
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while fetching data from the MarsRover Rover API.", ex);
            }     
        }
    }
}