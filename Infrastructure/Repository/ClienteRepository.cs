using AutoMapper;
using Domain.Interface.Persistence;
using Domain.Interface.Repository;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDomainDbContextFactory plantContextFactory;

        public ClienteRepository(
          IDomainDbContextFactory plantContextFactory)
        {
            this.plantContextFactory = plantContextFactory;
        }
        public async Task<string> AddCliente(Cliente dto)
        {
            using (var context = await this.plantContextFactory.Create(""))
            {
                context.Clientes.Add(dto);
                await context.SaveAsync();
                return dto.Codigo.ToString();
            }
        }

        public async Task<Cliente?> GetClienteByCodClienteAsync(Guid clienteId)
        {
            using (var context = await this.plantContextFactory.Create(""))
            {
                var cliente = await context.Clientes.Where(x => x.Codigo == clienteId).FirstOrDefaultAsync();
                return cliente;
            }
        }

        public async Task<string> UpdateCliente(Cliente dto)
        {
            using (var context = await this.plantContextFactory.Create(""))
            {
                context.Clientes.Update(dto);
                await context.SaveAsync();
                return "";
            }
        }

        public async Task<string> DeleteCliente(Cliente dto)
        {
            using (var context = await this.plantContextFactory.Create(""))
            {
                context.Clientes.Remove(dto);
                await context.SaveAsync();
                return "";
            }
        }
    }
}
