using System.Reflection;
using GameChar.Application.Abstractions.Repositories.CharacterRepository;
using GameChar.Application.Abstractions.Repositories.SkillRepository;
using GameChar.Persistence.DbContexts;
using GameChar.Persistence.Repositories.CharacterRepository;
using GameChar.Persistence.Repositories.SkillRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameChar.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration builder)
    {
        services.AddScoped<ICharacterReadRepository, CharacterReadRepository>();
        services.AddScoped<ICharacterWriteRepository, CharacterWriteRepository>();
        services.AddScoped<ISkillReadRepository, SkillReadRepository>();
        services.AddScoped<ISkillWriteRepository, SkillWriteRepository>();
        
        services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.GetConnectionString("SqlConnection")));
        // opt => opt.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext))!.GetName().Name)));
    }
}
