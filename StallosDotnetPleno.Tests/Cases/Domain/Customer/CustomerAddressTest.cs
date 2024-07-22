using FluentAssertions;
using StallosDotnetPleno.Tests.Builders.Domain;
using Xunit.Frameworks.Autofac;

namespace StallosDotnetPleno.Tests.Cases.Domain.Customer
{
    [UseAutofacTestFramework]
    public class CustomerAddressTest
    {
        [Theory(DisplayName = "Should return error when 'Name' is invalid")]
        [InlineData("", "Campo 'Neighborhood' obrigatório não preenchido", true)]
        [InlineData("Bairro Magabal", "Campo 'Neighborhood' obrigatório não preenchido", false)]
        public void TestName(string value, string expectedMessage, bool shouldContainError)
        {
            var model = CustomerAddressBuilder.Empty()
                          .WithNeighborhood(value)
                          .WithUF("SP")
                          .WithCity("São Paulo")
                          .WithStreet("Travessa Magabal")
                          .WithZipCode("04991-180")
                          .WithNumber("AP-25")
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

        [Theory(DisplayName = "Should return error when 'Name' is invalid")]
        [InlineData("", "Campo 'City' obrigatório não preenchido", true)]
        [InlineData("São Paulo", "Campo 'City' obrigatório não preenchido", false)]
        public void TestNameasd(string value, string expectedMessage, bool shouldContainError)
        {
            var model = CustomerAddressBuilder.Empty()
                          .WithNeighborhood("Bairro Magabal")
                          .WithUF("SP")
                          .WithCity(value)
                          .WithStreet("Travessa Magabal")
                          .WithZipCode("04991-180")
                          .WithNumber("AP-25")
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

        [Theory(DisplayName = "Should return error when 'Name' is invalid")]
        [InlineData("", "Campo 'Street' obrigatório não preenchido", true)]
        [InlineData("Travessa Magabal", "Campo 'Street' obrigatório não preenchido", false)]
        public void TestNameasds(string value, string expectedMessage, bool shouldContainError)
        {
            var model = CustomerAddressBuilder.Empty()
                          .WithNeighborhood("Bairro Magabal")
                          .WithUF("SP")
                          .WithCity("São Paulo")
                          .WithStreet(value)
                          .WithZipCode("04991-180")
                          .WithNumber("AP-25")
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

        [Theory(DisplayName = "Should return error when 'Name' is invalid")]
        [InlineData("", "Campo 'UF' obrigatório não preenchido", true)]
        [InlineData("S", "Campo 'UF' deve ter exatamente 2 caracteres.", true)]
        [InlineData("SP", "Campo 'Street' obrigatório não preenchido", false)]
        [InlineData("SP", "Campo 'UF' deve ter exatamente 2 caracteres.", false)]
        public void TestNameasdsasd(string value, string expectedMessage, bool shouldContainError)
        {
            var model = CustomerAddressBuilder.Empty()
                          .WithNeighborhood("Bairro Magabal")
                          .WithUF(value)
                          .WithCity("São Paulo")
                          .WithStreet("Travessa Magabal")
                          .WithZipCode("04991-180")
                          .WithNumber("AP-25")
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

        [Theory(DisplayName = "Should return error when 'Name' is invalid")]
        [InlineData("", "Campo 'Number' obrigatório não preenchido", true)]
        [InlineData("AP-25", "Campo 'Number' obrigatório não preenchido", false)]
        public void TestNameasasdds(string value, string expectedMessage, bool shouldContainError)
        {
            var model = CustomerAddressBuilder.Empty()
                          .WithNeighborhood("Bairro Magabal")
                          .WithUF("SP")
                          .WithCity("São Paulo")
                          .WithStreet("Travessa Magabal")
                          .WithZipCode("04991-180")
                          .WithNumber(value)
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

        [Theory(DisplayName = "Should return error when 'Name' is invalid")]
        [InlineData("", "Campo 'ZipCode' obrigatório não preenchido", true)]
        [InlineData("88787414514", "Campo 'ZipCode' incorreto. Utilize o formato 'XXXXX-XXX' ou 'XXXXXXXX'", true)]
        [InlineData("76962-30A", "Campo 'ZipCode' incorreto. Utilize o formato 'XXXXX-XXX' ou 'XXXXXXXX'", true)]
        [InlineData("76962-304", "Campo 'ZipCode' incorreto. Utilize o formato 'XXXXX-XXX' ou 'XXXXXXXX'", false)]
        public void TestNameasasasddds(string value, string expectedMessage, bool shouldContainError)
        {
            var model = CustomerAddressBuilder.Empty()
                          .WithNeighborhood("Bairro Magabal")
                          .WithUF("SP")
                          .WithCity("São Paulo")
                          .WithStreet("Travessa Magabal")
                          .WithZipCode(value)
                          .WithNumber("AP-25")
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