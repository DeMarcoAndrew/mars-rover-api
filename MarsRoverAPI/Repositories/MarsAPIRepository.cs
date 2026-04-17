using MarsRoverAPI.Models.CuriosityRover;
using MarsRoverAPI.Models.PerseveranceRover;

namespace MarsRoverAPI.Repositories
{
    public class MarsAPIRepository<T> : IMarsAPIRepository<T> where T : new()
    {
        private readonly HttpClient _httpClient;

        public MarsAPIRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MarsAPI");
        }

        public async Task<T> GetMarsAPIDataAsync(string apiPath, int? sol, int? page = null, int? per_page = null, string? camera = null)
        {
            try
            {
                var queryString = string.Empty;
                
                var queryParams = new List<string>();

                bool isPerseveranceOrIngenuity = apiPath.Contains("category=mars2020", StringComparison.OrdinalIgnoreCase) || apiPath.Contains("category=ingenuity", StringComparison.OrdinalIgnoreCase);

                if (isPerseveranceOrIngenuity && sol.HasValue)
                {
                    queryParams.Add($"condition_2={sol}:sol:gte&condition_3={sol}:sol:lte&");

                    if (per_page.HasValue)
                    {
                        queryParams.Add($"num={per_page.Value}");
                        
                        queryParams.Add($"page={page ?? 0}");
                    }

                }
                else if (sol.HasValue)
                {
                    queryParams.Add($"condition_2={sol}%3Asol%3Agte&condition_3={sol}%3Asol%3Alte");
    
                    if (per_page.HasValue)
                    {
                        queryParams.Add($"per_page={per_page.Value}");
                        
                        queryParams.Add($"page={page ?? 0}");
                    }

                }

                if (!string.IsNullOrWhiteSpace(camera))
                {
                    queryParams.Add($"search={camera}");
                }

                queryString = "&" + string.Join("&", queryParams);

                return await _httpClient.GetFromJsonAsync<T>(apiPath + queryString) ?? throw new Exception();
            }
            catch (Exception)
            {
                return new T();
            }
        }

        public async Task<Models.CuriosityRover.LatestDataRoot> GetLatestCuriosityRoverSolsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Models.CuriosityRover.LatestDataRoot>(MarsAPIConstants.LatestCuriosityRoverSolsPath) ?? throw new Exception();
            }
            catch (Exception)
            {
                return new Models.CuriosityRover.LatestDataRoot();
            }
        }

        public async Task<Models.PerseveranceRover.LatestDataRoot> GetLatestPerseveranceRoverSolsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Models.PerseveranceRover.LatestDataRoot>(MarsAPIConstants.PerseveranceRoverPath) ?? throw new Exception();
            }
            catch (Exception)
            {
                return new Models.PerseveranceRover.LatestDataRoot();
            }
        }
    }
}