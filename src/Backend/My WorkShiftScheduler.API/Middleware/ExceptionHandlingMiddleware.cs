using System.Net;
using System.Text.Json;
using WorkShiftScheduler.Application.Exceptions;

namespace My_WorkShiftScheduler.API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (RequestValidationException ex)
        {
            await HandleValidationException(context, ex);
        }
        catch (Exception ex)
        {
            await HandleGenericException(context, ex);
        }
    }

    private static async Task HandleValidationException(
        HttpContext context,
        RequestValidationException ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Response.ContentType = "application/json";

        var response = new
        {
            errors = ex.Errors
        };

        await context.Response.WriteAsync(
            JsonSerializer.Serialize(response));
    }

    private static async Task HandleGenericException(
        HttpContext context,
        Exception ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var response = new
        {
            error = "Erro interno no servidor."
        };

        await context.Response.WriteAsync(
            JsonSerializer.Serialize(response));
    }
}
