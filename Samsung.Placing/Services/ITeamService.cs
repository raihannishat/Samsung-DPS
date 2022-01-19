using System.Collections.Generic;
using Samsung.Placing.BusinessObjects;

namespace Samsung.Placing.Services
{
    public interface ITeamService
    {
        IList<Team> GetAllTeams();
        void CreateTeam(Team team);
        (IList<Team> records, int total, int totalDisplay) GetTeams(int pageIndex, int pageSize, string searchText, string sortText);
        Team GetTeam(int id);
        void UpdateTeam(Team team);
        void DeleteTeam(int teamId);
    }
}
