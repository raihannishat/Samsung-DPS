using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using Samsung.Placing.Services;
using Samsung.Web;
using Samsung.Placing.BusinessObjects;

namespace Samsung.Web.Areas.Admin.Models
{
    public class EditTeamModel
    {
        [Required, MaxLength(50, ErrorMessage = "Name shoul be less than 50 characters")]
        public string Name { get; set; }
        public int Id { get; set; }

        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;

        public EditTeamModel()
        {
            _teamService = Startup.AutofacContainer.Resolve<ITeamService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public EditTeamModel(ITeamService teamService)
        {
            _teamService = teamService;
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public void LoadModelData(int id)
        {
            _mapper.Map(_teamService.GetTeam(id), this);
        }

        public void Update()
        {
            _teamService.UpdateTeam(_mapper.Map(this, new Team()));
        }
    }
}
