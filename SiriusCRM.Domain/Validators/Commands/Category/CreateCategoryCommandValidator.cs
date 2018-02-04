using FluentValidation;
using SiriusCRM.Abstractions.Contracts.Commands.Category;

namespace SiriusCRM.Domain.Validators.Commands.Category
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}