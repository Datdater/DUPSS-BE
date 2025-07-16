using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Models.WorkShops
{
    public class GetWorkshopResponse
    {
        public GetWorkshopResponse()
        {
            Registrations = new List<Registrations>();
        }

        public string Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxParticipants { get; set; }
        public string Location { get; set; } = string.Empty;
        public List<Registrations> Registrations { get; set; }
        public int TotalRegistrations { get; set; }
    }

    public record Registrations(string UserId, string UserFullName);
}
