using Domain.Interface.Persistence;
using Domain.Entity;
using Infrastructure.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class DomainDbContext : DbContext, IDomainDbContext
    {
        DatabaseFacade Database { get; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        public DomainDbContext(DbContextOptions<DomainDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CuentaEntityTypeConfiguration().Configure(modelBuilder.Entity<Cuenta>());
            new MovimientoEntityTypeConfiguration().Configure(modelBuilder.Entity<Movimiento>());
        }

        public async Task<int> SaveAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
