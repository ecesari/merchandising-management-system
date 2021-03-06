using FluentValidation;
using MerchandisingManagement.Application.Common.Interfaces;
using MerchandisingManagement.Application.Product.Commands;

namespace MerchandisingManagement.Application.Product.Validators
{
	class UpdateProductCommandValidator : AbstractValidator<CreateProductCommand>
	{
		public UpdateProductCommandValidator(IMerchandisingDbContext context)
		{
			RuleFor(v => v.Title)
				.NotEmpty().WithMessage("Title is required.")
				.MaximumLength(200).WithMessage("Title must have at least 200 characters.");
		}
	}
}
