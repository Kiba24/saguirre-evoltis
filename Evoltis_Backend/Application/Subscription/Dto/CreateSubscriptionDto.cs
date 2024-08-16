using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Subscription.Dto
{
    public class CreateSubscriptionDto
    {
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("plan_name")]
        public string PlanName { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [JsonPropertyName("end_date")]
        public DateTime? EndDate { get; set; }

    }
}
