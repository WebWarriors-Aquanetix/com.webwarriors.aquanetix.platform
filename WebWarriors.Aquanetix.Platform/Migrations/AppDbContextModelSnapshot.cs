using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebWarriors.Aquanetix.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

#nullable disable

[DbContext(typeof(AppDbContext))]
partial class AppDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "10.0.8")
            .HasAnnotation("Relational:MaxIdentifierLength", 64);

        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasColumnName("id");

            b.Property<DateTimeOffset?>("CreatedAt")
                .HasColumnName("created_at");

                .HasColumnType("int")

                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)")

            b.Property<string>("Status")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)")
                .HasColumnName("status");

            b.Property<DateTimeOffset?>("UpdatedAt")
                .HasColumnName("updated_at");

                .HasColumnType("double")


        });
#pragma warning restore 612, 618
    }
}
