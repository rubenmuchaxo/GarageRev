using GarageRev.Models;
using Microsoft.AspNetCore.Identity;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "c", Name = "Cliente", NormalizedName = "CLIENTE" },
                new IdentityRole { Id = "a", Name = "Admin", NormalizedName = "ADMIN" }
            );

            // insert DB seed

            modelBuilder.Entity<Carros>().HasData(
                new Carros { Id = 1, Marca = "BMW", Modelo = "i3", Versao = "120Ah", Combustivel = "Electric", Ano = 2017, CilindradaouCapacidadeBateria = 42, Potencia = 170, TipoCaixa = "1 speed Auto CVT", Nportas = "5",Foto="bmw_i3_120ah.jpg" },

                new Carros { Id = 2, Marca = "BMW", Modelo = "i3", Versao = "s 120Ah", Combustivel = "Electric", Ano = 2018, CilindradaouCapacidadeBateria = 42, Potencia = 184, TipoCaixa = "1 speed Auto CVT", Nportas = "5", Foto = "bmw_i3_s120ah.jpg" },
                new Carros { Id = 3, Marca = "BMW", Modelo = "i4", Versao = "M50", Combustivel = "Electric", Ano = 2021, CilindradaouCapacidadeBateria = 84, Potencia = 544, TipoCaixa = "1 speed Auto CVT", Nportas = "5", Foto = "bmw_i4_M50.jpg" },
                new Carros { Id = 4, Marca = "BMW", Modelo = "i4", Versao = "edrive40", Combustivel = "Electric", Ano = 2021, CilindradaouCapacidadeBateria = 84, Potencia = 340, TipoCaixa = "1 speed Auto CVT", Nportas = "5",  Foto = "BMW_i4_eDrive40.jpg" },
                new Carros { Id = 5, Marca = "BMW", Modelo = "F40 serie 1", Versao = "116i", Combustivel = "Petrol", Ano = 2020, CilindradaouCapacidadeBateria = 1499, Potencia = 109, TipoCaixa = "6 speed Manual", Nportas = "5", Foto = "bmw_F40 Serie 1_116i.jpg" },
                new Carros { Id = 6, Marca = "BMW", Modelo = "F40 serie 1", Versao = "118i Auto", Combustivel = "Petrol", Ano = 2021, CilindradaouCapacidadeBateria = 1499, Potencia = 136, TipoCaixa = "7 speed DualClutch Automatic", Nportas = "5", Foto = "bmw_F40 Serie 1_118i.jpg" },
                new Carros { Id = 7, Marca = "BMW", Modelo = "F40 serie 1", Versao = "128ti", Combustivel = "Petrol", Ano = 2020, CilindradaouCapacidadeBateria = 1998, Potencia = 265, TipoCaixa = "7 speed DualClutch Automatic", Nportas = "5", Foto = "bmw_F40 Serie 1_128i.jpg" },
                new Carros { Id = 8, Marca = "BMW", Modelo = "F40 serie 1", Versao = "M135i xDrive", Combustivel = "Petrol", Ano = 2019, CilindradaouCapacidadeBateria = 1998, Potencia = 306, TipoCaixa = "8 speed Automatic", Nportas = "5" , Foto = "bmw_F40 Serie 1_m135i.jpg"},
                new Carros { Id = 9, Marca = "BMW", Modelo = "G02 X4 LCI", Versao = "xDrive30i", Combustivel = "Petrol", Ano = 2021, CilindradaouCapacidadeBateria = 1998, Potencia = 245, TipoCaixa = "8 speed Automatic", Nportas = "5" , Foto = "bmw_G02_X4 LCI.jpg" },
                new Carros { Id = 10, Marca = "BMW", Modelo = "F44 serie 2 Gran Coupe", Versao = "218i", Combustivel = "Petrol", Ano = 2021, CilindradaouCapacidadeBateria = 1499, Potencia = 136, TipoCaixa = "6 speed Manual", Nportas = "4", Foto = "bmw_F44 Serie2 gran Coupe_218i.jpg" },
                new Carros { Id = 11, Marca = "BMW", Modelo = "G21 serie 3 Touring", Versao = "318i Auto", Combustivel = "Petrol", Ano = 2020, CilindradaouCapacidadeBateria = 1998, Potencia = 156, TipoCaixa = "8 speed Automatic", Nportas = "5", Foto = "bmw_g21 serie3 touring_318i auto.jpg" },
                new Carros { Id = 12, Marca = "BMW", Modelo = "G23 serie 4 Cabrio", Versao = "430i", Combustivel = "Petrol", Ano = 2021, CilindradaouCapacidadeBateria = 1998, Potencia = 258, TipoCaixa = "8 speed Automatic", Nportas = "2", Foto = "bmw g23 serie 4 cabrio.jpg" },
                new Carros { Id = 13, Marca = "Ford", Modelo = "Fiesta", Versao = "1.0 Ecoboost", Combustivel = "Petrol", Ano = 2022, CilindradaouCapacidadeBateria = 999, Potencia = 100, TipoCaixa = "6 speed Manual", Nportas = "5", Foto = "ford_fiesta.jpg" },
                new Carros { Id = 14, Marca = "Honda", Modelo = "Civic 10", Versao = "1.0 Turbo VTEC", Combustivel = "Petrol", Ano = 2017, CilindradaouCapacidadeBateria = 988, Potencia = 129, TipoCaixa = "1 speed auto CVT", Nportas = "5", Foto = "honda_civic.jpg" },
                new Carros { Id = 15, Marca = "Mitsubishi", Modelo = "L200 Club Cab ", Versao = "2.2 DI-D ClearTec", Combustivel = "Diesel", Ano = 2020, CilindradaouCapacidadeBateria = 2268, Potencia = 150, TipoCaixa = "6 speed Manual", Nportas = "2", Foto = "mitsubishi_l200.jpg" },
                new Carros { Id = 16, Marca = "Mitsubishi", Modelo = "Space Star ", Versao = "1.2", Combustivel = "Petrol", Ano = 2020, CilindradaouCapacidadeBateria = 1193, Potencia = 80, TipoCaixa = "5 speed Manul", Nportas = "5", Foto = "Mitsubishi-Space-Star.jpeg" },
                new Carros { Id = 17, Marca = "Nissan", Modelo = "Micra K14  ", Versao = "I-GT 100", Combustivel = "Petrol", Ano = 2019, CilindradaouCapacidadeBateria = 999, Potencia = 100, TipoCaixa = "1 speed auto CVT", Nportas = "5", Foto = "nissan_micra k14.jpg" },
                new Carros { Id = 18, Marca = "Nissan", Modelo = "Leaf 2", Versao = "40kWh", Combustivel = "Electric", Ano = 2017, CilindradaouCapacidadeBateria = 40, Potencia = 150, TipoCaixa = "1 speed Auto CVT", Nportas = "5", Foto = "nissan-leaf.jpg" },
                new Carros { Id = 19, Marca = "Nissan", Modelo = "Qashqai J12", Versao = "DIG-T 158", Combustivel = "Petrol", Ano = 2021, CilindradaouCapacidadeBateria = 1332, Potencia = 158, TipoCaixa = "6 speed Manual", Nportas = "5", Foto = "nissan_qashqai_J12.jpg" },
                new Carros { Id = 20, Marca = "Nissan", Modelo = "GT R", Versao = "Nismo", Combustivel = "Petrol", Ano = 2018, CilindradaouCapacidadeBateria = 3799, Potencia = 600, TipoCaixa = "6 speed DualClutch Automatic", Nportas = "3", Foto = "nissan_GTR_Nismo.jpg" },
                new Carros { Id = 21, Marca = "Nissan", Modelo = "R33 Skyline ", Versao = "GT-R 40th Anniversary Autech", Combustivel = "Petrol", Ano = 1998, CilindradaouCapacidadeBateria = 2568, Potencia = 280, TipoCaixa = "5 speed Manual", Nportas = "4", Foto = "nissan_r33_Skyline.jpg" },
                new Carros { Id = 22, Marca = "Opel", Modelo = "Corsa F", Versao = "1.5 Diesel", Combustivel = "Diesel", Ano = 2019, CilindradaouCapacidadeBateria = 1499, Potencia = 102, TipoCaixa = "6 speed Manual", Nportas = "5", Foto = "opel_corsa_f.jpg" },
                new Carros { Id = 23, Marca = "Peugeot", Modelo = "108", Versao = "3-door 1.0 e-VTi 72", Combustivel = "Petrol", Ano = 2018, CilindradaouCapacidadeBateria = 998, Potencia = 72, TipoCaixa = "5 speed Manual", Nportas = "3", Foto = "peugeot_108.jpg" },
                new Carros { Id = 24, Marca = "Peugeot", Modelo = "508 II SW", Versao = "BlueHDi 130 Auto", Combustivel = "Diesel", Ano = 2021, CilindradaouCapacidadeBateria = 1499, Potencia = 130, TipoCaixa = "8 speed Automatic", Nportas = "5", Foto = "peugeot_508 II sw.jpg" },
                new Carros { Id = 25, Marca = "Peugeot", Modelo = "208 Facelift", Versao = "1.0 PureTech 68 ", Combustivel = "Petrol", Ano = 2015, CilindradaouCapacidadeBateria = 999, Potencia = 68, TipoCaixa = "5 speed Manual", Nportas = "5", Foto = "peugeot_208_facelift.jpg" },
                new Carros { Id = 26, Marca = "Renault", Modelo = "Clio 5", Versao = "Blue DCi 85", Combustivel = "Diesel", Ano = 2019, CilindradaouCapacidadeBateria = 1461, Potencia = 85, TipoCaixa = "6 speed Manual", Nportas = "5", Foto = "renault_clio 5.jpg" },
                new Carros { Id = 27, Marca = "Ferrari", Modelo = "La Ferrari", Versao = "F70 F150 HY-KERS System 963HP", Combustivel = "Hybrid/Petrol", Ano = 2013, CilindradaouCapacidadeBateria = 6262, Potencia = 800, TipoCaixa = "7 speed Sequential", Nportas = "2", Foto = "ferrari_Laferrari_f70.jpg" }

                );

            modelBuilder.Entity<Categorias>().HasData(
                new Categorias { Id = 1, NomeCat = "Elétrico" },
                new Categorias { Id = 2, NomeCat = "Desportivo" },
                new Categorias { Id = 3, NomeCat = "Citadino" },
                new Categorias { Id = 4, NomeCat = "SUV" },
                new Categorias { Id = 5, NomeCat = "Mota" }

            );
        }

        //define table on the database
        public DbSet<GarageRev.Models.Carros> Carros { get; set; }
        public DbSet<GarageRev.Models.Utilizadores> Utilizadores { get; set; }
        public DbSet<GarageRev.Models.Reviews> Reviews { get; set; }
        public DbSet<GarageRev.Models.Categorias> Categorias { get; set; }

    }
}