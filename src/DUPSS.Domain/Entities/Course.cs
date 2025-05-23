using DUPSS.Domain.Commons;
using DUPSS.Domain.Entities;

public class Course : BaseEntity
{
    public required string CourseName { get; set; }
    public string? CourseCode { get; set; }

    public string? PictureURL { get; set; }

    public string? Summary { get; set; }

    public string? Content { get; set; }

    public string? Attachment { get; set; }

    [Column(TypeName = "money")]
    public decimal? Price { get; set; }

    [Column(TypeName = "money")]
    public decimal? OldPrice { get; set; }

    public bool Status { get; set; }

    public int? TotalDuration { get; set; }

    public int? TotalSection { get; set; }

    public int? TotalStep { get; set; }

    public string? CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public Category Category { get; set; }

    [ForeignKey("CreatedBy")]
    public AppUser Creator { get; set; }
}