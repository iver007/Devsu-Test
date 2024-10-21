using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityTypeConfigurations
{
    public class CuentaEntityTypeConfiguration : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder
                .HasOne(e => e.Clientes)
                .WithMany()
                .HasForeignKey(e => e.ClientesId);
        }
    }
}
