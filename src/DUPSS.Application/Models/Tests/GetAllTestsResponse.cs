using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Models.Tests
{
    public class GetAllTestsResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string SurveyType { get; set; } = default!;
        public string? WorkshopTitle { get; set; }
        public string Category { get; set; } = default!;
    }
}
