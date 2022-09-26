﻿// <auto-generated />
using System;
using G7Album.BaseDatos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace G7Album.BaseDatos.Migrations
{
    [DbContext(typeof(BDContext))]
    partial class BDContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("G7Album.BaseDatos.Entidades.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CantidadImagen")
                        .HasColumnType("int");

                    b.Property<int>("CantidadImpreso")
                        .HasColumnType("int");

                    b.Property<int>("CodigoAlbum")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("Desde")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Hasta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "Entity_Id")
                        .IsUnique();

                    b.ToTable("TablaAlbumes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CantidadImagen = 1000,
                            CantidadImpreso = 1000,
                            CodigoAlbum = 10,
                            Descripcion = "figus",
                            Desde = new DateTime(2022, 9, 25, 19, 42, 0, 903, DateTimeKind.Local).AddTicks(8898),
                            Hasta = new DateTime(2022, 10, 5, 19, 42, 0, 903, DateTimeKind.Local).AddTicks(8906),
                            Titulo = "album"
                        });
                });

            modelBuilder.Entity("G7Album.BaseDatos.Entidades.AlbumImagenes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int>("CantidadImpresa")
                        .HasColumnType("int");

                    b.Property<int>("CodigoImagenOriginal")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroImagen")
                        .HasColumnType("int");

                    b.Property<string>("PathModeloImagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex(new[] { "Id" }, "Entity_Id")
                        .IsUnique()
                        .HasDatabaseName("Entity_Id2");

                    b.ToTable("TablaImagenes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlbumId = 1,
                            CantidadImpresa = 1000,
                            CodigoImagenOriginal = 31,
                            Descripcion = "era de hielo",
                            NumeroImagen = 200,
                            PathModeloImagen = "hola"
                        },
                        new
                        {
                            Id = 2,
                            AlbumId = 1,
                            CantidadImpresa = 1000,
                            CodigoImagenOriginal = 32,
                            Descripcion = "REY LEON",
                            NumeroImagen = 201,
                            PathModeloImagen = "chau"
                        },
                        new
                        {
                            Id = 3,
                            AlbumId = 1,
                            CantidadImpresa = 1000,
                            CodigoImagenOriginal = 33,
                            Descripcion = "Tarzan",
                            NumeroImagen = 202,
                            PathModeloImagen = "si"
                        });
                });

            modelBuilder.Entity("G7Album.BaseDatos.Entidades.AlbumImagenImpresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlbumImagenId")
                        .HasColumnType("int");

                    b.Property<int>("CodigoImagenImpresa")
                        .HasColumnType("int");

                    b.Property<string>("PathImagenImpreso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumImagenId");

                    b.HasIndex(new[] { "Id" }, "Entity_Id")
                        .IsUnique()
                        .HasDatabaseName("Entity_Id1");

                    b.ToTable("TablaImagenesImpresas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlbumImagenId = 1,
                            CodigoImagenImpresa = 100,
                            PathImagenImpreso = "gsk"
                        },
                        new
                        {
                            Id = 2,
                            AlbumImagenId = 1,
                            CodigoImagenImpresa = 110,
                            PathImagenImpreso = "sbcik"
                        },
                        new
                        {
                            Id = 3,
                            AlbumImagenId = 1,
                            CodigoImagenImpresa = 120,
                            PathImagenImpreso = "knxhi"
                        });
                });

            modelBuilder.Entity("G7Album.BaseDatos.Entidades.AlbumUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<string>("CodigoAlbum")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CodigoAlbumUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("UsuarioId");

                    b.HasIndex(new[] { "Id" }, "Entity_Id")
                        .IsUnique()
                        .HasDatabaseName("Entity_Id3");

                    b.ToTable("TablaAlbumesUsuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlbumId = 1,
                            CodigoAlbum = "a",
                            CodigoAlbumUsuario = "s",
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 2,
                            AlbumId = 1,
                            CodigoAlbum = "b",
                            CodigoAlbumUsuario = "t",
                            UsuarioId = 2
                        },
                        new
                        {
                            Id = 3,
                            AlbumId = 1,
                            CodigoAlbum = "c",
                            CodigoAlbumUsuario = "u",
                            UsuarioId = 3
                        });
                });

            modelBuilder.Entity("G7Album.BaseDatos.Entidades.AlbumUsuarioImagenes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlbumImagenImpresaId")
                        .HasColumnType("int");

                    b.Property<int>("AlbumUsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("EstaPegada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumImagenImpresaId");

                    b.HasIndex("AlbumUsuarioId");

                    b.HasIndex(new[] { "Id" }, "Entity_Id")
                        .IsUnique()
                        .HasDatabaseName("Entity_Id4");

                    b.ToTable("TablaUsuarioImagenes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlbumImagenImpresaId = 1,
                            AlbumUsuarioId = 1,
                            EstaPegada = "si"
                        },
                        new
                        {
                            Id = 2,
                            AlbumImagenImpresaId = 2,
                            AlbumUsuarioId = 2,
                            EstaPegada = "si"
                        },
                        new
                        {
                            Id = 3,
                            AlbumImagenImpresaId = 3,
                            AlbumUsuarioId = 3,
                            EstaPegada = "si"
                        });
                });

            modelBuilder.Entity("G7Album.BaseDatos.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varbinary(100)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "Entity_Id")
                        .IsUnique()
                        .HasDatabaseName("Entity_Id5");

                    b.ToTable("TablaUsuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "vanesa@gmail.com",
                            NombreCompleto = "Vanesa Herrera",
                            Password = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                        },
                        new
                        {
                            Id = 2,
                            Email = "juanledesma@gmail.com",
                            NombreCompleto = "juan ledesma",
                            Password = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                        },
                        new
                        {
                            Id = 3,
                            Email = "aili@gmail.com",
                            NombreCompleto = "oriana LALALA",
                            Password = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                        });
                });

            modelBuilder.Entity("G7Album.BaseDatos.Entidades.AlbumImagenes", b =>
                {
                    b.HasOne("G7Album.BaseDatos.Entidades.Album", "Album")
                        .WithMany()
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("G7Album.BaseDatos.Entidades.AlbumImagenImpresa", b =>
                {
                    b.HasOne("G7Album.BaseDatos.Entidades.AlbumImagenes", "AlbumImagenes")
                        .WithMany()
                        .HasForeignKey("AlbumImagenId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AlbumImagenes");
                });

            modelBuilder.Entity("G7Album.BaseDatos.Entidades.AlbumUsuario", b =>
                {
                    b.HasOne("G7Album.BaseDatos.Entidades.Album", "Album")
                        .WithMany()
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("G7Album.BaseDatos.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("G7Album.BaseDatos.Entidades.AlbumUsuarioImagenes", b =>
                {
                    b.HasOne("G7Album.BaseDatos.Entidades.AlbumImagenImpresa", "AlbumImagenImpresa")
                        .WithMany()
                        .HasForeignKey("AlbumImagenImpresaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("G7Album.BaseDatos.Entidades.AlbumUsuario", "AlbumUsuario")
                        .WithMany()
                        .HasForeignKey("AlbumUsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AlbumImagenImpresa");

                    b.Navigation("AlbumUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
