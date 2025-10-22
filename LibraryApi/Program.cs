using BusinessLayer;
using DataAccessLayer;

namespace LibraryApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDataLogic();
            builder.Services.AddBusinessLogic();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseDeveloperExceptionPage();    

            app.UseHttpsRedirection();
            app.MapControllers();
            
            app.Run();
        }
    }
}
