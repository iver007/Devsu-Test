using Application.Dto;
using AutoMapper;
using Domain.Entity;

namespace Application.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>();
            CreateMap<Cuenta, CuentaAddDto>();
            CreateMap<CuentaAddDto, Cuenta>();
            CreateMap<Movimiento, MovimientoDto>();
            CreateMap<MovimientoDto, Movimiento>();
        }
    }
}
