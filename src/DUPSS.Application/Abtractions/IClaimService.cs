namespace DUPSS.Application.Abtractions
{
    public interface IClaimService
    {
        string GetCurrentUser { get; }
        string GetCurrentRole { get; }
    }
}
