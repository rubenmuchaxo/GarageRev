using GarageRev.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GarageRev.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        /// <summary>
        /// it executes code before the creation of model
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // imports the previous execution of this method
            base.OnModelCreating(modelBuilder);

            //*****************************************
            // add, at this point, your new code

            // create the seed of your tables

            modelBuilder.Entity<Carros>().HasData(
               new Carros { Id = 2, Marca = "Mercedes", Modelo = "Cão", Versão = "Pastor Alemão", Combustivel = "Gasolina", Ano = 2018, Cilindrada = 1500, Potencia = 2500, TipoCaixa = "Automática", Nportas = "5", Fotografia = "noCar.png" }
            );

        }

        //define table on the database
        public DbSet<Carros> Carros { get; set; }
        public DbSet<Utilizadores> Utilizadores { get; set; }
        public DbSet<Fotografias> Fotografias { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<GarageRev.Models.Categorias> Categorias { get; set; }

    }
}