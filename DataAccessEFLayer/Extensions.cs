using DataAccessEFLayer.Abstractions;
using DataAccessEFLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessEFLayer
{
    public static class Extensions
    {
        public static IServiceCollection AddDataLogic(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            return services;
        }
    }
}
