using System.Text.Json.Serialization;

namespace DUPSS.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SeverityLevel
    {
        Low,
        Medium,
        High,
        Critical
    }
}
