namespace Application.Todos.Queries.GetTodos;

public sealed record GetTodosQuery() : IQuery<IEnumerable<TodoResponse>>;