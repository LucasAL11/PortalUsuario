using System.Net;

namespace PortalUsuario.Api.Middlewares.Errors;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            throw new NotImplementedException();
            await _next(context);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro: {e.Message}");
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync("Ocorreu um erro no servidor.");
        }
    }
}

