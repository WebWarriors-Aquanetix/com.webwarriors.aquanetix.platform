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

        modelBuilder.Entity("WebWarriors.Aquanetix.Platform.Monitoring.Domain.Model.Aggregates.Alert", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasColumnName("id");

            b.Property<DateTimeOffset?>("CreatedAt")
                .HasColumnType("datetime(6)")
                .HasColumnName("created_at");

            b.Property<int>("DeviceId")
                .HasColumnType("int")
                .HasColumnName("device_id");

            b.Property<string>("DeviceName")
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .HasColumnName("device_name");

            b.Property<string>("Location")
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)")
                .HasColumnName("location");

            b.Property<string>("Message")
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnType("varchar(500)")
                .HasColumnName("message");

            b.Property<string>("Severity")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)")
                .HasColumnName("severity");

            b.Property<string>("Status")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)")
                .HasColumnName("status");

            b.Property<double>("Threshold")
                .HasColumnType("double")
                .HasColumnName("threshold");

            b.Property<DateTimeOffset>("Timestamp")
                .HasColumnType("datetime(6)")
                .HasColumnName("timestamp");

            b.Property<string>("Type")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)")
                .HasColumnName("type");

            b.Property<DateTimeOffset?>("UpdatedAt")
                .HasColumnType("datetime(6)")
                .HasColumnName("updated_at");

            b.Property<double>("Value")
                .HasColumnType("double")
                .HasColumnName("value");

            b.HasKey("Id").HasName("pk_alerts");

            b.ToTable("alerts");
        });
#pragma warning restore 612, 618
    }
}