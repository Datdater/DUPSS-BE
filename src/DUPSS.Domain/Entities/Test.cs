using DUPSS.Domain.Commons;
using DUPSS.Domain.Enums;

namespace DUPSS.Domain.Entities
{

    public class Test : BaseEntity
    {
        public required string Name { get; set; }
        public required TestCategory Category { get; set; }
    }
}
