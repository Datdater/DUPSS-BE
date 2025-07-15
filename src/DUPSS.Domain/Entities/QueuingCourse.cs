using DUPSS.Domain.Commons;

namespace DUPSS.Domain.Entities;

public class QueuingCourse : BaseEntity
{
    public string CourseCode { get; set; }
    public string CourseName { get; set; }
    public string PictureUrl { get; set; }
    public string Summary { get; set; }
    public string Content { get; set; }
    public double Price { get; set; }
    public double OldPrice { get; set; }
    public string AttachmentUrl { get; set; }
    public int TotalDuration { get; set; }
    public int TotalSection { get; set; }
    public int TotalStep { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    //navigation
    [ForeignKey("User")]
    public string? CreatedBy { get; set; }
    public virtual AppUser? User { get; set; }

    [ForeignKey("Category")]
    public string CategoryId { get; set; }
    public virtual Category? Category { get; set; }

    public virtual required ICollection<QueuingCourseSection> QueuingCourseSections { get; set; }
    public virtual ICollection<Reason>? Reasons { get; set; }
}
