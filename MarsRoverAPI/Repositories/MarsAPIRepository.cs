using MarsRoverAPI.Models.CuriosityRover;
using MarsRoverAPI.Models.PerseveranceRover;

namespace MarsRoverAPI.Repositories
{
    public class MarsAPIRepository<T> : IMarsAPIRepository<T> where T : class
    {
        private readonly HttpClient _httpClient;

        public MarsAPIRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MarsAPI");
        }

        public async Task<T> GetMarsAPIDataAsync(string apiPath, int sol, int? page = null, int? per_page = null, string? camera = null)
        {
            try
            {
                var queryString = string.Empty;

                var queryParams = new List<string> { $"sol={sol}" };

                if (page.HasValue || per_page.HasValue)
                {
                    if (page.HasValue)
                        queryParams.Add($"page={page.Value}");
                    if (per_page.HasValue)
                        queryParams.Add($"per_page={per_page.Value}");
                }

                if (!string.IsNullOrWhiteSpace(camera))
                {
                    queryParams.Add($"search={camera}");
                }

                queryString = "&" + string.Join("&", queryParams);

                return await _httpClient.GetFromJsonAsync<T>(apiPath + queryString) ?? throw new Exception();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        public async Task<T> GetMarsAPIDataAsync(string apiPath, string? camera = null)
        {
            try
            {
                var queryString = string.Empty;

                if (!string.IsNullOrWhiteSpace(camera))
                {
                    queryString = $"&search={camera}";
                }

                return await _httpClient.GetFromJsonAsync<T>(apiPath + queryString) ?? throw new Exception();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        public async Task<Models.CuriosityRover.LatestDataRoot> GetLatestCuriosityRoverSolsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Models.CuriosityRover.LatestDataRoot>(MarsAPIConstants.LatestCuriosityRoverSolsPath) ?? throw new Exception();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        public async Task<Models.PerseveranceRover.LatestDataRoot> GetLatestPerseveranceRoverSolsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Models.PerseveranceRover.LatestDataRoot>(MarsAPIConstants.PerseveranceRoverPath + "?latest=true") ?? throw new Exception();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }
    }
}