namespace Application.Todos.Commands.CreateTodo;

public class CreateTodoCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateTodoCommand, Result<Guid>>
{
	private readonly IApplicationDbContext _context = context;

	public async Task<Result<Guid>> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
	{
		var todo = new Domain.Entities.Todo
		{
			Id = Guid.CreateVersion7(),
			Title = request.Title,
		};

		_context.Todos.Add(todo);

		await _context.SaveChangesAsync(cancellationToken);

		return Result.Success(todo.Id);
	}
}