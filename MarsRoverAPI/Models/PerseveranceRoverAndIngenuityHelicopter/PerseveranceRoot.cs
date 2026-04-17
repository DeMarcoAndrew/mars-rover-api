using System.Text.Json.Serialization;

namespace MarsRoverAPI.Models.PerseveranceRoverAndIngenuityHelicopter
{
    public class PerseveranceRoot
    {
        [JsonPropertyName("sol")]
        public int? Sol { get; set; }

        [JsonPropertyName("images")]
        public List<Image?>? Images { get; set; }

        [JsonPropertyName("num_images")]
        public int? NumImages { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("most_recent")]
        public DateTime? MostRecent { get; set; }

        [JsonPropertyName("mission")]
        public string? Mission { get; set; }
    }
}
