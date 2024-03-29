﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CommonCore
{
    public class ApplicationDbContext : IdentityDbContext<
        ApplicationUser, ApplicationRole, string,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
        ApplicationRoleClaim, ApplicationUserToken>
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-RFKKK95\\SQLEXPRESS; Initial Catalog = PruebaWebDB; Integrated Security = True;");
            }
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
                .HasQueryFilter(eb => eb.EstaBorrado);
            builder.Entity<Compra>()
                .HasQueryFilter(eb => eb.EstaBorrado).HasQueryFilter(ebcp => ebcp.EstaBorrado);
            builder.Entity<CompraProducto>().
                HasQueryFilter(ebc => ebc.Producto.EstaBorrado || ebc.EstaBorrado);


            builder.Entity<ApplicationUser>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne()
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne()
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne()
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne()
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            //https://docs.microsoft.com/es-es/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-2.2
            builder.Entity<ApplicationRole>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });
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

            //https://docs.microsoft.com/en-us/ef/core/saving/cascade-delete
            foreach (var foreingKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreingKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
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
