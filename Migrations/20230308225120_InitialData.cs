using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CURSO_FUNDAMENTOS_EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("16380453-22c4-4971-98f3-20404321d976"), null, "Actividades terminadas", 12 },
                    { new Guid("ac8e7b88-ba94-4525-a2d3-b91afb7b9968"), null, "Actividades personales", 30 },
                    { new Guid("e9786fb9-0b5a-4e0a-b181-0265123d1e2e"), null, "Actividades pendientes", 2 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("4c175dee-3cc8-4b85-be90-2d5c4f296557"), new Guid("e9786fb9-0b5a-4e0a-b181-0265123d1e2e"), null, new DateTime(2023, 3, 8, 19, 51, 20, 4, DateTimeKind.Local).AddTicks(358), 1, "Pago de servicios publicos" },
                    { new Guid("51a0aa6d-b01d-4100-bec1-9f91ed98ec30"), new Guid("ac8e7b88-ba94-4525-a2d3-b91afb7b9968"), null, new DateTime(2023, 3, 8, 19, 51, 20, 4, DateTimeKind.Local).AddTicks(370), 2, "Terminar curso ASP.NET" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("16380453-22c4-4971-98f3-20404321d976"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("4c175dee-3cc8-4b85-be90-2d5c4f296557"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("51a0aa6d-b01d-4100-bec1-9f91ed98ec30"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("ac8e7b88-ba94-4525-a2d3-b91afb7b9968"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("e9786fb9-0b5a-4e0a-b181-0265123d1e2e"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
