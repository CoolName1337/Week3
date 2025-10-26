using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public static class Extensions
    {
        public static IServiceCollection AddDataLogic(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Author>, AuthorRepository>();
            services.AddScoped<IRepository<Book>, BookRepository>();
            return services;
        }
    }
}
