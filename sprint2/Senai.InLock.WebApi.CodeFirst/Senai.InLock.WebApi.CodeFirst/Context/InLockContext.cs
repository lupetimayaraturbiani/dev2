using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Context
{
    public class InLockContext : DbContext
    {
        public DbSet<TipoUsuario> TipoUsuario { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Estudios> Estudios { get; set; }

        public DbSet<Jogos> Jogos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Sever=DEV601\\SQLEXPRESS; Database = InLock_Games_Tarde_CodeFirst; user Id = sa; pdw = sa@132");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoUsuario>().HasData(
                new TipoUsuario
                {
                    IdTipoUsuario = 1,
                    Titulo = "Administrador"
                },
                new TipoUsuario
                {
                    IdTipoUsuario = 2,
                    Titulo = "Comum"
                });

            modelBuilder.Entity<Usuarios>().HasData(
                new Usuarios
                {
                    IdUsuario = 1,
                    Email = "admin@admin.com",
                    Senha = "admin",
                    IdTipoUsuario = 1
                },
                new Usuarios
                {
                    IdUsuario = 2,
                    Email = "cliente@cliente.com",
                    Senha = "cliente",
                    IdTipoUsuario = 2
                });

            modelBuilder.Entity<Estudios>().HasData(
                new Estudios
                {
                    IdEstudio = 1,
                    NomeEstudio = "Blizzard"
                },
                new Estudios
                {
                    IdEstudio = 2,
                    NomeEstudio = "Rockstar Studios"
                },
                new Estudios
                {
                    IdEstudio = 3,
                    NomeEstudio = "Square Enix"
                });

            modelBuilder.Entity<Jogos>().HasData(
                new Jogos
                {
                    IdJogo = 1,
                    NomeJogo = "Diablo 3",
                    DataLancamento = Convert.ToDateTime("15/03/2012"),
                    Descricao = "É um jogo que contém bastante ação e é viciante, seja você um novato ou fã",
                    Valor = Convert.ToDecimal("99,00"),
                    IdEstudio = 1
                },
                new Jogos
                {
                    IdJogo = 2,
                    NomeJogo = "Red Dead Redemption II",
                    DataLancamento = Convert.ToDateTime("26/10/2018"),
                    Descricao = "Jogo eletrônico de ação-aventura western",
                    Valor = Convert.ToDecimal("120,00"),
                    IdEstudio = 2
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
