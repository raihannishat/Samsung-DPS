using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Samsung.Placing.Services;
using Samsung.Web.Models;

namespace Samsung.Web.Areas.Admin.Models
{
    public class DeveloperListModel
    {
        private readonly IDeveloperService _developerService;

        public DeveloperListModel()
        {
            _developerService = Startup.AutofacContainer.Resolve<IDeveloperService>();
        }

        public DeveloperListModel(IDeveloperService developerService)
        {
            _developerService = developerService;
        }

        public object GetDevelopers(DataTablesAjaxRequestModel dataTablesModel)
        {
            var data = _developerService.GetDevelopers(
                dataTablesModel.PageIndex,
                dataTablesModel.PageSize,
                dataTablesModel.SearchText,
                dataTablesModel.GetSortText(new string[] { "Id", "Name", "Skills", "TeamId" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Id.ToString(),
                            record.Name.ToString(),
                            record.Skills.ToString(),
                            record.TeamId.ToString(),
                            record.Id.ToString()
                        }
                ).ToArray()
            };
        }

        public void Delete(int id)
        {
            _developerService.DeleteDeveloper(id);
        }
    }
}
