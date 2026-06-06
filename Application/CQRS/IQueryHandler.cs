namespace Application.CQRS;

internal interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, Result<TResult>>
where TQuery : IQuery<TResult>
where TResult : notnull
{
}
