using FluentValidation;

namespace Application.Contracts.Common.Validators;

public class RequestFilterValidator : AbstractValidator<RequestFilter>
{
	public RequestFilterValidator()
	{
		RuleFor(x => x.PageNumber)
			.GreaterThanOrEqualTo(1)
			.WithMessage("Page number must be greater than or equal 1.");

		RuleFor(x => x.PageSize)
			.GreaterThanOrEqualTo(10)
			.LessThanOrEqualTo(50)
			.WithMessage("Page size must be between 10 and 50.");
	}
}