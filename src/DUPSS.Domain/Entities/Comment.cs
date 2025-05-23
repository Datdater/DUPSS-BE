using DUPSS.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace DUPSS.Domain.Entities;

public class Comment : BaseEntity
{
	[Required]
	public string UserId { get; set; }

	public string StepId { get; set; }

	public string? ParentCommentId { get; set; }

	public string? CommentDetail { get; set; }

	public bool Status { get; set; }

	// Navigation
	[ForeignKey("StepId")]
	public Step Step { get; set; }

	[ForeignKey("ParentCommentId")]
	public Comment ParentComment { get; set; }

	public ICollection<Comment> Replies { get; set; }
}