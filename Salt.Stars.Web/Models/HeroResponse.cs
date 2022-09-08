using System;
using System.Text.Json.Serialization;

namespace Salt.Stars.Web.Models
{
    public class HeroResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("Hero")]
        public Hero Hero { get; set; }
        [JsonPropertyName("RequestedAt")]
        public DateTime RequestedAt { get; set; }
    }
}