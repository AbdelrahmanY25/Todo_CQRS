namespace Application.Contracts.Todos.Validations;

public class CreateTodoValidator : AbstractValidator<CreateTodoRequest>
{
	public CreateTodoValidator()
	{
		RuleFor(x => x.Title)
			.NotEmpty()
			.MaximumLength(200);
	}
}