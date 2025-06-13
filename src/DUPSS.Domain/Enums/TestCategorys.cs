using System.Text.Json.Serialization;

namespace DUPSS.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TestCategory
    {
        Survey,
        ASSIS,
        CRAFFT,
    }
}
