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

    public void ApproveBooking(string staffId, string? meetingUrl = null)
    {
        if (Status != BookingStatus.Pending)
            throw new InvalidOperationException("Only pending bookings can be approved.");

        StaffId = staffId;
        Status = BookingStatus.Approved;
        UrlMeeting = meetingUrl;
    }

    public void CompleteBooking(string? feedback = null)
    {
        if (Status != BookingStatus.Approved)
            throw new InvalidOperationException("Only approved bookings can be completed.");

        Status = BookingStatus.Completed;
        BookingFeedback = feedback;
    }

    public void CancelBooking(string cancelReason)
    {
        if (Status == BookingStatus.Completed)
            throw new InvalidOperationException("Completed bookings cannot be cancelled.");

        Status = BookingStatus.Cancelled;
        CancelReason = cancelReason;
    }

    public void SetPendingStatus()
    {
        Status = BookingStatus.Pending;
        StaffId = null;
        UrlMeeting = null;
        CancelReason = null;
        BookingFeedback = null;
    }
}
