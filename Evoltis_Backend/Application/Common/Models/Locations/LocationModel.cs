using System.Text.Json.Serialization;

namespace Application.Common.Models.Locations
{
    public class LocationModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nombre")]
        public string Name { get; set; }

        [JsonPropertyName("ciudades")]
        public List<City> Cities { get; set; }

    }

    public class City
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName ("nombre")]
        public string Name { get; set; }

    }
}
