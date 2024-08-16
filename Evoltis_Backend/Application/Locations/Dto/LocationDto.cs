using System.Text.Json.Serialization;

namespace Application.Locations.Dto
{
    public class LocationDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nombre")]
        public string Name { get; set; }
    }
}
