using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Services
{
    public interface IClienteService
    {
        Task<string> AddCliente(ClienteDto dto);
    }
}
