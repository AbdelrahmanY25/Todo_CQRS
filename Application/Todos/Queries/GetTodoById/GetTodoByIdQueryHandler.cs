namespace Application.Todos.Queries.GetTodoById;

public class GetTodoByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetTodoByIdQuery, Result<TodoResponse>>
{
	private readonly IApplicationDbContext _context = context;

	public async Task<Result<TodoResponse>> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
	{
		var todo = await _context.Todos
			.AsNoTracking()
			.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
		
		if (todo is null)
			return Result.Failure<TodoResponse>(TodoErrors.NotFound);

		return Result.Success(new TodoResponse(todo.Id, todo.Title, todo.IsCompleted));
	}
}