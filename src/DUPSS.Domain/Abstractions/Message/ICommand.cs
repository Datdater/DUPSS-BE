using DUPSS.Domain.Abstractions.Shared;
using MediatR;

namespace DUPSS.Domain.Abstractions.Message;

public interface ICommand : IRequest<Result> { }

public interface ICommand<TResponse> : IRequest<Result<TResponse>> { }
