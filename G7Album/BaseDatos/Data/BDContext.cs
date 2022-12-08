using G7Album.BaseDatos.Data.Entidades;
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
                    CantidadImagen = 12,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 1,
                    Imagen = "https://www.elcomercio.com/wp-content/uploads/2022/10/Liber-COnme-700x391.jpg"
                },
                new Album
                {
                    Id = 2,
                    CodigoAlbum = 2,
                    Titulo = "Champions League",
                    Descripcion = "figus",
                    CantidadImagen = 12,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 1,
                    Imagen = "https://a.espncdn.com/photo/2021/0913/r908628_1296x729_16-9.jpg"
                },
                new Album
                {
                    Id = 3,
                    CodigoAlbum = 3,
                    Titulo = "Copa America",
                    Descripcion = "figus",
                    CantidadImagen = 12,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 1,
                    Imagen = "https://auf.org.uy/imagenes/img_contenido/contenido/c/copa-america_5.jpg"
                },

                new Album
                {
                    Id = 4,
                    CodigoAlbum = 4,
                    Titulo = "Wimbledon",
                    Descripcion = "figus",
                    CantidadImagen = 9,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 2,
                    Imagen = "https://image.shutterstock.com/image-photo/london-uk-april-2022-close-260nw-2165550065.jpg"
                },
                new Album
                {
                    Id = 5,
                    CodigoAlbum = 5,
                    Titulo = "Rollan Garros",
                    Descripcion = "figus",
                    CantidadImagen = 9,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 2,
                    Imagen = "https://espnpressroom.com/mexico/files/2018/05/Roland-Garros.png"
                },               
                new Album
                {
                    Id = 6,
                    CodigoAlbum = 6,
                    Titulo = "Us Open",
                    Descripcion = "figus",
                    CantidadImagen = 9,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 2,
                    Imagen = "https://brandemia.org/sites/default/files/inline/images/us_open_logo.jpg"
                },
            
                new Album
                {
                    Id = 7,
                    CodigoAlbum = 7,
                    Titulo = "Liga Endesa",
                    Descripcion = "figus",
                    CantidadImagen = 8,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 3,
                    Imagen = "https://www.unocontraunoweb.com/wp-content/uploads/2021/01/acb-logo-2019.jpg"
                },
                new Album
                {
                    Id = 8,
                    CodigoAlbum = 8,
                    Titulo = "NBA",
                    Descripcion = "figus",
                    CantidadImagen = 8,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 3,
                    Imagen = "https://a4.espncdn.com/combiner/i?img=%2Fi%2Fespn%2Fmisc_logos%2F500%2Fnba.png"
                },
                new Album
                {
                    Id = 9,
                    CodigoAlbum = 9,
                    Titulo = "La Liga Argentina",
                    Descripcion = "figus",
                    CantidadImagen = 8,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 3,
                    Imagen = "https://pbs.twimg.com/profile_images/1537068349385068544/OSkcZWlP_400x400.jpg"
                },
                new Album
                {
                    Id = 10,
                    CodigoAlbum = 10,
                    Titulo = "National Rugby League",
                    Descripcion = "figus",
                    CantidadImagen = 7,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 4,
                    Imagen = "https://searchvectorlogo.com/wp-content/uploads/2020/09/national-rugby-league-nrl-vector-logo.png"
                },
                new Album
                {
                    Id = 11,
                    CodigoAlbum = 11,
                    Titulo = "Super League",
                    Descripcion = "figus",
                    CantidadImagen = 7,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 4,
                    Imagen = "https://upload.wikimedia.org/wikipedia/en/a/a5/Super_League_logo_2017.jpg"
                },
                new Album
                {
                    Id = 12,
                    CodigoAlbum = 12,
                    Titulo = "The Rugby Championship",
                    Descripcion = "figus",
                    CantidadImagen = 7,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 4,
                    Imagen = "https://www.prensa-latina.cu/wp-content/uploads/2022/08/Rugby-Championship-2022.jpg"
                },
               
                new Album
                {
                    Id = 13,
                    CodigoAlbum = 100,
                    Titulo = "Monster Inc",
                    Descripcion = "figus",
                    CantidadImagen = 17,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 5,
                    Imagen = "https://cdn1.eldia.com/112021/1635837451953.jpg"
                },
                new Album
                {
                    Id = 14,
                    CodigoAlbum = 101,
                    Titulo = "Monster University",
                    Descripcion = "figus",
                    CantidadImagen = 17,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 5,
                    Imagen = "https://ichef.bbci.co.uk/images/ic/1200x675/p0915n36.jpg"
                },
                new Album
                {
                    Id = 15,
                    CodigoAlbum = 102,
                    Titulo = "High school Musical",
                    Descripcion = "figus",
                    CantidadImagen = 17,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 5,
                    Imagen = "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/16E670238DC278CF1FC15F794914B0371708F078C210E01443353314452473E9/scale?width=1200&aspectRatio=1.78&format=jpeg"
                },
                new Album
                {
                    Id = 16,
                    CodigoAlbum = 104,
                    Titulo = "High school Musical 2",
                    Descripcion = "figus",
                    CantidadImagen = 17,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 5,
                    Imagen = "https://pics.filmaffinity.com/High_School_Musical_2_TV-318249736-mmed.jpg"
                },
                new Album
                {
                    Id = 26,
                    CodigoAlbum = 105,
                    Titulo = "La era del hielo 1",
                    Descripcion = "figus",
                    CantidadImagen = 17,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 5,
                    Imagen = "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/050E5D6C2B62066D3397CD0855B4274A9728186CEE39451C68FAA17A1D8EBB98/scale?width=1200&aspectRatio=1.78&format=jpeg"
                },
                new Album
                {
                    Id = 27,
                    CodigoAlbum = 106,
                    Titulo = "La era del hielo 2",
                    Descripcion = "figus",
                    CantidadImagen = 17,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 5,
                    Imagen = "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/2BDBC39CA1B941A0C4360565C67E8EDB97E2D0904DF11737583ED61E80C7CC07/scale?width=1200&aspectRatio=1.78&format=jpeg"
                },
                new Album
                {
                    Id = 28,
                    CodigoAlbum = 107,
                    Titulo = "La era del hielo 3",
                    Descripcion = "figus",
                    CantidadImagen = 17,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 5,
                    Imagen = "https://mx.web.img3.acsta.net/c_310_420/pictures/20/10/21/20/18/4455162.jpg"
                },
                new Album
                {
                    Id = 100,
                    CodigoAlbum = 107,
                    Titulo = "Avatar",
                    Descripcion = "figus",
                    CantidadImagen = 17,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 5,
                    Imagen = "https://as01.epimg.net/meristation/imagenes/2022/09/30/reportajes/1664534991_626157_1664615989_noticia_normal.jpg"
                },
                new Album
                {
                    Id = 101,
                    CodigoAlbum = 107,
                    Titulo = "Avatar 2",
                    Descripcion = "figus",
                    CantidadImagen = 17,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 5,
                    Imagen = "https://i.blogs.es/884d13/avatar-2/840_560.jpeg"
                },
                 new Album
                {
                    Id = 63,
                    CodigoAlbum = 1,
                    Titulo = "Dragonball",
                    Descripcion = "figus",
                    CantidadImagen = 15,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 6,
                    Imagen = "https://img2.rtve.es/i/?w=1600&i=1657019155649.jpg"
                 },
                new Album
                {
                    Id = 64,
                    CodigoAlbum = 2,
                    Titulo = "Dragonball Z",
                    Descripcion = "figus",
                    CantidadImagen = 15,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 6,
                    Imagen = "https://www.crunchyroll.com/imgsrv/display/thumbnail/1200x675/catalog/crunchyroll/36bdc5ea4443cd8e42f22ec7d3884cbb.jpeg"
                },
                new Album
                {
                    Id = 65,
                    CodigoAlbum = 3,
                    Titulo = "Dragonball Super",
                    Descripcion = "figus",
                    CantidadImagen = 15,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 6,
                    Imagen = "https://depor.com/resizer/6Gmj2BD2B09Yug9skT5G_37oBgg=/580x330/smart/filters:format(jpeg):quality(75)/cloudfront-us-east-1.images.arcpublishing.com/elcomercio/B35WNLM7UJGIJNOWQFDO3UPY34.jpg"
                },
                 new Album
                {
                    Id = 96,
                    CodigoAlbum = 4,
                    Titulo = "Naruto",
                    Descripcion = "figus",
                    CantidadImagen = 15,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 6,
                    Imagen = "https://i.pinimg.com/originals/3f/0d/1a/3f0d1afe64a74343c0f173faec9df8e0.jpg"
                 },
                new Album
                {
                    Id = 70,
                    CodigoAlbum = 5,
                    Titulo = "Naruto Shippuden",
                    Descripcion = "figus",
                    CantidadImagen = 15,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 6,
                    Imagen = "https://es.web.img3.acsta.net/pictures/13/12/13/09/11/515425.jpg"
                },
                new Album
                {
                    Id = 71,
                    CodigoAlbum = 6,
                    Titulo = "Naruto Next Generation",
                    Descripcion = "figus",
                    CantidadImagen = 15,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 6,
                    Imagen = "https://img1.ak.crunchyroll.com/i/spire4/7dde3a40ce5d5615813a5ac12683631a1616450115_full.jpg"
                },
                new Album
                {
                    Id = 80,
                    CodigoAlbum = 7,
                    Titulo = "Saint Seiya the Lost Canvas",
                    Descripcion = "figus",
                    CantidadImagen = 15,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 6,
                    Imagen = "https://larepublica.pe/resizer/e0pacYSNg1Mt_pZBIbVHe65wXHw=/1200x660/top/arc-anglerfish-arc2-prod-gruporepublica.s3.amazonaws.com/public/ATQBEGGFCRDSHAONTOR7O2VCNM.jpg"
                },
                new Album
                {
                    Id = 81,
                    CodigoAlbum = 8,
                    Titulo = "Batalla de Poseidon",
                    Descripcion = "figus",
                    CantidadImagen = 15,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 6,
                    Imagen = "https://i.ytimg.com/vi/p2POuLSrWms/maxresdefault.jpg"
                },
                new Album
                {
                    Id = 82,
                    CodigoAlbum = 9,
                    Titulo = "Batalla de Asgard",
                    Descripcion = "figus",
                    CantidadImagen = 15,
                    CantidadImpreso = 1000,
                    Desde = DateTime.Now,
                    Hasta = DateTime.Now.AddDays(10),
                    ColeccionAlbumId = 6,
                    Imagen = "https://i.ytimg.com/vi/vsGd6A-CrbY/maxresdefault.jpg"
                }
            );

            modelBuilder.Entity<AlbumUsuario>().HasData(
               new AlbumUsuario
               {
                   Id = 1,
                   //CodigoAlbumUsuario = "s",
                   //CodigoAlbum = "a",
                   AlbumId = 1,
                   UsuarioId = 1,
              },
               new AlbumUsuario
               {
                   Id = 2,
                   //CodigoAlbumUsuario = "t",
                   //CodigoAlbum = "b",
                   AlbumId = 1,
                   UsuarioId = 2,
              },
               new AlbumUsuario
               {
                   Id = 3,
                   //CodigoAlbumUsuario = "u",
                   //CodigoAlbum = "c",
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
                    Imagen = "https://www.cariverplate.com.ar/imagenes/jugadores/2022-08/1638-01-armani-imagenprincipal.png",
                    Titulo = "Armani Franco",
                    AlbumId = 1,
                },
                new AlbumImagenes
                {
                    Id = 2,
                    NumeroImagen = 201,
                    CodigoImagenOriginal = 32,
                    CantidadImpresa = 1000,
                    Imagen = "https://upload.wikimedia.org/wikipedia/commons/4/4e/Uni%C3%B3n_Espa%C3%B1ola_-_Curic%C3%B3_Unido%2C_2018-09-30_-_Daniel_Franco_-_02.jpg",
                    Titulo = "Franco Daniel",
                    AlbumId = 1,
                },
                new AlbumImagenes
                {
                    Id = 3,
                    NumeroImagen = 202,
                    CodigoImagenOriginal = 33,
                    CantidadImpresa = 1000,
                    Imagen = "https://resizer.glanacion.com/resizer/dRtGyNR9KJ5Zr0BtIjvpdV8J5uU=/1200x800/smart/filters:format(webp):quality(80)/cloudfront-us-east-1.images.arcpublishing.com/lanacionar/CCXOIDZHQRG6PP2JQ2LVCQHOFU.jpg",
                    Titulo = "Guido Herrera",
                    AlbumId = 1,
                },
                new AlbumImagenes
                {
                    Id = 4,
                    NumeroImagen = 2023,
                    CodigoImagenOriginal = 34,
                    CantidadImpresa = 1000,
                    Imagen = "https://toppng.com/uploads/preview/lucas-pratto-png-river-plate-plantel-2018-11563129429edz4folhq2.png",
                    Titulo = "Pratto Lucas",
                    AlbumId = 1,
                },
                new AlbumImagenes
                {
                    Id = 5,
                    NumeroImagen = 204,
                    CodigoImagenOriginal = 35,
                    CantidadImpresa = 1000,
                    Imagen = "https://futhead.cursecdn.com/static/img/21/players_alt/p67333374.png",
                    Titulo = "Bou Walter",
                    AlbumId = 1,
                },
                new AlbumImagenes
                {
                    Id = 6,
                    NumeroImagen = 205,
                    CodigoImagenOriginal = 36,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.clubtalleres.com.ar/wp-content/uploads/2021/01/VALOYES-4.png",
                    Titulo = "Valoyes Diego",
                    AlbumId = 1,
                },
                new AlbumImagenes
                {
                    Id = 7,
                    NumeroImagen = 20,
                    CodigoImagenOriginal = 37,
                    CantidadImpresa = 1000,
                    Imagen = "https://futhead.cursecdn.com/static/img/21/players_alt/p67333374.png",
                    Titulo = "Bou Walter",
                    AlbumId = 2,
                },
                new AlbumImagenes
                {
                    Id = 8,
                    NumeroImagen = 21,
                    CodigoImagenOriginal = 38,
                    CantidadImpresa = 1000,
                    Imagen = "https://toppng.com/uploads/preview/lucas-pratto-png-river-plate-plantel-2018-11563129429edz4folhq2.png",
                    Titulo = "Pratto Lucas",
                    AlbumId = 2,
                },
                new AlbumImagenes
                {
                    Id = 9,
                    NumeroImagen = 22,
                    CodigoImagenOriginal = 39,
                    CantidadImpresa = 1000,
                    Imagen = "https://upload.wikimedia.org/wikipedia/commons/4/4e/Uni%C3%B3n_Espa%C3%B1ola_-_Curic%C3%B3_Unido%2C_2018-09-30_-_Daniel_Franco_-_02.jpg",
                    Titulo = "Franco Daniel",
                    AlbumId = 2,
                },
                new AlbumImagenes
                {
                    Id = 10,
                    NumeroImagen = 23,
                    CodigoImagenOriginal = 40,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.cariverplate.com.ar/imagenes/jugadores/2022-08/1638-01-armani-imagenprincipal.png",
                    Titulo = "ArmanI Franco",
                    AlbumId = 2,
                },
                new AlbumImagenes
                {
                    Id = 11,
                    NumeroImagen = 24,
                    CodigoImagenOriginal = 41,
                    CantidadImpresa = 1000,
                    Imagen = "https://resizer.glanacion.com/resizer/dRtGyNR9KJ5Zr0BtIjvpdV8J5uU=/1200x800/smart/filters:format(webp):quality(80)/cloudfront-us-east-1.images.arcpublishing.com/lanacionar/CCXOIDZHQRG6PP2JQ2LVCQHOFU.jpg",
                    Titulo = "Guido Herrera",
                    AlbumId = 2,
                },
                new AlbumImagenes
                {
                    Id = 12,
                    NumeroImagen = 25,
                    CodigoImagenOriginal = 42,
                    CantidadImpresa = 1000,
                    Imagen = "https://media.tycsports.com/files/2020/11/19/154997/pulga-rodriguez.jpg",
                    Titulo = "Luis Miguel Rodríguez",
                    AlbumId = 2,
                },
                new AlbumImagenes
                {
                    Id = 13,
                    NumeroImagen = 26,
                    CodigoImagenOriginal = 43,
                    CantidadImpresa = 1000,
                    Imagen = "https://img2.freepng.es/20180526/vrr/kisspng-roberto-firmino-liverpool-f-c-football-player-ren-roberto-firmino-5b097993b70f13.2394382015273476037498.jpg",
                    Titulo = "Firmiño",
                    AlbumId = 3,
                },
                new AlbumImagenes
                {
                    Id = 14,
                    NumeroImagen = 27,
                    CodigoImagenOriginal = 44,
                    CantidadImpresa = 1000,
                    Imagen = "https://s.hs-data.com/bilder/spieler/gross/445514.jpg?fallback=png",
                    Titulo = "Alvarez Julian",
                    AlbumId = 3,
                },
                new AlbumImagenes
                {
                    Id = 15,
                    NumeroImagen = 28,
                    CodigoImagenOriginal = 45,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.bundesliga.com/player/dfl-obj-002g8i-dfl-clu-000007-dfl-sea-0001k6.png",
                    Titulo = "Erling Haaland",
                    AlbumId = 3,
                },
                new AlbumImagenes
                {
                    Id = 16,
                    NumeroImagen = 29,
                    CodigoImagenOriginal = 46,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.pinimg.com/736x/0c/f6/9d/0cf69df73b50d137e2815387e9513aee.jpg",
                    Titulo = "Cuti Romero",
                    AlbumId = 3,
                },
                new AlbumImagenes
                {
                    Id = 17,
                    NumeroImagen = 30,
                    CodigoImagenOriginal = 47,
                    CantidadImpresa = 1000,
                    Imagen = "https://1vs1-7f65.kxcdn.com/img/players/original/big/png/damian-emiliano-martinez-romero_16482_71-ub-800.png",
                    Titulo = "Dibu Martinez",
                    AlbumId = 3,
                },
                new AlbumImagenes
                {
                    Id = 18,
                    NumeroImagen = 31,
                    CodigoImagenOriginal = 48,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.atptour.com/-/media/tennis/players/head-shot/2022/05/25/15/47/nadal-head-2022-may.png",
                    Titulo = "Nadal Rafael",
                    AlbumId = 4,
                },
                new AlbumImagenes
                {
                    Id = 19,
                    NumeroImagen = 32,
                    CodigoImagenOriginal = 49,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.mdzol.com/u/fotografias/m/2022/9/15/f608x342-1282478_1312201_10.jpg",
                    Titulo = "Federer Roger",
                    AlbumId = 4,
                },
                new AlbumImagenes
                {
                    Id = 20,
                    NumeroImagen = 33,
                    CodigoImagenOriginal = 50,
                    CantidadImpresa = 1000,
                    Imagen = "https://imgresizer.eurosport.com/unsafe/1200x0/filters:format(jpeg):focal(1313x574:1315x572)/origin-imgresizer.eurosport.com/2021/06/28/3163279-64821308-2560-1440.jpg",
                    Titulo = "Andy Murray",
                    AlbumId = 4,
                },
                new AlbumImagenes
                {
                    Id = 21,
                    NumeroImagen = 34,
                    CodigoImagenOriginal = 51,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.atptour.com/-/media/tennis/players/head-shot/2019/05/13/18/27/delpotro_head_rome19.png",
                    Titulo = "Juan Martin Del Potro",
                    AlbumId = 4,
                },
                new AlbumImagenes
                {
                    Id = 22,
                    NumeroImagen = 35,
                    CodigoImagenOriginal = 52,
                    CantidadImpresa = 1000,
                    Imagen = "https://resizer.iproimg.com/unsafe/880x/filters:format(webp)/https://assets.iproup.com/assets/jpg/2021/11/23871.jpg",
                    Titulo = "David Nalbandian",
                    AlbumId = 5,
                },
                new AlbumImagenes
                {
                    Id = 23,
                    NumeroImagen = 36,
                    CodigoImagenOriginal = 53,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.atptour.com/-/media/tennis/players/head-shot/2019/02/25/18/18/djokovic_head_ao19.png",
                    Titulo = "Novak Djovich",
                    AlbumId = 5,
                },
                new AlbumImagenes
                {
                    Id = 24,
                    NumeroImagen = 37,
                    CodigoImagenOriginal = 54,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.atptour.com/-/media/tennis/players/gladiator/2022/05/18/21/10/tsitsipas-full-2022-may.png",
                    Titulo = "Stefanos Tsitsipas",
                    AlbumId = 5,
                },
                new AlbumImagenes
                {
                    Id = 25,
                    NumeroImagen = 37,
                    CodigoImagenOriginal = 55,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.atptour.com/-/media/alias/player-headshot/MM58",
                    Titulo = "Danil Medvedev",
                    AlbumId = 5,
                },
                new AlbumImagenes
                {
                    Id = 26,
                    NumeroImagen = 38,
                    CodigoImagenOriginal = 56,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.atptour.com/-/media/alias/player-headshot/Z355",
                    Titulo = "Alexander Zverev",
                    AlbumId = 5,
                },
                new AlbumImagenes
                {
                    Id = 27,
                    NumeroImagen = 39,
                    CodigoImagenOriginal = 57,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.atptour.com/-/media/tennis/players/gladiator/2022/06/18/22/21/fognini-full-2022-june-1.png",
                    Titulo = "Fabio Fognini",
                    AlbumId = 5,
                },
                new AlbumImagenes
                {
                    Id = 28,
                    NumeroImagen = 40,
                    CodigoImagenOriginal = 58,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.atptour.com/-/media/images/news/2022/10/01/11/07/ruud-tokyo-2022-draw.jpg",
                    Titulo = "Casper Ruud",
                    AlbumId = 5,
                },
                new AlbumImagenes
                {
                    Id = 2800,
                    NumeroImagen = 41,
                    CodigoImagenOriginal = 59,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.atptour.com/-/media/tennis/players/gladiator/2022/06/18/23/00/fritz-full-2022-june-1.png",
                    Titulo = "Taylor Fritz",
                    AlbumId = 5,
                },
                new AlbumImagenes
                {
                    Id = 29,
                    NumeroImagen = 42,
                    CodigoImagenOriginal = 60,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.atptour.com/-/media/tennis/players/gladiator/2022/06/16/03/16/tiafoe-full-2022-june.png",
                    Titulo = "Frances Tiafoe",
                    AlbumId = 6,
                },
                new AlbumImagenes
                {
                    Id = 30,
                    NumeroImagen = 43,
                    CodigoImagenOriginal = 61,
                    CantidadImpresa = 1000,
                    Imagen = "https://fotos.perfil.com/2022/01/31/trim/720/410/schwartzman-1306189.jpg",
                    Titulo = "Diego Schwartzman",
                    AlbumId = 6,
                },
                new AlbumImagenes
                {
                    Id = 31,
                    NumeroImagen = 44,
                    CodigoImagenOriginal = 62,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.atptour.com/-/media/alias/player-headshot/BK40",
                    Titulo = "Matteo Berretini",
                    AlbumId = 6,
                },
                new AlbumImagenes
                {
                    Id = 32,
                    NumeroImagen = 45,
                    CodigoImagenOriginal = 63,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.atptour.com/-/media/tennis/players/gladiator/2022/05/25/15/17/baez-full-2022-may.png",
                    Titulo = "Sebastian Baez",
                    AlbumId = 6,
                },
                new AlbumImagenes
                {
                    Id = 33,
                    NumeroImagen = 46,
                    CodigoImagenOriginal = 64,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.atptour.com/-/media/tennis/players/head-shot/2022/05/25/15/45/auger-aliassime-head-2022-may.png",
                    Titulo = "Felix Auger-Aliassime",
                    AlbumId = 6,
                },
                new AlbumImagenes
                {
                    Id = 34,
                    NumeroImagen = 47,
                    CodigoImagenOriginal = 65,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.atptour.com/es/players/john-isner/i186/www.atptour.com/-/media/tennis/players/head-shot/2022/05/25/15/38/isner-head-2022-may.png",
                    Titulo = "John Isner",
                    AlbumId = 6,
                },

                new AlbumImagenes
                {
                    Id = 41,
                    NumeroImagen = 54,
                    CodigoImagenOriginal = 72,
                    CantidadImpresa = 1000,
                    Imagen = "https://a.espncdn.com/combiner/i?img=/i/headshots/nba/players/full/272.png",
                    Titulo = "Manuel Ginobilli",
                    AlbumId = 7,
                },
                new AlbumImagenes
                {
                    Id = 42,
                    NumeroImagen = 55,
                    CodigoImagenOriginal = 73,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.pngmart.com/files/16/Kevin-Durant-PNG-Clipart.png",
                    Titulo = "Kevin Durant",
                    AlbumId = 7,
                },
                new AlbumImagenes
                {
                    Id = 43,
                    NumeroImagen = 56,
                    CodigoImagenOriginal = 74,
                    CantidadImpresa = 1000,
                    Imagen = "https://cdn.nba.com/headshots/nba/latest/1040x760/76979.png",
                    Titulo = "Elvin Hayes",
                    AlbumId = 7,
                },
                new AlbumImagenes
                {
                    Id = 44,
                    NumeroImagen = 57,
                    CodigoImagenOriginal = 75,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.pinimg.com/originals/6a/78/91/6a789135b8ed3755d3258a88d85851a6.png",
                    Titulo = "Bob Pettit",
                    AlbumId = 7,
                },
                new AlbumImagenes
                {
                    Id = 45,
                    NumeroImagen = 58,
                    CodigoImagenOriginal = 76,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.pngplay.com/wp-content/uploads/13/Giannis-Antetokounmpo-Transparent-PNG.png",
                    Titulo = "Giannis Antokoumpo",
                    AlbumId = 8,
                },
                new AlbumImagenes
                {
                    Id = 46,
                    NumeroImagen = 59,
                    CodigoImagenOriginal = 77,
                    CantidadImpresa = 1000,
                    Imagen = "https://e7.pngegg.com/pngimages/95/141/png-clipart-russell-westbrook-oklahoma-city-thunder-nba-houston-rockets-kolmikduubel-nba-tshirt-jersey-thumbnail.png",
                    Titulo = "Oscar Robertson",
                    AlbumId = 8,
                },
                new AlbumImagenes
                {
                    Id = 460,
                    NumeroImagen = 60,
                    CodigoImagenOriginal = 78,
                    CantidadImpresa = 1000,
                    Imagen = "https://i0.wp.com/basquettotal.com/wp-content/uploads/2022/02/RC_L2664-e1645034434512.jpg?resize=627%2C376&ssl=1",
                    Titulo = "Fernando Martinez",
                    AlbumId = 8,
                },
                new AlbumImagenes
                {
                    Id = 47,
                    NumeroImagen = 61,
                    CodigoImagenOriginal = 79,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.laliganacional.com.ar/fotosjugadores/143078.png",
                    Titulo = "Martin Cabrera",
                    AlbumId = 8,
                },
                new AlbumImagenes
                {
                    Id = 48,
                    NumeroImagen = 62,
                    CodigoImagenOriginal = 80,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.pinimg.com/originals/6a/78/91/6a789135b8ed3755d3258a88d85851a6.png",
                    Titulo = "Bob Pettit",
                    AlbumId = 8,
                },
                new AlbumImagenes
                {
                    Id = 49,
                    NumeroImagen = 63,
                    CodigoImagenOriginal = 81,
                    CantidadImpresa = 1000,
                    Imagen = "https://i0.wp.com/pbs.twimg.com/media/Ee47M9zWoAETxa9.png?resize=450%2C450&ssl=1&crop=1",
                    Titulo = "Juan Cruz Oberto",
                    AlbumId = 9,
                },
                new AlbumImagenes
                {
                    Id = 50,
                    NumeroImagen = 64,
                    CodigoImagenOriginal = 82,
                    CantidadImpresa = 1000,
                    Imagen = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/58/Milanesio_argentina_1992.jpg/200px-Milanesio_argentina_1992.jpg",
                    Titulo = "Marcelo Milanesio",
                    AlbumId = 9,
                },
                 new AlbumImagenes
                 {
                     Id = 51,
                     NumeroImagen = 65,
                     CodigoImagenOriginal = 83,
                     CantidadImpresa = 1000,
                     Imagen = "https://i0.wp.com/pbs.twimg.com/media/Ee47M9zWoAETxa9.png?resize=450%2C450&ssl=1&crop=1",
                     Titulo = "Julian Montoya",
                     AlbumId = 10,
                 },
                 new AlbumImagenes
                 {
                     Id = 52,
                     NumeroImagen = 66,
                     CodigoImagenOriginal = 84,
                     CantidadImpresa = 1000,
                     Imagen = "https://www.lavoz.com.ar/resizer/9fLRQKRS9-FVN2RZHhyjb4l_thI=/1024x683/smart/cloudfront-us-east-1.images.arcpublishing.com/grupoclarin/RL7CQYI2W5CPNNXEXDSOIRPCII.jpg",
                     Titulo = "Matias Alemano",
                     AlbumId = 10,
                 },
                new AlbumImagenes
                {
                    Id = 53,
                    NumeroImagen = 67,
                    CodigoImagenOriginal = 85,
                    CantidadImpresa = 1000,
                    Imagen = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTVBi6OujLCFBCmpgMvMZQE6f9zLelwg1mEYPZs_Rt2tl0xszSijQdHiwhK4YtvWWlv08Q&usqp=CAU",
                    Titulo = "Julian Cruz Mallia",
                    AlbumId = 10,
                },
                new AlbumImagenes
                {
                    Id = 54,
                    NumeroImagen = 68,
                    CodigoImagenOriginal = 86,
                    CantidadImpresa = 1000,
                    Imagen = "https://deporfe.com/wp-content/uploads/2022/05/cubelli.jpg",
                    Titulo = "Tomas Cubeli",
                    AlbumId = 10,
                },
                new AlbumImagenes
                {
                    Id = 55,
                    NumeroImagen = 69,
                    CodigoImagenOriginal = 87,
                    CantidadImpresa = 1000,
                    Imagen = "https://sites.google.com/site/vidapuma/_/rsrc/1318771820838/jugadores/felipe-contepomi/J-12-Contepomi_%20Felipe.jpg",
                    Titulo = "Felipe Contemponi",
                    AlbumId = 10,
                },
                new AlbumImagenes
                {
                    Id = 56,
                    NumeroImagen = 70,
                    CodigoImagenOriginal = 88,
                    CantidadImpresa = 1000,
                    Imagen = "https://a.espncdn.com/photo/2021/0528/r860181_2_1024x576_16-9.jpg",
                    Titulo = "Julian Montoya",
                    AlbumId = 10,
                },
                new AlbumImagenes
                {
                    Id = 57,
                    NumeroImagen = 71,
                    CodigoImagenOriginal = 89,
                    CantidadImpresa = 1000,
                    Imagen = "https://cordobaxv.com.ar/wp-content/uploads/2020/07/2BZUZGQLGBHSPCRYIDF7POGUWY.jpg",
                    Titulo = "Beauden Barrett",
                    AlbumId = 10,
                },
                new AlbumImagenes
                {
                    Id = 58,
                    NumeroImagen = 72,
                    CodigoImagenOriginal = 90,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.allblacks.com/assets/Uploads/SW-copy__FocusFillWyIwLjAwIiwiMC4wMCIsMzUwLDQ2MF0.png",
                    Titulo = "Sam Whitelock",
                    AlbumId = 10,
                },
                new AlbumImagenes
                {
                    Id = 59,
                    NumeroImagen = 73,
                    CodigoImagenOriginal = 91,
                    CantidadImpresa = 1000,
                    Imagen = "https://cordobaxv.com.ar/wp-content/uploads/2021/12/Sam-Cane-contratro-allblacks-2025.jpg",
                    Titulo = "San Cane",
                    AlbumId = 10,
                },
                new AlbumImagenes
                {
                    Id = 60,
                    NumeroImagen = 74,
                    CodigoImagenOriginal = 92,
                    CantidadImpresa = 1000,
                    Imagen = "https://e00-elmundo.uecdn.es/assets/multimedia/imagenes/2015/10/30/14462260859727.jpg",
                    Titulo = "David Pocock",
                    AlbumId = 11,
                },
                new AlbumImagenes
                {
                    Id = 61,
                    NumeroImagen = 75,
                    CodigoImagenOriginal = 93,
                    CantidadImpresa = 1000,
                    Imagen = "https://a.espncdn.com/photo/2022/0805/r1044928_1296x729_16-9.jpg",
                    Titulo = "Michael Hooper",
                    AlbumId = 11,
                },
                new AlbumImagenes
                {
                    Id = 62,
                    NumeroImagen = 76,
                    CodigoImagenOriginal = 94,
                    CantidadImpresa = 1000,
                    Imagen = "https://d3gbf3ykm8gp5c.cloudfront.net/content/uploads/2022/02/18081522/Jake-Gordon-Waratahs-Super-Rugby-TT-2021-PA.jpg",
                    Titulo = "Jake Gordon",
                    AlbumId = 11,
                },
                new AlbumImagenes
                {
                    Id = 63,
                    NumeroImagen = 77,
                    CodigoImagenOriginal = 95,
                    CantidadImpresa = 1000,
                    Imagen = "https://s.libertaddigital.com/fotos/noticias/sebastien-chabal-050514.jpg",
                    Titulo = "Sebastian Chabal",
                    AlbumId = 11,
                },
                new AlbumImagenes
                {
                    Id = 64,
                    NumeroImagen = 78,
                    CodigoImagenOriginal = 96,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.lequipe.fr/_medias/img-photo-jpg/atonio-a-ete-condamne-a-six-mois-de-prison-avec-sursis-r-perrocheau-l-equipe/1500000001048599/168:174,1656:1166-828-552-75/c1350.jpg",
                    Titulo = "Uini Atonio",
                    AlbumId = 11,
                },
                new AlbumImagenes
                {
                    Id = 65,
                    NumeroImagen = 79,
                    CodigoImagenOriginal = 97,
                    CantidadImpresa = 1000,
                    Imagen = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQiFcdujAoFWYVHreXcZehSiNpkZ8qyDb9BSg&usqp=CAU",
                    Titulo = "Atsushi Sakate",
                    AlbumId = 12,
                },
                new AlbumImagenes
                {
                    Id = 66,
                    NumeroImagen = 80,
                    CodigoImagenOriginal = 98,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.ultimaterugby.com/images/entities/231381-a666c147e2-11/KenkiFukuokarugbyplayer.jpg",
                    Titulo = "Kenki Fukuoka",
                    AlbumId = 12,
                },
                new AlbumImagenes
                {
                    Id = 67,
                    NumeroImagen = 81,
                    CodigoImagenOriginal = 99,
                    CantidadImpresa = 1000,
                    Imagen = "https://d3gbf3ykm8gp5c.cloudfront.net/content/uploads/2019/10/05130704/Yu-Tamura-Japan-RWC-2019-PA.jpg",
                    Titulo = "Yu Tamura",
                    AlbumId = 12,
                },
                new AlbumImagenes
                {
                    Id = 68,
                    NumeroImagen = 82,
                    CodigoImagenOriginal = 100,
                    CantidadImpresa = 1000,
                    Imagen = "https://d3gbf3ykm8gp5c.cloudfront.net/content/uploads/2020/07/15094835/Johnny-Williams-Newcastle-Falcons-training-2020-PA.jpg",
                    Titulo = "Johnny Williams",
                    AlbumId = 12,
                },
                new AlbumImagenes
                {
                    Id = 69,
                    NumeroImagen = 83,
                    CodigoImagenOriginal = 101,
                    CantidadImpresa = 1000,
                    Imagen = "https://d3gbf3ykm8gp5c.cloudfront.net/content/uploads/2021/10/26123449/Wales-centre-Jonathan-Davies-looking-back-PA-1024x630.jpg",
                    Titulo = "Jonathan Davies",
                    AlbumId = 12,
                },
                new AlbumImagenes
                {
                    Id = 70,
                    NumeroImagen = 84,
                    CodigoImagenOriginal = 102,
                    CantidadImpresa = 1000,
                    Imagen = "https://d3gbf3ykm8gp5c.cloudfront.net/content/uploads/2020/09/17162439/Dan-Biggar-for-Wales-v-England-PA.jpg",
                    Titulo = "Dan Biggar",
                    AlbumId = 12,
                },
                new AlbumImagenes
                {
                    Id = 620,
                    NumeroImagen = 85,
                    CodigoImagenOriginal = 103,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.ytimg.com/vi/O6IPRouzvU0/hqdefault.jpg",
                    Titulo = "Joaquin Prada Centro",
                    AlbumId = 12,
                },
                new AlbumImagenes
                {
                    Id = 630,
                    NumeroImagen = 86,
                    CodigoImagenOriginal = 104,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.pinimg.com/originals/c4/4a/d3/c44ad3182299b9c08337465bef2ea2bc.png",
                    Titulo = "Boo",
                    AlbumId = 13,
                },
                new AlbumImagenes
                {
                    Id = 640,
                    NumeroImagen = 87,
                    CodigoImagenOriginal = 105,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.pinimg.com/originals/45/87/71/4587717835c6e0bbb388844a395bd04e.png",
                    Titulo = "Mike Wazowski",
                    AlbumId = 13,
                },
                new AlbumImagenes
                {
                    Id = 650,
                    NumeroImagen = 88,
                    CodigoImagenOriginal = 106,
                    CantidadImpresa = 1000,
                    Imagen = "https://e7.pngegg.com/pngimages/178/635/png-clipart-disney-monster-inc-fungus-fungus-at-the-movies-cartoons-thumbnail.png",
                    Titulo = "Fungus",
                    AlbumId = 13,
                },
                new AlbumImagenes
                {
                    Id = 660,
                    NumeroImagen = 89,
                    CodigoImagenOriginal = 107,
                    CantidadImpresa = 1000,
                    Imagen = "https://static.wikia.nocookie.net/heroes-of-the-characters/images/e/e5/Roz_%28Monsters_Inc._-_Render%29.png/revision/latest?cb=20210825084538",
                    Titulo = "Roz",
                    AlbumId = 13,
                },
                new AlbumImagenes
                {
                    Id = 670,
                    NumeroImagen = 90,
                    CodigoImagenOriginal = 108,
                    CantidadImpresa = 1000,
                    Imagen = "https://static.wikia.nocookie.net/monstersincmovies/images/6/67/Bile-white.jpg/revision/latest?cb=20130515201629",
                    Titulo = "Bile",
                    AlbumId = 13,
                },
                new AlbumImagenes
                {
                    Id = 680,
                    NumeroImagen = 91,
                    CodigoImagenOriginal = 109,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.pinimg.com/originals/c4/4a/d3/c44ad3182299b9c08337465bef2ea2bc.png",
                    Titulo = "Boo",
                    AlbumId = 14,
                },
                new AlbumImagenes
                {
                    Id = 690,
                    NumeroImagen = 92,
                    CodigoImagenOriginal = 110,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.pinimg.com/originals/45/87/71/4587717835c6e0bbb388844a395bd04e.png",
                    Titulo = "Mike Wazowski",
                    AlbumId = 14,
                },
                new AlbumImagenes
                {
                    Id = 700,
                    NumeroImagen = 93,
                    CodigoImagenOriginal = 111,
                    CantidadImpresa = 1000,
                    Imagen = "https://e7.pngegg.com/pngimages/178/635/png-clipart-disney-monster-inc-fungus-fungus-at-the-movies-cartoons-thumbnail.png",
                    Titulo = "Fungus",
                    AlbumId = 14,
                },
                new AlbumImagenes
                {
                    Id = 71,
                    NumeroImagen = 94,
                    CodigoImagenOriginal = 112,
                    CantidadImpresa = 1000,
                    Imagen = "https://static.wikia.nocookie.net/heroes-of-the-characters/images/e/e5/Roz_%28Monsters_Inc._-_Render%29.png/revision/latest?cb=20210825084538",
                    Titulo = "Roz",
                    AlbumId = 14,
                },
                new AlbumImagenes
                {
                    Id = 72,
                    NumeroImagen = 95,
                    CodigoImagenOriginal = 113,
                    CantidadImpresa = 1000,
                    Imagen = "https://static.wikia.nocookie.net/monstersincmovies/images/6/67/Bile-white.jpg/revision/latest?cb=20130515201629",
                    Titulo = "Bile",
                    AlbumId = 14,
                },
                new AlbumImagenes
                {
                    Id = 73,
                    NumeroImagen = 96,
                    CodigoImagenOriginal = 114,
                    CantidadImpresa = 1000,
                    Imagen = "https://fotografias.antena3.com/clipping/cmsimages01/2018/10/18/226A74E0-C67D-40BA-BD22-9EE8E9909F51/69.jpg?crop=1:1,smart&width=1200&height=1200&optimize=low&format=webply",
                    Titulo = "Troy Bolton",
                    AlbumId = 14,
                },
                new AlbumImagenes
                {
                    Id = 74,
                    NumeroImagen = 97,
                    CodigoImagenOriginal = 115,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.pinimg.com/originals/df/62/35/df623531f1ee71776396f506916d4095.png",
                    Titulo = "Gabriela Montes",
                    AlbumId = 15,
                },
                new AlbumImagenes
                {
                    Id = 75,
                    NumeroImagen = 98,
                    CodigoImagenOriginal = 116,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.pinimg.com/474x/77/05/bf/7705bf1970756bac22a304cf33abca34--ashley-tisdale-drama-queens.jpg",
                    Titulo = "Sharpay Evans",
                    AlbumId = 15,
                },
                new AlbumImagenes
                {
                    Id = 76,
                    NumeroImagen = 99,
                    CodigoImagenOriginal = 117,
                    CantidadImpresa = 1000,
                    Imagen = "http://images.girlslife.com/posts/004/4184/prettyleadphoto.jpg",
                    Titulo = "Martha Cox",
                    AlbumId = 15,
                },
                new AlbumImagenes
                {
                    Id = 77,
                    NumeroImagen = 100,
                    CodigoImagenOriginal = 118,
                    CantidadImpresa = 1000,
                    Imagen = "https://static.wikia.nocookie.net/my-high-school-musical/images/2/21/406630.jpg/revision/latest?cb=20180729024606",
                    Titulo = "Lucille Bolton",
                    AlbumId = 15,
                },
                new AlbumImagenes
                {
                    Id = 78,
                    NumeroImagen = 101,
                    CodigoImagenOriginal = 119,
                    CantidadImpresa = 1000,
                    Imagen = "https://fotografias.antena3.com/clipping/cmsimages01/2018/10/18/226A74E0-C67D-40BA-BD22-9EE8E9909F51/69.jpg?crop=1:1,smart&width=1200&height=1200&optimize=low&format=webply",
                    Titulo = "Troy Bolton",
                    AlbumId = 15,
                },
                new AlbumImagenes
                {
                    Id = 79,
                    NumeroImagen = 102,
                    CodigoImagenOriginal = 120,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.pinimg.com/originals/df/62/35/df623531f1ee71776396f506916d4095.png",
                    Titulo = "Gabriela Montes",
                    AlbumId = 15,
                },
                new AlbumImagenes
                {
                    Id = 80,
                    NumeroImagen = 103,
                    CodigoImagenOriginal = 121,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.pinimg.com/474x/77/05/bf/7705bf1970756bac22a304cf33abca34--ashley-tisdale-drama-queens.jpg",
                    Titulo = "Sharpay Evans",
                    AlbumId = 16,
                },
                new AlbumImagenes
                {
                    Id = 81,
                    NumeroImagen = 104,
                    CodigoImagenOriginal = 122,
                    CantidadImpresa = 1000,
                    Imagen = "http://images.girlslife.com/posts/004/4184/prettyleadphoto.jpg",
                    Titulo = "Martha Cox",
                    AlbumId = 15,
                },
                new AlbumImagenes
                {
                    Id = 82,
                    NumeroImagen = 105,
                    CodigoImagenOriginal = 123,
                    CantidadImpresa = 1000,
                    Imagen = "https://static.wikia.nocookie.net/my-high-school-musical/images/2/21/406630.jpg/revision/latest?cb=20180729024606",
                    Titulo = "Lucile Bolton",
                    AlbumId = 16,
                },
                 new AlbumImagenes
                 {
                     Id = 83,
                     NumeroImagen = 106,
                     CodigoImagenOriginal = 124,
                     CantidadImpresa = 1000,
                     Imagen = "https://fotografias.antena3.com/clipping/cmsimages01/2018/10/18/226A74E0-C67D-40BA-BD22-9EE8E9909F51/69.jpg?crop=1:1,smart&width=1200&height=1200&optimize=low&format=webply",
                     Titulo = "Troy Bolton",
                     AlbumId = 16,
                 },
                new AlbumImagenes
                {
                    Id = 84,
                    NumeroImagen = 107,
                    CodigoImagenOriginal = 125,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.pinimg.com/originals/df/62/35/df623531f1ee71776396f506916d4095.png",
                    Titulo = "Gabriela Montes",
                    AlbumId = 16,
                },
                new AlbumImagenes
                {
                    Id = 85,
                    NumeroImagen = 108,
                    CodigoImagenOriginal = 126,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.pinimg.com/474x/77/05/bf/7705bf1970756bac22a304cf33abca34--ashley-tisdale-drama-queens.jpg",
                    Titulo = "Sharpay Evans",
                    AlbumId = 16,
                },
                new AlbumImagenes
                {
                    Id = 86,
                    NumeroImagen = 109,
                    CodigoImagenOriginal = 127,
                    CantidadImpresa = 1000,
                    Imagen = "http://images.girlslife.com/posts/004/4184/prettyleadphoto.jpg",
                    Titulo = "Martha Cox",
                    AlbumId = 16,
                },
                new AlbumImagenes
                {
                    Id = 87,
                    NumeroImagen = 110,
                    CodigoImagenOriginal = 128,
                    CantidadImpresa = 1000,
                    Imagen = "https://static.wikia.nocookie.net/my-high-school-musical/images/2/21/406630.jpg/revision/latest?cb=20180729024606",
                    Titulo = "Lucile Bolton",
                    AlbumId = 16,
                },
                new AlbumImagenes
                {
                    Id = 88,
                    NumeroImagen = 111,
                    CodigoImagenOriginal = 129,
                    CantidadImpresa = 1000,
                    Imagen = "https://w7.pngwing.com/pngs/276/1019/png-transparent-sid-sloth-scrat-ice-age-the-sloth-buckle-free.png",
                    Titulo = "Sid",
                    AlbumId = 26,
                },
                new AlbumImagenes
                {
                    Id = 89,
                    NumeroImagen = 112,
                    CodigoImagenOriginal = 130,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.kindpng.com/picc/m/236-2361642_mammoth-manny-la-era-de-hielo-hd-png.png",
                    Titulo = "Many",
                    AlbumId = 26,
                },
                new AlbumImagenes
                {
                    Id = 90,
                    NumeroImagen = 113,
                    CodigoImagenOriginal = 131,
                    CantidadImpresa = 1000,
                    Imagen = "https://static.wikia.nocookie.net/iceage/images/a/a7/Bodoque.jpg/revision/latest?cb=20120607153944&path-prefix=es",
                    Titulo = "Roshan",
                    AlbumId = 26,
                },
                new AlbumImagenes
                {
                    Id = 91,
                    NumeroImagen = 114,
                    CodigoImagenOriginal = 132,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.pngkey.com/png/detail/318-3182891_download-diego-la-era-de-hielo.png",
                    Titulo = "Diego",
                    AlbumId = 26,
                },
                new AlbumImagenes
                {
                    Id = 92,
                    NumeroImagen = 115,
                    CodigoImagenOriginal = 133,
                    CantidadImpresa = 1000,
                    Imagen = "https://w7.pngwing.com/pngs/84/894/png-transparent-ice-age-scrat-scrat-sid-manfred-ellie-ice-age-ice-age-mammal-heroes-fauna-thumbnail.png",
                    Titulo = "Scrat",
                    AlbumId = 26,
                },
                new AlbumImagenes
                {
                    Id = 93,
                    NumeroImagen = 116,
                    CodigoImagenOriginal = 134,
                    CantidadImpresa = 1000,
                    Imagen = "https://w7.pngwing.com/pngs/276/1019/png-transparent-sid-sloth-scrat-ice-age-the-sloth-buckle-free.png",
                    Titulo = "Sid",
                    AlbumId = 27,
                },
                new AlbumImagenes
                {
                    Id = 94,
                    NumeroImagen = 117,
                    CodigoImagenOriginal = 135,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.kindpng.com/picc/m/236-2361642_mammoth-manny-la-era-de-hielo-hd-png.png",
                    Titulo = "Many",
                    AlbumId = 27,
                },
                new AlbumImagenes
                {
                    Id = 95,
                    NumeroImagen = 118,
                    CodigoImagenOriginal = 136,
                    CantidadImpresa = 1000,
                    Imagen = "https://static.wikia.nocookie.net/iceage/images/a/a7/Bodoque.jpg/revision/latest?cb=20120607153944&path-prefix=es",
                    Titulo = "Roshan",
                    AlbumId = 27,
                },
                new AlbumImagenes
                {
                    Id = 96,
                    NumeroImagen = 119,
                    CodigoImagenOriginal = 137,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.pngkey.com/png/detail/318-3182891_download-diego-la-era-de-hielo.png",
                    Titulo = "Diego",
                    AlbumId = 27,
                },
                new AlbumImagenes
                {
                    Id = 97,
                    NumeroImagen = 120,
                    CodigoImagenOriginal = 138,
                    CantidadImpresa = 1000,
                    Imagen = "https://w7.pngwing.com/pngs/84/894/png-transparent-ice-age-scrat-scrat-sid-manfred-ellie-ice-age-ice-age-mammal-heroes-fauna-thumbnail.png",
                    Titulo = "Scrat",
                    AlbumId = 27,
                },
                new AlbumImagenes
                {
                    //era hielo 3
                    Id = 98,
                    NumeroImagen = 121,
                    CodigoImagenOriginal = 139,
                    CantidadImpresa = 1000,
                    Imagen = "https://w7.pngwing.com/pngs/276/1019/png-transparent-sid-sloth-scrat-ice-age-the-sloth-buckle-free.png",
                    Titulo = "Sid",
                    AlbumId = 28,
                },
                new AlbumImagenes
                {
                    Id = 99,
                    NumeroImagen = 122,
                    CodigoImagenOriginal = 140,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.kindpng.com/picc/m/236-2361642_mammoth-manny-la-era-de-hielo-hd-png.png",
                    Titulo = "Many",
                    AlbumId = 28,
                },
                new AlbumImagenes
                {
                    Id = 100,
                    NumeroImagen = 123,
                    CodigoImagenOriginal = 141,
                    CantidadImpresa = 1000,
                    Imagen = "https://static.wikia.nocookie.net/iceage/images/a/a7/Bodoque.jpg/revision/latest?cb=20120607153944&path-prefix=es",
                    Titulo = "Roshan",
                    AlbumId = 28,
                },
                new AlbumImagenes
                {
                    Id = 101,
                    NumeroImagen = 124,
                    CodigoImagenOriginal = 142,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.pngkey.com/png/detail/318-3182891_download-diego-la-era-de-hielo.png",
                    Titulo = "Diego",
                    AlbumId = 28,
                },
                new AlbumImagenes
                {
                    Id = 102,
                    NumeroImagen = 125,
                    CodigoImagenOriginal = 143,
                    CantidadImpresa = 1000,
                    Imagen = "https://w7.pngwing.com/pngs/84/894/png-transparent-ice-age-scrat-scrat-sid-manfred-ellie-ice-age-ice-age-mammal-heroes-fauna-thumbnail.png",
                    Titulo = "Scrat",
                    AlbumId = 28,
                },
                new AlbumImagenes
                {
                    Id = 103,
                    NumeroImagen = 126,
                    CodigoImagenOriginal = 144,
                    CantidadImpresa = 1000,
                    Imagen = "https://static.wikia.nocookie.net/james-camerons-avatar/images/1/17/Grace.png/revision/latest?cb=20210408152516&path-prefix=es",
                    Titulo = "Dra Grace",
                    AlbumId = 100,
                },
                new AlbumImagenes
                {
                    Id = 104,
                    NumeroImagen = 127,
                    CodigoImagenOriginal = 145,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.pinimg.com/736x/b2/fd/5a/b2fd5a5b1aa105021bba52b2b4ee2394.jpg",
                    Titulo = "Neyriti",
                    AlbumId = 100,
                },
                new AlbumImagenes
                {
                    Id = 105,
                    NumeroImagen = 128,
                    CodigoImagenOriginal = 146,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.writeups.org/wp-content/uploads/Jake-Sully-Avatar-movie-Sam-Worthington.jpg",
                    Titulo = "Jake Sully",
                    AlbumId = 100,
                },
                new AlbumImagenes
                {
                    Id = 106,
                    NumeroImagen = 129,
                    CodigoImagenOriginal = 147,
                    CantidadImpresa = 1000,
                    Imagen = "https://static.wikia.nocookie.net/james-camerons-avatar/images/8/82/Tsu%27tey_te_Rongloa_Ateyo%27itan.png/revision/latest?cb=20210122023316&path-prefix=es",
                    Titulo = "Tsutey",
                    AlbumId = 100,
                },
                new AlbumImagenes
                {
                    Id = 107,
                    NumeroImagen = 130,
                    CodigoImagenOriginal = 148,
                    CantidadImpresa = 1000,
                    Imagen = "https://static.wikia.nocookie.net/james-camerons-avatar/images/2/21/Quaritch.png/revision/latest?cb=20210527234304&path-prefix=es",
                    Titulo = "Coronel Milles",
                    AlbumId = 100,
                },
                new AlbumImagenes
                {
                    Id = 108,
                    NumeroImagen = 131,
                    CodigoImagenOriginal = 149,
                    CantidadImpresa = 1000,
                    Imagen = "https://static.wikia.nocookie.net/james-camerons-avatar/images/1/17/Grace.png/revision/latest?cb=20210408152516&path-prefix=es",
                    Titulo = "Dra Grace",
                    AlbumId = 101,
                },
                new AlbumImagenes
                {
                    Id = 109,
                    NumeroImagen = 132,
                    CodigoImagenOriginal = 150,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.pinimg.com/736x/b2/fd/5a/b2fd5a5b1aa105021bba52b2b4ee2394.jpg",
                    Titulo = "Neyriti",
                    AlbumId = 101,
                },
                new AlbumImagenes
                {
                    Id = 110,
                    NumeroImagen = 133,
                    CodigoImagenOriginal = 151,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.writeups.org/wp-content/uploads/Jake-Sully-Avatar-movie-Sam-Worthington.jpg",
                    Titulo = "Jake Sully",
                    AlbumId = 101,
                },
                new AlbumImagenes
                {
                    Id = 111,
                    NumeroImagen = 134,
                    CodigoImagenOriginal = 152,
                    CantidadImpresa = 1000,
                    Imagen = "https://static.wikia.nocookie.net/james-camerons-avatar/images/8/82/Tsu%27tey_te_Rongloa_Ateyo%27itan.png/revision/latest?cb=20210122023316&path-prefix=es",
                    Titulo = "Tsutey",
                    AlbumId = 101,
                },
                new AlbumImagenes
                {
                    Id = 112,
                    NumeroImagen = 135,
                    CodigoImagenOriginal = 153,
                    CantidadImpresa = 1000,
                    Imagen = "https://static.wikia.nocookie.net/james-camerons-avatar/images/2/21/Quaritch.png/revision/latest?cb=20210527234304&path-prefix=es",
                    Titulo = "Coronel Milles",
                    AlbumId = 101,
                },
                new AlbumImagenes
                {
                    Id = 113,
                    NumeroImagen = 136,
                    CodigoImagenOriginal = 154,
                    CantidadImpresa = 1000,
                    Imagen = "https://tierragamer.com/wp-content/uploads/2019/06/Dragon-Ball-Pequeno-Goku.jpg",
                    Titulo = "Goku",
                    AlbumId = 63,
                },
                new AlbumImagenes
                {
                    Id = 114,
                    NumeroImagen = 137,
                    CodigoImagenOriginal = 155,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.pinimg.com/originals/01/1f/32/011f32363d97557ee7eaa383a07c2f5a.jpg",
                    Titulo = "Krilin",
                    AlbumId = 63,
                },
                new AlbumImagenes
                {
                    Id = 115,
                    NumeroImagen = 138,
                    CodigoImagenOriginal = 156,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.geekmi.news/__export/1654699584752/sites/debate/img/2022/06/08/taopaipai.jpg_1339198940.jpg",
                    Titulo = "Tao Pai Pai",
                    AlbumId = 63,
                },
                 new AlbumImagenes
                 {
                     Id = 116,
                     NumeroImagen = 139,
                     CodigoImagenOriginal = 157,
                     CantidadImpresa = 1000,
                     Imagen = "https://mir-s3-cdn-cf.behance.net/projects/404/11c0cc103711653.5f52b4b6a6dbd.png",
                     Titulo = "Picolo",
                     AlbumId = 63,
                 },
                 new AlbumImagenes
                 {
                     Id = 117,
                     NumeroImagen = 140,
                     CodigoImagenOriginal = 158,
                     CantidadImpresa = 1000,
                     Imagen = "https://pm1.narvii.com/6988/9052161534eeeec16bb57b2c7ab7441e25ce4dc5r1-720-404v2_hq.jpg",
                     Titulo = "General Blue",
                     AlbumId = 63,
                 },
                new AlbumImagenes
                {
                    Id = 118,
                    NumeroImagen = 141,
                    CodigoImagenOriginal = 159,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.fayerwayer.com/resizer/UAeNc2JHJP1xypVHNAVrMPqxEz4=/800x0/filters:format(jpg):quality(70)/cloudfront-us-east-1.images.arcpublishing.com/metroworldnews/VBRF4I3YM5G63AU637TTONVARE.jpg",
                    Titulo = "Vegeta",
                    AlbumId = 64,
                },
                new AlbumImagenes
                {
                    Id = 1180,
                    NumeroImagen = 142,
                    CodigoImagenOriginal = 160,
                    CantidadImpresa = 1000,
                    Imagen = "https://e.rpp-noticias.io/xlarge/2019/10/09/015501_849974.jpg",
                    Titulo = "Gohan",
                    AlbumId = 64,
                },
                new AlbumImagenes
                {
                    Id = 119,
                    NumeroImagen = 143,
                    CodigoImagenOriginal = 161,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.latercera.com/resizer/dFjofjUYrC3BacG8B3PGUYcgRnc=/900x600/smart/arc-anglerfish-arc2-prod-copesa.s3.amazonaws.com/public/WVF74GVKZZAI5KZQQRW6OZ6QGI.jpg",
                    Titulo = "Cell",
                    AlbumId = 64,
                },
                 new AlbumImagenes
                 {
                     Id = 120,
                     NumeroImagen = 144,
                     CodigoImagenOriginal = 162,
                     CantidadImpresa = 1000,
                     Imagen = "https://i.pinimg.com/originals/26/d0/8b/26d08be0ab87326fc6ad26cc9bdb2ddf.png",
                     Titulo = "Majin Boo",
                     AlbumId = 64,
                 },
                 new AlbumImagenes
                 {
                     Id = 121,
                     NumeroImagen = 145,
                     CodigoImagenOriginal = 163,
                     CantidadImpresa = 1000,
                     Imagen = "https://i.pinimg.com/originals/4e/3e/b5/4e3eb5933953657a4d1ea95cee39f366.png",
                     Titulo = "Darbura",
                     AlbumId = 64,
                 },
                new AlbumImagenes
                {
                    Id = 122,
                    NumeroImagen = 146,
                    CodigoImagenOriginal = 164,
                    CantidadImpresa = 1000,
                    Imagen = "http://pm1.narvii.com/6542/f434e2fb6efb78b182057696bbfef9760016dc5a_00.jpg",
                    Titulo = "Bills",
                    AlbumId = 65,
                },
                new AlbumImagenes
                {
                    Id = 123,
                    NumeroImagen = 147,
                    CodigoImagenOriginal = 165,
                    CantidadImpresa = 1000,
                    Imagen = "https://depor.com/resizer/0FTdOejzzLcQZgm2s-GDC87wDU8=/1200x1200/smart/filters:format(jpeg):quality(75)/cloudfront-us-east-1.images.arcpublishing.com/elcomercio/WDXFCIRCYNCHDCZ7F3FPT7K5V4.jpg",
                    Titulo = "Wiss",
                    AlbumId = 65,
                },
                new AlbumImagenes
                {
                    Id = 124,
                    NumeroImagen = 148,
                    CodigoImagenOriginal = 166,
                    CantidadImpresa = 1000,
                    Imagen = "https://gcdn.lanetaneta.com/wp-content/uploads/2022/03/La-historia-de-fondo-de-Dragon-Ball-Super-de-Jiren-780x470.jpg",
                    Titulo = "Jiren",
                    AlbumId = 65,
                },
                new AlbumImagenes
                {
                    Id = 125,
                    NumeroImagen = 149,
                    CodigoImagenOriginal = 167,
                    CantidadImpresa = 1000,
                    Imagen = "https://depor.com/resizer/hY70NAtbG9xSjZW65ZDRrs7X_tU=/580x330/smart/filters:format(jpeg):quality(75)/cloudfront-us-east-1.images.arcpublishing.com/elcomercio/XYRVWY753VGBZJA6FFXIAJBHF4.jpg",
                    Titulo = "Topo",
                    AlbumId = 65,
                },
                new AlbumImagenes
                {
                    Id = 126,
                    NumeroImagen = 150,
                    CodigoImagenOriginal = 168,
                    CantidadImpresa = 1000,
                    Imagen = "https://media.vandal.net/i/1440x1080/49072/dragon-ball-fighterz-2018927193257_3.jpg",
                    Titulo = "Androide 17",
                    AlbumId = 65,
                },
                new AlbumImagenes
                {
                    Id = 127,
                    NumeroImagen = 151,
                    CodigoImagenOriginal = 169,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.blogs.es/bc1dd2/naruto/450_1000.png",
                    Titulo = "Naruto",
                    AlbumId = 96,
                },
                new AlbumImagenes
                {
                    Id = 128,
                    NumeroImagen = 152,
                    CodigoImagenOriginal = 170,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.pinimg.com/600x315/a6/1f/be/a61fbe0e9d11632d65dd09fa0bead32d.jpg",
                    Titulo = "Sasuke",
                    AlbumId = 96,
                },
                new AlbumImagenes
                {
                    Id = 129,
                    NumeroImagen = 153,
                    CodigoImagenOriginal = 171,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.egames.news/__export/1637434465357/sites/debate/img/2021/11/20/itachi-uchiha.jpg_423682103.jpg",
                    Titulo = "Itachi",
                    AlbumId = 96,
                },
                new AlbumImagenes
                {
                    Id = 130,
                    NumeroImagen = 154,
                    CodigoImagenOriginal = 172,
                    CantidadImpresa = 1000,
                    Imagen = "https://w7.pngwing.com/pngs/130/591/png-transparent-sakura-haruno-kakashi-hatake-naruto-anime-sakura-fictional-character-cartoon-arm.png",
                    Titulo = "Sakura",
                    AlbumId = 96,
                },
                new AlbumImagenes
                {
                    Id = 131,
                    NumeroImagen = 155,
                    CodigoImagenOriginal = 173,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.lifeder.com/wp-content/uploads/2016/12/frases-de-Madara-Uchiha.jpg",
                    Titulo = "Madara",
                    AlbumId = 96,
                },
                new AlbumImagenes
                {
                    Id = 132,
                    NumeroImagen = 156,
                    CodigoImagenOriginal = 174,
                    CantidadImpresa = 1000,
                    Imagen = "https://indiehoy.com/wp-content/uploads/2018/11/naruto.jpg",
                    Titulo = "Jiraiya",
                    AlbumId = 70,
                },
                new AlbumImagenes
                {
                    Id = 133,
                    NumeroImagen = 157,
                    CodigoImagenOriginal = 175,
                    CantidadImpresa = 1000,
                    Imagen = "https://www.looper.com/img/gallery/untold-truth-of-obito-uchiha/l-intro-1663609851.jpg",
                    Titulo = "Obito Uchiha",
                    AlbumId = 70,
                },
                new AlbumImagenes
                {
                    Id = 134,
                    NumeroImagen = 158,
                    CodigoImagenOriginal = 176,
                    CantidadImpresa = 1000,
                    Imagen = "http://pm1.narvii.com/6807/cc8cd27924f9b644bf1a449ea5094c7869fbf60bv2_00.jpg",
                    Titulo = "Hinata Hyūga",
                    AlbumId = 70,
                },
                new AlbumImagenes
                {
                    Id = 135,
                    NumeroImagen = 159,
                    CodigoImagenOriginal = 177,
                    CantidadImpresa = 1000,
                    Imagen = "https://static1.cbrimages.com/wordpress/wp-content/uploads/2022/07/shikamaru-serious-face.jpg",
                    Titulo = "Shikamaru Nara",
                    AlbumId = 70,
                },
                new AlbumImagenes
                {
                    Id = 136,
                    NumeroImagen = 160,
                    CodigoImagenOriginal = 178,
                    CantidadImpresa = 1000,
                    Imagen = "https://pm1.narvii.com/6292/86499d2e3fd4b37f9c14709d4f899be025072251_hq.jpg",
                    Titulo = "Sasori",
                    AlbumId = 70,
                },
                new AlbumImagenes
                {
                    Id = 137,
                    NumeroImagen = 161,
                    CodigoImagenOriginal = 179,
                    CantidadImpresa = 1000,
                    Imagen = "http://pm1.narvii.com/6903/05259702594930914773e2c9bad84e3897de1d0er1-720-496v2_00.jpg",
                    Titulo = "Boruto Uzumaki",
                    AlbumId = 71,
                },
                new AlbumImagenes
                {
                    Id = 138,
                    NumeroImagen = 162,
                    CodigoImagenOriginal = 180,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.ytimg.com/vi/lCNj1tOMeSg/maxresdefault.jpg",
                    Titulo = "Sarada Uchiha",
                    AlbumId = 71,
                },
                new AlbumImagenes
                {
                    Id = 139,
                    NumeroImagen = 163,
                    CodigoImagenOriginal = 181,
                    CantidadImpresa = 1000,
                    Imagen = "http://pm1.narvii.com/6587/d7cd0f0324e819bcfb72eb49151eb11cc5f774da_00.jpg",
                    Titulo = "Mitsuki",
                    AlbumId = 71,
                },
                new AlbumImagenes
                {
                    Id = 140,
                    NumeroImagen = 164,
                    CodigoImagenOriginal = 182,
                    CantidadImpresa = 1000,
                    Imagen = "https://e7.pngegg.com/pngimages/858/176/png-clipart-inojin-yamanaka-ino-yamanaka-naruto-sarada-uchiha-sai-naruto-fictional-character-cartoon.png",
                    Titulo = "Inojin Yamanaka",
                    AlbumId = 71,
                },
                new AlbumImagenes
                {
                    Id = 141,
                    NumeroImagen = 165,
                    CodigoImagenOriginal = 183,
                    CantidadImpresa = 1000,
                    Imagen = "https://animeargentina.net/wp-content/uploads/2022/09/shikadai-nara-boruto-1024x567.jpg",
                    Titulo = "Shikadai Nara",
                    AlbumId = 71,
                },
                new AlbumImagenes
                {
                    Id = 142,
                    NumeroImagen = 166,
                    CodigoImagenOriginal = 184,
                    CantidadImpresa = 1000,
                    Imagen = "https://w0.peakpx.com/wallpaper/188/670/HD-wallpaper-seiya-pegaso-seiya-thumbnail.jpg",
                    Titulo = "Seiya de Pegaso",
                    AlbumId = 80,
                },
                new AlbumImagenes
                {
                    Id = 143,
                    NumeroImagen = 167,
                    CodigoImagenOriginal = 185,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.ytimg.com/vi/ERU1RT0p4XI/maxresdefault.jpg",
                    Titulo = "Seiya de Geminis",
                    AlbumId = 80,
                },
                new AlbumImagenes
                {
                    Id = 144,
                    NumeroImagen = 168,
                    CodigoImagenOriginal = 186,
                    CantidadImpresa = 1000,
                    Imagen = "https://4.bp.blogspot.com/-Y8dZy1ueVNE/UkH7jm2pQ0I/AAAAAAAAECo/nGb9T-6d39Q/w1200-h630-p-k-no-nu/Athena-Saori+47.JPG",
                    Titulo = "Atenea",
                    AlbumId = 80,
                },
                new AlbumImagenes
                {
                    Id = 145,
                    NumeroImagen = 169,
                    CodigoImagenOriginal = 187,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.pinimg.com/originals/31/e9/9e/31e99e59c05f07d0cd4428c9713f4e26.jpg",
                    Titulo = "Shaka de Virgo",
                    AlbumId = 80,
                },
                new AlbumImagenes
                {
                    Id = 146,
                    NumeroImagen = 170,
                    CodigoImagenOriginal = 188,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.pinimg.com/736x/01/3a/db/013adb562fba898abe5d2ec869e6e31d.jpg",
                    Titulo = "Mu de Aries",
                    AlbumId = 80,
                },
                new AlbumImagenes
                {
                    Id = 147,
                    NumeroImagen = 171,
                    CodigoImagenOriginal = 189,
                    CantidadImpresa = 1000,
                    Imagen = "http://pm1.narvii.com/6293/87a989c9c38a945509db9d65522169977e3e5e30_00.jpg",
                    Titulo = "Shun de Andromeda",
                    AlbumId = 81,
                },
                new AlbumImagenes
                {
                    Id = 148,
                    NumeroImagen = 172,
                    CodigoImagenOriginal = 190,
                    CantidadImpresa = 1000,
                    Imagen = "http://pm1.narvii.com/6712/ec816326096d2fe230f28f0760c5be0802e8399f_00.jpg",
                    Titulo = "Shura de Capricornio",
                    AlbumId = 81,
                },
                new AlbumImagenes
                {
                    Id = 149,
                    NumeroImagen = 173,
                    CodigoImagenOriginal = 191,
                    CantidadImpresa = 1000,
                    Imagen = "https://w0.peakpx.com/wallpaper/553/97/HD-wallpaper-dragon-shiryu-dragon-shiryu.jpg",
                    Titulo = "Shiryū de Dragón",
                    AlbumId = 81,
                },
                new AlbumImagenes
                {
                    Id = 150,
                    NumeroImagen = 174,
                    CodigoImagenOriginal = 192,
                    CantidadImpresa = 1000,
                    Imagen = "http://pm1.narvii.com/6803/9d7b4a867dec204fa73dea3b81b37053230fdb94v2_00.jpg",
                    Titulo = "Camus de Acuario",
                    AlbumId = 81,
                },
                new AlbumImagenes
                {
                    Id = 151,
                    NumeroImagen = 175,
                    CodigoImagenOriginal = 193,
                    CantidadImpresa = 1000,
                    Imagen = "http://pm1.narvii.com/6890/8c48ea5abaaad37c00a1a635b366553d2f33009br1-1280-1335v2_uhq.jpg",
                    Titulo = "Shion de Aries",
                    AlbumId = 81,
                },
                new AlbumImagenes
                {
                    Id = 152,
                    NumeroImagen = 176,
                    CodigoImagenOriginal = 194,
                    CantidadImpresa = 1000,
                    Imagen = "http://2.bp.blogspot.com/-du6bFdb47Xg/U-VQAgM3DVI/AAAAAAAAAs0/MvlEAOV6kHU/s1600/Siegfried+de+Dubhe+Alfa.JPG",
                    Titulo = "Siegfried de Dubhe Alfa",
                    AlbumId = 82,
                },
                new AlbumImagenes
                {
                    Id = 153,
                    NumeroImagen = 177,
                    CodigoImagenOriginal = 194,
                    CantidadImpresa = 1000,
                    Imagen = "http://pm1.narvii.com/6568/493d72b9815f1c67068f0b145128fbd7abc2ef78_00.jpg",
                    Titulo = "Syd de Mizar Zeta",
                    AlbumId = 82,
                },
                new AlbumImagenes
                {
                    Id = 154,
                    NumeroImagen = 178,
                    CodigoImagenOriginal = 194,
                    CantidadImpresa = 1000,
                    Imagen = "https://1.bp.blogspot.com/-EcqwLj7ds_M/TjXC8ySud9I/AAAAAAAAB-Y/7eKlYXKpEuo/s1600/Bud%2Bde%2BAlcor%2B14.JPG",
                    Titulo = "Bud de Alcor Zeta",
                    AlbumId = 82,
                },
                new AlbumImagenes
                {
                    Id = 155,
                    NumeroImagen = 179,
                    CodigoImagenOriginal = 195,
                    CantidadImpresa = 1000,
                    Imagen = "http://pm1.narvii.com/6943/0468c2b73ddcf1e183974f4f7ca9c6e5011fc215r1-500-625v2_00.jpg",
                    Titulo = "Thor de Phecda Gamma",
                    AlbumId = 82,
                },
                new AlbumImagenes
                {
                    Id = 156,
                    NumeroImagen = 180,
                    CodigoImagenOriginal = 196,
                    CantidadImpresa = 1000,
                    Imagen = "http://1.bp.blogspot.com/-LVDyeco5Ob4/T7SlNpDoxFI/AAAAAAAAAqs/34-fPlEuEGM/s1600/1222475717580_f.jpg",
                    Titulo = "Fenrir de Alioth Epsilon",
                    AlbumId = 82,
                },
                new AlbumImagenes
                {
                    Id = 157,
                    NumeroImagen = 181,
                    CodigoImagenOriginal = 197,
                    CantidadImpresa = 1000,
                    Imagen = "http://1.bp.blogspot.com/-bnI3Btv9PZo/T7TI4m7QCDI/AAAAAAAAAro/3ZtVAZG-IoM/s1600/mime0.jpg",
                    Titulo = "Mime de Benetnasch Eta",
                    AlbumId = 82,
                },
                new AlbumImagenes
                {
                    Id = 158,
                    NumeroImagen = 182,
                    CodigoImagenOriginal = 198,
                    CantidadImpresa = 1000,
                    Imagen = "http://pm1.narvii.com/6482/f62e6851ea49e05180b1df59281f1c51a37379ef_00.jpg",
                    Titulo = "Alberich de Megrez Delta",
                    AlbumId = 82,
                },
                new AlbumImagenes
                {
                    Id = 159,
                    NumeroImagen = 183,
                    CodigoImagenOriginal = 199,
                    CantidadImpresa = 1000,
                    Imagen = "https://2.bp.blogspot.com/-wLMXGMh4VaQ/Tgod1AWZBPI/AAAAAAAABw8/9xDpIpNMWIE/s1600/Hagen%2Bde%2BMerak%2B%2528Beta%2529%2B21.JPG",
                    Titulo = "Hagen de Merak Beta",
                    AlbumId = 82,
                },
                new AlbumImagenes
                {
                    Id = 160,
                    NumeroImagen = 184,
                    CodigoImagenOriginal = 200,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.pinimg.com/736x/5b/fa/40/5bfa4054ea0ec72fb6a79486403978cc.jpg",
                    Titulo = "Andromeda",
                    AlbumId = 82,
                },
                new AlbumImagenes
                {
                    Id = 161,
                    NumeroImagen = 185,
                    CodigoImagenOriginal = 1001,
                    CantidadImpresa = 1000,
                    Imagen = "https://i.pinimg.com/736x/8e/13/39/8e1339160a22b5c26a3e42dd859360b0.jpg",
                    Titulo = "Danae",
                    AlbumId = 82,
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
                //    EstaPegada = "si",
                //    AlbumUsuarioId = 1,
                   AlbumImagenesId = 1,
                   UsuarioId = 1
                   //AlbumImagenImpresaId = 1,

              },
               new AlbumUsuarioImagenes
               {
                   Id = 2,
                //    EstaPegada = "si",
                //    AlbumUsuarioId = 2,
                   AlbumImagenesId= 2,
                   UsuarioId = 2
                   //AlbumImagenImpresaId = 2,

              },
               new AlbumUsuarioImagenes
               {
                   Id = 3,
                //    EstaPegada = "si",
                //    AlbumUsuarioId = 3,
                   AlbumImagenesId = 3,
                   UsuarioId = 3
                   //AlbumImagenImpresaId = 3,

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
        public DbSet<Roles> TablaRoles { get; set;} 
    }
}
