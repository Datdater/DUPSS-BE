namespace DUPSS.Domain.Abstractions.Shared;

public interface IValidationResult
{
    public static readonly Error ValidationError = new(
        "ValidationError",
        "Validation error occurred."
    );

    Error[] Errors { get; }
}
