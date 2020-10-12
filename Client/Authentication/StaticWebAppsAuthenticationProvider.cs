using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Client.Authentication.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;

namespace Client.Authentication
{
    /*https://github.com/anthonychu/blazor-auth-static-web-apps/blob/main/src/StaticWebAppsAuthenticationExtensions/StaticWebAppsAuthenticationStateProvider.cs */
    
    
    public class StaticWebAppsAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _http;

        public StaticWebAppsAuthenticationStateProvider(IConfiguration config, IWebAssemblyHostEnvironment environment)
        {
            this._config = config;
            this._http = new HttpClient {BaseAddress = new Uri(environment.BaseAddress)};
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var authDataUrl =
                    _config.GetValue("StaticWebAppsAuthentication:AuthenticationDataUrl", "/.auth/me");
                var data = await _http.GetFromJsonAsync<AuthenticationData>(authDataUrl);

                var principal = data.ClientPrincipal;
                principal.UserRoles =
                    principal.UserRoles.Except(new string[] {"anonymous","authenticated"}, StringComparer.CurrentCultureIgnoreCase);

                var principalUserRoles = principal.UserRoles as string[] ?? principal.UserRoles.ToArray();
                if (!principalUserRoles.Any())
                {
                    return new AuthenticationState(new ClaimsPrincipal());
                }

                var identity = new ClaimsIdentity(principal.IdentityProvider);
                identity.AddClaim(new Claim(ClaimTypes.AuthenticationMethod,principal.IdentityProvider));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, principal.UserId));
                identity.AddClaim(new Claim(ClaimTypes.Name, principal.UserDetails));
                identity.AddClaims(principalUserRoles.Select(r => new Claim(ClaimTypes.Role, r)));
                return new AuthenticationState(new ClaimsPrincipal(identity));
            }
            catch
            {
                return new AuthenticationState(new ClaimsPrincipal());
            }
        }
    }
}