﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aulao.orm.infra;

namespace aulao.orm.infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("aulao.orm.domain.Armacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Material")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CorId");

                    b.ToTable("Armacao");
                });

            modelBuilder.Entity("aulao.orm.domain.Cor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cor");
                });

            modelBuilder.Entity("aulao.orm.domain.Lente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GrauId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GrauId");

                    b.ToTable("Lente");
                });

            modelBuilder.Entity("aulao.orm.domain.LenteCaracteristica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Caracteristica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LenteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LenteId");

                    b.ToTable("LenteCaracteristica");
                });

            modelBuilder.Entity("aulao.orm.domain.LenteGrau", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Direito")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Esquerdo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LenteGrau");
                });

            modelBuilder.Entity("aulao.orm.domain.Oculos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ArmacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LenteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ArmacaoId");

                    b.HasIndex("LenteId");

                    b.ToTable("Oculos");
                });

            modelBuilder.Entity("aulao.orm.domain.Armacao", b =>
                {
                    b.HasOne("aulao.orm.domain.Cor", "Cor")
                        .WithMany()
                        .HasForeignKey("CorId");
                });

            modelBuilder.Entity("aulao.orm.domain.Lente", b =>
                {
                    b.HasOne("aulao.orm.domain.LenteGrau", "Grau")
                        .WithMany()
                        .HasForeignKey("GrauId");
                });

            modelBuilder.Entity("aulao.orm.domain.LenteCaracteristica", b =>
                {
                    b.HasOne("aulao.orm.domain.Lente", null)
                        .WithMany("Caracteristicas")
                        .HasForeignKey("LenteId");
                });

            modelBuilder.Entity("aulao.orm.domain.Oculos", b =>
                {
                    b.HasOne("aulao.orm.domain.Armacao", "Armacao")
                        .WithMany()
                        .HasForeignKey("ArmacaoId");

                    b.HasOne("aulao.orm.domain.Lente", "Lente")
                        .WithMany()
                        .HasForeignKey("LenteId");
                });
#pragma warning restore 612, 618
        }
    }
}
