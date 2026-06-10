using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebWarriors.Aquanetix.Platform.Migrations;

/// <inheritdoc />
public partial class AddDashboardQualityAnalysis : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "quality_analyses",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                sensor_source_id = table.Column<int>(type: "int", nullable: false),
                detected_parameters = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                anomaly_status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                severity_score = table.Column<double>(type: "double", nullable: false),
                has_contamination_peak_prediction = table.Column<bool>(type: "tinyint(1)", nullable: false),
                created_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                updated_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_quality_analyses", x => x.id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "quality_analyses");
    }
}