namespace MarsRoverAPI.Repositories
{
    public class MarsAPIRepository<T> : IMarsAPIRepository<T> where T : class
    {
        private readonly HttpClient _httpClient;

        public MarsAPIRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetMarsAPIDataAsync(string apiPath, int sol, int? page = null, int? per_page = null)
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
                
                queryString = "&" + string.Join("&", queryParams);

                return await _httpClient.GetFromJsonAsync<T>(apiPath + queryString) ?? throw new Exception();
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while fetching data from the MarsRover Rover API.", ex);
            }     
        }
    }
}