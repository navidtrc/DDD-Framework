using Ardalis.GuardClauses;
using Framework.EndPoints.Web.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace Framework.EndPoints.Web.Extensions.Services;

public static class AuthenticationConfiguration
{
    public static IServiceCollection AddAuthentication(this IServiceCollection services,
        IConfiguration configuration)
    {
        var authority = configuration["IdentityProvider:Authority"];
        var audience = configuration["IdentityProvider:Audience"];
        Guard.Against.NullOrEmpty(authority, message: "authority option is empty.");
        Guard.Against.NullOrEmpty(audience, message: "audience option is empty.");

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = authority;
                options.RequireHttpsMetadata = !string.IsNullOrEmpty(authority) && authority.StartsWith("https", StringComparison.OrdinalIgnoreCase);
                options.Audience = audience;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidateIssuer = true,
                    ValidIssuer = authority,
                    ValidateAudience = true,
                    ValidAudience = audience
                };
                
                // Configuration manager for OpenID Connect configuration
                options.ConfigurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                    $"{options.Authority}/.well-known/openid-configuration",
                    new OpenIdConnectConfigurationRetriever(),
                    new HttpDocumentRetriever { RequireHttps = options.RequireHttpsMetadata }
                );

                // Optional: Specify the signing key resolver if needed
                options.TokenValidationParameters.IssuerSigningKeyResolver = (token, securityToken, kid, validationParameters) =>
                {
                    var configuration = options.ConfigurationManager.GetConfigurationAsync(CancellationToken.None).Result;
                    return configuration.SigningKeys;
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        string clientId = context.Request.GenerateTokenCookiePrefix();

                        if (string.IsNullOrEmpty(clientId))
                        {
                            Console.WriteLine(
                                "-----------------------------------------------------------------------------");
                            Console.WriteLine(
                                "ClientId is null (in OnMessageReceived in JwtBearerEvents for authorization).");
                            Console.WriteLine(
                                "-----------------------------------------------------------------------------");
                        }

                        var token = context.Request.Cookies[$"{clientId}_{Auth.TokenName}"];

                        if (string.IsNullOrWhiteSpace(token))
                        {
                            Console.WriteLine(
                                "-----------------------------------------------------------------------------");
                            Console.WriteLine("Token is null or withe space and there is no token.");
                            Console.WriteLine(
                                "-----------------------------------------------------------------------------");
                        }

                        if (!string.IsNullOrEmpty(token))
                        {
                            context.Token = token;
                        }

                        return Task.CompletedTask;
                    }
                };
            });

        return services;
    }

    public static string GenerateTokenCookiePrefix(this HttpRequest? request)
    {
        if (request is null)
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Request is null.");
            Console.WriteLine("-----------------------------------------------------------");
            return "";
        }
        Console.WriteLine($"---------------------------------------------------------");

        foreach (var keyValuePair in request.Headers)
        {
            Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value}\n");
        }

        Console.WriteLine($"---------------------------------------------------------");

        string role = request.Headers["role"];
        if (string.IsNullOrWhiteSpace(role)) role = request.Headers["Role"];
        if (string.IsNullOrWhiteSpace(role))
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Role is null or withe space and there is no token.");
            Console.WriteLine("-----------------------------------------------------------------");
            return "";
        }

        if (role.Equals(ApplicationRoles.AdminRoleName, StringComparison.OrdinalIgnoreCase))
        {
            return ApplicationClients.AdminClientName;
        }

        if (role.Equals(ApplicationRoles.EmployerRoleName, StringComparison.OrdinalIgnoreCase))
        {
            return ApplicationClients.EmployerClientName;
        }

        if (role.Equals(ApplicationRoles.SupportRoleName, StringComparison.OrdinalIgnoreCase))
        {
            return ApplicationClients.SupportClientName;
        }

        if (role.Equals(ApplicationRoles.EmployeeRoleName, StringComparison.OrdinalIgnoreCase))
        {
            return ApplicationClients.EmployeeClientName;
        }


        return "";
    }
}