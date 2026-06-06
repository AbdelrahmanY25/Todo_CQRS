namespace Application.Todos.Commands.CreateTodo;

public sealed record CreateTodoCommand(string Title) : ICommand<Guid>;