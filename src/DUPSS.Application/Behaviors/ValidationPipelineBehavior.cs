using DUPSS.Application.Exceptions;
using DUPSS.Domain.Abstractions.Shared;
using FluentValidation;
using MediatR;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace DUPSS.Application.Behaviors;

public class ValidationPipelineBehavior<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators
) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        if (!validators.Any())
        {
            return await next();
        }

        var errors = validators
            .Select(validator => validator.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(failure => failure is not null)
            .Select(failure => new ValidationError(failure.ErrorCode, failure.ErrorMessage))
            .Distinct()
            .ToArray();

        if (errors.Any())
            throw new Exceptions.ValidationException(errors);

        return await next();
    }
}
