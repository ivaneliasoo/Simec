using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace app.api.Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "App");

            migrationBuilder.CreateTable(
                name: "Clientes",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 16, nullable: false),
                    NombreCompleto = table.Column<string>(maxLength: 128, nullable: false),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentificadorCliente = table.Column<string>(maxLength: 16, nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetalleFactura",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<int>(nullable: false),
                    IdCliente = table.Column<int>(nullable: false),
                    IdFactura = table.Column<int>(nullable: false),
                    Cantidad = table.Column<double>(nullable: false),
                    Precio = table.Column<double>(nullable: false),
                    Subtotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleFactura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleFactura_Facturas_IdFactura",
                        column: x => x.IdFactura,
                        principalSchema: "App",
                        principalTable: "Facturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleFactura_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalSchema: "App",
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFactura_IdFactura",
                schema: "App",
                table: "DetalleFactura",
                column: "IdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFactura_IdProducto",
                schema: "App",
                table: "DetalleFactura",
                column: "IdProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes",
                schema: "App");

            migrationBuilder.DropTable(
                name: "DetalleFactura",
                schema: "App");

            migrationBuilder.DropTable(
                name: "Facturas",
                schema: "App");

            migrationBuilder.DropTable(
                name: "Productos",
                schema: "App");
        }
    }
}
