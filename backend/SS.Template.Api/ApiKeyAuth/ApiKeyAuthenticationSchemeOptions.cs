using Microsoft.AspNetCore.Authentication;

namespace SS.Template.Api.ApiKeyAuth
{
    public class ApiKeyAuthenticationSchemeOptions : AuthenticationSchemeOptions
    {
        public string ApiKey { get; set; } = null!;
    }
}
