using AutoMapper;
using Domain.Interface.Persistence;
using Domain.Interface.Repository;
using Infrastructure.Persistence;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ConfigureInfrastructure
    {
        public static IServiceCollection AddInfrastructureRegistrations(this IServiceCollection services)
        {
            services.AddSingleton<IClienteRepository, ClienteRepository>();
            services.AddSingleton<IDomainDbContextFactory, DomainDbContextFactory>();

            return services;
        }
}
}
