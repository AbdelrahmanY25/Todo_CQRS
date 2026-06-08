namespace Application.Contracts.Todos.Validations;

public class UpdateTodoValidator : AbstractValidator<UpdateTodoRequest>
{
	public UpdateTodoValidator()
	{
		RuleFor(x => x.Title)
			.NotEmpty()
			.MaximumLength(200);
	}
}