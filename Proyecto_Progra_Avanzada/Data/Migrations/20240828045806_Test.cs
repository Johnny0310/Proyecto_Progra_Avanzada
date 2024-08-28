using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_Progra_Avanzada.Data.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    ChatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.ChatID);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantesChat",
                columns: table => new
                {
                    ChatID = table.Column<int>(type: "int", nullable: false),
                    UsuarioID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaUnion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantesChat", x => new { x.ChatID, x.UsuarioID });
                    table.ForeignKey(
                        name: "FK_ParticipantesChat_AspNetUsers_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pokedex",
                columns: table => new
                {
                    id_Pokedex = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PokemonID = table.Column<int>(type: "int", nullable: false),
                    fecha_captura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vida = table.Column<int>(type: "int", nullable: false),
                    victorias = table.Column<int>(type: "int", nullable: false),
                    numeroEvolucion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokedex", x => x.id_Pokedex);
                });

            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    pokemonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroEvolucion = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    debilidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipoID = table.Column<int>(type: "int", nullable: false),
                    peso = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.pokemonID);
                });

            migrationBuilder.CreateTable(
                name: "Retos",
                columns: table => new
                {
                    RetoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetadorID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RetadoID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaReto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ganador = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retos", x => x.RetoID);
                });

            migrationBuilder.CreateTable(
                name: "TiposPokemon",
                columns: table => new
                {
                    tipoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPokemon", x => x.tipoID);
                });

            migrationBuilder.CreateTable(
                name: "MensajesChat",
                columns: table => new
                {
                    MensajeChatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChatID = table.Column<int>(type: "int", nullable: false),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEnvio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensajesChat", x => x.MensajeChatID);
                    table.ForeignKey(
                        name: "FK_MensajesChat_AspNetUsers_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MensajesChat_Chats_ChatID",
                        column: x => x.ChatID,
                        principalTable: "Chats",
                        principalColumn: "ChatID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MensajesChat_ChatID",
                table: "MensajesChat",
                column: "ChatID");

            migrationBuilder.CreateIndex(
                name: "IX_MensajesChat_UsuarioID",
                table: "MensajesChat",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantesChat_UsuarioID",
                table: "ParticipantesChat",
                column: "UsuarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MensajesChat");

            migrationBuilder.DropTable(
                name: "ParticipantesChat");

            migrationBuilder.DropTable(
                name: "Pokedex");

            migrationBuilder.DropTable(
                name: "Pokemon");

            migrationBuilder.DropTable(
                name: "Retos");

            migrationBuilder.DropTable(
                name: "TiposPokemon");

            migrationBuilder.DropTable(
                name: "Chats");
        }
    }
}
