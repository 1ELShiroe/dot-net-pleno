using StallosDotnetPleno.Infrastructure.Modules;
using StallosDotnetPleno.Application.Modules;
using StallosDotnetPleno.Api.Modules;
using Xunit.Frameworks.Autofac;
using Xunit.Abstractions;
using Autofac;

[assembly: TestFramework("StallosDotnetPleno.Tests.ConfigureTestFramework", "StallosDotnetPleno.Tests")]
namespace StallosDotnetPleno.Tests
{
    public class ConfigureTestFramework : AutofacTestFramework
    {
        public ConfigureTestFramework(IMessageSink diagnosticMessageSink) : base(diagnosticMessageSink)
        {
            Environment.SetEnvironmentVariable("DBCONN", string.Empty);
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<AutoMapperModule>();
            builder.RegisterModule<WebApiModule>();
            builder.RegisterModule<PresentersModule>();
            builder.RegisterModule<AutoMigrationModule>();
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<ApplicationModule>();
        }
    }
}