using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebWarriors.Aquanetix.Platform.Migrations
{
    /// <inheritdoc />
    public partial class TemporalFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "devices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    owner_id = table.Column<int>(type: "int", nullable: false),
                    serial_number = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    device_type = table.Column<int>(type: "int", nullable: false),
                    current_status = table.Column<int>(type: "int", nullable: false),
                    last_telemetry_sync = table.Column<DateTimeOffset>(type: "datetime", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devices", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "threshold_configurations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    sensor_id = table.Column<int>(type: "int", nullable: false),
                    min_value = table.Column<double>(type: "double", nullable: false),
                    max_value = table.Column<double>(type: "double", nullable: false),
                    unit = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    alert_level = table.Column<int>(type: "int", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_threshold_configurations", x => x.id);
                    table.ForeignKey(
                        name: "FK_threshold_configurations_devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "devices",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_threshold_configurations_DeviceId",
                table: "threshold_configurations",
                column: "DeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "threshold_configurations");

            migrationBuilder.DropTable(
                name: "devices");
        }
    }
}
