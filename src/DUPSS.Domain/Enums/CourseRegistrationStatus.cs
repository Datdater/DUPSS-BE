
namespace DUPSS.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CourseRegistrationStatus
    {
        [EnumMember(Value = "Purchased")]
        Purchased,

        [EnumMember(Value = "Completed")]
        Completed,

        [EnumMember(Value = "InProgress")]
        InProgress,
    }
}