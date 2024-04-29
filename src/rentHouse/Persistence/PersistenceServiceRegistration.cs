using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Persistence.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseNpgsql("Host=localhost:5432;Database=RentHouse;Username=postgres;Password=password"));
        services.AddDbMigrationApplier(buildServices => buildServices.GetRequiredService<BaseDbContext>());
        services.AddScoped<IBusinessRepository, BusinessRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IRentTypeRepository, RentTypeRepository>();
        services.AddScoped<IEstateRepository, EstateRepository>();
        services.AddScoped<IRentalRepository, RentalRepository>();
        return services;
    }
}
