using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class usuarioadmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Apellido", "Codigo", "GeneroId", "ImagenUrl", "Nombre", "Password", "TipoUsuarioId" },
                values: new object[] { 1, "admin", "admin", 1, null, "admin", "$2a$11$GSQTXLhKOSHcs3N9rs9qvuCI7COj8K1cBAlSF/h43HgLoBgo/Ac1e", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
