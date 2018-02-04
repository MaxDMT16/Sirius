using FluentValidation;
using SiriusCRM.Abstractions.Contracts.Commands.Product;

namespace SiriusCRM.Domain.Validators.Commands.Product
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Producer).NotEmpty();
            RuleFor(p => p.Price).GreaterThan(0);
        }
    }
}