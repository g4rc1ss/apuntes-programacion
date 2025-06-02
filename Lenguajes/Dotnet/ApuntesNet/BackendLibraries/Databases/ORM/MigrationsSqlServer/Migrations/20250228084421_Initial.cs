using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationsSqlServer.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "pueblos",
            columns: table => new
            {
                Id = table
                    .Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Nombre = table.Column<string>(type: "varchar(100)", nullable: false),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_pueblos", x => x.Id);
            }
        );

        migrationBuilder.CreateTable(
            name: "usuarios",
            columns: table => new
            {
                Id = table
                    .Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                PuebloId = table.Column<int>(type: "int", nullable: false),
                Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Edad = table.Column<int>(type: "int", nullable: false),
                FechaHoy = table.Column<DateTime>(type: "datetime2", nullable: false),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_usuarios", x => x.Id);
                table.ForeignKey(
                    name: "FK_usuarios_pueblos_PuebloId",
                    column: x => x.PuebloId,
                    principalTable: "pueblos",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade
                );
            }
        );

        migrationBuilder.CreateIndex(
            name: "IX_pueblos_IsDeleted",
            table: "pueblos",
            column: "IsDeleted"
        );

        migrationBuilder.CreateIndex(
            name: "IX_usuarios_IsDeleted",
            table: "usuarios",
            column: "IsDeleted"
        );

        migrationBuilder.CreateIndex(
            name: "IX_usuarios_PuebloId",
            table: "usuarios",
            column: "PuebloId"
        );
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "usuarios");

        migrationBuilder.DropTable(name: "pueblos");
    }
}
