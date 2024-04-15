
using Data.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SearchApp.SeedData;

namespace CrossCutting.DependencyInjection;

public class ConfigureContext
{
    public static void ConfigureDependencies(IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<MyContext>(options => options.UseSqlite("Data Source=Teste.db"));
    }

    public static async Task ConfigureSeedData(IServiceProvider serviceProvider)
    {
        var scopedFactory = serviceProvider.GetService<IServiceScopeFactory>();
        using (var scope = scopedFactory.CreateScope())
        {
            var seedData = scope.ServiceProvider.GetService<SeedService>();
            await seedData.Seed();
        } 
    }
}
