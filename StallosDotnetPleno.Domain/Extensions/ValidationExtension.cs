using StallosDotnetPleno.Domain.Helpers;
using FluentValidation;

namespace StallosDotnetPleno.Domain.Extensions
{
    public static class ValidationExtension
    {
        public static IRuleBuilderOptions<T, string> CNPJ<T>(this IRuleBuilder<T, string> rule)
            => rule.Must(CNPJHelper.IsValidCNPJ)
                .WithMessage("CNPJ inválido.");
        public static IRuleBuilderOptions<T, string> CPF<T>(this IRuleBuilder<T, string> rule)
            => rule.Must(CPFHelper.IsCPF)
                .WithMessage("CNPJ inválido."); 
    }
}