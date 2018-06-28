using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using SennoAPI.DTO;
using SennoAPI.Extensions;

namespace SennoAPI.Attributes
{
    /// <summary>
    /// Attribute for control API usage
    /// </summary>
    public class ThrottleAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Amount of seconds between requests
        /// </summary>
        private int Seconds { get; }

        /// <summary>
        /// Message template with {0} argument for amount of seconds
        /// <example>Too many requests try in {0} seconds</example>
        /// </summary>
        private string MessageTemplate { get; }

        private const int TooManyRequestsStatusCode = 429;

        public ThrottleAttribute(int seconds,
            string messageTemplate = Constants.THROTTLE_MESSAGE)
        {
            Seconds = seconds;
            MessageTemplate = messageTemplate;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var accessToken = context.HttpContext.Request.GetToken();
            var sennoToken = await GetSennoToken(accessToken);

            if (IsRequestAllowed(context, sennoToken))
            {
                await LogRequest(context, sennoToken);
                await next();
                return;
            }

            await WriteNotAllowedResponse(context);
        }

        private async Task<SennoApiToken> GetSennoToken(string accessToken)
        {
            //omitted for brevity
            throw new NotImplementedException();
        }

        private bool IsRequestAllowed(ActionExecutingContext context, SennoApiToken sennoToken)
        {
            var requestsLimit = GetRequestsLimit(context, sennoToken);
            var recentApiUsageCount = GetUsageCount(sennoToken);
            return recentApiUsageCount < requestsLimit;
        }

        private int GetUsageCount(SennoApiToken sennoToken)
        {
            //omitted for brevity
            throw new NotImplementedException();
        }

        private static int GetRequestsLimit(ActionExecutingContext context, SennoApiToken sennoToken)
        {
            //omitted for brevity
            throw new NotImplementedException();
        }

        private async Task LogRequest(ActionExecutingContext context, SennoApiToken sennoToken)
        {
            //omitted for brevity
            throw new NotImplementedException();
        }

        private async Task WriteNotAllowedResponse(ActionExecutingContext context)
        {
            context.HttpContext.Response.StatusCode = TooManyRequestsStatusCode;
            await context.HttpContext.Response.WriteAsync(string.Format(MessageTemplate, Seconds));
        }
    }
}
