using Application.Contracts.Todos.Requests;
using FluentValidation;

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