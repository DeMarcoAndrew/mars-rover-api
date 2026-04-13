using System.Text.Json.Serialization;

namespace MarsRoverAPI.Models.CuriosityRover
{
    public class LatestData
    {
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("latest")]
        public DateTime? Latest { get; set; }

        [JsonPropertyName("new_count")]
        public int? NewCount { get; set; }

        [JsonPropertyName("latest_sols")]
        public List<int?>? LatestSols { get; set; }

        [JsonPropertyName("latest_sol")]
        public int? LatestSol { get; set; }

        [JsonPropertyName("sol_count")]
        public int? SolCount { get; set; }
    }
    
}