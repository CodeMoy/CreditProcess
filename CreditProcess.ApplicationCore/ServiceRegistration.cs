using Microsoft.Extensions.DependencyInjection;

namespace CreditProcess.ApplicationCore;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICardValidationService, CardValidationService>();

        return services;
    }
}
