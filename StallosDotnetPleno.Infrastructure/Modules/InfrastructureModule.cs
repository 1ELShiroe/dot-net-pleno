using Autofac;

namespace StallosDotnetPleno.Infrastructure.Modules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                  .AsImplementedInterfaces()
                  .AsSelf().InstancePerLifetimeScope();
        }
    }
}