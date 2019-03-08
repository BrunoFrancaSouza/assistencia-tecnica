﻿// <auto-generated />
using AssistenciaTecnica.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AssistenciaTecnica.WebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AssistenciaTecnica.WebAPI.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlteradoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("Ativo");

                    b.Property<string>("DataAlteração")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Empresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Perfil")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
