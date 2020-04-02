using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebDBFirst.Models
{
    public partial class PruebaWebDBContext : DbContext
    {
        public PruebaWebDBContext()
        {
        }

        public PruebaWebDBContext(DbContextOptions<PruebaWebDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<CompraProducto> CompraProducto { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Tests> Tests { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source = DESKTOP-RFKKK95\\SQLEXPRESS; Initial Catalog = PruebaWebDB; Integrated Security = True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apellidos).IsRequired();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Nombres).IsRequired();

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UrlFoto)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasIndex(e => e.ApplicationUserId);

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.Compra)
                    .HasForeignKey(d => d.ApplicationUserId);
            });

            modelBuilder.Entity<CompraProducto>(entity =>
            {
                entity.HasKey(e => new { e.CompraId, e.ProductoId });

                entity.HasIndex(e => e.Id)
                    .HasName("AK_CompraProducto_Id")
                    .IsUnique();

                entity.HasIndex(e => e.ProductoId);

                entity.Property(e => e.PrecioUnitarioFinal).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Compra)
                    .WithMany(p => p.CompraProducto)
                    .HasForeignKey(d => d.CompraId);

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.CompraProducto)
                    .HasForeignKey(d => d.ProductoId);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasIndex(e => e.NombreProducto)
                    .IsUnique();

                entity.Property(e => e.ImagenUrl).HasColumnName("ImagenURL");

                entity.Property(e => e.NombreProducto).IsRequired();

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Tests>(entity =>
            {
                entity.Property(e => e.Apellidos).IsRequired();

                entity.Property(e => e.Nombres).IsRequired();
            });
        }
    }
}
