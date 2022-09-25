using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G7Album.BaseDatos.Migrations
{
    public partial class inico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Hasta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaAlbumes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TablaUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaUsuarios", x => x.Id);
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
                    PathModeloImagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "TablaAlbumesUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoAlbumUsuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CodigoAlbum = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                table: "TablaAlbumes",
                columns: new[] { "Id", "CantidadImagen", "CantidadImpreso", "CodigoAlbum", "Descripcion", "Desde", "Hasta", "Titulo" },
                values: new object[] { 1, 1000, 1000, 10, "figus", new DateTime(2022, 9, 25, 15, 8, 29, 601, DateTimeKind.Local).AddTicks(1827), new DateTime(2022, 10, 5, 15, 8, 29, 601, DateTimeKind.Local).AddTicks(1837), "album" });

            migrationBuilder.InsertData(
                table: "TablaUsuarios",
                columns: new[] { "Id", "Apellido", "Email", "Nombre", "Password" },
                values: new object[,]
                {
                    { 1, "Herrera", "vanesa@gmail.com", "Vanesa", "vanesa" },
                    { 2, "ledesma", "juanledesma@gmail.com", "juan", "juan" },
                    { 3, "arrieta", "aili@gmail.com", "oriana", "ailin" }
                });

            migrationBuilder.InsertData(
                table: "TablaAlbumesUsuarios",
                columns: new[] { "Id", "AlbumId", "CodigoAlbum", "CodigoAlbumUsuario", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 1, "a", "s", 1 },
                    { 2, 1, "b", "t", 2 },
                    { 3, 1, "c", "u", 3 }
                });

            migrationBuilder.InsertData(
                table: "TablaImagenes",
                columns: new[] { "Id", "AlbumId", "CantidadImpresa", "CodigoImagenOriginal", "Descripcion", "NumeroImagen", "PathModeloImagen" },
                values: new object[,]
                {
                    { 1, 1, 1000, 31, "era de hielo", 200, "hola" },
                    { 2, 1, 1000, 32, "REY LEON", 201, "chau" },
                    { 3, 1, 1000, 33, "Tarzan", 202, "si" }
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
                name: "Entity_Id5",
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
        }
    }
}
