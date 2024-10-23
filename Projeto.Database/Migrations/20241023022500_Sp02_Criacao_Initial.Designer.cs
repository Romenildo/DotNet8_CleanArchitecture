﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Projeto.Database.Context;

#nullable disable

namespace Projeto.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241023022500_Sp02_Criacao_Initial")]
    partial class Sp02_Criacao_Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Projeto.Model.Entities.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("ativo");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("data_criacao");

                    b.Property<Guid?>("EnderecoId")
                        .HasColumnType("uuid")
                        .HasColumnName("endereco_id");

                    b.Property<DateTime>("InativedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("data_inativacao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("data_atualizacao");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("cliente", (string)null);
                });

            modelBuilder.Entity("Projeto.Model.Entities.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("InativedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Projeto.Model.Entities.Cliente", b =>
                {
                    b.HasOne("Projeto.Model.Entities.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.Navigation("Endereco");
                });
#pragma warning restore 612, 618
        }
    }
}