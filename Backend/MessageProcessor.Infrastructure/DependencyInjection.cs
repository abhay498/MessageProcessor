using Microsoft.Extensions.DependencyInjection;
using MessageProcessor.Application.Interfaces;
using MessageProcessor.Application.Services;

namespace MessageProcessor.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddScoped<IMessageService, MessageService>();

        return services;
    }
}