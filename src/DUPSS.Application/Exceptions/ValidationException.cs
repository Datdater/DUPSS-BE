using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Domain.Exceptions;

namespace DUPSS.Application.Exceptions;

public class ValidationException(IReadOnlyCollection<ValidationError> errors)
    : DomainException("Validation error", "One or more validation errors occurred.")
{
    public IReadOnlyCollection<ValidationError> Errors { get; } = errors;
}

public record ValidationError(string Title, string Message);
