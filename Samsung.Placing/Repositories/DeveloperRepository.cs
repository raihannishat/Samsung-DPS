using Samsung.Data;
using Samsung.Placing.Entities;
using Samsung.Placing.Contexts;

namespace Samsung.Placing.Repositories
{
    public class DeveloperRepository : Repository<Developer, int>, IDeveloperRepository
    {
        public DeveloperRepository(ICommonContext context) : base((Context)context)
        {
            
        }
    }
}
