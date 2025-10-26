using BusinessLayer.Exceptions;
namespace LibraryApi
{
    public class ExceptionHandlingMiddleware(RequestDelegate next)
    {
        
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (NotFoundException ex)
            {
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                await httpContext.Response.WriteAsync(ex.Message);
            }
            catch (ValidationException ex)
            {
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                await httpContext.Response.WriteAsync(ex.Message);
            }
            catch(Exception ex)
            {
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await httpContext.Response.WriteAsync(ex.Message);
            }
        }
    }

}
