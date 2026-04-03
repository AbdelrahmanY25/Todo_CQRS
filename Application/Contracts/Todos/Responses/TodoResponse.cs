namespace Application.Contracts.Todos.Responses;

public sealed record TodoResponse(Guid Id, string Title, bool IsCompleted);