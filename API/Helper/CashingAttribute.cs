using System.Text;
using infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Helper
{
    public class CashingAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _timeToLiveInSeconds;
        public CashingAttribute(int timeToLiveInSeconds)
        {
            _timeToLiveInSeconds = timeToLiveInSeconds;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, 
        ActionExecutionDelegate next)
        {
            var cashingServive = context.HttpContext.RequestServices
            .GetRequiredService<CashingService>();
            var casheKey = GenerateCasheKeyFromRequest(context.HttpContext.Request);
            var cashedResponse = await cashingServive.GetCasheResponseAsync(casheKey);
            if(!string.IsNullOrEmpty(cashedResponse)){
                var cashingResult = new ContentResult{
                    Content = cashedResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };

            context.Result = cashingResult;
            return ;
            }

            var executedContent = await next();

            if(executedContent.Result is OkObjectResult okObjectResult){
                    await cashingServive.CasheResponseAsync(casheKey,
                    okObjectResult,TimeSpan.FromSeconds(_timeToLiveInSeconds));
            }

            
        }

        private string GenerateCasheKeyFromRequest(HttpRequest request)
        {
            var keyBuilder = new StringBuilder();

            keyBuilder.Append($"{request.Path}");

            foreach(var (key,value) in request.Query.OrderBy(x=>x.Key)){
                 keyBuilder.Append($"|{key}-{value}");
            }

            return keyBuilder.ToString();
        }
    }
}