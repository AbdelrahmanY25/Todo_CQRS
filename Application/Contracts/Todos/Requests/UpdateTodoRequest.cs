namespace Application.Contracts.Todos.Requests;

public sealed record UpdateTodoRequest(string Title, bool IsCompleted);