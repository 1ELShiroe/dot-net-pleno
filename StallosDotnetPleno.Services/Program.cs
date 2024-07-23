using StallosDotnetPleno.Services.DependencyInjection;
using Autofac.Extensions.DependencyInjection;
using StallosDotnetPleno.Services.Services;
using Autofac;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.AddAutofacRegistration());


builder.Services.AddHostedService<GetHistoryCPFService>();

var app = builder.Build();
app.Run();