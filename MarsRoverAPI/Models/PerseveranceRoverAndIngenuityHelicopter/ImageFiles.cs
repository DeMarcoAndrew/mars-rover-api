using System.Text.Json.Serialization;

namespace MarsRoverAPI.Models.PerseveranceRoverAndIngenuityHelicopter
{
    public class ImageFiles
    {
        [JsonPropertyName("medium")]
        public string? Medium { get; set; }

        [JsonPropertyName("small")]
        public string? Small { get; set; }

        [JsonPropertyName("full_res")]
        public string? FullRes { get; set; }
        
        [JsonPropertyName("large")]
        public string? Large { get; set; }
    }
}
