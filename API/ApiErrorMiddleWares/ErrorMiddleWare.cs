using System.Net;
using System.Text.Json;
using API.ErrorsHandlers;


namespace API.ApiErrorMiddleWares
{
    public class ErrorMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _iloger;
        private readonly IHostEnvironment _env;
        public ErrorMiddleWare(RequestDelegate next, ILogger<ErrorMiddleWare> iloger, IHostEnvironment env)
        {
            _env = env;
            _iloger = iloger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext){

                try{
                          await  _next(httpContext);

                }

                catch(Exception e){

                       _iloger.LogError(e, e.Message);

                       httpContext.Response.ContentType = "application/json";

                       httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                       var response = _env.IsDevelopment() ? new ApiErrorExceptions(
                                    (int)HttpStatusCode.InternalServerError, e.Message, 
                                                 e.StackTrace.ToString()): 
                                                 new ApiErrorExceptions(
                                                    (int)HttpStatusCode.InternalServerError);

                        var options = new JsonSerializerOptions{PropertyNamingPolicy =
                                     JsonNamingPolicy.CamelCase};

                        var json = JsonSerializer.Serialize(response,options);

                        await httpContext.Response.WriteAsync(json);


                }
        }
    }
}