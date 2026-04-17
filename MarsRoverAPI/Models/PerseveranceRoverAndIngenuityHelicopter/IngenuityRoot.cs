using System.Text.Json.Serialization;

namespace MarsRoverAPI.Models.PerseveranceRoverAndIngenuityHelicopter
{
    public class IngenuityRoot
    {
        [JsonPropertyName("images")]
        public List<Image?>? Images { get; set; }

        [JsonPropertyName("per_page")]
        public string? PerPage { get; set; }

        [JsonPropertyName("total_results")]
        public int? TotalResults { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("page")]
        public int? Page { get; set; }

        [JsonPropertyName("mission")]
        public string? Mission { get; set; }

        [JsonPropertyName("total_images")]
        public int? TotalImages { get; set; }
    }
}
