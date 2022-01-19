using Samsung.Data;
using Samsung.Placing.Repositories;
using Samsung.Placing.Contexts;

namespace Samsung.Placing.UnitOfWorks
{
    public class PlacingUnitOfWork : UnitOfWork, IPlacingUnitOfWork
    {
        public PlacingUnitOfWork(ICommonContext dbContext, 
            IDeveloperRepository developerRepository, 
            ITeamRepository teamRepository)
            : base((Context)dbContext)
        {
            DeveloperRepository = developerRepository;
            TeamRepository = teamRepository;
        }

        public IDeveloperRepository DeveloperRepository { get; private set; }
        public ITeamRepository TeamRepository { get; private set; }
    }
}
