using Data.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
namespace CrossCutting.DependencyInjection;

public static class ConfigureRepository
{
    public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IRepositoryBase<Person>, RepositoryBase<Person>>();
        serviceCollection.AddScoped<IRepositoryBase<Response>, RepositoryBase<Response>>();
        serviceCollection.AddScoped<IRepositoryBase<Question>, RepositoryBase<Question>>();
        serviceCollection.AddScoped<IQuestionRepository, QuestionRepository>();
    }

}
