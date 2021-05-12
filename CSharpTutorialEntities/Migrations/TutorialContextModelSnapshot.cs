﻿// <auto-generated />
using System;
using CSharpTutorialEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CSharpTutorialEntities.Migrations
{
    [DbContext(typeof(TutorialContext))]
    partial class TutorialContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CSharpTutorialEntities.Models.CarCompany", b =>
                {
                    b.Property<Guid>("CarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CarCompanyName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("PersonEntityID")
                        .HasColumnType("char(36)");

                    b.HasKey("CarID");

                    b.HasIndex("PersonEntityID");

                    b.ToTable("CarCompany");
                });

            modelBuilder.Entity("CSharpTutorialEntities.Models.FoodCompany", b =>
                {
                    b.Property<Guid>("FoodCompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("FoodComanyName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("FoodCompanyID");

                    b.ToTable("FoodCompany");
                });

            modelBuilder.Entity("CSharpTutorialEntities.Models.PersonEntity", b =>
                {
                    b.Property<Guid>("PersonEntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("PersonEntityID");

                    b.ToTable("PersonEntity");
                });

            modelBuilder.Entity("CSharpTutorialEntities.Models.CarCompany", b =>
                {
                    b.HasOne("CSharpTutorialEntities.Models.PersonEntity", "PersonEntity")
                        .WithMany()
                        .HasForeignKey("PersonEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
