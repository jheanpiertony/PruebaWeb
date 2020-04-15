using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CommonCore
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)");

            builder.Entity<CompraProducto>()
                .Property(puf => puf.PrecioUnitarioFinal)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Producto>()
                .HasIndex(np => np.NombreProducto)
                .IsUnique();

            builder.Entity<CompraProducto>()
                .HasKey(x => new 
                {
                    x.CompraId,
                    x.ProductoId
                });

            builder.Entity<Producto>()
                .HasQueryFilter(eb => eb.EstaBorrado == false);
            builder.Entity<Compra>()
                .HasQueryFilter(eb => eb.EstaBorrado == false).HasQueryFilter(ebcp => ebcp.EstaBorrado == false);
            builder.Entity<CompraProducto>().
                HasQueryFilter(ebc => ebc.Producto.EstaBorrado == true || ebc.EstaBorrado == true);

            //Seed
            //builder.Entity<CompraProducto>().HasData(
            //    new CompraProducto() 
            //    {
            //        Cantidad = 1, 
            //        CompraId = 1, 
            //        EstaBorrado = false, 
            //        Id = 1, 
            //        PrecioUnitarioFinal = 10000, 
            //        ProductoId = 1
            //    },
            //    new CompraProducto()
            //    {
            //        Cantidad = 2,
            //        CompraId = 1,
            //        EstaBorrado = false,
            //        Id = 2,
            //        PrecioUnitarioFinal = 1100,
            //        ProductoId = 2
            //    },
            //    new CompraProducto()
            //    {
            //        Cantidad = 3,
            //        CompraId = 1,
            //        EstaBorrado = false,
            //        Id = 3,
            //        PrecioUnitarioFinal = 2200,
            //        ProductoId = 4
            //    });

        }
        #region Borrado Suave en SaveChanges y SaveChangesAsync
        public override int SaveChanges()
        {
            //Borrado Suave
            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted &&
                e.Metadata.GetProperties().Any(x => x.Name == "EstaBorrado")))
            {
                item.State = EntityState.Unchanged;
                item.CurrentValues["EstaBorrado"] = true;
            }
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            //Borrado Suave
            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted &&
                e.Metadata.GetProperties().Any(x => x.Name == "EstaBorrado")))
            {
                item.State = EntityState.Unchanged;
                item.CurrentValues["EstaBorrado"] = true;
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        } 
        #endregion

        public DbSet<Producto> Productos { get; set; }
        public DbSet<DoWork> DoWorks { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<CompraProducto> ComprasProductos { get; set; }
    }
}
