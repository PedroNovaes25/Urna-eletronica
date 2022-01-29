﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UrnaEletronica.Persistencia._BDContexto;

namespace UrnaEletronica.Persistencia.Migrations
{
    [DbContext(typeof(UrnaBDContext))]
    [Migration("20220129213655_atualizando")]
    partial class atualizando
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UrnaEletronica.Dominio.Candidato", b =>
                {
                    b.Property<int>("LegendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataDeRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Legenda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeVice")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LegendaId");

                    b.ToTable("Candidatos");

                    b.HasData(
                        new
                        {
                            LegendaId = 8,
                            DataDeRegistro = new DateTime(2022, 1, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            Nome = "Branco"
                        },
                        new
                        {
                            LegendaId = 9,
                            DataDeRegistro = new DateTime(2022, 1, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            Nome = "Nulo"
                        });
                });

            modelBuilder.Entity("UrnaEletronica.Dominio.Voto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CandidatoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDeVoto")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CandidatoId");

                    b.ToTable("Votos");
                });

            modelBuilder.Entity("UrnaEletronica.Dominio.Voto", b =>
                {
                    b.HasOne("UrnaEletronica.Dominio.Candidato", "Candidato")
                        .WithMany("Votos")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidato");
                });

            modelBuilder.Entity("UrnaEletronica.Dominio.Candidato", b =>
                {
                    b.Navigation("Votos");
                });
#pragma warning restore 612, 618
        }
    }
}
