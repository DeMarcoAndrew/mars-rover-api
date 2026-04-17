using System.Text.Json.Serialization;

namespace MarsRoverAPI.Models.CuriosityRover
{
     public class Root
    {
        [JsonPropertyName("Items")]
        public List<Item?>? Items { get; set; }

        [JsonPropertyName("more")]
        public bool? More { get; set; }

        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("page")]
        public int? Page { get; set; }

        [JsonPropertyName("per_page")]
        public int? PerPage { get; set; }
    }
}
