using StallosDotnetPleno.Application.UseCases.Customer.GetCustomer;
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

namespace StallosDotnetPleno.Tests.Cases.Application.Customer.GetCustomer
{
    [UseAutofacTestFramework]
    public class GetCustomerUCTest(IUseCase<GetCustomerUCRequest> UseCase)
    {
        [Fact(DisplayName = "Should log a message when customer is not found and contain no error logs")]
        public void ShouldLogMessageWhenCustomerIsNotFound()
        {
            var customerId = 10;

            var request = new GetCustomerUCRequest(customerId);
            UseCase.Execute(request);

            request.Logs.Should().NotContain(l => l.Type == TypeLog.Error);
            request.Logs.Should().Contain(l => l.Message.Equals($"Customer with ID {customerId} not found"));
        }

        [Fact(DisplayName = "Should not log error or not found message when customer is retrieved successfully")]
        public void ShouldNotLogErrorOrNotFoundMessageWhenCustomerIsRetrievedSuccessfully()
        {
            var customer = CustomerBuilder.Empty().Build();

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock
               .Setup(repo => repo.GetCustomer(It.IsAny<Expression<Func<CustomerModel, bool>>>()))
               .Returns(customer);

            using var autoMock = AutoMock.GetLoose(cfg =>
            {
                cfg.RegisterMock(customerRepositoryMock);
                cfg.RegisterType<GetCustomerUC>().As<IUseCase<GetCustomerUCRequest>>();
            });

            var useCase = autoMock.Create<IUseCase<GetCustomerUCRequest>>();

            var request = new GetCustomerUCRequest(customer.Id);
            useCase.Execute(request);

            request.Logs.Should().NotContain(l =>
                l.Message.Equals($"Customer with ID {customer.Id} not found") ||
                l.Type == TypeLog.Error);
        }
    }
}