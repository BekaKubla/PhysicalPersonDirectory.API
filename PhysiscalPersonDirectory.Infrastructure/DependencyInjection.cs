using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhysiscalPersonDirectory.Application.Infrastructure.Services;
using PhysiscalPersonDirectory.Domain.Repositories.CityRepository;
using PhysiscalPersonDirectory.Domain.Repositories.PersonRepository;
using PhysiscalPersonDirectory.Domain.Repositories.PhoneNumberRepository;
using PhysiscalPersonDirectory.Domain.SeedWork;
using PhysiscalPersonDirectory.Infrastructure.Persistence.Context;
using PhysiscalPersonDirectory.Infrastructure.Persistence.Repositories.CityRepository;
using PhysiscalPersonDirectory.Infrastructure.Persistence.Repositories.PersonRepository;
using PhysiscalPersonDirectory.Infrastructure.Persistence.Repositories.PhoneNumberRepository;
using PhysiscalPersonDirectory.Infrastructure.Persistence.UnitOfWork;
using PhysiscalPersonDirectory.Infrastructure.Services.FileService;

namespace PhysiscalPersonDirectory.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer();
            services.AddEntityFrameworkProxies();
            services.AddDbContextPool<PersonDbContext>((serviceProvider, options) =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(configuration.GetConnectionString("PersonDatabase"));
                options.UseInternalServiceProvider(serviceProvider);
            });

            services.AddScoped<PersonDbContext>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IPhoneNumberRepository, PhoneNumberRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFileService, FileService>();

            return services;
        }
    }
}
