using Application.Common.Abstractions;
using Application.Common.Errors.TodosErrors;
using Application.Interfaces.Persistence;
using MediatR;

namespace Application.Todos.Commands.DeleteTodo;

public class DeleteTodoCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteTodoCommand, Result>
{
	private readonly IApplicationDbContext _context = context;

	public async Task<Result> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
	{
		var todo = await _context.Todos.FindAsync([request.Id], cancellationToken);

		if (todo is null)
			return Result.Failure(TodoErrors.NotFound);

		_context.Todos.Remove(todo);

		await _context.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}