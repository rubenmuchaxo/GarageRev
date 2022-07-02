﻿// <auto-generated />
using System;
using GarageRev.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GarageRev.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarrosCategorias", b =>
                {
                    b.Property<int>("CarrosId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriasId")
                        .HasColumnType("int");

                    b.HasKey("CarrosId", "CategoriasId");

                    b.HasIndex("CategoriasId");

                    b.ToTable("CarrosCategorias", (string)null);
                });

            modelBuilder.Entity("GarageRev.Models.Carros", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<int>("CilindradaouCapacidadeBateria")
                        .HasColumnType("int");

                    b.Property<string>("Combustivel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nportas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Potencia")
                        .HasColumnType("int");

                    b.Property<string>("TipoCaixa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Versao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carros", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ano = 2017,
                            CilindradaouCapacidadeBateria = 42,
                            Combustivel = "Electric",
                            Foto = "bmw_i3_120ah.jpg",
                            Marca = "BMW",
                            Modelo = "i3",
                            Nportas = "5",
                            Potencia = 170,
                            TipoCaixa = "1 speed Auto CVT",
                            Versao = "120Ah"
                        },
                        new
                        {
                            Id = 2,
                            Ano = 2018,
                            CilindradaouCapacidadeBateria = 42,
                            Combustivel = "Electric",
                            Foto = "bmw_i3_s120ah.jpg",
                            Marca = "BMW",
                            Modelo = "i3",
                            Nportas = "5",
                            Potencia = 184,
                            TipoCaixa = "1 speed Auto CVT",
                            Versao = "s 120Ah"
                        },
                        new
                        {
                            Id = 3,
                            Ano = 2021,
                            CilindradaouCapacidadeBateria = 84,
                            Combustivel = "Electric",
                            Foto = "bmw_i4_M50.jpg",
                            Marca = "BMW",
                            Modelo = "i4",
                            Nportas = "5",
                            Potencia = 544,
                            TipoCaixa = "1 speed Auto CVT",
                            Versao = "M50"
                        },
                        new
                        {
                            Id = 4,
                            Ano = 2021,
                            CilindradaouCapacidadeBateria = 84,
                            Combustivel = "Electric",
                            Foto = "BMW_i4_eDrive40.jpg",
                            Marca = "BMW",
                            Modelo = "i4",
                            Nportas = "5",
                            Potencia = 340,
                            TipoCaixa = "1 speed Auto CVT",
                            Versao = "edrive40"
                        },
                        new
                        {
                            Id = 5,
                            Ano = 2020,
                            CilindradaouCapacidadeBateria = 1499,
                            Combustivel = "Petrol",
                            Foto = "bmw_F40 Serie 1_116i.jpg",
                            Marca = "BMW",
                            Modelo = "F40 serie 1",
                            Nportas = "5",
                            Potencia = 109,
                            TipoCaixa = "6 speed Manual",
                            Versao = "116i"
                        },
                        new
                        {
                            Id = 6,
                            Ano = 2021,
                            CilindradaouCapacidadeBateria = 1499,
                            Combustivel = "Petrol",
                            Foto = "bmw_F40 Serie 1_118i.jpg",
                            Marca = "BMW",
                            Modelo = "F40 serie 1",
                            Nportas = "5",
                            Potencia = 136,
                            TipoCaixa = "7 speed DualClutch Automatic",
                            Versao = "118i Auto"
                        },
                        new
                        {
                            Id = 7,
                            Ano = 2020,
                            CilindradaouCapacidadeBateria = 1998,
                            Combustivel = "Petrol",
                            Foto = "bmw_F40 Serie 1_128i.jpg",
                            Marca = "BMW",
                            Modelo = "F40 serie 1",
                            Nportas = "5",
                            Potencia = 265,
                            TipoCaixa = "7 speed DualClutch Automatic",
                            Versao = "128ti"
                        },
                        new
                        {
                            Id = 8,
                            Ano = 2019,
                            CilindradaouCapacidadeBateria = 1998,
                            Combustivel = "Petrol",
                            Foto = "bmw_F40 Serie 1_m135i.jpg",
                            Marca = "BMW",
                            Modelo = "F40 serie 1",
                            Nportas = "5",
                            Potencia = 306,
                            TipoCaixa = "8 speed Automatic",
                            Versao = "M135i xDrive"
                        },
                        new
                        {
                            Id = 9,
                            Ano = 2021,
                            CilindradaouCapacidadeBateria = 1998,
                            Combustivel = "Petrol",
                            Foto = "bmw_G02_X4 LCI.jpg",
                            Marca = "BMW",
                            Modelo = "G02 X4 LCI",
                            Nportas = "5",
                            Potencia = 245,
                            TipoCaixa = "8 speed Automatic",
                            Versao = "xDrive30i"
                        },
                        new
                        {
                            Id = 10,
                            Ano = 2021,
                            CilindradaouCapacidadeBateria = 1499,
                            Combustivel = "Petrol",
                            Foto = "bmw_f44 Serie2 gran Coupe_218i.jpg",
                            Marca = "BMW",
                            Modelo = "F44 serie 2 Gran Coupe",
                            Nportas = "4",
                            Potencia = 136,
                            TipoCaixa = "6 speed Manual",
                            Versao = "218i"
                        },
                        new
                        {
                            Id = 11,
                            Ano = 2020,
                            CilindradaouCapacidadeBateria = 1998,
                            Combustivel = "Petrol",
                            Foto = "bmw_g21 serie3 touring_318i auto.jpg",
                            Marca = "BMW",
                            Modelo = "G21 serie 3 Touring",
                            Nportas = "5",
                            Potencia = 156,
                            TipoCaixa = "8 speed Automatic",
                            Versao = "318i Auto"
                        },
                        new
                        {
                            Id = 12,
                            Ano = 2021,
                            CilindradaouCapacidadeBateria = 1998,
                            Combustivel = "Petrol",
                            Foto = "bmw g23 serie 4 cabrio.jpg",
                            Marca = "BMW",
                            Modelo = "G23 serie 4 Cabrio",
                            Nportas = "2",
                            Potencia = 258,
                            TipoCaixa = "8 speed Automatic",
                            Versao = "430i"
                        },
                        new
                        {
                            Id = 13,
                            Ano = 2022,
                            CilindradaouCapacidadeBateria = 999,
                            Combustivel = "Petrol",
                            Foto = "ford_fiesta.jpg",
                            Marca = "Ford",
                            Modelo = "Fiesta",
                            Nportas = "5",
                            Potencia = 100,
                            TipoCaixa = "6 speed Manual",
                            Versao = "1.0 Ecoboost"
                        },
                        new
                        {
                            Id = 14,
                            Ano = 2017,
                            CilindradaouCapacidadeBateria = 988,
                            Combustivel = "Petrol",
                            Foto = "honda_civic.jpg",
                            Marca = "Honda",
                            Modelo = "Civic 10",
                            Nportas = "5",
                            Potencia = 129,
                            TipoCaixa = "1 speed auto CVT",
                            Versao = "1.0 Turbo VTEC"
                        },
                        new
                        {
                            Id = 15,
                            Ano = 2020,
                            CilindradaouCapacidadeBateria = 2268,
                            Combustivel = "Diesel",
                            Foto = "mitsubishi_l200.jpg",
                            Marca = "Mitsubishi",
                            Modelo = "L200 Club Cab ",
                            Nportas = "2",
                            Potencia = 150,
                            TipoCaixa = "6 speed Manual",
                            Versao = "2.2 DI-D ClearTec"
                        },
                        new
                        {
                            Id = 16,
                            Ano = 2020,
                            CilindradaouCapacidadeBateria = 1193,
                            Combustivel = "Petrol",
                            Foto = "Mitsubishi-Space-Star.jpeg",
                            Marca = "Mitsubishi",
                            Modelo = "Space Star ",
                            Nportas = "5",
                            Potencia = 80,
                            TipoCaixa = "5 speed Manul",
                            Versao = "1.2"
                        },
                        new
                        {
                            Id = 17,
                            Ano = 2019,
                            CilindradaouCapacidadeBateria = 999,
                            Combustivel = "Petrol",
                            Foto = "nissan_micra k14.jpg",
                            Marca = "Nissan",
                            Modelo = "Micra K14  ",
                            Nportas = "5",
                            Potencia = 100,
                            TipoCaixa = "1 speed auto CVT",
                            Versao = "I-GT 100"
                        },
                        new
                        {
                            Id = 18,
                            Ano = 2017,
                            CilindradaouCapacidadeBateria = 40,
                            Combustivel = "Electric",
                            Foto = "nissan-leaf.jpg",
                            Marca = "Nissan",
                            Modelo = "Leaf 2",
                            Nportas = "5",
                            Potencia = 150,
                            TipoCaixa = "1 speed Auto CVT",
                            Versao = "40kWh"
                        },
                        new
                        {
                            Id = 19,
                            Ano = 2021,
                            CilindradaouCapacidadeBateria = 1332,
                            Combustivel = "Petrol",
                            Foto = "nissan_qashqai_J12.jpg",
                            Marca = "Nissan",
                            Modelo = "Qashqai J12",
                            Nportas = "5",
                            Potencia = 158,
                            TipoCaixa = "6 speed Manual",
                            Versao = "DIG-T 158"
                        },
                        new
                        {
                            Id = 20,
                            Ano = 2018,
                            CilindradaouCapacidadeBateria = 3799,
                            Combustivel = "Petrol",
                            Foto = "nissan_GTR_Nismo.jpg",
                            Marca = "Nissan",
                            Modelo = "GT R",
                            Nportas = "3",
                            Potencia = 600,
                            TipoCaixa = "6 speed DualClutch Automatic",
                            Versao = "Nismo"
                        },
                        new
                        {
                            Id = 21,
                            Ano = 1998,
                            CilindradaouCapacidadeBateria = 2568,
                            Combustivel = "Petrol",
                            Foto = "nissan_r33_Skyline.jpg",
                            Marca = "Nissan",
                            Modelo = "R33 Skyline ",
                            Nportas = "4",
                            Potencia = 280,
                            TipoCaixa = "5 speed Manual",
                            Versao = "GT-R 40th Anniversary Autech"
                        },
                        new
                        {
                            Id = 22,
                            Ano = 2019,
                            CilindradaouCapacidadeBateria = 1499,
                            Combustivel = "Diesel",
                            Foto = "opel_corsa_f.jpg",
                            Marca = "Opel",
                            Modelo = "Corsa F",
                            Nportas = "5",
                            Potencia = 102,
                            TipoCaixa = "6 speed Manual",
                            Versao = "1.5 Diesel"
                        },
                        new
                        {
                            Id = 23,
                            Ano = 2018,
                            CilindradaouCapacidadeBateria = 998,
                            Combustivel = "Petrol",
                            Foto = "peugeot_108.jpg",
                            Marca = "Peugeot",
                            Modelo = "108",
                            Nportas = "3",
                            Potencia = 72,
                            TipoCaixa = "5 speed Manual",
                            Versao = "3-door 1.0 e-VTi 72"
                        },
                        new
                        {
                            Id = 24,
                            Ano = 2021,
                            CilindradaouCapacidadeBateria = 1499,
                            Combustivel = "Diesel",
                            Foto = "peugeot_508 II sw.jpg",
                            Marca = "Peugeot",
                            Modelo = "508 II SW",
                            Nportas = "5",
                            Potencia = 130,
                            TipoCaixa = "8 speed Automatic",
                            Versao = "BlueHDi 130 Auto"
                        },
                        new
                        {
                            Id = 25,
                            Ano = 2015,
                            CilindradaouCapacidadeBateria = 999,
                            Combustivel = "Petrol",
                            Foto = "peugeot_208_facelift.jpg",
                            Marca = "Peugeot",
                            Modelo = "208 Facelift",
                            Nportas = "5",
                            Potencia = 68,
                            TipoCaixa = "5 speed Manual",
                            Versao = "1.0 PureTech 68 "
                        },
                        new
                        {
                            Id = 26,
                            Ano = 2019,
                            CilindradaouCapacidadeBateria = 1461,
                            Combustivel = "Diesel",
                            Foto = "renault_clio 5.jpg",
                            Marca = "Renault",
                            Modelo = "Clio 5",
                            Nportas = "5",
                            Potencia = 85,
                            TipoCaixa = "6 speed Manual",
                            Versao = "Blue DCi 85"
                        },
                        new
                        {
                            Id = 27,
                            Ano = 2013,
                            CilindradaouCapacidadeBateria = 6262,
                            Combustivel = "Hybrid/Petrol",
                            Foto = "ferrari_Laferrari_f70.jpg",
                            Marca = "Ferrari",
                            Modelo = "La Ferrari",
                            Nportas = "2",
                            Potencia = 800,
                            TipoCaixa = "7 speed Sequential",
                            Versao = "F70 F150 HY-KERS System 963HP"
                        });
                });

            modelBuilder.Entity("GarageRev.Models.Categorias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NomeCat")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorias", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NomeCat = "Elétrico"
                        },
                        new
                        {
                            Id = 2,
                            NomeCat = "Desportivo"
                        },
                        new
                        {
                            Id = 3,
                            NomeCat = "Citadino"
                        },
                        new
                        {
                            Id = 4,
                            NomeCat = "SUV"
                        },
                        new
                        {
                            Id = 5,
                            NomeCat = "Mota"
                        });
                });

            modelBuilder.Entity("GarageRev.Models.Reviews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarroFK")
                        .HasColumnType("int");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("UtilizadorFK")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarroFK");

                    b.HasIndex("UtilizadorFK");

                    b.ToTable("Reviews", (string)null);
                });

            modelBuilder.Entity("GarageRev.Models.Utilizadores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarroFavorito")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUtilizador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nacionalidade")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CarroFavorito");

                    b.ToTable("Utilizadores", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "c",
                            ConcurrencyStamp = "bb5458d1-13a7-4e3b-920d-3e1b9e3fbd69",
                            Name = "Cliente",
                            NormalizedName = "CLIENTE"
                        },
                        new
                        {
                            Id = "a",
                            ConcurrencyStamp = "1f0dd35b-925f-4333-b2d0-65334dbbaaac",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CarrosCategorias", b =>
                {
                    b.HasOne("GarageRev.Models.Carros", null)
                        .WithMany()
                        .HasForeignKey("CarrosId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GarageRev.Models.Categorias", null)
                        .WithMany()
                        .HasForeignKey("CategoriasId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("GarageRev.Models.Reviews", b =>
                {
                    b.HasOne("GarageRev.Models.Carros", "Carro")
                        .WithMany("Reviews")
                        .HasForeignKey("CarroFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GarageRev.Models.Utilizadores", "Utilizador")
                        .WithMany("Reviews")
                        .HasForeignKey("UtilizadorFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Carro");

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("GarageRev.Models.Utilizadores", b =>
                {
                    b.HasOne("GarageRev.Models.Carros", "Carros")
                        .WithMany("Utilizadores")
                        .HasForeignKey("CarroFavorito")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Carros");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("GarageRev.Models.Carros", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("Utilizadores");
                });

            modelBuilder.Entity("GarageRev.Models.Utilizadores", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
