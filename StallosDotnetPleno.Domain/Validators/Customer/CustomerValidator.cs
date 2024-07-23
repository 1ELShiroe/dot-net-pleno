using FluentValidation;
using StallosDotnetPleno.Domain.Enums;
using StallosDotnetPleno.Domain.Extensions;

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

            When(c => c.Type == TypeUser.PF, () =>
             {
                 RuleFor(c => c.Document)
                     .CPF().WithMessage("Campo 'Document' deve ser um CPF válido com 11 dígitos.");
             });

            When(c => c.Type == TypeUser.PJ, () =>
            {
                RuleFor(c => c.Document)
                    .CNPJ().WithMessage("Campo 'Document' deve ser um CNPJ válido com 14 dígitos.");
            });
        }
    }
}
