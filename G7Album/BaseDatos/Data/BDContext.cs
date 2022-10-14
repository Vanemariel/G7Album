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
               },
                new ColeccionAlbum{
                    Id = 5,
                    TituloColeccion= "Disney"
               },
                 new ColeccionAlbum{
                    Id = 6,
                    TituloColeccion= "Anime"
               }
            );

            modelBuilder.Entity<Album>().HasData(
                new Album
                {
                    Id = 1,
                    CodigoAlbum = 1,
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
                    CodigoAlbum = 2,
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
                    CodigoAlbum = 3,
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
                    CodigoAlbum = 4,
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
                    CodigoAlbum = 5,
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
                    CodigoAlbum = 6,
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
                    Id = 7,
                    CodigoAlbum = 7,
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
                    CodigoAlbum = 8,
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
                    CodigoAlbum = 9,
                    Titulo = "La Liga Argentina",
                    Descripcion = "figus",
                    CantidadImagen = 1000,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 3
               },
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
               },
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
               },
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
               },
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
               },
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
               },
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
               },
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
               },
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
               },
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
               },
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
               },
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
               },
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
               },
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
               },
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
               },
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
               },
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
               },
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
               },
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
               },
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
                    Imagen = " ",
                    Titulo = "Armani Franco",
                    AlbumId = 1,
               },
                new AlbumImagenes
                {
                    Id = 2,
                    NumeroImagen = 201,
                    CodigoImagenOriginal = 32,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Franco Daniel",
                    AlbumId = 1,
               },
                new AlbumImagenes
                {
                    Id = 3,
                    NumeroImagen = 202,
                    CodigoImagenOriginal = 33,
                    CantidadImpresa = 1000,
                    Imagen = "si",
                    Titulo = "Guido Herrera",
                    AlbumId = 1,
               },
                new AlbumImagenes
                {
                    Id = 4,
                    NumeroImagen = 2023,
                    CodigoImagenOriginal = 34,
                    CantidadImpresa = 1000,
                    Imagen = "si",
                    Titulo = "Pratto Lucas",
                    AlbumId = 1,
               },
                new AlbumImagenes
                {
                    Id = 5,
                    NumeroImagen = 204,
                    CodigoImagenOriginal = 35,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Bou Walter",
                    AlbumId = 1,
               },
                new AlbumImagenes
                {
                    Id = 6,
                    NumeroImagen = 205,
                    CodigoImagenOriginal = 36,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Valoyes Diego",
                    AlbumId = 1,
               },
                new AlbumImagenes
                {
                    Id = 7,
                    NumeroImagen = 20,
                    CodigoImagenOriginal = 37,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Bou Walter",
                    AlbumId = 1,
               },
                new AlbumImagenes
                {
                    Id = 8,
                    NumeroImagen = 21,
                    CodigoImagenOriginal = 38,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Pratto Lucas",
                    AlbumId = 1,
               },
                new AlbumImagenes
                {
                    Id = 9,
                    NumeroImagen = 22,
                    CodigoImagenOriginal = 39,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Franco Daniel",
                    AlbumId = 1,
               },
                new AlbumImagenes
                {
                    Id = 10,
                    NumeroImagen = 23,
                    CodigoImagenOriginal = 40,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "ArmanI Franco",
                    AlbumId = 1,
               },
                new AlbumImagenes
                {
                    Id = 11,
                    NumeroImagen = 24,
                    CodigoImagenOriginal = 41,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Guido Herrera",
                    AlbumId = 1,
               },
                new AlbumImagenes
                {
                    Id = 12,
                    NumeroImagen = 25,
                    CodigoImagenOriginal = 42,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Salas",
                    AlbumId = 1,
               },
                new AlbumImagenes
                {
                    Id = 13,
                    NumeroImagen = 26,
                    CodigoImagenOriginal = 43,
                    CantidadImpresa = 1000,
                    Imagen = "si",
                    Titulo = "Firmiño",
                    AlbumId = 1,
               },
                new AlbumImagenes
                {
                    Id = 14,
                    NumeroImagen = 27,
                    CodigoImagenOriginal = 44,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Alvarez Julian",
                    AlbumId = 1,
               },
                new AlbumImagenes
                {
                    Id = 15,
                    NumeroImagen = 28,
                    CodigoImagenOriginal = 45,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Halan",
                    AlbumId = 1,
               },
                new AlbumImagenes
                {
                    Id = 16,
                    NumeroImagen = 29,
                    CodigoImagenOriginal = 46,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Cuti Romero",
                    AlbumId = 1,
               },
                new AlbumImagenes
                {
                    Id = 17,
                    NumeroImagen = 30,
                    CodigoImagenOriginal = 47,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Dibu Martinez",
                    AlbumId = 1,
               },
                new AlbumImagenes
                {
                    Id = 18,
                    NumeroImagen = 31,
                    CodigoImagenOriginal = 48,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Nadal Rafael",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 19,
                    NumeroImagen = 32,
                    CodigoImagenOriginal = 49,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Federer Roger",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 20,
                    NumeroImagen = 33,
                    CodigoImagenOriginal = 50,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Murray",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 21,
                    NumeroImagen = 34,
                    CodigoImagenOriginal = 51,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Del Potro",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 22,
                    NumeroImagen = 35,
                    CodigoImagenOriginal = 52,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "David Nalvandian",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 23,
                    NumeroImagen = 36,
                    CodigoImagenOriginal = 53,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Novak Djovich",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 24,
                    NumeroImagen = 37,
                    CodigoImagenOriginal = 54,
                    CantidadImpresa = 1000,
                    Imagen= "",
                    Titulo = "Nadal Rafael",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 25,
                    NumeroImagen = 37,
                    CodigoImagenOriginal = 55,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Federer Roger",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 26,
                    NumeroImagen = 38,
                    CodigoImagenOriginal = 56,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Murray",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 27,
                    NumeroImagen = 39,
                    CodigoImagenOriginal = 57,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Del Potro",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 28,
                    NumeroImagen = 40,
                    CodigoImagenOriginal = 58,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "David Nalvandian",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 2800,
                    NumeroImagen = 41,
                    CodigoImagenOriginal = 59,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Novak Djokovich",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 29,
                    NumeroImagen = 42,
                    CodigoImagenOriginal = 60,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Nadal Rafael",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 30,
                    NumeroImagen = 43,
                    CodigoImagenOriginal = 61,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Federer Roger",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 31,
                    NumeroImagen = 44,
                    CodigoImagenOriginal = 62,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Murray",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 32,
                    NumeroImagen = 45,
                    CodigoImagenOriginal = 63,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Del Potro",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 33,
                    NumeroImagen = 46,
                    CodigoImagenOriginal = 64,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "David Nalvandian",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 34,
                    NumeroImagen = 47,
                    CodigoImagenOriginal = 65,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Novak Djokovich",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 35,
                    NumeroImagen = 48,
                    CodigoImagenOriginal = 66,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Nadal Rafael",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 36,
                    NumeroImagen = 49,
                    CodigoImagenOriginal = 67,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Federer Roger",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 37,
                    NumeroImagen = 50,
                    CodigoImagenOriginal = 68,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Murray",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 38,
                    NumeroImagen = 51,
                    CodigoImagenOriginal = 69,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Del Potro",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 39,
                    NumeroImagen = 52,
                    CodigoImagenOriginal = 70,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "David Nalvandian",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 40,
                    NumeroImagen = 53,
                    CodigoImagenOriginal = 71,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Novak Djokovich",
                    AlbumId = 2,
               },
                new AlbumImagenes
                {
                    Id = 41,
                    NumeroImagen = 54,
                    CodigoImagenOriginal = 72,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Manuel Ginobilli",
                    AlbumId = 3,
               },
                new AlbumImagenes
                {
                    Id = 42,
                    NumeroImagen = 55,
                    CodigoImagenOriginal = 73,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Kevin Durant",
                    AlbumId = 3,
               },
                new AlbumImagenes
                {
                    Id = 43,
                    NumeroImagen = 56,
                    CodigoImagenOriginal = 74,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Elvin Hayes",
                    AlbumId = 3,
               },
                new AlbumImagenes
                {
                    Id = 44,
                    NumeroImagen = 57,
                    CodigoImagenOriginal = 75,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Bob Pettit",
                    AlbumId = 3,
               },
                new AlbumImagenes
                {
                    Id = 45,
                    NumeroImagen = 58,
                    CodigoImagenOriginal = 76,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Giannis Antokoumpo",
                    AlbumId = 3,
               },
                new AlbumImagenes
                {
                    Id = 46,
                    NumeroImagen = 59,
                    CodigoImagenOriginal = 77,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Oscar Robertson",
                    AlbumId = 3,
               },
                new AlbumImagenes
                {
                    Id = 460,
                    NumeroImagen = 60,
                    CodigoImagenOriginal = 78,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Fernando Martina",
                    AlbumId = 3,
               },
                new AlbumImagenes
                {
                    Id = 47,
                    NumeroImagen = 61,
                    CodigoImagenOriginal = 79,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Martin Cabrera",
                    AlbumId = 3,
               },
                new AlbumImagenes
                {
                    Id = 48,
                    NumeroImagen = 62,
                    CodigoImagenOriginal = 80,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Franco Barroso",
                    AlbumId = 3,
               },
                new AlbumImagenes
                {
                    Id = 49,
                    NumeroImagen = 63,
                    CodigoImagenOriginal = 81,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Juan Cruz Oberto",
                    AlbumId = 3,
               },
                new AlbumImagenes
                {
                    Id = 50,
                    NumeroImagen = 64,
                    CodigoImagenOriginal = 82,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Marcelo Milanesio",
                    AlbumId = 3,
               },
                 new AlbumImagenes
                {
                    Id = 51,
                    NumeroImagen = 65,
                    CodigoImagenOriginal = 83,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Julian Montoya",
                    AlbumId = 4,
               },
                 new AlbumImagenes
                {
                    Id = 52,
                    NumeroImagen = 66,
                    CodigoImagenOriginal = 84,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Matias Alemano",
                    AlbumId = 4,
               },
                new AlbumImagenes
                {
                    Id = 53,
                    NumeroImagen = 67,
                    CodigoImagenOriginal = 85,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Julian Cruz Mallia",
                    AlbumId = 4,
               },
                new AlbumImagenes
                {
                    Id = 54,
                    NumeroImagen = 68,
                    CodigoImagenOriginal = 86,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Tomas Cubeli",
                    AlbumId = 4,
               },
                new AlbumImagenes
                {
                    Id = 55,
                    NumeroImagen = 69,
                    CodigoImagenOriginal = 87,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Felipe Contemponi",
                    AlbumId = 4,
               },
                new AlbumImagenes
                {
                    Id = 56,
                    NumeroImagen = 70,
                    CodigoImagenOriginal = 88,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Julian Montoya",
                    AlbumId = 4,
               },
                new AlbumImagenes
                {
                    Id = 57,
                    NumeroImagen = 71,
                    CodigoImagenOriginal = 89,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Matias Alemano",
                    AlbumId = 4,
               },
                new AlbumImagenes
                {
                    Id = 58,
                    NumeroImagen = 72,
                    CodigoImagenOriginal = 90,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Julian Cruz Mallia",
                    AlbumId = 4,
               },
                new AlbumImagenes
                {
                    Id = 59,
                    NumeroImagen = 73,
                    CodigoImagenOriginal = 91,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Tomas Cubelli",
                    AlbumId = 4,
               },
                new AlbumImagenes
                {
                    Id = 60,
                    NumeroImagen = 74,
                    CodigoImagenOriginal = 92,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Felipe Contemponi",
                    AlbumId = 4,
               },
                new AlbumImagenes
                {
                    Id = 61,
                    NumeroImagen = 75,
                    CodigoImagenOriginal = 93,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Julian Montoya",
                    AlbumId = 4,
               },
                new AlbumImagenes
                {
                    Id = 62,
                    NumeroImagen = 76,
                    CodigoImagenOriginal = 94,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Matias Alemano",
                    AlbumId = 4,
               },
                new AlbumImagenes
                {
                    Id = 63,
                    NumeroImagen = 77,
                    CodigoImagenOriginal = 95,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Julian Cruz Mallia",
                    AlbumId = 4,
               },
                new AlbumImagenes
                {
                    Id = 64,
                    NumeroImagen = 78,
                    CodigoImagenOriginal = 96,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Tomas Cubelli",
                    AlbumId = 4,
               },
                new AlbumImagenes
                {
                    Id = 65,
                    NumeroImagen = 79,
                    CodigoImagenOriginal = 97,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Felipe Contemponi",
                    AlbumId = 4,
               },
                new AlbumImagenes
                {
                    Id = 66,
                    NumeroImagen = 80,
                    CodigoImagenOriginal = 98,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Julian Montoya",
                    AlbumId = 4,
               },
                new AlbumImagenes
                {
                    Id = 67,
                    NumeroImagen = 81,
                    CodigoImagenOriginal = 99,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Matias Alemano",
                    AlbumId = 4,
               },
                new AlbumImagenes
                {
                    Id = 68,
                    NumeroImagen = 82,
                    CodigoImagenOriginal = 100,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Julian Cruz Mallia",
                    AlbumId = 4,
               },
                new AlbumImagenes
                {
                    Id = 69,
                    NumeroImagen = 83,
                    CodigoImagenOriginal = 101,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Tomas Cubelli",
                    AlbumId = 4,
               },
                new AlbumImagenes
                {
                    Id = 70,
                    NumeroImagen = 84,
                    CodigoImagenOriginal = 102,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Felipe Contemponi",
                    AlbumId = 4,
               },
                new AlbumImagenes
                {
                    Id = 620,
                    NumeroImagen = 85,
                    CodigoImagenOriginal = 103,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Matias Alemano",
                    AlbumId = 4,
               },
                new AlbumImagenes
                {
                    Id = 630,
                    NumeroImagen = 86,
                    CodigoImagenOriginal = 104,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Boo",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 640,
                    NumeroImagen = 87,
                    CodigoImagenOriginal = 105,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Mike Wazowski",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 650,
                    NumeroImagen = 88,
                    CodigoImagenOriginal = 106,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Fungus",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 660,
                    NumeroImagen = 89,
                    CodigoImagenOriginal = 107,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Roz",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 670,
                    NumeroImagen = 90,
                    CodigoImagenOriginal = 108,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Bile",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 680,
                    NumeroImagen = 91,
                    CodigoImagenOriginal = 109,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Boo",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 690,
                    NumeroImagen = 92,
                    CodigoImagenOriginal = 110,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Mike Wazowski",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 700,
                    NumeroImagen = 93,
                    CodigoImagenOriginal = 111,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Fungus",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 71,
                    NumeroImagen = 94,
                    CodigoImagenOriginal = 112,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Roz",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 72,
                    NumeroImagen = 95,
                    CodigoImagenOriginal = 113,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Bile",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 73,
                    NumeroImagen = 96,
                    CodigoImagenOriginal = 114,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Troy Bolton",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 74,
                    NumeroImagen = 97,
                    CodigoImagenOriginal = 115,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Gabriela Montes",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 75,
                    NumeroImagen = 98,
                    CodigoImagenOriginal = 116,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Sharpay Evans",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 76,
                    NumeroImagen = 99,
                    CodigoImagenOriginal = 117,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Martha Cox",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 77,
                    NumeroImagen = 100,
                    CodigoImagenOriginal = 118,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Lucille Bolton",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 78,
                    NumeroImagen = 101,
                    CodigoImagenOriginal = 119,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Troy Bolton",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 79,
                    NumeroImagen = 102,
                    CodigoImagenOriginal = 120,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Gabriela Montes",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 80,
                    NumeroImagen = 103,
                    CodigoImagenOriginal = 121,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Sharpay Evans",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 81,
                    NumeroImagen = 104,
                    CodigoImagenOriginal = 122,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Martha Cox",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 82,
                    NumeroImagen = 105,
                    CodigoImagenOriginal = 123,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Lucile Bolton",
                    AlbumId = 5,
               },
                 new AlbumImagenes
                {
                    Id = 83,
                    NumeroImagen = 106,
                    CodigoImagenOriginal = 124,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Troy Bolton",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 84,
                    NumeroImagen = 107,
                    CodigoImagenOriginal = 125,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Gabriela Montes",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 85,
                    NumeroImagen = 108,
                    CodigoImagenOriginal = 126,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Sharpay Evans",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 86,
                    NumeroImagen = 109,
                    CodigoImagenOriginal = 127,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Martha Cox",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 87,
                    NumeroImagen = 110,
                    CodigoImagenOriginal = 128,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Lucile Bolton",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 88,
                    NumeroImagen = 111,
                    CodigoImagenOriginal = 129,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Sid",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 89,
                    NumeroImagen = 112,
                    CodigoImagenOriginal = 130,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Many",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 90,
                    NumeroImagen = 113,
                    CodigoImagenOriginal = 131,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Roshan",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 91,
                    NumeroImagen = 114,
                    CodigoImagenOriginal = 132,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Diego",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 92,
                    NumeroImagen = 115,
                    CodigoImagenOriginal = 133,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Scrat",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 93,
                    NumeroImagen = 116,
                    CodigoImagenOriginal = 134,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Sid",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 94,
                    NumeroImagen = 117,
                    CodigoImagenOriginal = 135,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Many",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 95,
                    NumeroImagen = 118,
                    CodigoImagenOriginal = 136,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Roshan",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 96,
                    NumeroImagen = 119,
                    CodigoImagenOriginal = 137,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Diego",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 97,
                    NumeroImagen = 120,
                    CodigoImagenOriginal = 138,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Scrat",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 98,
                    NumeroImagen = 121,
                    CodigoImagenOriginal = 139,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Sid",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 99,
                    NumeroImagen = 122,
                    CodigoImagenOriginal = 140,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Many",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 100,
                    NumeroImagen = 123,
                    CodigoImagenOriginal = 141,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Roshan",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 101,
                    NumeroImagen = 124,
                    CodigoImagenOriginal = 142,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Diego",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 102,
                    NumeroImagen = 125,
                    CodigoImagenOriginal = 143,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Scrat",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 103,
                    NumeroImagen = 126,
                    CodigoImagenOriginal = 144,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Dra Grace",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 104,
                    NumeroImagen = 127,
                    CodigoImagenOriginal = 145,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Neyriti",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 105,
                    NumeroImagen = 128,
                    CodigoImagenOriginal = 146,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Jake Sully",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 106,
                    NumeroImagen = 129,
                    CodigoImagenOriginal = 147,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Tsutey",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 107,
                    NumeroImagen = 130,
                    CodigoImagenOriginal = 148,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Coronel Milles",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 108,
                    NumeroImagen = 131,
                    CodigoImagenOriginal = 149,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Dra Grace",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 109,
                    NumeroImagen = 132,
                    CodigoImagenOriginal = 150,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Neyriti",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 110,
                    NumeroImagen = 133,
                    CodigoImagenOriginal = 151,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Jake Sully",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 111,
                    NumeroImagen = 134,
                    CodigoImagenOriginal = 152,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Tsutey",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 112,
                    NumeroImagen = 135,
                    CodigoImagenOriginal = 153,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Coronel Milles",
                    AlbumId = 5,
               },
                new AlbumImagenes
                {
                    Id = 113,
                    NumeroImagen = 136,
                    CodigoImagenOriginal = 154,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Goku",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 114,
                    NumeroImagen = 137,
                    CodigoImagenOriginal = 155,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Vegeta",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 115,
                    NumeroImagen = 138,
                    CodigoImagenOriginal = 156,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Cell",
                    AlbumId = 6,
               },
                 new AlbumImagenes
                {
                    Id = 116,
                    NumeroImagen = 139,
                    CodigoImagenOriginal = 157,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Picolo",
                    AlbumId = 6,
               },
                 new AlbumImagenes
                {
                    Id = 117,
                    NumeroImagen = 140,
                    CodigoImagenOriginal = 158,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Son Gohan",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 118,
                    NumeroImagen = 141,
                    CodigoImagenOriginal = 159,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Goku",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 1180,
                    NumeroImagen = 142,
                    CodigoImagenOriginal = 160,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Vegeta",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 119,
                    NumeroImagen = 143,
                    CodigoImagenOriginal = 161,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Cell",
                    AlbumId = 6,
               },
                 new AlbumImagenes
                {
                    Id = 120,
                    NumeroImagen = 144,
                    CodigoImagenOriginal = 162,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Picolo",
                    AlbumId = 6,
               },
                 new AlbumImagenes
                {
                    Id = 121,
                    NumeroImagen = 145,
                    CodigoImagenOriginal = 163,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Son Gohan",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 122,
                    NumeroImagen = 146,
                    CodigoImagenOriginal = 164,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Goku",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 123,
                    NumeroImagen = 147,
                    CodigoImagenOriginal = 165,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Vegeta",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 124,
                    NumeroImagen = 148,
                    CodigoImagenOriginal = 166,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Cell",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 125,
                    NumeroImagen = 149,
                    CodigoImagenOriginal = 167,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Picolo",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 126,
                    NumeroImagen = 150,
                    CodigoImagenOriginal = 168,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Son Gohan",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 127,
                    NumeroImagen = 151,
                    CodigoImagenOriginal = 169,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Naruto",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 128,
                    NumeroImagen = 152,
                    CodigoImagenOriginal = 170,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Sasuke",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 129,
                    NumeroImagen = 153,
                    CodigoImagenOriginal = 171,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Itachi",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 130,
                    NumeroImagen = 154,
                    CodigoImagenOriginal = 172 ,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Sakura",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 131,
                    NumeroImagen = 155,
                    CodigoImagenOriginal = 173,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Madara",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 132,
                    NumeroImagen = 156,
                    CodigoImagenOriginal = 174,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Naruto",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 133,
                    NumeroImagen = 157,
                    CodigoImagenOriginal = 175,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Sasuke",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 134,
                    NumeroImagen = 158,
                    CodigoImagenOriginal = 176,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Itachi",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 135,
                    NumeroImagen = 159,
                    CodigoImagenOriginal = 177,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Sakura",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 136,
                    NumeroImagen = 160,
                    CodigoImagenOriginal = 178,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Madara",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 137,
                    NumeroImagen = 161,
                    CodigoImagenOriginal = 179,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Naruto",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 138,
                    NumeroImagen = 162,
                    CodigoImagenOriginal = 180,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Sasuke",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 139,
                    NumeroImagen = 163,
                    CodigoImagenOriginal = 181,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Itachi",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 140,
                    NumeroImagen = 164,
                    CodigoImagenOriginal = 182,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Sakura",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 141,
                    NumeroImagen = 165,
                    CodigoImagenOriginal = 183,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Madara",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 142,
                    NumeroImagen = 166,
                    CodigoImagenOriginal = 184,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Seiya de Pegaso",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 143,
                    NumeroImagen = 167,
                    CodigoImagenOriginal = 185,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Seya de Geminis",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 144,
                    NumeroImagen = 168,
                    CodigoImagenOriginal = 186,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Atenea",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 145,
                    NumeroImagen = 169,
                    CodigoImagenOriginal = 187,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Saka de Virgo",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 146,
                    NumeroImagen = 170,
                    CodigoImagenOriginal = 188,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Mu de Aries",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 147,
                    NumeroImagen = 171,
                    CodigoImagenOriginal = 189,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Seiya de Pegaso",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 148,
                    NumeroImagen = 172,
                    CodigoImagenOriginal = 190,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Seya de Geminis",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 149,
                    NumeroImagen = 173,
                    CodigoImagenOriginal = 191,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Atenea",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 150,
                    NumeroImagen = 174,
                    CodigoImagenOriginal = 192,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Saka de Virgo",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 151,
                    NumeroImagen = 175,
                    CodigoImagenOriginal = 193,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Mu de Aries",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 152,
                    NumeroImagen = 176,
                    CodigoImagenOriginal = 194,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Seiya de Pegaso",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 153,
                    NumeroImagen = 177,
                    CodigoImagenOriginal = 194,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Seya de Geminis",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 154,
                    NumeroImagen = 178,
                    CodigoImagenOriginal = 194,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Atenea",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 155,
                    NumeroImagen = 179,
                    CodigoImagenOriginal = 195,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Saka de Virgo",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 156,
                    NumeroImagen = 180,
                    CodigoImagenOriginal = 196,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Mu de Aries",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 157,
                    NumeroImagen = 181,
                    CodigoImagenOriginal = 197,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Calibos",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 158,
                    NumeroImagen = 182,
                    CodigoImagenOriginal = 198,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Medusa",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 159,
                    NumeroImagen = 183,
                    CodigoImagenOriginal = 199,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Io",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 160,
                    NumeroImagen = 184,
                    CodigoImagenOriginal = 200,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Andromeda",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 161,
                    NumeroImagen = 185,
                    CodigoImagenOriginal = 1001,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Danae",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 162,
                    NumeroImagen = 186,
                    CodigoImagenOriginal = 102,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Calibos",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 163,
                    NumeroImagen = 187,
                    CodigoImagenOriginal = 103,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Medusa",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 164,
                    NumeroImagen = 188,
                    CodigoImagenOriginal = 104,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Io",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 165,
                    NumeroImagen = 189,
                    CodigoImagenOriginal = 105,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Andromeda",
                    AlbumId = 6,
               },
                new AlbumImagenes
                {
                    Id = 166,
                    NumeroImagen = 189,
                    CodigoImagenOriginal = 106,
                    CantidadImpresa = 1000,
                    Imagen = " ",
                    Titulo = "Danae",
                    AlbumId = 6,
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

        public DbSet<ColeccionAlbum> TablaColeccionAlbumes  { get; set;}
        public DbSet<Album> TablaAlbumes  { get; set;}
        public DbSet<AlbumImagenImpresa> TablaImagenesImpresas  { get; set;}
        public DbSet<AlbumImagenes> TablaImagenes  { get; set;}
        public DbSet<AlbumUsuarioImagenes> TablaUsuarioImagenes { get; set;}
        public DbSet<AlbumUsuario> TablaAlbumesUsuarios { get; set;}
        public DbSet<Usuario> TablaUsuarios { get; set;}
    }
}
