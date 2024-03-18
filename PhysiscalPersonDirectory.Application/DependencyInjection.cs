using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PhysiscalPersonDirectory.Application.Infrastructure;
using PhysiscalPersonDirectory.Application.Infrastructure.Behaviours;
using System.Reflection;

namespace PhysiscalPersonDirectory.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            AssemblyScanner.FindValidatorsInAssembly(typeof(DependencyInjection).Assembly).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));  
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

            return services;
        }
    }
}
