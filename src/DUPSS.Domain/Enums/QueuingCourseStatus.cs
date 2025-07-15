namespace DUPSS.Domain.Enums;

public enum QueuingCourseStatus
{
    [EnumMember(Value = "Pending")]
    Pending,

    [EnumMember(Value = "Approved")]
    Approved,

    [EnumMember(Value = "Reject")]
    Reject,
}
