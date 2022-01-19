using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Samsung.Placing.BusinessObjects;
using Samsung.Placing.Services;
using Autofac;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace Samsung.Web.Areas.Admin.Models
{
    public class CreateDeveloperModel
    {
        [Required, MaxLength(50, ErrorMessage = "Name shoul be less than 50 characters")]
        public string Name { get; set; }
        public string Skills { get; set; }
        public int TeamId { get; set; }

        private readonly IDeveloperService _developerService;
        private readonly IMapper _mapper;

        public CreateDeveloperModel()
        {
            _developerService = Startup.AutofacContainer.Resolve<IDeveloperService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public CreateDeveloperModel(IDeveloperService developerService)
        {
            _developerService = developerService;
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public void Create()
        {
            _developerService.CreateDeveloper(_mapper.Map<Developer>(this));
        }
    }
}
