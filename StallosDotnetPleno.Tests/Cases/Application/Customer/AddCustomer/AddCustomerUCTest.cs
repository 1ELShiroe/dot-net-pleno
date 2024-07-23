using StallosDotnetPleno.Application.UseCases.Customer.AddCustomer;
using StallosDotnetPleno.Application.Interfaces.Repositories;
using StallosDotnetPleno.Domain.Models.Customer;
using StallosDotnetPleno.Tests.Builders.Domain;
using StallosDotnetPleno.Application.UseCases;
using StallosDotnetPleno.Domain.Enums;
using Xunit.Frameworks.Autofac;
using System.Linq.Expressions;
using Autofac.Extras.Moq;
using FluentAssertions;
using Autofac;
using Moq;

namespace StallosDotnetPleno.Tests.Cases.Application.Customer.AddCustomer
{
    [UseAutofacTestFramework]
    public class AddCustomerUCTest
    {
        [Fact(DisplayName = "Add Customer Use Case should log correct process count and erro exist user")]
        public void ShouldLogCorrectProcessCount()
        {
            var customer = CustomerBuilder.Empty().Build();

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock
               .Setup(repo => repo.GetCustomer(It.IsAny<Expression<Func<CustomerModel, bool>>>()))
               .Returns(customer);

            using var autoMock = AutoMock.GetLoose(cfg =>
            {
                cfg.RegisterMock(customerRepositoryMock);
                cfg.RegisterType<AddCustomerUC>().As<IUseCase<AddCustomerUCRequest>>();
            });

            var useCase = autoMock.Create<IUseCase<AddCustomerUCRequest>>();

            var request = new AddCustomerUCRequest(customer);
            useCase.Execute(request);

            request.Logs.Where(l => l.Type == TypeLog.Process).Should().HaveCount(2);
            request.Logs.Should().NotContain(l => l.Message.Equals("No users found with the data provided"));
        }

        [Fact(DisplayName = "Add Customer Use Case should log correct messages and count created user")]
        public void ShouldLogCorrectMessagesAndCount()
        {
            var customer = CustomerBuilder.Empty().Build();

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock
               .Setup(repo => repo.GetCustomer(It.IsAny<Expression<Func<CustomerModel, bool>>>()));

            using var autoMock = AutoMock.GetLoose(cfg =>
            {
                cfg.RegisterMock(customerRepositoryMock);
                cfg.RegisterType<AddCustomerUC>().As<IUseCase<AddCustomerUCRequest>>();
            });

            var useCase = autoMock.Create<IUseCase<AddCustomerUCRequest>>();

            var request = new AddCustomerUCRequest(customer);
            useCase.Execute(request);

            request.Logs.Where(l => l.Type == TypeLog.Process).Should().HaveCount(3);
            request.Logs.Should()
                .Contain(l => l.Message.Equals("No users found with the data provided")).And
                .Contain(l => l.Message.Equals("Customer successfully created."));
        }
    }
}