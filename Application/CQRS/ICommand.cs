namespace Application.CQRS;

internal interface ICommand : IRequest<Result>
{
}

internal interface ICommand<TResult> : IRequest<Result<TResult>>
{
}