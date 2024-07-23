using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper;
using Autofac;

namespace StallosDotnetPleno.Infrastructure.Modules
{
    public class AutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
            .Where(t => (t.Namespace ?? string.Empty).Contains("Mapper") && typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
            .As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                    cfg.AddProfile(profile);
                    
                cfg.AddExpressionMapping();
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
                    .CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}