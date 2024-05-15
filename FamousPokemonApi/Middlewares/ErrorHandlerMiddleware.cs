using System.Net;
using System.Text.Json;
using FamousPokemonApi.Exceptions;

namespace FamousPokemonApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case NotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case NoContentException e:
                        response.StatusCode = (int)HttpStatusCode.NoContent;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                if (response.StatusCode != (int)HttpStatusCode.NoContent)
                {
                    var result = JsonSerializer.Serialize(new { message = error?.Message });
                    await response.WriteAsync(result);
                }
            }
        }
    }
}