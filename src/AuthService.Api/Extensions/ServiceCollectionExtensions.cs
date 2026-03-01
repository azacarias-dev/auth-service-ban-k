using AuthService.Domain.Entities;
using AuthService.Domain.Constants;
using AuthService.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using AuthService.Application.Interfaces;
using AuthService.Application.Service;

namespace AuthService.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, 
    IConfiguration configuration) 
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            .UseSnakeCaseNamingConvention());
        
        services.AddScoped<IEmailService, EmailService>();
        
        services.AddHealthChecks();

        return services;
    }
}
