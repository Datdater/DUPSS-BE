using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Domain.Commons;

namespace DUPSS.Domain.Entities;

public class WorkshopRegistration : BaseEntity
{
    public required string WorkshopId { get; set; }
    public required string UserId { get; set; }
    public string? Note { get; set; }

    public Workshop Workshop { get; set; } = null!;
    public AppUser User { get; set; } = null!;
}
