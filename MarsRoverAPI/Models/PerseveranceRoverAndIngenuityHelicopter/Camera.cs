using System.Text.Json.Serialization;

namespace MarsRoverAPI.Models.PerseveranceRoverAndIngenuityHelicopter
{
    public class Camera
    {
        [JsonPropertyName("filter_name")]
        public string? FilterName { get; set; }

        [JsonPropertyName("camera_vector")]
        public string? CameraVector { get; set; }

        [JsonPropertyName("camera_model_component_list")]
        public string? CameraModelComponentList { get; set; }

        [JsonPropertyName("camera_position")]
        public string? CameraPosition { get; set; }

        [JsonPropertyName("instrument")]
        public string? Instrument { get; set; }

        [JsonPropertyName("camera_model_type")]
        public string? CameraModelType { get; set; }
    }
}
