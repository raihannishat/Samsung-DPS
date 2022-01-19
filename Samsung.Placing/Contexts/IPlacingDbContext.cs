using Microsoft.EntityFrameworkCore;
using Samsung.Placing.Entities;

namespace Samsung.Placing.Contexts
{
    public interface IPlacingDbContext
    {
        DbSet<Developer> Developers { get; set; }
        DbSet<Team> Teams { get; set; }
    }
}