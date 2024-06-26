using System.Diagnostics.CodeAnalysis;

namespace CreditProcess.Api;
[ExcludeFromCodeCoverage]
public static class ApiServiceRegister
{
    public static IServiceCollection AddPublicApi(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddProblemDetails();
        return services;
    }
}