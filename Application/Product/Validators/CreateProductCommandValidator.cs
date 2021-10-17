using Application.Product.Commands;
using Application.Common.Interfaces;
using FluentValidation;

namespace Application.Product.Validators
{
	class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
	{
		public CreateProductCommandValidator(IMerchandisingDbContext context)
		{

			RuleFor(v => v.Title)
				.NotEmpty().WithMessage("Title is required.")
				.MaximumLength(200).WithMessage("Title must have at least 200 characters.");
		}
	}
}
