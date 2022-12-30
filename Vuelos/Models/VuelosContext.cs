using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Vuelos.Models
{
    public partial class VuelosContext : DbContext
    {
        public VuelosContext()
        {
        }

        public VuelosContext(DbContextOptions<VuelosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Vuelo> Vuelo { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Aqui tienes que cambiar la ruta por la ruta del server de tu base de datos
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=Vuelos", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Vuelo>(entity =>
            {
                entity.HasKey(e => e.IdVuelo)
                    .HasName("PRIMARY");

                entity.ToTable("vuelo");

                entity.Property(e => e.ClaveVuelo).HasMaxLength(50);

                entity.Property(e => e.Destino).HasMaxLength(50);

                entity.Property(e => e.Hora).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
