﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimuladorATM.Banco;

#nullable disable

namespace SimuladorATM.Migrations
{
    [DbContext(typeof(SimuladorATMContext))]
    [Migration("20240626151113_InserirDadosConta")]
    partial class InserirDadosConta
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SimuladorATM.Modelos.DadosConta", b =>
                {
                    b.Property<int>("Conta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Conta"));

                    b.Property<string>("Agencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titular")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Conta");

                    b.ToTable("DadosContas");
                });
#pragma warning restore 612, 618
        }
    }
}
