using System.Text.Json.Serialization;

namespace MarsRoverAPI.ModelBase.Models
{
    public class CameraBase
    {
        [JsonPropertyName("filter_name")]
        public string? FilterName { get; set; }

        [JsonPropertyName("camera_model_component_list")]
        public string? CameraModelComponentList { get; set; }

        [JsonPropertyName("instrument")]
        public string? Instrument { get; set; }

        [JsonPropertyName("camera_model_type")]
        public string? CameraModelType { get; set; }
    }
}
