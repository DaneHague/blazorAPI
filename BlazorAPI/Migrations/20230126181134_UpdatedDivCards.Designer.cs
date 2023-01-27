﻿// <auto-generated />
using BlazorAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorAPI.Migrations
{
    [DbContext(typeof(PoEDBContext))]
    [Migration("20230126181134_UpdatedDivCards")]
    partial class UpdatedDivCards
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorAPI.Models.DivinationCard", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("artFilename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("baseType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("flavourText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("frameType")
                        .HasColumnType("int");

                    b.Property<int>("h")
                        .HasColumnType("int");

                    b.Property<string>("icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("identified")
                        .HasColumnType("bit");

                    b.Property<int>("ilvl")
                        .HasColumnType("int");

                    b.Property<string>("inventoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("league")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("maxStackSize")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("stackSize")
                        .HasColumnType("int");

                    b.Property<string>("typeLine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("verified")
                        .HasColumnType("bit");

                    b.Property<int>("w")
                        .HasColumnType("int");

                    b.Property<int>("x")
                        .HasColumnType("int");

                    b.Property<int>("y")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("DivinationCard");
                });

            modelBuilder.Entity("BlazorAPI.Models.TestModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TestModel");
                });
#pragma warning restore 612, 618
        }
    }
}
