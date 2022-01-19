using AutoMapper;
using Samsung.Placing.BusinessObjects;
using Samsung.Placing.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samsung.Placing.Services
{
    public class TeamService : ITeamService
    {
        private readonly IPlacingUnitOfWork _placingUnitOfWork;
        private readonly IMapper _mapper;

        public TeamService(IPlacingUnitOfWork placingUnitOfWork, IMapper mapper)
        {
            _placingUnitOfWork = placingUnitOfWork;
            _mapper = mapper;
        }

        public void CreateTeam(Team team)
        {
            _placingUnitOfWork.TeamRepository.Add(
                _mapper.Map<Entities.Team>(team));

            _placingUnitOfWork.Save();
        }

        public void DeleteTeam(int teamId)
        {
            _placingUnitOfWork.TeamRepository.Remove(teamId);
            _placingUnitOfWork.Save();
        }

        public IList<Team> GetAllTeams()
        {
            var teamEntities = _placingUnitOfWork.TeamRepository.GetAll();
            var teams = new List<Team>();

            foreach (var entity in teamEntities)
            {
                teams.Add(_mapper.Map<Team>(entity));
            }

            return teams;
        }

        public Team GetTeam(int id)
        {
            var team = _placingUnitOfWork.TeamRepository.GetById(id);

            if (team == null) return null;

            return _mapper.Map<Team>(team);
        }

        public (IList<Team> records, int total, int totalDisplay) GetTeams(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var teamData = _placingUnitOfWork.TeamRepository.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);

            var result = (from team in teamData.data
                          select _mapper.Map<Team>(team)).ToList();

            return (result, teamData.total, teamData.totalDisplay);
        }

        public void UpdateTeam(Team team)
        {
            var teamEntity = _placingUnitOfWork.TeamRepository.GetById(team.Id);

            if (teamEntity != null)
            {
                _mapper.Map(team, teamEntity);
                _placingUnitOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Could not find Team");
            }
        }
    }
}
