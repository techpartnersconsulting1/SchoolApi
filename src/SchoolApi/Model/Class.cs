using Newtonsoft.Json;

namespace School.Api.School.Model
{
    public class ClassDto
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("isActive")]
        public string IsActive { get; set; } = string.Empty;

        [JsonProperty("teacherId")]
        public string TeacherId { get; set; } = string.Empty;

        [JsonProperty("class")]
        public string Class { get; set; } = string.Empty;
    }
}