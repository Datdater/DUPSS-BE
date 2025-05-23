using DUPSS.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Domain.Entities
{
    public class WorkshopRegistration : BaseEntity
    {
        public string WorkshopId { get; set; }
        public string UserId { get; set; }
        public string Note { get; set; }

        public Workshop Workshop { get; set; } 
        public AppUser User { get; set; }
    }
}
