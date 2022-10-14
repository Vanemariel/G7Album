﻿using G7Album.BaseDatos.Entidades;
using Microsoft.EntityFrameworkCore;


namespace G7Album.BaseDatos.Data
{
    public class BDContext: DbContext
    {
        public BDContext(DbContextOptions<BDContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach ( /// Desactiva la eliminacion en cascada de todas las relaciones
                var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Email = "vanesa@gmail.com",
                    Password = new Byte[10],
                    NombreCompleto = "Vanesa Herrera"
                },
                new Usuario
                {
                    Id = 2,
                    Email = "juanledesma@gmail.com",
                    Password = new Byte[10],
                    NombreCompleto = "juan ledesma"

                },
                new Usuario
                {
                    Id = 3,
                    Email = "aili@gmail.com",
                    Password = new Byte[10],
                    NombreCompleto = "oriana LALALA",
                }
            );

            modelBuilder.Entity<ColeccionAlbum>().HasData(
                new ColeccionAlbum {
                    Id = 1,
                    TituloColeccion= "Futbol"
                },
                new ColeccionAlbum {
                    Id = 2,
                    TituloColeccion= "Tenis"
                },
                new ColeccionAlbum{
                    Id = 3,
                    TituloColeccion= "Basket"
                }
            );

            modelBuilder.Entity<Album>().HasData(
                new Album
                {
                    Id = 1,
                    CodigoAlbum = 10,
                    Titulo = "Copa Libertadores",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 1
                },
                new Album
                {
                    Id = 2,
                    CodigoAlbum = 10,
                    Titulo = "Champions Lague",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 1
                },
                new Album
                {
                    Id = 3,
                    CodigoAlbum = 10,
                    Titulo = "Copa America",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 1
                },

                new Album
                {
                    Id = 4,
                    CodigoAlbum = 10,
                    Titulo = "Winledom",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 2
                },
                new Album
                {
                    Id = 5,
                    CodigoAlbum = 10,
                    Titulo = "Rollan Garros",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 2
                },               
                new Album
                {
                    Id = 6,
                    CodigoAlbum = 10,
                    Titulo = "Us Open",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 2
                },
            
                new Album
                {
                    Id = 10,
                    CodigoAlbum = 10,
                    Titulo = "Liga ndesa",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 3
                },
                new Album
                {
                    Id = 11,
                    CodigoAlbum = 10,
                    Titulo = "NBA",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 3
                },
                new Album
                {
                    Id = 12,
                    CodigoAlbum = 10,
                    Titulo = "La Liga Argentina",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 3
                }
            );



            modelBuilder.Entity<AlbumUsuario>().HasData(
               new AlbumUsuario
               {
                   Id = 1,
                   CodigoAlbumUsuario = "s",
                   CodigoAlbum = "a",
                   AlbumId = 1,
                   UsuarioId = 1,
               },
               new AlbumUsuario
               {
                   Id = 2,
                   CodigoAlbumUsuario = "t",
                   CodigoAlbum = "b",
                   AlbumId = 1,
                   UsuarioId = 2,
               },
               new AlbumUsuario
               {
                   Id = 3,
                   CodigoAlbumUsuario = "u",
                   CodigoAlbum = "c",
                   AlbumId = 1,
                   UsuarioId = 3,
               }
            );

            modelBuilder.Entity<AlbumImagenes>().HasData(
                new AlbumImagenes
                {
                    Id = 1,
                    NumeroImagen = 200,
                    CodigoImagenOriginal = 31,
                    CantidadImpresa = 1000,
                    PathModeloImagen = "hola",
                    Descripcion = "era de hielo",
                    AlbumId = 1,
                },
                new AlbumImagenes
                {
                    Id = 2,
                    NumeroImagen = 201,
                    CodigoImagenOriginal = 32,
                    CantidadImpresa = 1000,
                    PathModeloImagen = "chau",
                    Descripcion = "REY LEON",
                    AlbumId = 1,
                },
                new AlbumImagenes
                {
                    Id = 3,
                    NumeroImagen = 202,
                    CodigoImagenOriginal = 33,
                    CantidadImpresa = 1000,
                    PathModeloImagen = "si",
                    Descripcion = "Tarzan",
                    AlbumId = 1,
                }
            );

            modelBuilder.Entity<AlbumImagenImpresa>().HasData(
                new AlbumImagenImpresa
                {
                    Id = 1,
                    CodigoImagenImpresa = 100,
                    PathImagenImpreso = "gsk",
                    AlbumImagenId = 1,

                },
                new AlbumImagenImpresa
                {
                    Id = 2,
                    CodigoImagenImpresa = 110,
                    PathImagenImpreso = "sbcik",
                    AlbumImagenId = 1,

                },
                new AlbumImagenImpresa
                {
                    Id = 3,
                    CodigoImagenImpresa = 120,
                    PathImagenImpreso = "knxhi",
                    AlbumImagenId = 1,

                }
            );

            modelBuilder.Entity<AlbumUsuarioImagenes>().HasData(
               new AlbumUsuarioImagenes
               {
                   Id = 1,
                   EstaPegada = "si",
                   AlbumUsuarioId = 1,
                   AlbumImagenImpresaId = 1,

               },
               new AlbumUsuarioImagenes
               {
                   Id = 2,
                   EstaPegada = "si",
                   AlbumUsuarioId = 2,
                   AlbumImagenImpresaId = 2,

               },
               new AlbumUsuarioImagenes
               {
                   Id = 3,
                   EstaPegada = "si",
                   AlbumUsuarioId = 3,
                   AlbumImagenImpresaId = 3,

               }
            );
        }

        public DbSet<ColeccionAlbum> TablaColeccionAlbumes  { get; set; }
        public DbSet<Album> TablaAlbumes  { get; set; }
        public DbSet<AlbumImagenImpresa> TablaImagenesImpresas  { get; set; }
        public DbSet<AlbumImagenes> TablaImagenes  { get; set; }
        public DbSet<AlbumUsuarioImagenes> TablaUsuarioImagenes { get; set; }
        public DbSet<AlbumUsuario> TablaAlbumesUsuarios { get; set; }
        public DbSet<Usuario> TablaUsuarios { get; set; }
    }
}
