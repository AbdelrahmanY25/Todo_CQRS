using Application.Contracts.Todos.Requests;
using FluentValidation;

namespace Application.Contracts.Todos.Validations;

public class CreateTodoValidator : AbstractValidator<CreateTodoRequest>
{
	public CreateTodoValidator()
	{
		RuleFor(x => x.Title)
			.NotEmpty()
			.MaximumLength(2);
	}
}