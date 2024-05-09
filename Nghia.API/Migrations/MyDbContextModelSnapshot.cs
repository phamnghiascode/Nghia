﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nghia.API.Data;

#nullable disable

namespace Nghia.API.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Nghia.API.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ce6a68d1-b490-4d38-a162-21ce3c371bfa"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("f5a9b531-a099-493a-a05a-81c95627adbc"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("261f60b6-efa7-426d-8ea4-7b34cf9beba1"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("Nghia.API.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3a5d1dd2-abc5-412b-9e3d-c1b2648a228f"),
                            Code = "HN",
                            Name = "Ha Noi",
                            RegionImageUrl = ""
                        },
                        new
                        {
                            Id = new Guid("22715dff-abad-4263-837a-9e97d80fa86d"),
                            Code = "SG",
                            Name = "Sai Gon",
                            RegionImageUrl = ""
                        },
                        new
                        {
                            Id = new Guid("bc562c11-d7b2-478b-a75d-56a8da71b85a"),
                            Code = "DN",
                            Name = "Da Nang",
                            RegionImageUrl = ""
                        },
                        new
                        {
                            Id = new Guid("76675766-473f-4d1d-aba3-e4673f805d0c"),
                            Code = "NB",
                            Name = "Ninh Binh",
                            RegionImageUrl = ""
                        });
                });

            modelBuilder.Entity("Nghia.API.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("Nghia.API.Models.Domain.Walk", b =>
                {
                    b.HasOne("Nghia.API.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nghia.API.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
