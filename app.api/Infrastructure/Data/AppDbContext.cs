using app.api.Core;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace app.api.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "App";

        public AppDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<DetalleFactura> DetalleFactura { get; set; }
    }

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(@"Server=.;Initial Catalog=AppDb;Integrated Security=False;User Id=sa; password=15560367o%");
            return new AppDbContext(builder.Options);
        }
    }
}
