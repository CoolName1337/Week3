using BusinessLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer
{
    public static class Extensions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services) 
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            return services;
        }
    }
}
