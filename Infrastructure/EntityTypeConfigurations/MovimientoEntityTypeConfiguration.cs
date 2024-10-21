using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityTypeConfigurations
{
    public class MovimientoEntityTypeConfiguration : IEntityTypeConfiguration<Movimiento>
    {
        public void Configure(EntityTypeBuilder<Movimiento> builder)
        {
            builder
                .HasOne(e => e.Cuentas)
                .WithMany()
                .HasForeignKey(e => e.NumeroCuenta);
        }
    }
}
