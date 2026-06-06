namespace Application.CQRS;

internal interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result>
where TCommand : ICommand
{
}

internal interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, Result<TResult>>
where TCommand : ICommand<TResult>
where TResult : notnull
{
}