using Domain.Entities;
using System.Text.Json.Serialization;

namespace Application.User.Dto
{
    public class UserCreateDto
    {
        [JsonPropertyName("name")]

        public string? Name { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }
        [JsonPropertyName("email")]

        public string Email { get; set; }

        [JsonPropertyName("location_id")]
        public int LocationId {  get; set; }

    }
}
