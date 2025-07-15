using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Enums;

namespace DUPSS.Application.Features.Tests.Commands.Update
{
    public class UpdateTestCommand : ICommand
    {
        public string Id { get; set; }
        public string Name { get; set; } = default!;
        public TestCategory Category { get; set; }
        public string? WorkshopId { get; set; }
    }
}
