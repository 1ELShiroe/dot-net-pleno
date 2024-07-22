using FluentValidation;

namespace StallosDotnetPleno.Domain.Validators.Customer
{
    public class CustomerValidator : AbstractValidator<Models.Customer.Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Campo 'Name' obrigatório não preenchido");

            RuleFor(c => c.Document)
                .NotEmpty().WithMessage("Campo 'Document' obrigatório não preenchido");
        }
    }
}
