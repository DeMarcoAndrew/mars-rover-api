using System.Text.Json.Serialization;

namespace MarsRoverAPI.Models.PerseveranceRoverAndIngenuityHelicopter
{
    public class LatestDataRoot
    {
        [JsonPropertyName("latest")]
        public DateTime? Latest { get; set; }

        [JsonPropertyName("new_count")]
        public int? NewCount { get; set; }

        [JsonPropertyName("sol_count")]
        public int? SolCount { get; set; }

        [JsonPropertyName("latest_sols")]
        public List<int?>? LatestSols { get; set; }

        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("latest_sol")]
        public int? LatestSol { get; set; }
    }
}