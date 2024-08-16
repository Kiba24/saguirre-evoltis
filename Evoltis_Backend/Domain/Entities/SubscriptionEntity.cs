using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ThirdParty.Json.LitJson;

namespace Domain.Entities
{
    public class SubscriptionEntity : BaseEntity
    {
        [JsonPropertyName("plan_name")]
        public string PlanName { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("end_date")]
        public DateTime? EndDate { get; set; }

        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonIgnore]
        public UserEntity User { get; set; }
    }
}
