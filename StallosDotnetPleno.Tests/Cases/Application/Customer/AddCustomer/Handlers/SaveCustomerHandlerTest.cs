using StallosDotnetPleno.Application.UseCases.Customer.AddCustomer.Handlers;
using StallosDotnetPleno.Application.UseCases.Customer.AddCustomer;
using StallosDotnetPleno.Application.Interfaces.Repositories;
using StallosDotnetPleno.Domain.Models.Customer;
using StallosDotnetPleno.Tests.Builders.Domain;
using Xunit.Frameworks.Autofac;
using System.Linq.Expressions;
using Autofac.Extras.Moq;
using FluentAssertions;
using Moq;

namespace StallosDotnetPleno.Tests.Cases.Application.Customer.AddCustomer.Handlers
{
    [UseAutofacTestFramework]
    public class SaveCustomerHandlerTest
    {
        [Fact(DisplayName = "Should log success message when customer is successfully saved")]
        public void ShouldLogSuccessMessageWhenCustomerIsSuccessfullySaved()
        {
            var customer = CustomerBuilder.Empty().Build();

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock
               .Setup(repo => repo.GetCustomer(It.IsAny<Expression<Func<CustomerModel, bool>>>()))
               .Returns(customer);

            using var autoMock = AutoMock.GetLoose(cfg =>
            {
                cfg.RegisterMock(customerRepositoryMock);
            });

            var handler = autoMock.Create<SaveCustomerHandler>();

            var request = new AddCustomerUCRequest(customer);
            handler.ProcessRequest(request);

            request.Logs.Should().Contain(l => l.Message.Equals("Customer successfully created."));
        }
    }
}