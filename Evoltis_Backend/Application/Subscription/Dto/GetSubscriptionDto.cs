using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Subscription.Dto
{
    public class GetSubscriptionDto : CreateSubscriptionDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
