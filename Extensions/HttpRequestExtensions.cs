using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace SennoAPI.Extensions
{
    public static class HttpRequestExtensions
    {
        public static string GetToken(this HttpRequest request)
        {
            request.Headers.TryGetValue("X-Auth-Token", out StringValues token);
            return token;
        }
    }
}
