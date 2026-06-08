namespace Application.Todos.Queries.GetTodos;

public sealed record GetTodosQuery(RequestFilter RequestFilter) : IQuery<PaginatedList<TodoResponse>>;