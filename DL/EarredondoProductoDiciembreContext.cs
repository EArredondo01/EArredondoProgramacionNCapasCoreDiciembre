using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class EarredondoProductoDiciembreContext : DbContext
{
    public EarredondoProductoDiciembreContext()
    {
    }

    public EarredondoProductoDiciembreContext(DbContextOptions<EarredondoProductoDiciembreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductoVwGetAll> ProductoVwGetAlls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database=EArredondoProductoDiciembre; TrustServerCertificate=True; Trusted_Connection=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__09889210AF26DA9F");

            entity.ToTable("Producto");

            entity.Property(e => e.Costo).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProductoVwGetAll>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ProductoVwGetAll");

            entity.Property(e => e.Costo).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdProducto).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
