using Data.Models.Context;
using Microsoft.Extensions.DependencyInjection;
using SearchApp.SeedData;
using SearchApp.Services;
using Service.Interfaces.Services;

namespace CrossCutting.DependencyInjection;

public static class ConfigureService
{
    public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<SeedService>();
        serviceCollection.AddScoped<IConsignedCreditFormService, ConsignedCreditFormService>();
    }
}
