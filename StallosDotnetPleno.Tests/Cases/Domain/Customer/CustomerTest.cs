using StallosDotnetPleno.Tests.Builders.Domain;
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
                .WithName(name)
                .WithDocument("documentTest")
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
        [InlineData("", "Campo 'Document' obrigatório não preenchido", true)]
        [InlineData("documentTest", "Campo 'Document' obrigatório não preenchido", false)]
        public void ValidateCustomerDocument_ShouldReturnErrorWhenDocumentIsInvalid(string document, string expectedMessage, bool shouldContainError)
        {
            var model = CustomerBuilder.Empty()
                .WithName("Username")
                .WithDocument(document)
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
