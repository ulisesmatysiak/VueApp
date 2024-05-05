using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VueApp_API.Models;

public partial class VueappDbContext : DbContext
{
    public VueappDbContext()
    {
    }

    public VueappDbContext(DbContextOptions<VueappDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Publicacion> Publicacions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-O5DKPSA\\SQLEXPRESS; Database=VUEAPP_DB; Integrated Security=true; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Publicacion>(entity =>
        {
            entity.HasKey(e => e.IdPublicacion).HasName("PK__PUBLICAC__24F1B7D364E5F04D");

            entity.ToTable("PUBLICACION");

            entity.Property(e => e.Antiguedad).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.CoordenadasUbicacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Imagenes)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TipoOperacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoPropiedad)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
