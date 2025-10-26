using BusinessLayer;
using DataAccessLayer;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDataLogic();
            builder.Services.AddBusinessLogic();

            var app = builder.Build();


            app.UseSwagger();
            app.UseSwaggerUI(); 

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.MapControllers();
            
            app.Run();
        }
    }
}
