using FluentValidation;

namespace StallosDotnetPleno.Domain.Validators.Customer
{
    public class CustomerAddressValidator : AbstractValidator<Models.Customer.CustomerAddress>
    {
        public CustomerAddressValidator()
        {
            RuleFor(c => c.City)
                .NotEmpty().WithMessage("Campo 'City' obrigatório não preenchido");

            RuleFor(c => c.Street)
                .NotEmpty().WithMessage("Campo 'Street' obrigatório não preenchido");

            RuleFor(c => c.UF)
                .NotEmpty().WithMessage("Campo 'UF' obrigatório não preenchido");

            RuleFor(c => c.Neighborhood)
                .NotEmpty().WithMessage("Campo 'Neighborhood' obrigatório não preenchido");

            RuleFor(c => c.Number)
                .NotEmpty().WithMessage("Campo 'Number' obrigatório não preenchido");

            RuleFor(c => c.ZipCode)
                .NotEmpty().WithMessage("Campo 'ZipCode' obrigatório não preenchido");
        }
    }
}
