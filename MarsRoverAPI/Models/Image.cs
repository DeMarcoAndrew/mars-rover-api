using System.Text.Json.Serialization;

namespace MarsRoverAPI.Models
{
    public class Image
    {
        [JsonPropertyName("sol")]
        public int? sol { get; set; }

        [JsonPropertyName("attitude")]
        public string? attitude { get; set; }

        [JsonPropertyName("image_files")]
        public ImageFiles? ImageFiles { get; set; }

        [JsonPropertyName("imageid")]
        public string? ImageId { get; set; }

        [JsonPropertyName("camera")]
        public Camera? Camera { get; set; }

        [JsonPropertyName("caption")]
        public string? Caption { get; set; }

        [JsonPropertyName("sample_type")]
        public string? SampleType { get; set; }

        [JsonPropertyName("date_taken_mars")]
        public string? DateTakenMars { get; set; }

        [JsonPropertyName("credit")]
        public string? Credit { get; set; }

        [JsonPropertyName("date_taken_utc")]
        public DateTime? DateTakenUtc { get; set; }

        [JsonPropertyName("json_link")]
        public string? JsonLink { get; set; }

        [JsonPropertyName("link")]
        public string? Link { get; set; }

        [JsonPropertyName("drive")]
        public string? Drive { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("site")]
        public string? Site { get; set; }

        [JsonPropertyName("date_received")]
        public DateTime? DateReceived { get; set; }
    }
}
