using Application.Common.Abstractions;
using Application.Contracts.Todos.Responses;
using Application.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Todos.Queries.GetTodos;

public class GetTodosQueryHandler(IApplicationDbContext context) : IRequestHandler<GetTodosQuery, Result<IEnumerable<TodoResponse>>>
{
	private readonly IApplicationDbContext _context = context;

	public async Task<Result<IEnumerable<TodoResponse>>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
	{
		var response = await _context.Todos
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