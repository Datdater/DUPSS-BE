using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DUPSS.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BookingStatus
{
    [EnumMember(Value = "Pending")]
    Pending,

    [EnumMember(Value = "Approved")]
    Approved,

    [EnumMember(Value = "Completed")]
    Completed,

    [EnumMember(Value = "Cancelled")]
    Cancelled,
}
