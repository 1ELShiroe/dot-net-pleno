using StallosDotnetPleno.Application.Boundaries.Customer;
using StallosDotnetPleno.Application.Boundaries;
using Autofac;

namespace StallosDotnetPleno.Api.Modules
{
    public class PresentersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UseCases.Customer.AddCustomer.AddCustomerPresenter>()
                    .As<OutputPort<AddCustomerOPP>>()
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope().AsSelf();

            builder.RegisterType<UseCases.Customer.PutCustomer.PutCustomerPresenter>()
                    .As<OutputPort<PutCustomerOPP>>()
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope().AsSelf();
        }
    }
}