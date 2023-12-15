﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(SolicitudesPlatformContext))]
    [Migration("20231215200728_configuracion-relaciones")]
    partial class configuracionrelaciones
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Features.EstadoSolicitud.EstadoSolicitudEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.ToTable("EstadoSolicitud");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Estado = "Pendiente",
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Estado = "Aprobado",
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Estado = "Cancelado",
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Core.Features.Genero.GeneroEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genero");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Tipo = "Masculino"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Tipo = "Femenino"
                        });
                });

            modelBuilder.Entity("Core.Features.Solicitud.SolicitudEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("EstadoSolicitudId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("TipoSolicitudId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("ZonaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstadoSolicitudId");

                    b.HasIndex("TipoSolicitudId");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("ZonaId");

                    b.ToTable("Solicitud");
                });

            modelBuilder.Entity("Core.Features.TipoSolicitud.TipoSolicitudEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TipoSolicitud");
                });

            modelBuilder.Entity("Core.Features.TipoUsuario.TipoUsuarioEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TipoUsuario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Tipo = "Interno"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Tipo = "Externo"
                        });
                });

            modelBuilder.Entity("Core.Features.Usuario.UsuarioEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("ImagenUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoUsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GeneroId");

                    b.HasIndex("TipoUsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Core.Features.UsuarioTipoSolicitud.UsuarioTipoSolicitudEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("TipoSolicitudId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoSolicitudId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioSolicitud");
                });

            modelBuilder.Entity("Core.Features.UsuarioZona.UsuarioZonaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("ZonaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("ZonaId");

                    b.ToTable("UsuarioZona");
                });

            modelBuilder.Entity("Core.Features.Zona.ZonaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Zona");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Norte"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Sur"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Este"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Oeste"
                        });
                });

            modelBuilder.Entity("Core.Features.Solicitud.SolicitudEntity", b =>
                {
                    b.HasOne("Core.Features.EstadoSolicitud.EstadoSolicitudEntity", "EstadoSolicitud")
                        .WithMany("Solicitudes")
                        .HasForeignKey("EstadoSolicitudId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Features.TipoSolicitud.TipoSolicitudEntity", "TipoSolicitud")
                        .WithMany("Solicitudes")
                        .HasForeignKey("TipoSolicitudId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Features.Usuario.UsuarioEntity", "Usuario")
                        .WithMany("Solicitudes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Features.Zona.ZonaEntity", "Zona")
                        .WithMany("Solicitudes")
                        .HasForeignKey("ZonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoSolicitud");

                    b.Navigation("TipoSolicitud");

                    b.Navigation("Usuario");

                    b.Navigation("Zona");
                });

            modelBuilder.Entity("Core.Features.Usuario.UsuarioEntity", b =>
                {
                    b.HasOne("Core.Features.Genero.GeneroEntity", "Genero")
                        .WithMany("Usuarios")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Features.TipoUsuario.TipoUsuarioEntity", "TipoUsuario")
                        .WithMany("Usuarios")
                        .HasForeignKey("TipoUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");

                    b.Navigation("TipoUsuario");
                });

            modelBuilder.Entity("Core.Features.UsuarioTipoSolicitud.UsuarioTipoSolicitudEntity", b =>
                {
                    b.HasOne("Core.Features.TipoSolicitud.TipoSolicitudEntity", "TipoSolicitud")
                        .WithMany("UsuariosTipoSolicitud")
                        .HasForeignKey("TipoSolicitudId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Features.Usuario.UsuarioEntity", "Usuario")
                        .WithMany("UsuariosTipoSolicitud")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoSolicitud");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Core.Features.UsuarioZona.UsuarioZonaEntity", b =>
                {
                    b.HasOne("Core.Features.Usuario.UsuarioEntity", "Usuario")
                        .WithMany("UsuariosZona")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Features.Zona.ZonaEntity", "Zona")
                        .WithMany("UsuariosZona")
                        .HasForeignKey("ZonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");

                    b.Navigation("Zona");
                });

            modelBuilder.Entity("Core.Features.EstadoSolicitud.EstadoSolicitudEntity", b =>
                {
                    b.Navigation("Solicitudes");
                });

            modelBuilder.Entity("Core.Features.Genero.GeneroEntity", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Core.Features.TipoSolicitud.TipoSolicitudEntity", b =>
                {
                    b.Navigation("Solicitudes");

                    b.Navigation("UsuariosTipoSolicitud");
                });

            modelBuilder.Entity("Core.Features.TipoUsuario.TipoUsuarioEntity", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Core.Features.Usuario.UsuarioEntity", b =>
                {
                    b.Navigation("Solicitudes");

                    b.Navigation("UsuariosTipoSolicitud");

                    b.Navigation("UsuariosZona");
                });

            modelBuilder.Entity("Core.Features.Zona.ZonaEntity", b =>
                {
                    b.Navigation("Solicitudes");

                    b.Navigation("UsuariosZona");
                });
#pragma warning restore 612, 618
        }
    }
}
