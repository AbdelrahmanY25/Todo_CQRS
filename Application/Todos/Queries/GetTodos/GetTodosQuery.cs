namespace Application.Todos.Queries.GetTodos;

public sealed record GetTodosQuery() : IRequest<Result<IEnumerable<TodoResponse>>>;