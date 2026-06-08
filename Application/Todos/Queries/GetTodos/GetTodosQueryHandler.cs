namespace Application.Todos.Queries.GetTodos;

public class GetTodosQueryHandler(IApplicationDbContext context) : IQueryHandler<GetTodosQuery, PaginatedList<TodoResponse>>
{
	private readonly IApplicationDbContext _context = context;

	public async Task<Result<PaginatedList<TodoResponse>>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
	{
		var source = _context.Todos
			.AsNoTracking()
			.OrderBy(t => t.Title)
			.Select(t => new TodoResponse
				(
					t.Id,
					t.Title,
					t.IsCompleted
				)
			);

		var response = await PaginatedList<TodoResponse>
			.CreateAsync(source, request.RequestFilter.PageNumber, request.RequestFilter.PageSize, cancellationToken);

		return Result.Success(response);
	}
}