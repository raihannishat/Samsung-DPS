using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using Samsung.Placing.Services;
using Samsung.Placing.BusinessObjects;

namespace Samsung.Web.Areas.Admin.Models
{
    public class CreateTeamModel
    {
        [Required, MaxLength(50, ErrorMessage = "Name shoul be less than 50 characters")]
        public string Name { get; set; }

        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;

        public CreateTeamModel()
        {
            _teamService = Startup.AutofacContainer.Resolve<ITeamService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public CreateTeamModel(ITeamService teamService)
        {
            _teamService = teamService;
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public void Create()
        {
            _teamService.CreateTeam(_mapper.Map<Team>(this));
        }
    }
}
