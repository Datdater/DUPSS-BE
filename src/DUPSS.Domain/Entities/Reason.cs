using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Domain.Commons;

namespace DUPSS.Domain.Entities;

public class Reason : BaseEntity
{
    public string Detail { get; set; }
    public string QueuingCoureseId { get; set; }
    public QueuingCourse QueuingCourese { get; set; }
}
