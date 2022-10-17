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
                    ColeccionAlbumId = table.Column<int>(type: "int", nullable: false)
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
                    EstaPegada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumUsuarioId = table.Column<int>(type: "int", nullable: false),
                    AlbumImagenImpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaUsuarioImagenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TablaUsuarioImagenes_TablaAlbumesUsuarios_AlbumUsuarioId",
                        column: x => x.AlbumUsuarioId,
                        principalTable: "TablaAlbumesUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TablaUsuarioImagenes_TablaImagenesImpresas_AlbumImagenImpresaId",
                        column: x => x.AlbumImagenImpresaId,
                        principalTable: "TablaImagenesImpresas",
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
                columns: new[] { "Id", "CantidadImagen", "CantidadImpreso", "CodigoAlbum", "ColeccionAlbumId", "Descripcion", "Desde", "Hasta", "Titulo" },
                values: new object[,]
                {
                    { 1, 1000, 1000, 1, 1, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9251), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9267), "Copa Libertadores" },
                    { 2, 1000, 1000, 2, 1, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9280), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9281), "Champions Lague" },
                    { 3, 1000, 1000, 3, 1, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9282), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9283), "Copa America" },
                    { 4, 1000, 1000, 4, 2, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9285), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9285), "Winledom" },
                    { 5, 1000, 1000, 5, 2, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9287), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9287), "Rollan Garros" },
                    { 6, 1000, 1000, 6, 2, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9289), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9290), "Us Open" },
                    { 7, 1000, 1000, 7, 3, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9291), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9292), "Liga Endesa" },
                    { 8, 1000, 1000, 8, 3, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9293), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9294), "NBA" },
                    { 9, 1000, 1000, 9, 3, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9295), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9296), "La Liga Argentina" },
                    { 10, 1000, 1000, 10, 4, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9298), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9299), "National Rugby League" },
                    { 11, 1000, 1000, 11, 4, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9301), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9301), "Super League" },
                    { 12, 1000, 1000, 12, 4, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9303), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9303), "The Rugby Championship" },
                    { 13, 1000, 1000, 1, 5, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9305), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9306), "Dragonball" },
                    { 14, 1000, 1000, 2, 5, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9307), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9308), "Dragonball Z" },
                    { 15, 1000, 1000, 3, 5, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9309), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9310), "Dragonball Super" },
                    { 16, 1000, 1000, 4, 5, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9312), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9312), "Naruto" },
                    { 17, 1000, 1000, 5, 5, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9314), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9315), "Naruto Shippuden" },
                    { 18, 1000, 1000, 6, 5, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9316), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9317), "Naruto Next Generation" },
                    { 19, 1000, 1000, 7, 5, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9318), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9319), "Saint Seiya the Lost Canvas" },
                    { 20, 1000, 1000, 8, 5, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9320), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9321), "Batalla de Poseidon" },
                    { 21, 1000, 1000, 9, 5, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9323), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9323), "Batalla de Asgard" },
                    { 22, 1000, 1000, 100, 6, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9325), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9325), "Monster Inc" },
                    { 23, 1000, 1000, 101, 6, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9328), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9329), "Monster University" },
                    { 24, 1000, 1000, 102, 6, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9331), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9331), "High school Musical" },
                    { 25, 1000, 1000, 104, 6, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9333), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9333), "High school Musical 2" },
                    { 26, 1000, 1000, 105, 6, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9338), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9338), "La era del hielo 1" },
                    { 27, 1000, 1000, 106, 6, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9340), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9340), "La era del hielo 2" },
                    { 28, 1000, 1000, 107, 6, "figus", new DateTime(2022, 10, 17, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9342), new DateTime(2022, 10, 27, 19, 55, 14, 661, DateTimeKind.Local).AddTicks(9343), "La era del hielo 3" }
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
                    { 1, 1, 1000, 31, " ", 200, "Armani Franco" },
                    { 2, 1, 1000, 32, " ", 201, "Franco Daniel" },
                    { 3, 1, 1000, 33, "si", 202, "Guido Herrera" },
                    { 4, 1, 1000, 34, "si", 2023, "Pratto Lucas" },
                    { 5, 1, 1000, 35, " ", 204, "Bou Walter" },
                    { 6, 1, 1000, 36, " ", 205, "Valoyes Diego" },
                    { 7, 2, 1000, 37, " ", 20, "Bou Walter" },
                    { 8, 2, 1000, 38, " ", 21, "Pratto Lucas" },
                    { 9, 2, 1000, 39, " ", 22, "Franco Daniel" },
                    { 10, 2, 1000, 40, " ", 23, "ArmanI Franco" },
                    { 11, 2, 1000, 41, " ", 24, "Guido Herrera" },
                    { 12, 2, 1000, 42, " ", 25, "Salas" },
                    { 13, 3, 1000, 43, " ", 26, "Firmiño" },
                    { 14, 3, 1000, 44, " ", 27, "Alvarez Julian" },
                    { 15, 3, 1000, 45, " ", 28, "Halan" },
                    { 16, 3, 1000, 46, " ", 29, "Cuti Romero" },
                    { 17, 3, 1000, 47, " ", 30, "Dibu Martinez" },
                    { 18, 4, 1000, 48, " ", 31, "Nadal Rafael" },
                    { 19, 4, 1000, 49, " ", 32, "Federer Roger" },
                    { 20, 4, 1000, 50, " ", 33, "Murray" },
                    { 21, 4, 1000, 51, " ", 34, "Del Potro" },
                    { 22, 2, 1000, 52, " ", 35, "David Nalvandian" },
                    { 23, 2, 1000, 53, " ", 36, "Novak Djovich" },
                    { 24, 5, 1000, 54, " ", 37, "Nadal Rafael" },
                    { 25, 5, 1000, 55, " ", 37, "Federer Roger" },
                    { 26, 5, 1000, 56, " ", 38, "Murray" },
                    { 27, 5, 1000, 57, " ", 39, "Del Potro" },
                    { 28, 4, 1000, 58, " ", 40, "David Nalvandian" },
                    { 29, 6, 1000, 60, " ", 42, "Nadal Rafael" },
                    { 30, 6, 1000, 61, " ", 43, "Federer Roger" },
                    { 31, 6, 1000, 62, " ", 44, "Murray" },
                    { 32, 6, 1000, 63, " ", 45, "Del Potro" },
                    { 33, 6, 1000, 64, " ", 46, "David Nalvandian" },
                    { 34, 6, 1000, 65, " ", 47, "Novak Djokovich" },
                    { 41, 3, 1000, 72, " ", 54, "Manuel Ginobilli" },
                    { 42, 3, 1000, 73, " ", 55, "Kevin Durant" },
                    { 43, 3, 1000, 74, " ", 56, "Elvin Hayes" },
                    { 44, 3, 1000, 75, " ", 57, "Bob Pettit" },
                    { 45, 3, 1000, 76, " ", 58, "Giannis Antokoumpo" }
                });

            migrationBuilder.InsertData(
                table: "TablaImagenes",
                columns: new[] { "Id", "AlbumId", "CantidadImpresa", "CodigoImagenOriginal", "Imagen", "NumeroImagen", "Titulo" },
                values: new object[,]
                {
                    { 46, 3, 1000, 77, " ", 59, "Oscar Robertson" },
                    { 47, 3, 1000, 79, " ", 61, "Martin Cabrera" },
                    { 48, 3, 1000, 80, " ", 62, "Franco Barroso" },
                    { 49, 3, 1000, 81, " ", 63, "Juan Cruz Oberto" },
                    { 50, 3, 1000, 82, " ", 64, "Marcelo Milanesio" },
                    { 51, 4, 1000, 83, " ", 65, "Julian Montoya" },
                    { 52, 4, 1000, 84, " ", 66, "Matias Alemano" },
                    { 53, 4, 1000, 85, " ", 67, "Julian Cruz Mallia" },
                    { 54, 4, 1000, 86, " ", 68, "Tomas Cubeli" },
                    { 55, 4, 1000, 87, " ", 69, "Felipe Contemponi" },
                    { 56, 4, 1000, 88, " ", 70, "Julian Montoya" },
                    { 57, 4, 1000, 89, " ", 71, "Matias Alemano" },
                    { 58, 4, 1000, 90, " ", 72, "Julian Cruz Mallia" },
                    { 59, 4, 1000, 91, " ", 73, "Tomas Cubelli" },
                    { 60, 4, 1000, 92, " ", 74, "Felipe Contemponi" },
                    { 61, 4, 1000, 93, " ", 75, "Julian Montoya" },
                    { 62, 4, 1000, 94, " ", 76, "Matias Alemano" },
                    { 63, 4, 1000, 95, " ", 77, "Julian Cruz Mallia" },
                    { 64, 4, 1000, 96, " ", 78, "Tomas Cubelli" },
                    { 65, 4, 1000, 97, " ", 79, "Felipe Contemponi" },
                    { 66, 4, 1000, 98, " ", 80, "Julian Montoya" },
                    { 67, 4, 1000, 99, " ", 81, "Matias Alemano" },
                    { 68, 4, 1000, 100, " ", 82, "Julian Cruz Mallia" },
                    { 69, 4, 1000, 101, " ", 83, "Tomas Cubelli" },
                    { 70, 4, 1000, 102, " ", 84, "Felipe Contemponi" },
                    { 71, 5, 1000, 112, " ", 94, "Roz" },
                    { 72, 5, 1000, 113, " ", 95, "Bile" },
                    { 73, 5, 1000, 114, " ", 96, "Troy Bolton" },
                    { 74, 5, 1000, 115, " ", 97, "Gabriela Montes" },
                    { 75, 5, 1000, 116, " ", 98, "Sharpay Evans" },
                    { 76, 5, 1000, 117, " ", 99, "Martha Cox" },
                    { 77, 5, 1000, 118, " ", 100, "Lucille Bolton" },
                    { 78, 5, 1000, 119, " ", 101, "Troy Bolton" },
                    { 79, 5, 1000, 120, " ", 102, "Gabriela Montes" },
                    { 80, 5, 1000, 121, " ", 103, "Sharpay Evans" },
                    { 81, 5, 1000, 122, " ", 104, "Martha Cox" },
                    { 82, 5, 1000, 123, " ", 105, "Lucile Bolton" },
                    { 83, 5, 1000, 124, " ", 106, "Troy Bolton" },
                    { 84, 5, 1000, 125, " ", 107, "Gabriela Montes" },
                    { 85, 5, 1000, 126, " ", 108, "Sharpay Evans" },
                    { 86, 5, 1000, 127, " ", 109, "Martha Cox" },
                    { 87, 5, 1000, 128, " ", 110, "Lucile Bolton" }
                });

            migrationBuilder.InsertData(
                table: "TablaImagenes",
                columns: new[] { "Id", "AlbumId", "CantidadImpresa", "CodigoImagenOriginal", "Imagen", "NumeroImagen", "Titulo" },
                values: new object[,]
                {
                    { 88, 5, 1000, 129, " ", 111, "Sid" },
                    { 89, 5, 1000, 130, " ", 112, "Many" },
                    { 90, 5, 1000, 131, " ", 113, "Roshan" },
                    { 91, 5, 1000, 132, " ", 114, "Diego" },
                    { 92, 5, 1000, 133, " ", 115, "Scrat" },
                    { 93, 5, 1000, 134, " ", 116, "Sid" },
                    { 94, 5, 1000, 135, " ", 117, "Many" },
                    { 95, 5, 1000, 136, " ", 118, "Roshan" },
                    { 96, 5, 1000, 137, " ", 119, "Diego" },
                    { 97, 5, 1000, 138, " ", 120, "Scrat" },
                    { 98, 5, 1000, 139, " ", 121, "Sid" },
                    { 99, 5, 1000, 140, " ", 122, "Many" },
                    { 100, 5, 1000, 141, " ", 123, "Roshan" },
                    { 101, 5, 1000, 142, " ", 124, "Diego" },
                    { 102, 5, 1000, 143, " ", 125, "Scrat" },
                    { 103, 5, 1000, 144, " ", 126, "Dra Grace" },
                    { 104, 5, 1000, 145, " ", 127, "Neyriti" },
                    { 105, 5, 1000, 146, " ", 128, "Jake Sully" },
                    { 106, 5, 1000, 147, " ", 129, "Tsutey" },
                    { 107, 5, 1000, 148, " ", 130, "Coronel Milles" },
                    { 108, 5, 1000, 149, " ", 131, "Dra Grace" },
                    { 109, 5, 1000, 150, " ", 132, "Neyriti" },
                    { 110, 5, 1000, 151, " ", 133, "Jake Sully" },
                    { 111, 5, 1000, 152, " ", 134, "Tsutey" },
                    { 112, 5, 1000, 153, " ", 135, "Coronel Milles" },
                    { 113, 6, 1000, 154, " ", 136, "Goku" },
                    { 114, 6, 1000, 155, " ", 137, "Vegeta" },
                    { 115, 6, 1000, 156, " ", 138, "Cell" },
                    { 116, 6, 1000, 157, " ", 139, "Picolo" },
                    { 117, 6, 1000, 158, " ", 140, "Son Gohan" },
                    { 118, 6, 1000, 159, " ", 141, "Goku" },
                    { 119, 6, 1000, 161, " ", 143, "Cell" },
                    { 120, 6, 1000, 162, " ", 144, "Picolo" },
                    { 121, 6, 1000, 163, " ", 145, "Son Gohan" },
                    { 122, 6, 1000, 164, " ", 146, "Goku" },
                    { 123, 6, 1000, 165, " ", 147, "Vegeta" },
                    { 124, 6, 1000, 166, " ", 148, "Cell" },
                    { 125, 6, 1000, 167, " ", 149, "Picolo" },
                    { 126, 6, 1000, 168, " ", 150, "Son Gohan" },
                    { 127, 6, 1000, 169, " ", 151, "Naruto" },
                    { 128, 6, 1000, 170, " ", 152, "Sasuke" },
                    { 129, 6, 1000, 171, " ", 153, "Itachi" }
                });

            migrationBuilder.InsertData(
                table: "TablaImagenes",
                columns: new[] { "Id", "AlbumId", "CantidadImpresa", "CodigoImagenOriginal", "Imagen", "NumeroImagen", "Titulo" },
                values: new object[,]
                {
                    { 130, 6, 1000, 172, " ", 154, "Sakura" },
                    { 131, 6, 1000, 173, " ", 155, "Madara" },
                    { 132, 6, 1000, 174, " ", 156, "Naruto" },
                    { 133, 6, 1000, 175, " ", 157, "Sasuke" },
                    { 134, 6, 1000, 176, " ", 158, "Itachi" },
                    { 135, 6, 1000, 177, " ", 159, "Sakura" },
                    { 136, 6, 1000, 178, " ", 160, "Madara" },
                    { 137, 6, 1000, 179, " ", 161, "Naruto" },
                    { 138, 6, 1000, 180, " ", 162, "Sasuke" },
                    { 139, 6, 1000, 181, " ", 163, "Itachi" },
                    { 140, 6, 1000, 182, " ", 164, "Sakura" },
                    { 141, 6, 1000, 183, " ", 165, "Madara" },
                    { 142, 6, 1000, 184, " ", 166, "Seiya de Pegaso" },
                    { 143, 6, 1000, 185, " ", 167, "Seya de Geminis" },
                    { 144, 6, 1000, 186, " ", 168, "Atenea" },
                    { 145, 6, 1000, 187, " ", 169, "Saka de Virgo" },
                    { 146, 6, 1000, 188, " ", 170, "Mu de Aries" },
                    { 147, 6, 1000, 189, " ", 171, "Seiya de Pegaso" },
                    { 148, 6, 1000, 190, " ", 172, "Seya de Geminis" },
                    { 149, 6, 1000, 191, " ", 173, "Atenea" },
                    { 150, 6, 1000, 192, " ", 174, "Saka de Virgo" },
                    { 151, 6, 1000, 193, " ", 175, "Mu de Aries" },
                    { 152, 6, 1000, 194, " ", 176, "Seiya de Pegaso" },
                    { 153, 6, 1000, 194, " ", 177, "Seya de Geminis" },
                    { 154, 6, 1000, 194, " ", 178, "Atenea" },
                    { 155, 6, 1000, 195, " ", 179, "Saka de Virgo" },
                    { 156, 6, 1000, 196, " ", 180, "Mu de Aries" },
                    { 157, 6, 1000, 197, " ", 181, "Calibos" },
                    { 158, 6, 1000, 198, " ", 182, "Medusa" },
                    { 159, 6, 1000, 199, " ", 183, "Io" },
                    { 160, 6, 1000, 200, " ", 184, "Andromeda" },
                    { 161, 6, 1000, 1001, " ", 185, "Danae" },
                    { 162, 6, 1000, 102, " ", 186, "Calibos" },
                    { 163, 6, 1000, 103, " ", 187, "Medusa" },
                    { 164, 6, 1000, 104, " ", 188, "Io" },
                    { 165, 6, 1000, 105, " ", 189, "Andromeda" },
                    { 166, 6, 1000, 106, " ", 189, "Danae" },
                    { 460, 3, 1000, 78, " ", 60, "Fernando Martina" },
                    { 620, 4, 1000, 103, " ", 85, "Matias Alemano" },
                    { 630, 5, 1000, 104, " ", 86, "Boo" },
                    { 640, 5, 1000, 105, " ", 87, "Mike Wazowski" },
                    { 650, 5, 1000, 106, " ", 88, "Fungus" }
                });

            migrationBuilder.InsertData(
                table: "TablaImagenes",
                columns: new[] { "Id", "AlbumId", "CantidadImpresa", "CodigoImagenOriginal", "Imagen", "NumeroImagen", "Titulo" },
                values: new object[,]
                {
                    { 660, 5, 1000, 107, " ", 89, "Roz" },
                    { 670, 5, 1000, 108, " ", 90, "Bile" },
                    { 680, 5, 1000, 109, " ", 91, "Boo" },
                    { 690, 5, 1000, 110, " ", 92, "Mike Wazowski" },
                    { 700, 5, 1000, 111, " ", 93, "Fungus" },
                    { 1180, 6, 1000, 160, " ", 142, "Vegeta" },
                    { 2800, 5, 1000, 59, " ", 41, "Novak Djokovich" }
                });

            migrationBuilder.InsertData(
                table: "TablaImagenesImpresas",
                columns: new[] { "Id", "AlbumImagenId", "CodigoImagenImpresa", "PathImagenImpreso" },
                values: new object[] { 1, 1, 100, "gsk" });

            migrationBuilder.InsertData(
                table: "TablaImagenesImpresas",
                columns: new[] { "Id", "AlbumImagenId", "CodigoImagenImpresa", "PathImagenImpreso" },
                values: new object[] { 2, 1, 110, "sbcik" });

            migrationBuilder.InsertData(
                table: "TablaImagenesImpresas",
                columns: new[] { "Id", "AlbumImagenId", "CodigoImagenImpresa", "PathImagenImpreso" },
                values: new object[] { 3, 1, 120, "knxhi" });

            migrationBuilder.InsertData(
                table: "TablaUsuarioImagenes",
                columns: new[] { "Id", "AlbumImagenImpresaId", "AlbumUsuarioId", "EstaPegada" },
                values: new object[] { 1, 1, 1, "si" });

            migrationBuilder.InsertData(
                table: "TablaUsuarioImagenes",
                columns: new[] { "Id", "AlbumImagenImpresaId", "AlbumUsuarioId", "EstaPegada" },
                values: new object[] { 2, 2, 2, "si" });

            migrationBuilder.InsertData(
                table: "TablaUsuarioImagenes",
                columns: new[] { "Id", "AlbumImagenImpresaId", "AlbumUsuarioId", "EstaPegada" },
                values: new object[] { 3, 3, 3, "si" });

            migrationBuilder.CreateIndex(
                name: "Entity_Id",
                table: "TablaAlbumes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TablaAlbumes_ColeccionAlbumId",
                table: "TablaAlbumes",
                column: "ColeccionAlbumId");

            migrationBuilder.CreateIndex(
                name: "Entity_Id3",
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
                name: "Entity_Id5",
                table: "TablaColeccionAlbumes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Entity_Id2",
                table: "TablaImagenes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TablaImagenes_AlbumId",
                table: "TablaImagenes",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "Entity_Id1",
                table: "TablaImagenesImpresas",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TablaImagenesImpresas_AlbumImagenId",
                table: "TablaImagenesImpresas",
                column: "AlbumImagenId");

            migrationBuilder.CreateIndex(
                name: "Entity_Id4",
                table: "TablaUsuarioImagenes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TablaUsuarioImagenes_AlbumImagenImpresaId",
                table: "TablaUsuarioImagenes",
                column: "AlbumImagenImpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_TablaUsuarioImagenes_AlbumUsuarioId",
                table: "TablaUsuarioImagenes",
                column: "AlbumUsuarioId");

            migrationBuilder.CreateIndex(
                name: "Entity_Id6",
                table: "TablaUsuarios",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TablaUsuarioImagenes");

            migrationBuilder.DropTable(
                name: "TablaAlbumesUsuarios");

            migrationBuilder.DropTable(
                name: "TablaImagenesImpresas");

            migrationBuilder.DropTable(
                name: "TablaUsuarios");

            migrationBuilder.DropTable(
                name: "TablaImagenes");

            migrationBuilder.DropTable(
                name: "TablaAlbumes");

            migrationBuilder.DropTable(
                name: "TablaColeccionAlbumes");
        }
    }
}
