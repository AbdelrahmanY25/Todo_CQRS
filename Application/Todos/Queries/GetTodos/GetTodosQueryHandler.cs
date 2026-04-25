namespace Application.Todos.Queries.GetTodos;

public class GetTodosQueryHandler(IApplicationDbContext context) : IRequestHandler<GetTodosQuery, Result<IEnumerable<TodoResponse>>>
{
	private readonly IApplicationDbContext _context = context;

	public async Task<Result<IEnumerable<TodoResponse>>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
	{
		var response = await _context.Todos
			.AsNoTracking()
			.Where(t => t.IsCompleted)
			.OrderBy(t => t.Title)
			.Select(t => new TodoResponse
				(
					t.Id,
					t.Title,
					t.IsCompleted
				)
			)
			.ToListAsync(cancellationToken);

		return Result.Success<IEnumerable<TodoResponse>>(response);
	}
}