using Microsoft.EntityFrameworkCore;
using Autofac;

namespace StallosDotnetPleno.Infrastructure.Modules
{
    public class AutoMigrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var connection = Environment.GetEnvironmentVariable("DBCONN");

            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
               .Where(t => (t.Namespace ?? string.Empty).Contains("Database"))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();

            using var context = new Database.Context();
            if (!string.IsNullOrEmpty(connection))
                context.Database.Migrate();
            else
                context.Database.EnsureCreated();
        }
    }
}