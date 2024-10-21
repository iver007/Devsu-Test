using Application.Dto;
using AutoMapper;
using Domain.Interface.Repository;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            this._clienteRepository = clienteRepository;
            this._mapper = mapper;
        }
        public ClienteService()
        {
        }
        public virtual async Task<ApiResponse> AddCliente(ClienteDto dto)
        {
            Cliente cliente = _mapper.Map<Cliente>(dto);
            cliente.Codigo = Guid.NewGuid();
            var result = await _clienteRepository.AddCliente(cliente);

            return ActionResultApiResponse("Ok", result, false);
        }
        public async Task<ApiResponse> GetClienteByCodCliente(Guid codCliente)
        {
            var obj = await this._clienteRepository.GetClienteByCodClienteAsync(codCliente);
            return ActionResultApiResponse("Ok", obj, false);
        }
        public async Task<ApiResponse> UpdateCliente(Guid codCliente, ClienteDto dto)
        {
            Cliente cliente = _mapper.Map<Cliente>(dto);
            cliente.Codigo = codCliente;
            var obj = await this._clienteRepository.GetClienteByCodClienteAsync(codCliente);
            if(obj != null)
            {
                obj.Nombre = cliente.Nombre;
                obj.Genero = cliente.Genero;
                obj.Edad = cliente.Edad;
                obj.Identificacion = cliente.Identificacion;
                obj.Direccion = cliente.Direccion;
                obj.Telefono = cliente.Telefono;
                obj.Contrasenia = cliente.Contrasenia;
                obj.Estado = cliente.Estado;
                await _clienteRepository.UpdateCliente(obj);
                return ActionResultApiResponse("Ok", obj, false);

            }

            return ActionResultApiResponse("No exists Usuario", obj, true);
        }
        public async Task<ApiResponse> DeleteCliente(Guid codCliente)
        {
            var obj = await this._clienteRepository.GetClienteByCodClienteAsync(codCliente);
            if (obj != null)
            {
                await _clienteRepository.DeleteCliente(obj);
                return ActionResultApiResponse("Ok", obj, false);
            }

            return ActionResultApiResponse("No exists Usuario", obj, true);
        }

        private ApiResponse ActionResultApiResponse(string message, object? data = null, bool IsFailed = true)
        {
            return new ApiResponse
            {
                IsFailed = IsFailed,
                Message = message,
                Data = data
            };
        }
    }
}
