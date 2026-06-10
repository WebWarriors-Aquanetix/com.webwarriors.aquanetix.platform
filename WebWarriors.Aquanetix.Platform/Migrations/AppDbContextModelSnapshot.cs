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

        modelBuilder.Entity("WebWarriors.Aquanetix.Platform.ServiceDesign.Domain.Model.Aggregates.WaterBatch", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasColumnName("id");

            b.Property<string>("CertificationCode")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)")
                .HasColumnName("certification_code");

            b.Property<DateTimeOffset?>("CreatedAt")
                .HasColumnType("datetime(6)")
                .HasColumnName("created_at");

            b.Property<DateTimeOffset>("DeliveryTimestamp")
                .HasColumnType("datetime(6)")
                .HasColumnName("delivery_timestamp");

            b.Property<int>("DestinationSectorId")
                .HasColumnType("int")
                .HasColumnName("destination_sector_id");

            b.Property<string>("Source")
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)")
                .HasColumnName("source");

            b.Property<string>("Status")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)")
                .HasColumnName("status");

            b.Property<DateTimeOffset?>("UpdatedAt")
                .HasColumnType("datetime(6)")
                .HasColumnName("updated_at");

            b.Property<double>("VolumeLiters")
                .HasColumnType("double")
                .HasColumnName("volume_liters");

            b.HasKey("Id").HasName("pk_water_batches");

            b.ToTable("water_batches");
        });
#pragma warning restore 612, 618
    }
}
