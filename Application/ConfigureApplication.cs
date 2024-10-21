using Application.Dto;
using Application.Profiles;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ConfigureApplication
    {
        public static IServiceCollection AddApplicationRegistrations(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<CustomerProfile>();
                mc.AllowNullCollections = false;
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddValidatorsFromAssemblyContaining<ClienteDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<CuentaDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<CuentaUpdateDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<ReporteDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<MovimientoDtoValidator>();
            return services;
        }
}
}
