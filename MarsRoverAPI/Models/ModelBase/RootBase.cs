using System.Text.Json.Serialization;

namespace MarsRoverAPI.ModelBase.Models
{
    public class RootBase<T>
    {
        [JsonPropertyName("sol")]
        public int? Sol { get; set; }

        [JsonPropertyName("images")]
        public List<T?>? Images { get; set; }

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
