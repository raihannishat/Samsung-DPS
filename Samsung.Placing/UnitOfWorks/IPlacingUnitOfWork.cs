using Samsung.Placing.Repositories;
using Samsung.Data;

namespace Samsung.Placing.UnitOfWorks
{
    public interface IPlacingUnitOfWork : IUnitOfWork
    {
        IDeveloperRepository DeveloperRepository { get; }
        ITeamRepository TeamRepository { get; }
    }
}
