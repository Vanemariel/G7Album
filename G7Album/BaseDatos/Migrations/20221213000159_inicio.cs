using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G7Album.BaseDatos.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TablaColeccionAlbumes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TituloColeccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaColeccionAlbumes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TablaUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(100)", maxLength: 100, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    NombreCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TablaAlbumes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoAlbum = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CantidadImagen = table.Column<int>(type: "int", nullable: false),
                    CantidadImpreso = table.Column<int>(type: "int", nullable: false),
                    Desde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hasta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ColeccionAlbumId = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaAlbumes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TablaAlbumes_TablaColeccionAlbumes_ColeccionAlbumId",
                        column: x => x.ColeccionAlbumId,
                        principalTable: "TablaColeccionAlbumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TablaRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TablaRoles_TablaUsuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TablaUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TablaAlbumesUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaAlbumesUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TablaAlbumesUsuarios_TablaAlbumes_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "TablaAlbumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TablaAlbumesUsuarios_TablaUsuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TablaUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TablaImagenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroImagen = table.Column<int>(type: "int", nullable: false),
                    CodigoImagenOriginal = table.Column<int>(type: "int", nullable: false),
                    CantidadImpresa = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaImagenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TablaImagenes_TablaAlbumes_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "TablaAlbumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TablaImagenesImpresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoImagenImpresa = table.Column<int>(type: "int", nullable: false),
                    PathImagenImpreso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumImagenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaImagenesImpresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TablaImagenesImpresas_TablaImagenes_AlbumImagenId",
                        column: x => x.AlbumImagenId,
                        principalTable: "TablaImagenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TablaUsuarioImagenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumImagenesId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaUsuarioImagenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TablaUsuarioImagenes_TablaImagenes_AlbumImagenesId",
                        column: x => x.AlbumImagenesId,
                        principalTable: "TablaImagenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TablaUsuarioImagenes_TablaUsuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TablaUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TablaColeccionAlbumes",
                columns: new[] { "Id", "TituloColeccion" },
                values: new object[,]
                {
                    { 1, "Futbol" },
                    { 2, "Tenis" },
                    { 3, "Basket" },
                    { 4, "Rugby" },
                    { 5, "Disney" },
                    { 6, "Anime" }
                });

            migrationBuilder.InsertData(
                table: "TablaUsuarios",
                columns: new[] { "Id", "Email", "NombreCompleto", "Password", "PasswordSalt" },
                values: new object[,]
                {
                    { 1, "vanesa@gmail.com", "Vanesa Herrera", new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, null },
                    { 2, "juanledesma@gmail.com", "juan ledesma", new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, null },
                    { 3, "aili@gmail.com", "oriana LALALA", new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, null }
                });

            migrationBuilder.InsertData(
                table: "TablaAlbumes",
                columns: new[] { "Id", "CantidadImagen", "CantidadImpreso", "CodigoAlbum", "ColeccionAlbumId", "Descripcion", "Desde", "Hasta", "Imagen", "Titulo" },
                values: new object[,]
                {
                    { 1, 12, 1000, 1, 1, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9638), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9687), "https://www.elcomercio.com/wp-content/uploads/2022/10/Liber-COnme-700x391.jpg", "Copa Libertadores" },
                    { 2, 12, 1000, 2, 1, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9693), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9696), "https://a.espncdn.com/photo/2021/0913/r908628_1296x729_16-9.jpg", "Champions League" },
                    { 3, 12, 1000, 3, 1, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9700), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9703), "https://auf.org.uy/imagenes/img_contenido/contenido/c/copa-america_5.jpg", "Copa America" },
                    { 4, 9, 1000, 4, 2, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9707), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9709), "https://image.shutterstock.com/image-photo/london-uk-april-2022-close-260nw-2165550065.jpg", "Wimbledon" },
                    { 5, 9, 1000, 5, 2, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9713), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9716), "https://espnpressroom.com/mexico/files/2018/05/Roland-Garros.png", "Rollan Garros" },
                    { 6, 9, 1000, 6, 2, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9719), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9722), "https://brandemia.org/sites/default/files/inline/images/us_open_logo.jpg", "Us Open" },
                    { 7, 8, 1000, 7, 3, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9726), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9729), "https://www.unocontraunoweb.com/wp-content/uploads/2021/01/acb-logo-2019.jpg", "Liga Endesa" },
                    { 8, 8, 1000, 8, 3, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9732), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9735), "https://a4.espncdn.com/combiner/i?img=%2Fi%2Fespn%2Fmisc_logos%2F500%2Fnba.png", "NBA" },
                    { 9, 8, 1000, 9, 3, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9739), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9741), "https://pbs.twimg.com/profile_images/1537068349385068544/OSkcZWlP_400x400.jpg", "La Liga Argentina" },
                    { 10, 7, 1000, 10, 4, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9745), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9748), "https://searchvectorlogo.com/wp-content/uploads/2020/09/national-rugby-league-nrl-vector-logo.png", "National Rugby League" },
                    { 11, 7, 1000, 11, 4, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9752), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9754), "https://upload.wikimedia.org/wikipedia/en/a/a5/Super_League_logo_2017.jpg", "Super League" },
                    { 12, 7, 1000, 12, 4, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9759), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9762), "https://www.prensa-latina.cu/wp-content/uploads/2022/08/Rugby-Championship-2022.jpg", "The Rugby Championship" },
                    { 13, 17, 1000, 100, 5, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9767), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9769), "https://cdn1.eldia.com/112021/1635837451953.jpg", "Monster Inc" },
                    { 14, 17, 1000, 101, 5, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9776), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9779), "https://ichef.bbci.co.uk/images/ic/1200x675/p0915n36.jpg", "Monster University" },
                    { 15, 17, 1000, 102, 5, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9782), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9785), "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/16E670238DC278CF1FC15F794914B0371708F078C210E01443353314452473E9/scale?width=1200&aspectRatio=1.78&format=jpeg", "High school Musical" },
                    { 16, 17, 1000, 104, 5, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9789), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9791), "https://pics.filmaffinity.com/High_School_Musical_2_TV-318249736-mmed.jpg", "High school Musical 2" },
                    { 26, 17, 1000, 105, 5, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9795), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9797), "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/050E5D6C2B62066D3397CD0855B4274A9728186CEE39451C68FAA17A1D8EBB98/scale?width=1200&aspectRatio=1.78&format=jpeg", "La era del hielo 1" },
                    { 27, 17, 1000, 106, 5, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9801), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9804), "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/2BDBC39CA1B941A0C4360565C67E8EDB97E2D0904DF11737583ED61E80C7CC07/scale?width=1200&aspectRatio=1.78&format=jpeg", "La era del hielo 2" },
                    { 28, 17, 1000, 107, 5, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9807), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9810), "https://mx.web.img3.acsta.net/c_310_420/pictures/20/10/21/20/18/4455162.jpg", "La era del hielo 3" },
                    { 63, 15, 1000, 1, 6, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9826), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9829), "https://img2.rtve.es/i/?w=1600&i=1657019155649.jpg", "Dragonball" },
                    { 64, 15, 1000, 2, 6, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9832), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9837), "https://www.crunchyroll.com/imgsrv/display/thumbnail/1200x675/catalog/crunchyroll/36bdc5ea4443cd8e42f22ec7d3884cbb.jpeg", "Dragonball Z" },
                    { 65, 15, 1000, 3, 6, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9841), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9844), "https://depor.com/resizer/6Gmj2BD2B09Yug9skT5G_37oBgg=/580x330/smart/filters:format(jpeg):quality(75)/cloudfront-us-east-1.images.arcpublishing.com/elcomercio/B35WNLM7UJGIJNOWQFDO3UPY34.jpg", "Dragonball Super" },
                    { 70, 15, 1000, 5, 6, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9855), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9857), "https://es.web.img3.acsta.net/pictures/13/12/13/09/11/515425.jpg", "Naruto Shippuden" },
                    { 71, 15, 1000, 6, 6, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9861), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9863), "https://img1.ak.crunchyroll.com/i/spire4/7dde3a40ce5d5615813a5ac12683631a1616450115_full.jpg", "Naruto Next Generation" },
                    { 80, 15, 1000, 7, 6, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9867), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9870), "https://larepublica.pe/resizer/e0pacYSNg1Mt_pZBIbVHe65wXHw=/1200x660/top/arc-anglerfish-arc2-prod-gruporepublica.s3.amazonaws.com/public/ATQBEGGFCRDSHAONTOR7O2VCNM.jpg", "Saint Seiya the Lost Canvas" },
                    { 81, 15, 1000, 8, 6, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9873), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9876), "https://i.ytimg.com/vi/p2POuLSrWms/maxresdefault.jpg", "Batalla de Poseidon" },
                    { 82, 15, 1000, 9, 6, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9880), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9883), "https://i.ytimg.com/vi/vsGd6A-CrbY/maxresdefault.jpg", "Batalla de Asgard" },
                    { 96, 15, 1000, 4, 6, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9848), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9851), "https://i.pinimg.com/originals/3f/0d/1a/3f0d1afe64a74343c0f173faec9df8e0.jpg", "Naruto" },
                    { 100, 17, 1000, 107, 5, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9814), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9816), "https://as01.epimg.net/meristation/imagenes/2022/09/30/reportajes/1664534991_626157_1664615989_noticia_normal.jpg", "Avatar" },
                    { 101, 17, 1000, 107, 5, "figus", new DateTime(2022, 12, 12, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9820), new DateTime(2022, 12, 22, 18, 1, 59, 334, DateTimeKind.Local).AddTicks(9822), "https://i.blogs.es/884d13/avatar-2/840_560.jpeg", "Avatar 2" }
                });

            migrationBuilder.InsertData(
                table: "TablaAlbumesUsuarios",
                columns: new[] { "Id", "AlbumId", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "TablaImagenes",
                columns: new[] { "Id", "AlbumId", "CantidadImpresa", "CodigoImagenOriginal", "Imagen", "NumeroImagen", "Titulo" },
                values: new object[,]
                {
                    { 1, 1, 1000, 31, "https://www.cariverplate.com.ar/imagenes/jugadores/2022-08/1638-01-armani-imagenprincipal.png", 200, "Armani Franco" },
                    { 2, 1, 1000, 32, "https://upload.wikimedia.org/wikipedia/commons/4/4e/Uni%C3%B3n_Espa%C3%B1ola_-_Curic%C3%B3_Unido%2C_2018-09-30_-_Daniel_Franco_-_02.jpg", 201, "Franco Daniel" },
                    { 3, 1, 1000, 33, "https://resizer.glanacion.com/resizer/dRtGyNR9KJ5Zr0BtIjvpdV8J5uU=/1200x800/smart/filters:format(webp):quality(80)/cloudfront-us-east-1.images.arcpublishing.com/lanacionar/CCXOIDZHQRG6PP2JQ2LVCQHOFU.jpg", 202, "Guido Herrera" },
                    { 4, 1, 1000, 34, "https://toppng.com/uploads/preview/lucas-pratto-png-river-plate-plantel-2018-11563129429edz4folhq2.png", 2023, "Pratto Lucas" },
                    { 5, 1, 1000, 35, "https://futhead.cursecdn.com/static/img/21/players_alt/p67333374.png", 204, "Bou Walter" },
                    { 6, 1, 1000, 36, "https://www.clubtalleres.com.ar/wp-content/uploads/2021/01/VALOYES-4.png", 205, "Valoyes Diego" },
                    { 7, 2, 1000, 37, "https://futhead.cursecdn.com/static/img/21/players_alt/p67333374.png", 20, "Bou Walter" },
                    { 8, 2, 1000, 38, "https://toppng.com/uploads/preview/lucas-pratto-png-river-plate-plantel-2018-11563129429edz4folhq2.png", 21, "Pratto Lucas" },
                    { 9, 2, 1000, 39, "https://upload.wikimedia.org/wikipedia/commons/4/4e/Uni%C3%B3n_Espa%C3%B1ola_-_Curic%C3%B3_Unido%2C_2018-09-30_-_Daniel_Franco_-_02.jpg", 22, "Franco Daniel" },
                    { 10, 2, 1000, 40, "https://www.cariverplate.com.ar/imagenes/jugadores/2022-08/1638-01-armani-imagenprincipal.png", 23, "ArmanI Franco" },
                    { 11, 2, 1000, 41, "https://resizer.glanacion.com/resizer/dRtGyNR9KJ5Zr0BtIjvpdV8J5uU=/1200x800/smart/filters:format(webp):quality(80)/cloudfront-us-east-1.images.arcpublishing.com/lanacionar/CCXOIDZHQRG6PP2JQ2LVCQHOFU.jpg", 24, "Guido Herrera" },
                    { 12, 2, 1000, 42, "https://media.tycsports.com/files/2020/11/19/154997/pulga-rodriguez.jpg", 25, "Luis Miguel Rodríguez" },
                    { 13, 3, 1000, 43, "https://img2.freepng.es/20180526/vrr/kisspng-roberto-firmino-liverpool-f-c-football-player-ren-roberto-firmino-5b097993b70f13.2394382015273476037498.jpg", 26, "Firmiño" },
                    { 14, 3, 1000, 44, "https://s.hs-data.com/bilder/spieler/gross/445514.jpg?fallback=png", 27, "Alvarez Julian" },
                    { 15, 3, 1000, 45, "https://i.bundesliga.com/player/dfl-obj-002g8i-dfl-clu-000007-dfl-sea-0001k6.png", 28, "Erling Haaland" },
                    { 16, 3, 1000, 46, "https://i.pinimg.com/736x/0c/f6/9d/0cf69df73b50d137e2815387e9513aee.jpg", 29, "Cuti Romero" },
                    { 17, 3, 1000, 47, "https://1vs1-7f65.kxcdn.com/img/players/original/big/png/damian-emiliano-martinez-romero_16482_71-ub-800.png", 30, "Dibu Martinez" },
                    { 18, 4, 1000, 48, "https://www.atptour.com/-/media/tennis/players/head-shot/2022/05/25/15/47/nadal-head-2022-may.png", 31, "Nadal Rafael" },
                    { 19, 4, 1000, 49, "https://www.mdzol.com/u/fotografias/m/2022/9/15/f608x342-1282478_1312201_10.jpg", 32, "Federer Roger" },
                    { 20, 4, 1000, 50, "https://imgresizer.eurosport.com/unsafe/1200x0/filters:format(jpeg):focal(1313x574:1315x572)/origin-imgresizer.eurosport.com/2021/06/28/3163279-64821308-2560-1440.jpg", 33, "Andy Murray" },
                    { 21, 4, 1000, 51, "https://www.atptour.com/-/media/tennis/players/head-shot/2019/05/13/18/27/delpotro_head_rome19.png", 34, "Juan Martin Del Potro" },
                    { 22, 5, 1000, 52, "https://resizer.iproimg.com/unsafe/880x/filters:format(webp)/https://assets.iproup.com/assets/jpg/2021/11/23871.jpg", 35, "David Nalbandian" },
                    { 23, 5, 1000, 53, "https://www.atptour.com/-/media/tennis/players/head-shot/2019/02/25/18/18/djokovic_head_ao19.png", 36, "Novak Djovich" },
                    { 24, 5, 1000, 54, "https://www.atptour.com/-/media/tennis/players/gladiator/2022/05/18/21/10/tsitsipas-full-2022-may.png", 37, "Stefanos Tsitsipas" },
                    { 25, 5, 1000, 55, "https://www.atptour.com/-/media/alias/player-headshot/MM58", 37, "Danil Medvedev" },
                    { 26, 5, 1000, 56, "https://www.atptour.com/-/media/alias/player-headshot/Z355", 38, "Alexander Zverev" },
                    { 27, 5, 1000, 57, "https://www.atptour.com/-/media/tennis/players/gladiator/2022/06/18/22/21/fognini-full-2022-june-1.png", 39, "Fabio Fognini" },
                    { 28, 5, 1000, 58, "https://www.atptour.com/-/media/images/news/2022/10/01/11/07/ruud-tokyo-2022-draw.jpg", 40, "Casper Ruud" },
                    { 29, 6, 1000, 60, "https://www.atptour.com/-/media/tennis/players/gladiator/2022/06/16/03/16/tiafoe-full-2022-june.png", 42, "Frances Tiafoe" },
                    { 30, 6, 1000, 61, "https://fotos.perfil.com/2022/01/31/trim/720/410/schwartzman-1306189.jpg", 43, "Diego Schwartzman" },
                    { 31, 6, 1000, 62, "https://www.atptour.com/-/media/alias/player-headshot/BK40", 44, "Matteo Berretini" },
                    { 32, 6, 1000, 63, "https://www.atptour.com/-/media/tennis/players/gladiator/2022/05/25/15/17/baez-full-2022-may.png", 45, "Sebastian Baez" },
                    { 33, 6, 1000, 64, "https://www.atptour.com/-/media/tennis/players/head-shot/2022/05/25/15/45/auger-aliassime-head-2022-may.png", 46, "Felix Auger-Aliassime" },
                    { 34, 6, 1000, 65, "https://www.atptour.com/es/players/john-isner/i186/www.atptour.com/-/media/tennis/players/head-shot/2022/05/25/15/38/isner-head-2022-may.png", 47, "John Isner" },
                    { 41, 7, 1000, 72, "https://a.espncdn.com/combiner/i?img=/i/headshots/nba/players/full/272.png", 54, "Manuel Ginobilli" },
                    { 42, 7, 1000, 73, "https://www.pngmart.com/files/16/Kevin-Durant-PNG-Clipart.png", 55, "Kevin Durant" },
                    { 43, 7, 1000, 74, "https://cdn.nba.com/headshots/nba/latest/1040x760/76979.png", 56, "Elvin Hayes" },
                    { 44, 7, 1000, 75, "https://i.pinimg.com/originals/6a/78/91/6a789135b8ed3755d3258a88d85851a6.png", 57, "Bob Pettit" },
                    { 45, 8, 1000, 76, "https://www.pngplay.com/wp-content/uploads/13/Giannis-Antetokounmpo-Transparent-PNG.png", 58, "Giannis Antokoumpo" }
                });

            migrationBuilder.InsertData(
                table: "TablaImagenes",
                columns: new[] { "Id", "AlbumId", "CantidadImpresa", "CodigoImagenOriginal", "Imagen", "NumeroImagen", "Titulo" },
                values: new object[,]
                {
                    { 46, 8, 1000, 77, "https://e7.pngegg.com/pngimages/95/141/png-clipart-russell-westbrook-oklahoma-city-thunder-nba-houston-rockets-kolmikduubel-nba-tshirt-jersey-thumbnail.png", 59, "Oscar Robertson" },
                    { 47, 8, 1000, 79, "https://www.laliganacional.com.ar/fotosjugadores/143078.png", 61, "Martin Cabrera" },
                    { 48, 8, 1000, 80, "https://i.pinimg.com/originals/6a/78/91/6a789135b8ed3755d3258a88d85851a6.png", 62, "Bob Pettit" },
                    { 49, 9, 1000, 81, "https://i0.wp.com/pbs.twimg.com/media/Ee47M9zWoAETxa9.png?resize=450%2C450&ssl=1&crop=1", 63, "Juan Cruz Oberto" },
                    { 50, 9, 1000, 82, "https://upload.wikimedia.org/wikipedia/commons/thumb/5/58/Milanesio_argentina_1992.jpg/200px-Milanesio_argentina_1992.jpg", 64, "Marcelo Milanesio" },
                    { 51, 10, 1000, 83, "https://i0.wp.com/pbs.twimg.com/media/Ee47M9zWoAETxa9.png?resize=450%2C450&ssl=1&crop=1", 65, "Julian Montoya" },
                    { 52, 10, 1000, 84, "https://www.lavoz.com.ar/resizer/9fLRQKRS9-FVN2RZHhyjb4l_thI=/1024x683/smart/cloudfront-us-east-1.images.arcpublishing.com/grupoclarin/RL7CQYI2W5CPNNXEXDSOIRPCII.jpg", 66, "Matias Alemano" },
                    { 53, 10, 1000, 85, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTVBi6OujLCFBCmpgMvMZQE6f9zLelwg1mEYPZs_Rt2tl0xszSijQdHiwhK4YtvWWlv08Q&usqp=CAU", 67, "Julian Cruz Mallia" },
                    { 54, 10, 1000, 86, "https://deporfe.com/wp-content/uploads/2022/05/cubelli.jpg", 68, "Tomas Cubeli" },
                    { 55, 10, 1000, 87, "https://sites.google.com/site/vidapuma/_/rsrc/1318771820838/jugadores/felipe-contepomi/J-12-Contepomi_%20Felipe.jpg", 69, "Felipe Contemponi" },
                    { 56, 10, 1000, 88, "https://a.espncdn.com/photo/2021/0528/r860181_2_1024x576_16-9.jpg", 70, "Julian Montoya" },
                    { 57, 10, 1000, 89, "https://cordobaxv.com.ar/wp-content/uploads/2020/07/2BZUZGQLGBHSPCRYIDF7POGUWY.jpg", 71, "Beauden Barrett" },
                    { 58, 10, 1000, 90, "https://www.allblacks.com/assets/Uploads/SW-copy__FocusFillWyIwLjAwIiwiMC4wMCIsMzUwLDQ2MF0.png", 72, "Sam Whitelock" },
                    { 59, 10, 1000, 91, "https://cordobaxv.com.ar/wp-content/uploads/2021/12/Sam-Cane-contratro-allblacks-2025.jpg", 73, "San Cane" },
                    { 60, 11, 1000, 92, "https://e00-elmundo.uecdn.es/assets/multimedia/imagenes/2015/10/30/14462260859727.jpg", 74, "David Pocock" },
                    { 61, 11, 1000, 93, "https://a.espncdn.com/photo/2022/0805/r1044928_1296x729_16-9.jpg", 75, "Michael Hooper" },
                    { 62, 11, 1000, 94, "https://d3gbf3ykm8gp5c.cloudfront.net/content/uploads/2022/02/18081522/Jake-Gordon-Waratahs-Super-Rugby-TT-2021-PA.jpg", 76, "Jake Gordon" },
                    { 63, 11, 1000, 95, "https://s.libertaddigital.com/fotos/noticias/sebastien-chabal-050514.jpg", 77, "Sebastian Chabal" },
                    { 64, 11, 1000, 96, "https://www.lequipe.fr/_medias/img-photo-jpg/atonio-a-ete-condamne-a-six-mois-de-prison-avec-sursis-r-perrocheau-l-equipe/1500000001048599/168:174,1656:1166-828-552-75/c1350.jpg", 78, "Uini Atonio" },
                    { 65, 12, 1000, 97, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQiFcdujAoFWYVHreXcZehSiNpkZ8qyDb9BSg&usqp=CAU", 79, "Atsushi Sakate" },
                    { 66, 12, 1000, 98, "https://www.ultimaterugby.com/images/entities/231381-a666c147e2-11/KenkiFukuokarugbyplayer.jpg", 80, "Kenki Fukuoka" },
                    { 67, 12, 1000, 99, "https://d3gbf3ykm8gp5c.cloudfront.net/content/uploads/2019/10/05130704/Yu-Tamura-Japan-RWC-2019-PA.jpg", 81, "Yu Tamura" },
                    { 68, 12, 1000, 100, "https://d3gbf3ykm8gp5c.cloudfront.net/content/uploads/2020/07/15094835/Johnny-Williams-Newcastle-Falcons-training-2020-PA.jpg", 82, "Johnny Williams" },
                    { 69, 12, 1000, 101, "https://d3gbf3ykm8gp5c.cloudfront.net/content/uploads/2021/10/26123449/Wales-centre-Jonathan-Davies-looking-back-PA-1024x630.jpg", 83, "Jonathan Davies" },
                    { 70, 12, 1000, 102, "https://d3gbf3ykm8gp5c.cloudfront.net/content/uploads/2020/09/17162439/Dan-Biggar-for-Wales-v-England-PA.jpg", 84, "Dan Biggar" },
                    { 71, 14, 1000, 112, "https://static.wikia.nocookie.net/heroes-of-the-characters/images/e/e5/Roz_%28Monsters_Inc._-_Render%29.png/revision/latest?cb=20210825084538", 94, "Roz" },
                    { 72, 14, 1000, 113, "https://static.wikia.nocookie.net/monstersincmovies/images/6/67/Bile-white.jpg/revision/latest?cb=20130515201629", 95, "Bile" },
                    { 73, 14, 1000, 114, "https://fotografias.antena3.com/clipping/cmsimages01/2018/10/18/226A74E0-C67D-40BA-BD22-9EE8E9909F51/69.jpg?crop=1:1,smart&width=1200&height=1200&optimize=low&format=webply", 96, "Troy Bolton" },
                    { 74, 15, 1000, 115, "https://i.pinimg.com/originals/df/62/35/df623531f1ee71776396f506916d4095.png", 97, "Gabriela Montes" },
                    { 75, 15, 1000, 116, "https://i.pinimg.com/474x/77/05/bf/7705bf1970756bac22a304cf33abca34--ashley-tisdale-drama-queens.jpg", 98, "Sharpay Evans" },
                    { 76, 15, 1000, 117, "http://images.girlslife.com/posts/004/4184/prettyleadphoto.jpg", 99, "Martha Cox" },
                    { 77, 15, 1000, 118, "https://static.wikia.nocookie.net/my-high-school-musical/images/2/21/406630.jpg/revision/latest?cb=20180729024606", 100, "Lucille Bolton" },
                    { 78, 15, 1000, 119, "https://fotografias.antena3.com/clipping/cmsimages01/2018/10/18/226A74E0-C67D-40BA-BD22-9EE8E9909F51/69.jpg?crop=1:1,smart&width=1200&height=1200&optimize=low&format=webply", 101, "Troy Bolton" },
                    { 79, 15, 1000, 120, "https://i.pinimg.com/originals/df/62/35/df623531f1ee71776396f506916d4095.png", 102, "Gabriela Montes" },
                    { 80, 16, 1000, 121, "https://i.pinimg.com/474x/77/05/bf/7705bf1970756bac22a304cf33abca34--ashley-tisdale-drama-queens.jpg", 103, "Sharpay Evans" },
                    { 81, 15, 1000, 122, "http://images.girlslife.com/posts/004/4184/prettyleadphoto.jpg", 104, "Martha Cox" },
                    { 82, 16, 1000, 123, "https://static.wikia.nocookie.net/my-high-school-musical/images/2/21/406630.jpg/revision/latest?cb=20180729024606", 105, "Lucile Bolton" },
                    { 83, 16, 1000, 124, "https://fotografias.antena3.com/clipping/cmsimages01/2018/10/18/226A74E0-C67D-40BA-BD22-9EE8E9909F51/69.jpg?crop=1:1,smart&width=1200&height=1200&optimize=low&format=webply", 106, "Troy Bolton" },
                    { 84, 16, 1000, 125, "https://i.pinimg.com/originals/df/62/35/df623531f1ee71776396f506916d4095.png", 107, "Gabriela Montes" },
                    { 85, 16, 1000, 126, "https://i.pinimg.com/474x/77/05/bf/7705bf1970756bac22a304cf33abca34--ashley-tisdale-drama-queens.jpg", 108, "Sharpay Evans" },
                    { 86, 16, 1000, 127, "http://images.girlslife.com/posts/004/4184/prettyleadphoto.jpg", 109, "Martha Cox" },
                    { 87, 16, 1000, 128, "https://static.wikia.nocookie.net/my-high-school-musical/images/2/21/406630.jpg/revision/latest?cb=20180729024606", 110, "Lucile Bolton" }
                });

            migrationBuilder.InsertData(
                table: "TablaImagenes",
                columns: new[] { "Id", "AlbumId", "CantidadImpresa", "CodigoImagenOriginal", "Imagen", "NumeroImagen", "Titulo" },
                values: new object[,]
                {
                    { 88, 26, 1000, 129, "https://w7.pngwing.com/pngs/276/1019/png-transparent-sid-sloth-scrat-ice-age-the-sloth-buckle-free.png", 111, "Sid" },
                    { 89, 26, 1000, 130, "https://www.kindpng.com/picc/m/236-2361642_mammoth-manny-la-era-de-hielo-hd-png.png", 112, "Many" },
                    { 90, 26, 1000, 131, "https://static.wikia.nocookie.net/iceage/images/a/a7/Bodoque.jpg/revision/latest?cb=20120607153944&path-prefix=es", 113, "Roshan" },
                    { 91, 26, 1000, 132, "https://www.pngkey.com/png/detail/318-3182891_download-diego-la-era-de-hielo.png", 114, "Diego" },
                    { 92, 26, 1000, 133, "https://w7.pngwing.com/pngs/84/894/png-transparent-ice-age-scrat-scrat-sid-manfred-ellie-ice-age-ice-age-mammal-heroes-fauna-thumbnail.png", 115, "Scrat" },
                    { 93, 27, 1000, 134, "https://w7.pngwing.com/pngs/276/1019/png-transparent-sid-sloth-scrat-ice-age-the-sloth-buckle-free.png", 116, "Sid" },
                    { 94, 27, 1000, 135, "https://www.kindpng.com/picc/m/236-2361642_mammoth-manny-la-era-de-hielo-hd-png.png", 117, "Many" },
                    { 95, 27, 1000, 136, "https://static.wikia.nocookie.net/iceage/images/a/a7/Bodoque.jpg/revision/latest?cb=20120607153944&path-prefix=es", 118, "Roshan" },
                    { 96, 27, 1000, 137, "https://www.pngkey.com/png/detail/318-3182891_download-diego-la-era-de-hielo.png", 119, "Diego" },
                    { 97, 27, 1000, 138, "https://w7.pngwing.com/pngs/84/894/png-transparent-ice-age-scrat-scrat-sid-manfred-ellie-ice-age-ice-age-mammal-heroes-fauna-thumbnail.png", 120, "Scrat" },
                    { 98, 28, 1000, 139, "https://w7.pngwing.com/pngs/276/1019/png-transparent-sid-sloth-scrat-ice-age-the-sloth-buckle-free.png", 121, "Sid" },
                    { 99, 28, 1000, 140, "https://www.kindpng.com/picc/m/236-2361642_mammoth-manny-la-era-de-hielo-hd-png.png", 122, "Many" },
                    { 100, 28, 1000, 141, "https://static.wikia.nocookie.net/iceage/images/a/a7/Bodoque.jpg/revision/latest?cb=20120607153944&path-prefix=es", 123, "Roshan" },
                    { 101, 28, 1000, 142, "https://www.pngkey.com/png/detail/318-3182891_download-diego-la-era-de-hielo.png", 124, "Diego" },
                    { 102, 28, 1000, 143, "https://w7.pngwing.com/pngs/84/894/png-transparent-ice-age-scrat-scrat-sid-manfred-ellie-ice-age-ice-age-mammal-heroes-fauna-thumbnail.png", 125, "Scrat" },
                    { 103, 100, 1000, 144, "https://static.wikia.nocookie.net/james-camerons-avatar/images/1/17/Grace.png/revision/latest?cb=20210408152516&path-prefix=es", 126, "Dra Grace" },
                    { 104, 100, 1000, 145, "https://i.pinimg.com/736x/b2/fd/5a/b2fd5a5b1aa105021bba52b2b4ee2394.jpg", 127, "Neyriti" },
                    { 105, 100, 1000, 146, "https://www.writeups.org/wp-content/uploads/Jake-Sully-Avatar-movie-Sam-Worthington.jpg", 128, "Jake Sully" },
                    { 106, 100, 1000, 147, "https://static.wikia.nocookie.net/james-camerons-avatar/images/8/82/Tsu%27tey_te_Rongloa_Ateyo%27itan.png/revision/latest?cb=20210122023316&path-prefix=es", 129, "Tsutey" },
                    { 107, 100, 1000, 148, "https://static.wikia.nocookie.net/james-camerons-avatar/images/2/21/Quaritch.png/revision/latest?cb=20210527234304&path-prefix=es", 130, "Coronel Milles" },
                    { 108, 101, 1000, 149, "https://static.wikia.nocookie.net/james-camerons-avatar/images/1/17/Grace.png/revision/latest?cb=20210408152516&path-prefix=es", 131, "Dra Grace" },
                    { 109, 101, 1000, 150, "https://i.pinimg.com/736x/b2/fd/5a/b2fd5a5b1aa105021bba52b2b4ee2394.jpg", 132, "Neyriti" },
                    { 110, 101, 1000, 151, "https://www.writeups.org/wp-content/uploads/Jake-Sully-Avatar-movie-Sam-Worthington.jpg", 133, "Jake Sully" },
                    { 111, 101, 1000, 152, "https://static.wikia.nocookie.net/james-camerons-avatar/images/8/82/Tsu%27tey_te_Rongloa_Ateyo%27itan.png/revision/latest?cb=20210122023316&path-prefix=es", 134, "Tsutey" },
                    { 112, 101, 1000, 153, "https://static.wikia.nocookie.net/james-camerons-avatar/images/2/21/Quaritch.png/revision/latest?cb=20210527234304&path-prefix=es", 135, "Coronel Milles" },
                    { 113, 63, 1000, 154, "https://tierragamer.com/wp-content/uploads/2019/06/Dragon-Ball-Pequeno-Goku.jpg", 136, "Goku" },
                    { 114, 63, 1000, 155, "https://i.pinimg.com/originals/01/1f/32/011f32363d97557ee7eaa383a07c2f5a.jpg", 137, "Krilin" },
                    { 115, 63, 1000, 156, "https://www.geekmi.news/__export/1654699584752/sites/debate/img/2022/06/08/taopaipai.jpg_1339198940.jpg", 138, "Tao Pai Pai" },
                    { 116, 63, 1000, 157, "https://mir-s3-cdn-cf.behance.net/projects/404/11c0cc103711653.5f52b4b6a6dbd.png", 139, "Picolo" },
                    { 117, 63, 1000, 158, "https://pm1.narvii.com/6988/9052161534eeeec16bb57b2c7ab7441e25ce4dc5r1-720-404v2_hq.jpg", 140, "General Blue" },
                    { 118, 64, 1000, 159, "https://www.fayerwayer.com/resizer/UAeNc2JHJP1xypVHNAVrMPqxEz4=/800x0/filters:format(jpg):quality(70)/cloudfront-us-east-1.images.arcpublishing.com/metroworldnews/VBRF4I3YM5G63AU637TTONVARE.jpg", 141, "Vegeta" },
                    { 119, 64, 1000, 161, "https://www.latercera.com/resizer/dFjofjUYrC3BacG8B3PGUYcgRnc=/900x600/smart/arc-anglerfish-arc2-prod-copesa.s3.amazonaws.com/public/WVF74GVKZZAI5KZQQRW6OZ6QGI.jpg", 143, "Cell" },
                    { 120, 64, 1000, 162, "https://i.pinimg.com/originals/26/d0/8b/26d08be0ab87326fc6ad26cc9bdb2ddf.png", 144, "Majin Boo" },
                    { 121, 64, 1000, 163, "https://i.pinimg.com/originals/4e/3e/b5/4e3eb5933953657a4d1ea95cee39f366.png", 145, "Darbura" },
                    { 122, 65, 1000, 164, "http://pm1.narvii.com/6542/f434e2fb6efb78b182057696bbfef9760016dc5a_00.jpg", 146, "Bills" },
                    { 123, 65, 1000, 165, "https://depor.com/resizer/0FTdOejzzLcQZgm2s-GDC87wDU8=/1200x1200/smart/filters:format(jpeg):quality(75)/cloudfront-us-east-1.images.arcpublishing.com/elcomercio/WDXFCIRCYNCHDCZ7F3FPT7K5V4.jpg", 147, "Wiss" },
                    { 124, 65, 1000, 166, "https://gcdn.lanetaneta.com/wp-content/uploads/2022/03/La-historia-de-fondo-de-Dragon-Ball-Super-de-Jiren-780x470.jpg", 148, "Jiren" },
                    { 125, 65, 1000, 167, "https://depor.com/resizer/hY70NAtbG9xSjZW65ZDRrs7X_tU=/580x330/smart/filters:format(jpeg):quality(75)/cloudfront-us-east-1.images.arcpublishing.com/elcomercio/XYRVWY753VGBZJA6FFXIAJBHF4.jpg", 149, "Topo" },
                    { 126, 65, 1000, 168, "https://media.vandal.net/i/1440x1080/49072/dragon-ball-fighterz-2018927193257_3.jpg", 150, "Androide 17" },
                    { 127, 96, 1000, 169, "https://i.blogs.es/bc1dd2/naruto/450_1000.png", 151, "Naruto" },
                    { 128, 96, 1000, 170, "https://i.pinimg.com/600x315/a6/1f/be/a61fbe0e9d11632d65dd09fa0bead32d.jpg", 152, "Sasuke" },
                    { 129, 96, 1000, 171, "https://www.egames.news/__export/1637434465357/sites/debate/img/2021/11/20/itachi-uchiha.jpg_423682103.jpg", 153, "Itachi" }
                });

            migrationBuilder.InsertData(
                table: "TablaImagenes",
                columns: new[] { "Id", "AlbumId", "CantidadImpresa", "CodigoImagenOriginal", "Imagen", "NumeroImagen", "Titulo" },
                values: new object[,]
                {
                    { 130, 96, 1000, 172, "https://w7.pngwing.com/pngs/130/591/png-transparent-sakura-haruno-kakashi-hatake-naruto-anime-sakura-fictional-character-cartoon-arm.png", 154, "Sakura" },
                    { 131, 96, 1000, 173, "https://www.lifeder.com/wp-content/uploads/2016/12/frases-de-Madara-Uchiha.jpg", 155, "Madara" },
                    { 132, 70, 1000, 174, "https://indiehoy.com/wp-content/uploads/2018/11/naruto.jpg", 156, "Jiraiya" },
                    { 133, 70, 1000, 175, "https://www.looper.com/img/gallery/untold-truth-of-obito-uchiha/l-intro-1663609851.jpg", 157, "Obito Uchiha" },
                    { 134, 70, 1000, 176, "http://pm1.narvii.com/6807/cc8cd27924f9b644bf1a449ea5094c7869fbf60bv2_00.jpg", 158, "Hinata Hyūga" },
                    { 135, 70, 1000, 177, "https://static1.cbrimages.com/wordpress/wp-content/uploads/2022/07/shikamaru-serious-face.jpg", 159, "Shikamaru Nara" },
                    { 136, 70, 1000, 178, "https://pm1.narvii.com/6292/86499d2e3fd4b37f9c14709d4f899be025072251_hq.jpg", 160, "Sasori" },
                    { 137, 71, 1000, 179, "http://pm1.narvii.com/6903/05259702594930914773e2c9bad84e3897de1d0er1-720-496v2_00.jpg", 161, "Boruto Uzumaki" },
                    { 138, 71, 1000, 180, "https://i.ytimg.com/vi/lCNj1tOMeSg/maxresdefault.jpg", 162, "Sarada Uchiha" },
                    { 139, 71, 1000, 181, "http://pm1.narvii.com/6587/d7cd0f0324e819bcfb72eb49151eb11cc5f774da_00.jpg", 163, "Mitsuki" },
                    { 140, 71, 1000, 182, "https://e7.pngegg.com/pngimages/858/176/png-clipart-inojin-yamanaka-ino-yamanaka-naruto-sarada-uchiha-sai-naruto-fictional-character-cartoon.png", 164, "Inojin Yamanaka" },
                    { 141, 71, 1000, 183, "https://animeargentina.net/wp-content/uploads/2022/09/shikadai-nara-boruto-1024x567.jpg", 165, "Shikadai Nara" },
                    { 142, 80, 1000, 184, "https://w0.peakpx.com/wallpaper/188/670/HD-wallpaper-seiya-pegaso-seiya-thumbnail.jpg", 166, "Seiya de Pegaso" },
                    { 143, 80, 1000, 185, "https://i.ytimg.com/vi/ERU1RT0p4XI/maxresdefault.jpg", 167, "Seiya de Geminis" },
                    { 144, 80, 1000, 186, "https://4.bp.blogspot.com/-Y8dZy1ueVNE/UkH7jm2pQ0I/AAAAAAAAECo/nGb9T-6d39Q/w1200-h630-p-k-no-nu/Athena-Saori+47.JPG", 168, "Atenea" },
                    { 145, 80, 1000, 187, "https://i.pinimg.com/originals/31/e9/9e/31e99e59c05f07d0cd4428c9713f4e26.jpg", 169, "Shaka de Virgo" },
                    { 146, 80, 1000, 188, "https://i.pinimg.com/736x/01/3a/db/013adb562fba898abe5d2ec869e6e31d.jpg", 170, "Mu de Aries" },
                    { 147, 81, 1000, 189, "http://pm1.narvii.com/6293/87a989c9c38a945509db9d65522169977e3e5e30_00.jpg", 171, "Shun de Andromeda" },
                    { 148, 81, 1000, 190, "http://pm1.narvii.com/6712/ec816326096d2fe230f28f0760c5be0802e8399f_00.jpg", 172, "Shura de Capricornio" },
                    { 149, 81, 1000, 191, "https://w0.peakpx.com/wallpaper/553/97/HD-wallpaper-dragon-shiryu-dragon-shiryu.jpg", 173, "Shiryū de Dragón" },
                    { 150, 81, 1000, 192, "http://pm1.narvii.com/6803/9d7b4a867dec204fa73dea3b81b37053230fdb94v2_00.jpg", 174, "Camus de Acuario" },
                    { 151, 81, 1000, 193, "http://pm1.narvii.com/6890/8c48ea5abaaad37c00a1a635b366553d2f33009br1-1280-1335v2_uhq.jpg", 175, "Shion de Aries" },
                    { 152, 82, 1000, 194, "http://2.bp.blogspot.com/-du6bFdb47Xg/U-VQAgM3DVI/AAAAAAAAAs0/MvlEAOV6kHU/s1600/Siegfried+de+Dubhe+Alfa.JPG", 176, "Siegfried de Dubhe Alfa" },
                    { 153, 82, 1000, 194, "http://pm1.narvii.com/6568/493d72b9815f1c67068f0b145128fbd7abc2ef78_00.jpg", 177, "Syd de Mizar Zeta" },
                    { 154, 82, 1000, 194, "https://1.bp.blogspot.com/-EcqwLj7ds_M/TjXC8ySud9I/AAAAAAAAB-Y/7eKlYXKpEuo/s1600/Bud%2Bde%2BAlcor%2B14.JPG", 178, "Bud de Alcor Zeta" },
                    { 155, 82, 1000, 195, "http://pm1.narvii.com/6943/0468c2b73ddcf1e183974f4f7ca9c6e5011fc215r1-500-625v2_00.jpg", 179, "Thor de Phecda Gamma" },
                    { 156, 82, 1000, 196, "http://1.bp.blogspot.com/-LVDyeco5Ob4/T7SlNpDoxFI/AAAAAAAAAqs/34-fPlEuEGM/s1600/1222475717580_f.jpg", 180, "Fenrir de Alioth Epsilon" },
                    { 157, 82, 1000, 197, "http://1.bp.blogspot.com/-bnI3Btv9PZo/T7TI4m7QCDI/AAAAAAAAAro/3ZtVAZG-IoM/s1600/mime0.jpg", 181, "Mime de Benetnasch Eta" },
                    { 158, 82, 1000, 198, "http://pm1.narvii.com/6482/f62e6851ea49e05180b1df59281f1c51a37379ef_00.jpg", 182, "Alberich de Megrez Delta" },
                    { 159, 82, 1000, 199, "https://2.bp.blogspot.com/-wLMXGMh4VaQ/Tgod1AWZBPI/AAAAAAAABw8/9xDpIpNMWIE/s1600/Hagen%2Bde%2BMerak%2B%2528Beta%2529%2B21.JPG", 183, "Hagen de Merak Beta" },
                    { 160, 82, 1000, 200, "https://i.pinimg.com/736x/5b/fa/40/5bfa4054ea0ec72fb6a79486403978cc.jpg", 184, "Andromeda" },
                    { 161, 82, 1000, 1001, "https://i.pinimg.com/736x/8e/13/39/8e1339160a22b5c26a3e42dd859360b0.jpg", 185, "Danae" },
                    { 460, 8, 1000, 78, "https://i0.wp.com/basquettotal.com/wp-content/uploads/2022/02/RC_L2664-e1645034434512.jpg?resize=627%2C376&ssl=1", 60, "Fernando Martinez" },
                    { 620, 12, 1000, 103, "https://i.ytimg.com/vi/O6IPRouzvU0/hqdefault.jpg", 85, "Joaquin Prada Centro" },
                    { 630, 13, 1000, 104, "https://i.pinimg.com/originals/c4/4a/d3/c44ad3182299b9c08337465bef2ea2bc.png", 86, "Boo" },
                    { 640, 13, 1000, 105, "https://i.pinimg.com/originals/45/87/71/4587717835c6e0bbb388844a395bd04e.png", 87, "Mike Wazowski" },
                    { 650, 13, 1000, 106, "https://e7.pngegg.com/pngimages/178/635/png-clipart-disney-monster-inc-fungus-fungus-at-the-movies-cartoons-thumbnail.png", 88, "Fungus" },
                    { 660, 13, 1000, 107, "https://static.wikia.nocookie.net/heroes-of-the-characters/images/e/e5/Roz_%28Monsters_Inc._-_Render%29.png/revision/latest?cb=20210825084538", 89, "Roz" },
                    { 670, 13, 1000, 108, "https://static.wikia.nocookie.net/monstersincmovies/images/6/67/Bile-white.jpg/revision/latest?cb=20130515201629", 90, "Bile" },
                    { 680, 14, 1000, 109, "https://i.pinimg.com/originals/c4/4a/d3/c44ad3182299b9c08337465bef2ea2bc.png", 91, "Boo" },
                    { 690, 14, 1000, 110, "https://i.pinimg.com/originals/45/87/71/4587717835c6e0bbb388844a395bd04e.png", 92, "Mike Wazowski" },
                    { 700, 14, 1000, 111, "https://e7.pngegg.com/pngimages/178/635/png-clipart-disney-monster-inc-fungus-fungus-at-the-movies-cartoons-thumbnail.png", 93, "Fungus" }
                });

            migrationBuilder.InsertData(
                table: "TablaImagenes",
                columns: new[] { "Id", "AlbumId", "CantidadImpresa", "CodigoImagenOriginal", "Imagen", "NumeroImagen", "Titulo" },
                values: new object[] { 1180, 64, 1000, 160, "https://e.rpp-noticias.io/xlarge/2019/10/09/015501_849974.jpg", 142, "Gohan" });

            migrationBuilder.InsertData(
                table: "TablaImagenes",
                columns: new[] { "Id", "AlbumId", "CantidadImpresa", "CodigoImagenOriginal", "Imagen", "NumeroImagen", "Titulo" },
                values: new object[] { 2800, 5, 1000, 59, "https://www.atptour.com/-/media/tennis/players/gladiator/2022/06/18/23/00/fritz-full-2022-june-1.png", 41, "Taylor Fritz" });

            migrationBuilder.InsertData(
                table: "TablaImagenesImpresas",
                columns: new[] { "Id", "AlbumImagenId", "CodigoImagenImpresa", "PathImagenImpreso" },
                values: new object[,]
                {
                    { 1, 1, 100, "gsk" },
                    { 2, 1, 110, "sbcik" },
                    { 3, 1, 120, "knxhi" }
                });

            migrationBuilder.InsertData(
                table: "TablaUsuarioImagenes",
                columns: new[] { "Id", "AlbumId", "AlbumImagenesId", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 0, 1, 1 },
                    { 2, 0, 2, 2 },
                    { 3, 0, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "Entity_Id1",
                table: "TablaAlbumes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TablaAlbumes_ColeccionAlbumId",
                table: "TablaAlbumes",
                column: "ColeccionAlbumId");

            migrationBuilder.CreateIndex(
                name: "Entity_Id4",
                table: "TablaAlbumesUsuarios",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TablaAlbumesUsuarios_AlbumId",
                table: "TablaAlbumesUsuarios",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_TablaAlbumesUsuarios_UsuarioId",
                table: "TablaAlbumesUsuarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "Entity_Id6",
                table: "TablaColeccionAlbumes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Entity_Id3",
                table: "TablaImagenes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TablaImagenes_AlbumId",
                table: "TablaImagenes",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "Entity_Id2",
                table: "TablaImagenesImpresas",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TablaImagenesImpresas_AlbumImagenId",
                table: "TablaImagenesImpresas",
                column: "AlbumImagenId");

            migrationBuilder.CreateIndex(
                name: "Entity_Id",
                table: "TablaRoles",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TablaRoles_UsuarioId",
                table: "TablaRoles",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "Entity_Id5",
                table: "TablaUsuarioImagenes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TablaUsuarioImagenes_AlbumImagenesId",
                table: "TablaUsuarioImagenes",
                column: "AlbumImagenesId");

            migrationBuilder.CreateIndex(
                name: "IX_TablaUsuarioImagenes_UsuarioId",
                table: "TablaUsuarioImagenes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "Entity_Id7",
                table: "TablaUsuarios",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TablaAlbumesUsuarios");

            migrationBuilder.DropTable(
                name: "TablaImagenesImpresas");

            migrationBuilder.DropTable(
                name: "TablaRoles");

            migrationBuilder.DropTable(
                name: "TablaUsuarioImagenes");

            migrationBuilder.DropTable(
                name: "TablaImagenes");

            migrationBuilder.DropTable(
                name: "TablaUsuarios");

            migrationBuilder.DropTable(
                name: "TablaAlbumes");

            migrationBuilder.DropTable(
                name: "TablaColeccionAlbumes");
        }
    }
}
