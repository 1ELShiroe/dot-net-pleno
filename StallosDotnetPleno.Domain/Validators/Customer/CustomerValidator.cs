using StallosDotnetPleno.Domain.Models.Customer;
using StallosDotnetPleno.Domain.Extensions;
using StallosDotnetPleno.Domain.Enums;
using FluentValidation;

namespace StallosDotnetPleno.Domain.Validators.Customer
{
    public class CustomerValidator : AbstractValidator<CustomerModel>
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
