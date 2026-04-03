using Application.Common.Abstractions;
using Application.Common.Errors.TodosErrors;
using Application.Contracts.Todos.Responses;
using Application.Interfaces.Persistence;
using MediatR;

namespace Application.Todos.Queries.GetTodoById;

public class GetTodoByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetTodoByIdQuery, Result<TodoResponse>>
{
	private readonly IApplicationDbContext _context = context;

	public async Task<Result<TodoResponse>> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
	{
		var todo = await _context.Todos.FindAsync([request.Id], cancellationToken);

		if (todo is null)
			return Result.Failure<TodoResponse>(TodoErrors.NotFound);

		return Result.Success(new TodoResponse(todo.Id, todo.Title, todo.IsCompleted));
	}
}