using System.Text.Json;
using MarsRoverAPI.Models;

namespace MarsRoverAPI.Repositories
{
    public class CuriosityRoverRepository : ICuriosityRoverRepository
    {
        private readonly string _curiosityRoverBaseUrl;

        public CuriosityRoverRepository(string curiosityRoverBaseUrl)
        {
            _curiosityRoverBaseUrl = curiosityRoverBaseUrl;
        }

        public async Task<Root> GetCuriosityRoverDataAsync(int? sol = null, int? page = null, int? per_page = null)
        {
            try 
            {
                using HttpClient client = new HttpClient();

                var queryString = string.Empty;

                if (sol.HasValue || page.HasValue || per_page.HasValue)
                {
                    var queryParams = new List<string>();

                    if (sol.HasValue)
                        queryParams.Add($"sol={sol.Value}");
                    if (page.HasValue)
                        queryParams.Add($"page={page.Value}");
                    if (per_page.HasValue)
                        queryParams.Add($"per_page={per_page.Value}");

                    queryString = "&" + string.Join("&", queryParams);
                }

                return await client.GetFromJsonAsync<Root>(_curiosityRoverBaseUrl + queryString) ?? throw new Exception();
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while fetching data from the Curiosity Rover API.", ex);
            }     
        }
    }
}