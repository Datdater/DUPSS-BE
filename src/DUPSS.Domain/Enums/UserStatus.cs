using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DUPSS.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,

        [EnumMember(Value = "Approved")]
        Approved,

        [EnumMember(Value = "Banned")]
        Banned,

        [EnumMember(Value = "Closed")]
        Closed,
    }
}
