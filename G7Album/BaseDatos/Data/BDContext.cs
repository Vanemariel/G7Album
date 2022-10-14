using G7Album.BaseDatos.Entidades;
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
                },
                new ColeccionAlbum{
                    Id = 4,
                    TituloColeccion= "Rugby"
                }
                new ColeccionAlbum{
                    Id = 5,
                    TituloColeccion= "Anime"
                }
                 new ColeccionAlbum{
                    Id = 6,
                    TituloColeccion= "Disney"
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
                }
            
                new Album
                {
                    Id = 7,
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
                    Id = 8,
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
                    Id = 9,
                    CodigoAlbum = 10,
                    Titulo = "La Liga Argentina",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 3
                }
                new Album
                {
                    Id = 10,
                    CodigoAlbum = 10,
                    Titulo = "National Rugby League",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 4
                }
                new Album
                {
                    Id = 11,
                    CodigoAlbum = 11,
                    Titulo = "Super League",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 4
                }
                new Album
                {
                    Id = 12,
                    CodigoAlbum = 12,
                    Titulo = "The Rugby Championship",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 4
                }
                new Album
                {
                    Id = 13,
                    CodigoAlbum = 1,
                    Titulo = "Dragonball",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 5
                }
                new Album
                {
                    Id = 14,
                    CodigoAlbum = 2,
                    Titulo = "Dragonball Z",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 5
                }
                new Album
                {
                    Id = 15,
                    CodigoAlbum = 3,
                    Titulo = "Dragonball Super",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 5
                }
                 new Album
                {
                    Id = 16,
                    CodigoAlbum = 4,
                    Titulo = "Naruto",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 5
                }
                new Album
                {
                    Id = 17,
                    CodigoAlbum = 5,
                    Titulo = "Naruto Shippuden",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 5
                }
                new Album
                {
                    Id = 18,
                    CodigoAlbum = 6,
                    Titulo = "Naruto Next Generation",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 5
                }
                new Album
                {
                    Id = 19,
                    CodigoAlbum = 7,
                    Titulo = "Saint Seiya the Lost Canvas",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 5
                }
                new Album
                {
                    Id = 20,
                    CodigoAlbum = 8,
                    Titulo = "Batalla de Poseidon",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 5
                }
                new Album
                {
                    Id = 21,
                    CodigoAlbum = 9,
                    Titulo = "Batalla de Asgard",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 5
                }
                new Album
                {
                    Id = 22,
                    CodigoAlbum = 100,
                    Titulo = "Monster Inc",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 6
                }
                new Album
                {
                    Id = 23,
                    CodigoAlbum = 101,
                    Titulo = "Monster University",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 6
                }
                new Album
                {
                    Id = 24,
                    CodigoAlbum = 102,
                    Titulo = "High school Musical",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 6
                }
                new Album
                {
                    Id = 25,
                    CodigoAlbum = 104,
                    Titulo = "High school Musical 2",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 6
                }
                new Album
                {
                    Id = 26,
                    CodigoAlbum = 105,
                    Titulo = "La era del hielo 1",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 6
                }
                new Album
                {
                    Id = 27,
                    CodigoAlbum = 106,
                    Titulo = "La era del hielo 2",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 6
                }
                new Album
                {
                    Id = 28,
                    CodigoAlbum = 107,
                    Titulo = "La era del hielo 3",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 6
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
                    Imagen = "hola",
                    Imagen = "era de hielo",
                    AlbumId = 1,
                },
                new AlbumImagenes
                {
                    Id = 2,
                    NumeroImagen = 201,
                    CodigoImagenOriginal = 32,
                    CantidadImpresa = 1000,
                    Imagen = "chau",
                    Imagen = "REY LEON",
                    AlbumId = 1,
                },
                new AlbumImagenes
                {
                    Id = 3,
                    NumeroImagen = 202,
                    CodigoImagenOriginal = 33,
                    CantidadImpresa = 1000,
                    Imagen = "si",
                    Titulo = "Tarzan",
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
