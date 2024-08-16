using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json.Serialization;

namespace Application.Common.Models
{
    public class ResponseObjectJsonDto
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("response")]
        public object Response { get; set; }
        [JsonPropertyName("status_code")]
        public int StatusCode { get; set; }
    }
}
