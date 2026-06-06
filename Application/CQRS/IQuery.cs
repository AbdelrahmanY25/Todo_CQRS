namespace Application.CQRS;

internal interface IQuery<TResult> : IRequest<Result<TResult>> where TResult : notnull
{
}