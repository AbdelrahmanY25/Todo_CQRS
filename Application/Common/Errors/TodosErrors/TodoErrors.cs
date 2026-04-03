using Application.Common.Abstractions;

namespace Application.Common.Errors.TodosErrors;

public static class TodoErrors
{
	public static Error NotFound => new("Todos.NotFound", "Todo was not found.", StatusCode: 404);
}