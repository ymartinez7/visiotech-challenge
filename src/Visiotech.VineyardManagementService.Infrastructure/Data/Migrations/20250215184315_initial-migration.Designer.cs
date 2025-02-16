﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Visiotech.VineyardManagementService.Infrastructure.Data.Context;

#nullable disable

namespace Visiotech.VineyardManagementService.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250215184315_initial-migration")]
    partial class initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Visiotech.VineyardManagementService.Domain.Entities.Grape", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Grapes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tempranillo"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Albariño"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Garnacha"
                        });
                });

            modelBuilder.Entity("Visiotech.VineyardManagementService.Domain.Entities.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Managers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Miguel Torres",
                            TaxNumber = "132254524"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ana Martín",
                            TaxNumber = "143618668"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Carlos Ruiz",
                            TaxNumber = "78903228"
                        });
                });

            modelBuilder.Entity("Visiotech.VineyardManagementService.Domain.Entities.Parcel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<int>("GrapeId")
                        .HasColumnType("int");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<int>("VineyardId")
                        .HasColumnType("int");

                    b.Property<int>("YearPlanted")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GrapeId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("VineyardId");

                    b.ToTable("Parcels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Area = 1500,
                            GrapeId = 1,
                            ManagerId = 1,
                            VineyardId = 1,
                            YearPlanted = 2019
                        },
                        new
                        {
                            Id = 2,
                            Area = 9000,
                            GrapeId = 2,
                            ManagerId = 2,
                            VineyardId = 2,
                            YearPlanted = 2021
                        },
                        new
                        {
                            Id = 3,
                            Area = 3000,
                            GrapeId = 3,
                            ManagerId = 3,
                            VineyardId = 1,
                            YearPlanted = 2020
                        },
                        new
                        {
                            Id = 4,
                            Area = 2000,
                            GrapeId = 1,
                            ManagerId = 1,
                            VineyardId = 2,
                            YearPlanted = 2020
                        },
                        new
                        {
                            Id = 5,
                            Area = 1000,
                            GrapeId = 3,
                            ManagerId = 3,
                            VineyardId = 2,
                            YearPlanted = 2021
                        });
                });

            modelBuilder.Entity("Visiotech.VineyardManagementService.Domain.Entities.Vineyard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vineyards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Viña Esmeralda"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bodegas Bilbaínas"
                        });
                });

            modelBuilder.Entity("Visiotech.VineyardManagementService.Domain.Entities.Parcel", b =>
                {
                    b.HasOne("Visiotech.VineyardManagementService.Domain.Entities.Grape", "Grape")
                        .WithMany("Parcels")
                        .HasForeignKey("GrapeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Visiotech.VineyardManagementService.Domain.Entities.Manager", "Manager")
                        .WithMany("Parcels")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Visiotech.VineyardManagementService.Domain.Entities.Vineyard", "Vineyard")
                        .WithMany("Parcels")
                        .HasForeignKey("VineyardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Grape");

                    b.Navigation("Manager");

                    b.Navigation("Vineyard");
                });

            modelBuilder.Entity("Visiotech.VineyardManagementService.Domain.Entities.Grape", b =>
                {
                    b.Navigation("Parcels");
                });

            modelBuilder.Entity("Visiotech.VineyardManagementService.Domain.Entities.Manager", b =>
                {
                    b.Navigation("Parcels");
                });

            modelBuilder.Entity("Visiotech.VineyardManagementService.Domain.Entities.Vineyard", b =>
                {
                    b.Navigation("Parcels");
                });
#pragma warning restore 612, 618
        }
    }
}
