using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Domain.Interface.Persistence
{
    public interface IDomainDbContext : IDisposable
    {
        DbSet<Persona> Personas { get; set; }
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Cuenta> Cuentas { get; set; }
        DbSet<Movimiento> Movimientos { get; set; }
        DatabaseFacade Database { get; }
        Task<int> SaveAsync();
    }
}
