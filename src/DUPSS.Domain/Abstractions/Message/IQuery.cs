using DUPSS.Domain.Abstractions.Shared;
using MediatR;

namespace DUPSS.Domain.Abstractions.Message;

public interface IQuery : IRequest<Result> { }

public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }
