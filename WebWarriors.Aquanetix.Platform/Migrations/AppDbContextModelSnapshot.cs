using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

#nullable disable

namespace WebWarriors.Aquanetix.Platform.Migrations;

[DbContext(typeof(AppDbContext))]
partial class AppDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "10.0.8")
            .HasAnnotation("Relational:MaxIdentifierLength", 64);

        modelBuilder.Entity("WebWarriors.Aquanetix.Platform.Dashboard.Domain.Model.Aggregates.QualityAnalysis", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasColumnName("id");

            b.Property<string>("DetectedParameters")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)")
                .HasColumnName("detected_parameters");

            b.Property<string>("AnomalyStatus")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)")
                .HasColumnName("anomaly_status");

            b.Property<double>("SeverityScore")
                .HasColumnType("double")
                .HasColumnName("severity_score");

            b.Property<bool>("HasContaminationPeakPrediction")
                .HasColumnType("tinyint(1)")
                .HasColumnName("has_contamination_peak_prediction");

            b.Property<int>("SensorSourceId")
                .HasColumnType("int")
                .HasColumnName("sensor_source_id");

            b.Property<DateTimeOffset?>("CreatedAt")
                .HasColumnType("datetime(6)")
                .HasColumnName("created_at");

            b.Property<DateTimeOffset?>("UpdatedAt")
                .HasColumnType("datetime(6)")
                .HasColumnName("updated_at");

            b.HasKey("Id").HasName("pk_quality_analyses");

            b.ToTable("quality_analyses");
        });
#pragma warning restore 612, 618
    }
}