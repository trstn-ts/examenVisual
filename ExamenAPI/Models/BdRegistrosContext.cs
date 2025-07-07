using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ExamenAPI.Models;

public partial class BdRegistrosContext : DbContext
{
    public BdRegistrosContext()
    {
    }

    public BdRegistrosContext(DbContextOptions<BdRegistrosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Registros> Registros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Registros>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Registros__756A540292BEDAF1");

            entity.ToTable("Registros");

            entity.Property(e => e.Id).HasColumnName("Id");

            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Titulo");

            entity.Property(e => e.Sinopsis)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Sinopsis");

            entity.Property(e => e.Portada)
               .HasMaxLength(250)
               .IsUnicode(false)
               .HasColumnName("Portada");

            entity.Property(e => e.Precio)
               .HasColumnType("decimal(18,2)")
               .HasColumnName("Precio");

            entity.Property(e => e.Genero)
               .HasMaxLength(100)
               .IsUnicode(false)
               .HasColumnName("Genero");
 
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
