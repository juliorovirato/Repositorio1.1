﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using SistemaAC.Data;
using System;

namespace SistemaAC.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190428200840_[Migration3]")]
    partial class Migration3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SistemaAC.Models.Actividades", b =>
                {
                    b.Property<int>("ActividadesID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cantidad");

                    b.Property<string>("Descripcion");

                    b.Property<bool>("Estado");

                    b.Property<string>("Nombre");

                    b.HasKey("ActividadesID");

                    b.ToTable("Actividades");
                });

            modelBuilder.Entity("SistemaAC.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SistemaAC.Models.Asignacion", b =>
                {
                    b.Property<int>("AsignacionID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActividadesID");

                    b.Property<DateTime>("Fecha");

                    b.Property<int>("InstructorID");

                    b.HasKey("AsignacionID");

                    b.ToTable("Asignacion");
                });

            modelBuilder.Entity("SistemaAC.Models.Horario", b =>
                {
                    b.Property<int>("HorarioID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActividadesID");

                    b.Property<string>("Dia");

                    b.Property<string>("Hora");

                    b.HasKey("HorarioID");

                    b.HasIndex("ActividadesID");

                    b.ToTable("Horario");
                });

            modelBuilder.Entity("SistemaAC.Models.Maquinaria", b =>
                {
                    b.Property<int>("MaquinariaID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActividadesID");

                    b.Property<string>("Cantidad");

                    b.Property<string>("Nombre");

                    b.HasKey("MaquinariaID");

                    b.HasIndex("ActividadesID");

                    b.ToTable("Maquinaria");
                });

            modelBuilder.Entity("SistemaAC.Models.Persona", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellidos");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Documento");

                    b.Property<string>("Email");

                    b.Property<bool>("Estado");

                    b.Property<string>("Nombres");

                    b.Property<string>("Telefono");

                    b.HasKey("ID");

                    b.ToTable("Persona");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("SistemaAC.Models.Tarifas", b =>
                {
                    b.Property<int>("TarifaID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActividadesID");

                    b.Property<double>("ValorEmp");

                    b.Property<double>("ValorEst");

                    b.Property<double>("ValorFam");

                    b.Property<double>("ValorGrad");

                    b.HasKey("TarifaID");

                    b.HasIndex("ActividadesID");

                    b.ToTable("Tarifas");
                });

            modelBuilder.Entity("SistemaAC.Models.Beneficiario", b =>
                {
                    b.HasBaseType("SistemaAC.Models.Persona");

                    b.Property<string>("Codigo");

                    b.ToTable("Beneficiario");

                    b.HasDiscriminator().HasValue("Beneficiario");
                });

            modelBuilder.Entity("SistemaAC.Models.Instructor", b =>
                {
                    b.HasBaseType("SistemaAC.Models.Persona");

                    b.Property<string>("Especialidad");

                    b.ToTable("Instructor");

                    b.HasDiscriminator().HasValue("Instructor");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SistemaAC.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SistemaAC.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SistemaAC.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SistemaAC.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaAC.Models.Horario", b =>
                {
                    b.HasOne("SistemaAC.Models.Actividades", "Actividades")
                        .WithMany("Horario")
                        .HasForeignKey("ActividadesID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaAC.Models.Maquinaria", b =>
                {
                    b.HasOne("SistemaAC.Models.Actividades", "Actividades")
                        .WithMany("Maquinaria")
                        .HasForeignKey("ActividadesID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaAC.Models.Tarifas", b =>
                {
                    b.HasOne("SistemaAC.Models.Actividades", "Actividades")
                        .WithMany("Tarifas")
                        .HasForeignKey("ActividadesID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
