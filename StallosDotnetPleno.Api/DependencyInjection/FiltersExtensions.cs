using System.Text.Json.Serialization;
using StallosDotnetPleno.Api.Filters;

namespace StallosDotnetPleno.Api.DependencyInjection
{
    public static class FiltersExtensions
    {
        public static IServiceCollection AddCustomFilters(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(NotificationFilter));
            })
            .AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter()))
            .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            return services;
        }
    }
}