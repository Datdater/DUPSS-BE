using DUPSS.Domain.Abstractions.Shared;
using MediatR;

namespace DUPSS.Domain.Abstractions.Message;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse> { }
