using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Inlock.WebApi.DatabaseFirst.Domains
{
    public partial class InLockContext : DbContext
    {
        public InLockContext()
        {
        }

        public InLockContext(DbContextOptions<InLockContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estudios> Estudios { get; set; }
        public virtual DbSet<Jogos> Jogos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DEV601\\SQLEXPRESS; Initial Catalog=InLock_Games_Tarde; user Id=sa; pwd=sa@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudios>(entity =>
            {
                entity.HasKey(e => e.IdEstudio);

                entity.HasIndex(e => e.NomeEstudio)
                    .HasName("UQ__Estudios__112A56900106A13B")
                    .IsUnique();

                entity.Property(e => e.NomeEstudio)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Jogos>(entity =>
            {
                entity.HasKey(e => e.IdJogo);

                entity.HasIndex(e => e.NomeJogo)
                    .HasName("UQ__Jogos__89AF93E43C8959DD")
                    .IsUnique();

                entity.Property(e => e.DataLancamento).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeJogo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstudioNavigation)
                    .WithMany(p => p.Jogos)
                    .HasForeignKey(d => d.IdEstudio)
                    .HasConstraintName("FK__Jogos__IdEstudio__5AEE82B9");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.HasIndex(e => e.Titulo)
                    .HasName("UQ__TipoUsua__7B406B56BCE6C954")
                    .IsUnique();

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D10534B1BAE680")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuarios__IdTipo__4D94879B");
            });
        }
    }
}
