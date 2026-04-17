using System.Text.Json.Serialization;

namespace MarsRoverAPI.Models.InSightLander
{
    public class Item
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("camera_vector")]
        public string? CameraVector { get; set; }

        [JsonPropertyName("site")]
        public string? Site { get; set; }

        [JsonPropertyName("imageid")]
        public string? Imageid { get; set; }

        [JsonPropertyName("subframe_rect")]
        public string? SubframeRect { get; set; }

        [JsonPropertyName("sol")]
        public int? Sol { get; set; }

        [JsonPropertyName("scale_factor")]
        public int? ScaleFactor { get; set; }

        [JsonPropertyName("camera_model_component_list")]
        public string? CameraModelComponentList { get; set; }

        [JsonPropertyName("instrument")]
        public string? Instrument { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("spacecraft_clock")]
        public double? SpacecraftClock { get; set; }

        [JsonPropertyName("attitude")]
        public string? Attitude { get; set; }

        [JsonPropertyName("camera_position")]
        public string? CameraPosition { get; set; }

        [JsonPropertyName("camera_model_type")]
        public string? CameraModelType { get; set; }

        [JsonPropertyName("drive")]
        public string? Drive { get; set; }

        [JsonPropertyName("xyz")]
        public string? Xyz { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("mission")]
        public string? Mission { get; set; }

        [JsonPropertyName("extended")]
        public Extended? Extended { get; set; }

        [JsonPropertyName("date_taken")]
        public DateTime? DateTaken { get; set; }

        [JsonPropertyName("date_received")]
        public DateTime? DateReceived { get; set; }

        [JsonPropertyName("instrument_sort")]
        public int? InstrumentSort { get; set; }

        [JsonPropertyName("sample_type_sort")]
        public int? SampleTypeSort { get; set; }

        [JsonPropertyName("is_thumbnail")]
        public bool? IsThumbnail { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("link")]
        public string? Link { get; set; }

        [JsonPropertyName("image_credit")]
        public string? ImageCredit { get; set; }

        [JsonPropertyName("https_url")]
        public string? HttpsUrl { get; set; }
    }
}
