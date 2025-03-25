using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using Asp.Versioning;

namespace Framework.EndPoints.Web.Extensions.Services;

public static class SwaggerConfiguration
{
    public static void AddSwaggerGen(this WebApplicationBuilder builder, string appName,string abbr)
    {
        builder.Services.AddSwaggerGen(c =>
        {
            c.CustomSchemaIds(x => x.FullName);

            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = @$"{appName} 
                - {System.Diagnostics.FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly()!.Location).ProductVersion!.Remove(14)} 
                - {Environment.MachineName}
                - {builder.Environment.EnvironmentName}",
                Version = "v1"
            });

            // Include XML comments (for API documentation)
            //var xmlFile = $"SwaggerWebApi.xml";
            //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //c.IncludeXmlComments(xmlPath);


            if (!builder.Environment.IsDevelopment()) c.DocumentFilter<PathPrefixInsertDocumentFilter>($"/{abbr}");


            c.OperationFilter<RemoveVersionParameters>();

            c.DocumentFilter<SetVersionInPaths>();

            c.DocInclusionPredicate((docName, apiDesc) =>
            {
                if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

                var versions = methodInfo.DeclaringType
                    .GetCustomAttributes<ApiVersionAttribute>(true)
                    .SelectMany(attr => attr.Versions);

                return versions.Any(v => $"v{v}" == docName);
            });


            c.AddSecurityDefinition("OAuth2", new OpenApiSecurityScheme
            {
                Scheme = "Bearer",
                In = ParameterLocation.Cookie,
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    Password = new OpenApiOAuthFlow
                    {
                        TokenUrl = new Uri("https://newapi.hesabo.app/idp/api/v1/Auth/login2", UriKind.Absolute),
                    }
                }
            });
        });
    }
}

public class PathPrefixInsertDocumentFilter : IDocumentFilter
{
    private readonly string _pathPrefix;

    public PathPrefixInsertDocumentFilter(string prefix)
    {
        _pathPrefix = prefix;
    }

    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var paths = swaggerDoc.Paths.Keys.ToList();
        foreach (var path in paths)
        {
            var pathToChange = swaggerDoc.Paths[path];
            swaggerDoc.Paths.Remove(path);
            swaggerDoc.Paths.Add($"{_pathPrefix}{path}", pathToChange);
        }
    }
}

public class RemoveVersionParameters : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Remove version parameter from all Operations
        var versionParameter = operation.Parameters.SingleOrDefault(p => p.Name == "version");
        if (versionParameter != null)
            operation.Parameters.Remove(versionParameter);
    }
}

public class SetVersionInPaths : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var updatedPaths = new OpenApiPaths();

        foreach (var entry in swaggerDoc.Paths)
        {
            updatedPaths.Add(
                entry.Key.Replace("v{version}", swaggerDoc.Info.Version),
                entry.Value);
        }

        swaggerDoc.Paths = updatedPaths;
    }
}