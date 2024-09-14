using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GameChar.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ServiceRegistration));
    }
}
