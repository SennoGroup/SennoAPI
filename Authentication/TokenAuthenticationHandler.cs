using System;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SennoAPI.Extensions;

namespace SennoAPI.Authentication
{
    public class TokenAuthenticationHandler : AuthenticationHandler<TokenAuthenticationOptions>
    {
        public const string SchemeName = Constants.AUTH_SCHENE;

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string accessToken = Request.GetToken();
            var isValid = Validate(accessToken);

            if (isValid)
            {
                var claims = new[] { new Claim(Constants.CLAIM_NAME, accessToken) };
                var claimsIdentity = new ClaimsIdentity(claims, nameof(TokenAuthenticationHandler));
                var ticket = new AuthenticationTicket(new ClaimsPrincipal(claimsIdentity), Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }

            return AuthenticateResult.Fail(Constants.INVALID_TOKEN_MESSAGE);
        }

        private bool Validate(string accessToken)
        {
            //omitted for brevity
            throw new NotImplementedException();
        }

        public TokenAuthenticationHandler(IOptionsMonitor<TokenAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }
    }
}

