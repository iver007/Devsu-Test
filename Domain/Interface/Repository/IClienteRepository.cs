using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IClienteRepository
    {
        Task<string> AddCliente(Cliente dto);
        Task<Cliente?> GetClienteByCodClienteAsync(Guid clienteId);
        Task<string> UpdateCliente(Cliente dto);
        Task<string> DeleteCliente(Cliente dto);
    }
}
