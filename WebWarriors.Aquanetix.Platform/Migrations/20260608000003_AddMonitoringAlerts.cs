using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebWarriors.Aquanetix.Platform.Migrations;

/// <inheritdoc />
public partial class AddMonitoringAlerts : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "alerts",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                device_id = table.Column<int>(type: "int", nullable: false),
                device_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                location = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                severity = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                message = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                timestamp = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                value = table.Column<double>(type: "double", nullable: false),
                threshold = table.Column<double>(type: "double", nullable: false),
                created_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                updated_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_alerts", x => x.id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "alerts");
    }
}
