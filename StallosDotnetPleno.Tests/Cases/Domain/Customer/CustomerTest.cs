using StallosDotnetPleno.Tests.Builders.Domain;
using StallosDotnetPleno.Domain.Enums;
using Xunit.Frameworks.Autofac;
using FluentAssertions;

namespace StallosDotnetPleno.Tests.Cases.Domain.Customer
{
    [UseAutofacTestFramework]
    public class CustomerTests
    {
        [Theory(DisplayName = "Should return error when 'Name' is invalid")]
        [InlineData("", "Campo 'Name' obrigatório não preenchido", true)]
        [InlineData("Nivaldeir", "Campo 'Name' obrigatório não preenchido", false)]
        public void ValidateCustomerName_ShouldReturnErrorWhenNameIsInvalid(string name, string expectedMessage, bool shouldContainError)
        {
            var model = CustomerBuilder.Empty()
                .WithType(TypeUser.PJ)
                .WithDocument("75.002.339/0001-26")
                .WithName(name)
                .Build();

            if (shouldContainError)
            {
                model.IsValid.Should().BeFalse();
                model.ValidationResult?.Errors.Should()
                    .Contain(error => error.ErrorMessage.Equals(expectedMessage));

                return;
            }

            model.IsValid.Should().BeTrue();
            model.ValidationResult?.Errors.Should()
                .NotContain(error => error.ErrorMessage.Equals(expectedMessage));
        }

        [Theory(DisplayName = "Should return error when 'Document' is invalid")]
        [InlineData(TypeUser.PJ, "", "Campo 'Document' obrigatório não preenchido", true)]
        [InlineData(TypeUser.PF, "", "Campo 'Document' obrigatório não preenchido", true)]
        [InlineData(TypeUser.PF, "620.286.380-36", "Campo 'Document' deve ser um CPF válido com 11 dígitos.", false)]
        [InlineData(TypeUser.PJ, "75.002.339/0001-26", "Campo 'Document' deve ser um CNPJ válido com 14 dígitos.", false)]
        [InlineData(TypeUser.PJ, "75.002.339/0001-2655", "Campo 'Document' deve ser um CNPJ válido com 14 dígitos.", true)]
        [InlineData(TypeUser.PF, "620.286.3803656", "Campo 'Document' deve ser um CPF válido com 11 dígitos.", true)]
        public void ValidateCustomerDocument_ShouldReturnErrorWhenDocumentIsInvalid(TypeUser type, string document, string expectedMessage, bool shouldContainError)
        {
            var model = CustomerBuilder.Empty()
                .WithType(type)
                .WithDocument(document)
                .WithName("Username")
                .Build();

            if (shouldContainError)
            {
                model.IsValid.Should().BeFalse();
                model.ValidationResult?.Errors.Should()
                    .Contain(error => error.ErrorMessage.Equals(expectedMessage));

                return;
            }

            model.IsValid.Should().BeTrue();
            model.ValidationResult?.Errors.Should()
                .NotContain(error => error.ErrorMessage.Equals(expectedMessage));
        }
    }
}
