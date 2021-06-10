using app.api.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.api.Infrastructure.Data.Config
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes", AppDbContext.DEFAULT_SCHEMA);
            builder.Ignore(p => p.DomainEvents);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.NombreCompleto).IsRequired();
            builder.Property(p => p.Estado).IsRequired();
        }
    }

    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Productos", AppDbContext.DEFAULT_SCHEMA);
            builder.Ignore(p => p.DomainEvents);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Descripcion).IsRequired();
        }
    }

    public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.ToTable("Facturas", AppDbContext.DEFAULT_SCHEMA);
            builder.Ignore(p => p.DomainEvents);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.IdentificadorCliente).IsRequired();
            builder.Property(p => p.Fecha).IsRequired();
            builder.Property(p => p.Total)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            var navigationDetalle = builder.Metadata.FindNavigation(nameof(Factura.Detalle));
            navigationDetalle.SetField("_detalle");
            navigationDetalle.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }

    public class DetalleFacturaConfiguration : IEntityTypeConfiguration<DetalleFactura>
    {
        public void Configure(EntityTypeBuilder<DetalleFactura> builder)
        {
            builder.ToTable("DetalleFactura", AppDbContext.DEFAULT_SCHEMA);
            builder.Ignore(p => p.DomainEvents);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.IdCliente).IsRequired();
            builder.Property(p => p.IdFactura).IsRequired();
            builder.Property(p => p.IdProducto).IsRequired();
            builder.Property(p => p.Precio).IsRequired();
            builder.Property(p => p.Cantidad).IsRequired();
            builder.Property(p => p.Subtotal)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
