
using System.Text.Json.Serialization;

namespace MarsRoverAPI.Models.CuriosityRover
{
    public class Extended
    {
        [JsonPropertyName("lmst")]
        public string? Lmst { get; set; }

        [JsonPropertyName("bucket")]
        public string? Bucket { get; set; }

        [JsonPropertyName("mast_az")]
        public string? MastAz { get; set; }

        [JsonPropertyName("mast_el")]
        public string? MastEl { get; set; }

        [JsonPropertyName("url_list")]
        public string? UrlList { get; set; }

        [JsonPropertyName("contributor")]
        public string? Contributor { get; set; }

        [JsonPropertyName("filter_name")]
        public string? FilterName { get; set; }

        [JsonPropertyName("sample_type")]
        public string? SampleType { get; set; }
    }
}
