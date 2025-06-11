using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Gestor_de_eventos.Modelos;

public partial class GestorEventosContext : DbContext
{
    public GestorEventosContext()
    {
    }

    public GestorEventosContext(DbContextOptions<GestorEventosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistente> Asistentes { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=MSI;Database=GestorEventos;User Id=sa;Password=0928;Encrypt=True;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asistente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Asistent__3214EC07F9EFD6E4");

            entity.ToTable("Asistente");

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(11)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Evento__3214EC07D2B8B2F4");

            entity.ToTable("Evento");

            entity.Property(e => e.Capacidad).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ticket__3214EC079CD2397A");

            entity.ToTable("Ticket");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FechaTicket)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Ticket");
            entity.Property(e => e.IdAsistente).HasColumnName("Id_Asistente");
            entity.Property(e => e.IdEvento).HasColumnName("Id_Evento");
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TipoTicket)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Tipo_Ticket");

            entity.HasOne(d => d.IdAsistenteNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.IdAsistente)
                .HasConstraintName("FK_Ticket_Asistente");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.IdEvento)
                .HasConstraintName("FK_Ticket_Evento");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
