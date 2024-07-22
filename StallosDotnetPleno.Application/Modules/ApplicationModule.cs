using Autofac;

namespace StallosDotnetPleno.Application.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ApplicationException).Assembly)
               .AsImplementedInterfaces()
               .AsSelf().InstancePerLifetimeScope();
        }
    }
}