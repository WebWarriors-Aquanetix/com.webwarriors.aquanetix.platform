using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebWarriors.Aquanetix.Platform.Migrations;

/// <inheritdoc />
public partial class AddServiceDesignWaterBatch : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "water_batches",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                certification_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                destination_sector_id = table.Column<int>(type: "int", nullable: false),
                volume_liters = table.Column<double>(type: "double", nullable: false),
                delivery_timestamp = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                source = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                created_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                updated_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_water_batches", x => x.id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "water_batches");
    }
}