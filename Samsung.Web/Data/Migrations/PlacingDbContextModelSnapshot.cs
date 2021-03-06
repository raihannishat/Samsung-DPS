// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Samsung.Placing.Contexts;

namespace Samsung.Web.Data.Migrations
{
    [DbContext(typeof(PlacingDbContext))]
    partial class PlacingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Samsung.Placing.Entities.Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Skills")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Developers");

                    b.HasData(
                        new
                        {
                            Id = 2518,
                            Name = "Raihan Nishat",
                            Skills = "OOP, Design Pattern, C#, .NET Core, AWS",
                            TeamId = 584
                        },
                        new
                        {
                            Id = 2548,
                            Name = "Asif Abdullah",
                            Skills = "C++, Algorithm, Data Structure",
                            TeamId = 149
                        },
                        new
                        {
                            Id = 2545,
                            Name = "Zihad Muhammad",
                            Skills = "C++, Degital Device, Robotics",
                            TeamId = 275
                        });
                });

            modelBuilder.Entity("Samsung.Placing.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 304,
                            Name = "DevOps"
                        },
                        new
                        {
                            Id = 584,
                            Name = "Cloud"
                        },
                        new
                        {
                            Id = 275,
                            Name = "Embedded"
                        },
                        new
                        {
                            Id = 149,
                            Name = "TizenOS"
                        },
                        new
                        {
                            Id = 791,
                            Name = "SamsungTV"
                        });
                });

            modelBuilder.Entity("Samsung.Placing.Entities.Developer", b =>
                {
                    b.HasOne("Samsung.Placing.Entities.Team", "Team")
                        .WithMany("Developers")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Samsung.Placing.Entities.Team", b =>
                {
                    b.Navigation("Developers");
                });
#pragma warning restore 612, 618
        }
    }
}
