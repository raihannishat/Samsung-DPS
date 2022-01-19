using Samsung.Data;
using Samsung.Placing.Entities;
using Samsung.Placing.Contexts;

namespace Samsung.Placing.Repositories
{
    public class TeamRepository : Repository<Team, int>, ITeamRepository
    {
        public TeamRepository(IPlacingDbContext context) : base((Context)context)
        {

        }
    }
}
