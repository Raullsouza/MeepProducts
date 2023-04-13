﻿// <auto-generated />
using System;
using MeepProducts.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeepProducts.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230413212654_Add-Migration CriandoBD")]
    partial class AddMigrationCriandoBD
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MeepProducts.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PortalId")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId");

                    b.HasIndex("PortalId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("MeepProducts.Models.Local", b =>
                {
                    b.Property<int>("LocalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocalId"));

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocalId");

                    b.ToTable("Locais");
                });

            modelBuilder.Entity("MeepProducts.Models.Portal", b =>
                {
                    b.Property<int>("PortalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PortalId"));

                    b.Property<int>("LocalId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PortalId");

                    b.HasIndex("LocalId");

                    b.ToTable("Portais");
                });

            modelBuilder.Entity("MeepProducts.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutoId"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Preco")
                        .HasColumnType("int");

                    b.HasKey("ProdutoId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("MeepProducts.Models.Categoria", b =>
                {
                    b.HasOne("MeepProducts.Models.Portal", "Portal")
                        .WithMany("Categorias")
                        .HasForeignKey("PortalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portal");
                });

            modelBuilder.Entity("MeepProducts.Models.Portal", b =>
                {
                    b.HasOne("MeepProducts.Models.Local", "Local")
                        .WithMany("Portais")
                        .HasForeignKey("LocalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Local");
                });

            modelBuilder.Entity("MeepProducts.Models.Produto", b =>
                {
                    b.HasOne("MeepProducts.Models.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("MeepProducts.Models.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("MeepProducts.Models.Local", b =>
                {
                    b.Navigation("Portais");
                });

            modelBuilder.Entity("MeepProducts.Models.Portal", b =>
                {
                    b.Navigation("Categorias");
                });
#pragma warning restore 612, 618
        }
    }
}