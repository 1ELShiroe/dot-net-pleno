using StallosDotnetPleno.Application.UseCases.Customer.RemoveCustomer;
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

namespace StallosDotnetPleno.Tests.Cases.Application.Customer.RemoveCustomer
{
    [UseAutofacTestFramework]
    public class RemoveCustomerUCTest(IUseCase<RemoveCustomerUCRequest> UseCase)
    {
        [Fact(DisplayName = "Should log not found message and not log error when removing non-existent customer")]
        public void ShouldLogNotFoundMessageAndNotLogErrorWhenRemovingNonExistentCustomer()
        {
            var customer = CustomerBuilder.Empty().Build();

            var request = new RemoveCustomerUCRequest(customer.Id);
            UseCase.Execute(request);

            request.Logs.Should()
                .Contain(l => l.Message.Equals($"Customer with Id: {customer.Id} not found"))
                .And.NotContain(l => l.Type == TypeLog.Error);
        }

        [Fact(DisplayName = "Should log deletion success and not log error when removing existing customer")]
        public void ShouldLogDeletionSuccessAndNotLogErrorWhenRemovingExistingCustomer()
        {
            var customer = CustomerBuilder.Empty().Build();

            var customerRepositoryMock = new Mock<ICustomerRepository>();

            customerRepositoryMock
               .Setup(repo => repo.GetCustomer(It.IsAny<Expression<Func<CustomerModel, bool>>>()))
               .Returns(customer);

            customerRepositoryMock
                .Setup(repo => repo.Remove(It.IsAny<CustomerModel>()))
                .Returns(1);

            using var autoMock = AutoMock.GetLoose(cfg =>
            {
                cfg.RegisterMock(customerRepositoryMock);
                cfg.RegisterType<RemoveCustomerUC>().As<IUseCase<RemoveCustomerUCRequest>>();
            });

            var useCase = autoMock.Create<IUseCase<RemoveCustomerUCRequest>>();

            var request = new RemoveCustomerUCRequest(customer.Id);
            useCase.Execute(request);

            request.Logs.Should()
                .Contain(l => l.Message.Equals($"1 users were deleted"))
                .And.NotContain(l =>
                    l.Message.Equals($"Customer with ID {customer.Id} not found") ||
                    l.Type == TypeLog.Error);
        }
    }
}