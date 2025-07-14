using DUPSS.Domain.Commons;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Enums;

public class BookingRequest : BaseEntity
{
    public DateTime BookingDate { get; set; }
    public string? BookingNote { get; set; }
    public required string BookingCode { get; set; }
    public string? BookingFeedback { get; set; }
    public string? CancelReason { get; set; }

    public string? UrlMeeting { get; set; }

    public BookingStatus Status { get; set; }

    [ForeignKey("User")]
    public required string UserId { get; set; }
    public AppUser? User { get; set; }

    [ForeignKey("Staff")]
    public string? StaffId { get; set; }
    public AppUser? Staff { get; set; }
}
