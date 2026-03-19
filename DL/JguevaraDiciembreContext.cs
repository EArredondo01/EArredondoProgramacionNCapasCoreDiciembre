using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class JguevaraDiciembreContext : DbContext
{
    public JguevaraDiciembreContext()
    {
    }

    public JguevaraDiciembreContext(DbContextOptions<JguevaraDiciembreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Plantel> Plantels { get; set; }

    public virtual DbSet<Semestre> Semestres { get; set; }
    public virtual DbSet<MateriaGetAllDTO> MateriaGetAllDTO {  get; set; }
    public virtual DbSet<VwMateriaGetAll> VwMateriaGetAlls { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.; Database=JGuevaraDiciembre; TrustServerCertificate=True; Trusted_Connection=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MateriaGetAllDTO>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estado__FBB0EDC1A03F4744");

            entity.ToTable("Estado");

            entity.Property(e => e.IdEstado).ValueGeneratedNever();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.IdGrupo).HasName("PK__Grupo__303F6FD97A17E6BE");

            entity.ToTable("Grupo");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdMateriaNavigation).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.IdMateria)
                .HasConstraintName("FK__Grupo__IdMateria__24927208");

            entity.HasOne(d => d.IdPlantelNavigation).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.IdPlantel)
                .HasConstraintName("FK__Grupo__IdPlantel__25869641");
        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.IdMateria).HasName("PK__Materia__EC1746707E83B256");

            entity.HasIndex(e => e.Costo, "UQ_Costo").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__Materia__C9F284561187DC2E").IsUnique();

            entity.Property(e => e.Costo).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Promedio).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdSemestreNavigation).WithMany(p => p.Materia)
                .HasForeignKey(d => d.IdSemestre)
                .HasConstraintName("FK__Materia__IdSemes__267ABA7A");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.IdMunicipio).HasName("PK__Municipi__6100597820E5C2CA");

            entity.ToTable("Municipio");

            entity.Property(e => e.IdMunicipio).ValueGeneratedNever();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("IdEstado");
        });

        modelBuilder.Entity<Plantel>(entity =>
        {
            entity.HasKey(e => e.IdPlantel).HasName("PK__Plantel__485FDCFEEAF83A77");

            entity.ToTable("Plantel");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Semestre>(entity =>
        {
            entity.HasKey(e => e.IdSemestre).HasName("PK__Semestre__BD1FD7F83A6BF977");

            entity.ToTable("Semestre");

            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwMateriaGetAll>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwMateriaGetALl");

            entity.Property(e => e.Costo).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.IdMateria).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Promedio).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
