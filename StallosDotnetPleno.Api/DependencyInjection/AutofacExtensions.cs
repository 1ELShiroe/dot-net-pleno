using StallosDotnetPleno.Infrastructure.Modules;
using StallosDotnetPleno.Application.Modules;
using StallosDotnetPleno.Api.Modules;
using Autofac;

namespace StallosDotnetPleno.Api.DependencyInjection
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder AddAutoFac(this ContainerBuilder builder)
        {
            builder.RegisterModule<AutoMapperModule>();
            builder.RegisterModule<WebApiModule>();
            builder.RegisterModule<PresentersModule>();
            builder.RegisterModule<AutoMigrationModule>();
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<ApplicationModule>();

            return builder;
        }
    }
}