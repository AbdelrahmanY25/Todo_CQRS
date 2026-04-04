namespace Application.Todos.Commands.UpdateTodo;

public class UpdateTodoCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateTodoCommand, Result>
{
	private readonly IApplicationDbContext _context = context;

	public async Task<Result> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
	{
		var todo = await _context.Todos.FindAsync([request.Id], cancellationToken);

		if (todo is null)
			return Result.Failure(TodoErrors.NotFound);

		todo.Title = request.Title;
		todo.IsCompleted = request.IsCompleted;

		await _context.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}