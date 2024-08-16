
using System.Text.Json.Serialization;

namespace Application.User.Dto
{
    public class UserUpdateDto
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        [JsonPropertyName("location_id")]
        public int LocationId { get; set; }
    }
}
