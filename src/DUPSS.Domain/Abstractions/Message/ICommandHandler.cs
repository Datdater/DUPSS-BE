﻿using DUPSS.Domain.Abstractions.Shared;
using MediatR;

namespace DUPSS.Domain.Abstractions.Message;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand { }

public interface ICommandHandler<in TCommand, TResponse>
    : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse> { }
