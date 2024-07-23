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
    public class ExistCustomerHandlerTest
    {
        [Fact(DisplayName = "Should not log 'No users found with the data provided' when customer exists")]
        public void ShouldNotLogNoUsersFoundWhenCustomerExists()
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

            var handler = autoMock.Create<ExistCustomerHandler>();

            var request = new AddCustomerUCRequest(customer);
            handler.ProcessRequest(request);

            request.Logs.Should().NotContain(l => l.Message.Equals("No users found with the data provided"));
        }

        [Fact(DisplayName = "Should log 'No users found with the data provided' when customer does not exist")]
        public void ShouldLogNoUsersFoundWhenCustomerDoesNotExist()
        {
            var customer = CustomerBuilder.Empty().Build();

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock
               .Setup(repo => repo.GetCustomer(It.IsAny<Expression<Func<CustomerModel, bool>>>()));

            using var autoMock = AutoMock.GetLoose(cfg =>
            {
                cfg.RegisterMock(customerRepositoryMock);
            });

            var handler = autoMock.Create<ExistCustomerHandler>();

            var request = new AddCustomerUCRequest(customer);
            handler.ProcessRequest(request);

            request.Logs.Should().Contain(l => l.Message.Equals("No users found with the data provided"));
        }
    }
}