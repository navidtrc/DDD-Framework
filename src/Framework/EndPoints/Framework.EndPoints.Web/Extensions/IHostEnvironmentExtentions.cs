namespace Framework.EndPoints.Web.Extensions;

public static class IHostEnvironmentExtentions
{
    public static bool IsSelf(this IHostEnvironment hostEnvironment) =>
         hostEnvironment.IsEnvironment(ApplicationEnvironments.Self);
    
    public static bool IsDevelopment(this IHostEnvironment hostEnvironment) =>
         hostEnvironment.IsEnvironment(ApplicationEnvironments.Development);

    public static bool IsStaging(this IHostEnvironment hostEnvironment) =>
        hostEnvironment.IsEnvironment(ApplicationEnvironments.Staging);

    public static bool IsUat(this IHostEnvironment hostEnvironment) =>
        hostEnvironment.IsEnvironment(ApplicationEnvironments.Uat);

    public static bool IsPreProduction(this IHostEnvironment hostEnvironment) =>
        hostEnvironment.IsEnvironment(ApplicationEnvironments.PreProduction);

    public static bool IsProduction(this IHostEnvironment hostEnvironment) =>
        hostEnvironment.IsEnvironment(ApplicationEnvironments.Production);
}

public static class ApplicationEnvironments
{
    public static readonly string Self = "Self";
    public static readonly string Development = Environments.Development;
    public static readonly string Staging = Environments.Staging;
    public static readonly string Uat = "Uat";
    public static readonly string PreProduction = "PreProduction";
    public static readonly string Production = Environments.Production;
}