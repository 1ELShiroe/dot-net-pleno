using Autofac;
using StallosDotnetPleno.Application.Modules;
using StallosDotnetPleno.Infrastructure.Modules;

namespace StallosDotnetPleno.Services.DependencyInjection
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder AddAutofacRegistration(this ContainerBuilder builder)
        {
            builder.RegisterModule<AutoMapperModule>();
            builder.RegisterModule<AutoMigrationModule>();
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<ApplicationModule>();

            return builder;
        }
    }
}
