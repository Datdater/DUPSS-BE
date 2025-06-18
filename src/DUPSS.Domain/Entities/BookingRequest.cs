using DUPSS.Domain.Commons;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Enums;

public class BookingRequest : BaseEntity
{
    public string BookingCode { get; set; }
    public string BookingFeedback { get; set; }
    public string CancelReason { get; set; }

    [Required]
    public string UrlMeeting { get; set; }

    public BookingStatus Status { get; set; }

    [ForeignKey("User")]
    public string UserId { get; set; }
    public AppUser? User { get; set; }

    [ForeignKey("Staff")]
    public string? StaffId { get; set; }
    public AppUser? Staff { get; set; }
}
