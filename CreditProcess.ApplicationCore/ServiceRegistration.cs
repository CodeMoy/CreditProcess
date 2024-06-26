using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace CreditProcess.ApplicationCore;
[ExcludeFromCodeCoverage]
public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICardValidationService, CardValidationService>();
        return services;
    }
}
