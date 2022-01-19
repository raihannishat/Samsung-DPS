using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Samsung.Placing.Services;
using Samsung.Web;
using Autofac;
using Samsung.Web.Models;

namespace Samsung.Web.Areas.Admin.Models
{
    public class TeamListModel
    {
        private readonly ITeamService _teamService;

        public TeamListModel()
        {
            _teamService = Startup.AutofacContainer.Resolve<ITeamService>();
        }

        public TeamListModel(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public object GetTeams(DataTablesAjaxRequestModel dataTablesModel)
        {
            var data = _teamService.GetTeams(
                dataTablesModel.PageIndex,
                dataTablesModel.PageSize,
                dataTablesModel.SearchText,
                dataTablesModel.GetSortText(new string[] { "Id", "Name" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Id.ToString(),
                            record.Name.ToString(),
                            record.Id.ToString()
                        }
                ).ToArray()
            };
        }

        public void Delete(int id)
        {
            _teamService.DeleteTeam(id);
        }
    }
}
