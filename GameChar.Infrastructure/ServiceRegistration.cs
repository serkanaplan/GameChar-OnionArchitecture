using GameChar.Application.Abstractions.Services;
using Microsoft.Extensions.DependencyInjection;
using GameChar.Infrastructure.Services;
using System.Net.Mail;

namespace GameChar.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IFileService, FileService>();
        services.AddTransient<IEmailService>(provider =>
        {
            var smtpClient = new SmtpClient("smtp.yourdomain.com");
            return new EmailService(smtpClient);
        });

        services.AddHttpClient<IExternalApiService, ExternalApiService>();
    }
}
