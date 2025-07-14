using DUPSS.Domain.Commons;

public class Notification : BaseEntity
{
    public string Content { get; set; }

    public bool IsRead { get; set; } = false;

    public string? ReturnUrl { get; set; }

    public string UserId { get; set; }
    public required AppUser User { get; set; }

    public string? FromUserId { get; set; }
    public AppUser? FromUser { get; set; }
}
