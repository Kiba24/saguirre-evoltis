using System.Text.Json.Serialization;

namespace Application.User.Dto
{
    public class UserGetMeDto : UserUpdateDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        
    }
}
