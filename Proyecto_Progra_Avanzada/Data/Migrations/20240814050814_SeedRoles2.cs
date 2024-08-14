using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_Progra_Avanzada.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles2 : Migration
    {
        private string Entrenador = Guid.NewGuid().ToString();
        private string Administrador = Guid.NewGuid().ToString();
        private string Enfermero = Guid.NewGuid().ToString();

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesSQL(migrationBuilder);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }


        private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
                VALUES ('{Entrenador}', 'Entrenador', 'Entrenador', null);");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
                VALUES ('{Administrador}', 'Administrador', 'Administrador', null);");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
                VALUES ('{Enfermero}', 'Enfermero', 'Enfermero', null);");
        }
    }
}
