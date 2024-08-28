using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_Progra_Avanzada.Data.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_823 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MensajesChat",
                columns: table => new
                {
                    MensajeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChatID = table.Column<int>(type: "int", nullable: false),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEnvio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensajesChat", x => x.MensajeID);
                    table.ForeignKey(
                        name: "FK_MensajesChat_AspNetUsers_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantesChat",
                columns: table => new
                {
                    ParticipanteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatID = table.Column<int>(type: "int", nullable: false),
                    UsuarioID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantesChat", x => x.ParticipanteID);
                    table.ForeignKey(
                        name: "FK_ParticipantesChat_AspNetUsers_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Retos",
                columns: table => new
                {
                    RetoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetadorID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RetadoID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaReto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retos", x => x.RetoID);
                    table.ForeignKey(
                        name: "FK_Retos_AspNetUsers_RetadoID",
                        column: x => x.RetadoID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Retos_AspNetUsers_RetadorID",
                        column: x => x.RetadorID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MensajesChat_UsuarioID",
                table: "MensajesChat",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantesChat_UsuarioID",
                table: "ParticipantesChat",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Retos_RetadoID",
                table: "Retos",
                column: "RetadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Retos_RetadorID",
                table: "Retos",
                column: "RetadorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MensajesChat");

            migrationBuilder.DropTable(
                name: "ParticipantesChat");

            migrationBuilder.DropTable(
                name: "Retos");
        }
    }
}
