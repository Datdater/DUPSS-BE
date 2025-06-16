using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Domain.Commons;

namespace DUPSS.Domain.Entities;

public class Workshop : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Host { get; set; }
    public bool Status { get; set; }
    public ICollection<WorkshopRegistration> Registrations { get; set; }
}
