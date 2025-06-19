using System;
using DUPSS.Domain.Commons;

namespace DUPSS.Domain.Entities;

public class Blog : BaseEntity
{
    public string Title { get; set; }
    public string? Content { get; set; }
    public string? Description { get; set; }
    public string AuthorId { get; set; }

    public AppUser? User { get; set; }
}
