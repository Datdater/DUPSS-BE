using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Enums;

namespace DUPSS.Application.Features.Tests.Commands.Create
{
    public class CreateTestCommand : ICommand
    {
        public string Name { get; set; } = default!;
        public TestCategory Category { get; set; }
        public Guid? WorkshopId { get; set; }
        public SurveyType SurveyType { get; set; } = SurveyType.None;
    }
}
