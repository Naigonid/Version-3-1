﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sciaraffia.Entidades;

namespace Sciaraffia.Migrations
{
    [DbContext(typeof(HorarioDbContext))]
    partial class HorarioDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15");

            modelBuilder.Entity("Sciaraffia.Entidades.HorarioCita", b =>
                {
                    b.Property<int>("serial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("hora")
                        .HasColumnType("TEXT");

                    b.Property<string>("usuario")
                        .HasColumnType("TEXT");

                    b.HasKey("serial");

                    b.ToTable("HorarioC");
                });

            modelBuilder.Entity("Sciaraffia.Entidades.Usuario", b =>
                {
                    b.Property<string>("correo")
                        .HasColumnType("TEXT");

                    b.Property<string>("clave")
                        .HasColumnType("TEXT");

                    b.Property<string>("nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("correo");

                    b.ToTable("usuarioC");
                });
#pragma warning restore 612, 618
        }
    }
}
