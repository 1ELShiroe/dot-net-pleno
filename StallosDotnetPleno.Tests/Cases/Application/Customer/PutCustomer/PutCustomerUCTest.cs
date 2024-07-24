using DTORequest = StallosDotnetPleno.Application.UseCases.Customer.PutCustomer.PutCustomer;
using StallosDotnetPleno.Application.UseCases.Customer.PutCustomer;
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

namespace StallosDotnetPleno.Tests.Cases.Application.Customer.PutCustomer
{
    [UseAutofacTestFramework]
    public class PutCustomerUCTest(IUseCase<PutCustomerUCRequest> UseCase)
    {
        [Fact(DisplayName = "Should log not found message and not log error when updating non-existent customer")]
        public void ShouldLogNotFoundMessageAndNotLogErrorWhenUpdatingNonExistentCustomer()
        {
            DTORequest newCustomer = new("Nivaldeir", "asd48548", []);

            var request = new PutCustomerUCRequest(newCustomer);
            UseCase.Execute(request);

            request.Logs.Should()
                .Contain(l => l.Message.Equals($"Customer with Document {newCustomer.Document} not found"))
                .And.NotContain(l => l.Type == TypeLog.Error);
        }

        [Fact(DisplayName = "Should update existing customer and log success message without errors")]
        public void ShouldUpdateExistingCustomerAndLogSuccessMessageWithoutErrors()
        {
            var customer = CustomerBuilder.Empty()
                .WithDocument("49.561.498/0001-50")
                .Build();

            DTORequest newCustomer = new("Nivaldeir", customer.Document, []);

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
                cfg.RegisterType<PutCustomerUC>().As<IUseCase<PutCustomerUCRequest>>();
            });

            var request = new PutCustomerUCRequest(newCustomer);

            autoMock.Create<IUseCase<PutCustomerUCRequest>>()
                    .Execute(request);

            request.Logs.Should()
                .NotContain(l => l.Message.Equals($"Customer with Document {newCustomer.Document} not found"))
                .And.NotContain(l => l.Type == TypeLog.Error)
                .And.Contain(l => l.Message.Equals($"User found successfully document: {newCustomer.Document}"));
        }


        [Fact(DisplayName = "Should update existing customer and log success message without unnecessary logs")]
        public void ShouldUpdateExistingCustomerAndLogSuccessMessageWithoutUnnecessaryLogs()
        {
            var customer = CustomerBuilder.Empty()
                .WithName("Testing")
                .WithDocument("603.787.890-00007")
                .Build();

            DTORequest newCustomer = new("Nivaldeir", customer.Document, []);

            var customerRepositoryMock = new Mock<ICustomerRepository>();

            customerRepositoryMock
               .Setup(repo => repo.GetCustomer(It.IsAny<Expression<Func<CustomerModel, bool>>>()))
               .Returns(customer);

            using var autoMock = AutoMock.GetLoose(cfg =>
            {
                cfg.RegisterMock(customerRepositoryMock);
                cfg.RegisterType<PutCustomerUC>().As<IUseCase<PutCustomerUCRequest>>();
            });

            var request = new PutCustomerUCRequest(newCustomer);

            autoMock.Create<IUseCase<PutCustomerUCRequest>>()
                    .Execute(request);

            request.Logs.Should()
                .NotContain(l => l.Message.Equals($"Customer with Document {newCustomer.Document} not found"))
                .And.NotContain(l => l.Type == TypeLog.Error)
                .And.NotContain(l => l.Message.Equals("Validation succeeded, proceeding to next handler"))
                .And.Contain(l => l.Message.Equals($"User found successfully document: {newCustomer.Document}"));
        }
    }
}