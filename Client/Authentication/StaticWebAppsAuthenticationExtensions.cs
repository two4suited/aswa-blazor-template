using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Client.Authentication
{
    public static class StaticWebAppsAuthenticationExtensions
    {
        public static IServiceCollection AddStaticWebAppsAuthentication(this IServiceCollection services)
        {
            return services
                .AddAuthorizationCore( config =>
                {
                    config.AddPolicy(Policies.IsAdmin, Policies.IsAdminPolicy());
                    config.AddPolicy(Policies.IsUser,Policies.IsUserPolicy());
                })
                .AddScoped<AuthenticationStateProvider, StaticWebAppsAuthenticationStateProvider>();
        }
    }
}