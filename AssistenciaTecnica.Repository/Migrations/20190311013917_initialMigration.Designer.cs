﻿// <auto-generated />
using System;
using AssistenciaTecnica.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AssistenciaTecnica.Repository.Migrations
{
    [DbContext(typeof(AssistenciaTecnicaContext))]
    [Migration("20190311013917_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AssistenciaTecnica.Domain.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlteradoPor")
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("Ativo");

                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("DataAlteracao");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("NomeFantasia")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Setor")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("AssistenciaTecnica.Domain.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlteradoPor")
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DataAlteracao");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("EmpresaId");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Perfil")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("AssistenciaTecnica.Domain.Usuario", b =>
                {
                    b.HasOne("AssistenciaTecnica.Domain.Empresa", "Empresa")
                        .WithMany("Usuarios")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}