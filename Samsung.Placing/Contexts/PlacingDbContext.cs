using Microsoft.EntityFrameworkCore;
using Samsung.Placing.Entities;
using Samsung.Placing.Seeds;

namespace Samsung.Placing.Contexts
{
    public class PlacingDbContext : Context, IPlacingDbContext
    {
        public PlacingDbContext(string connectionString, string migrationAssembly)
            : base(connectionString, migrationAssembly)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasMany(d => d.Developers)
                .WithOne(t => t.Team)
                .HasForeignKey(d => d.TeamId);

            modelBuilder.Entity<Team>()
                .HasData(TeamSeed.Teams);

            modelBuilder.Entity<Developer>()
                .HasData(DeveloperSeed.Developers);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Developer> Developers { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
